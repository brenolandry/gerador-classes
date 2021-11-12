using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GeradorClasses
{
    public partial class Form1 : Form
    {
        private string connectionString;
        private List<InformationSchema> informationSchemas;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            informationSchemas = new List<InformationSchema>();

            if (cbxAuth.SelectedItem.Equals("Autenticação do Windows"))
                connectionString = $"Server={txbServerName.Text};Initial Catalog={txbDataBaseName.Text};Integrated Security=True";
            else
                connectionString = $"Server={txbServerName.Text};Initial Catalog={txbDataBaseName.Text};User ID={txbLogon.Text};Password={txbPassword.Text}";

            using (var conn = new SqlConnection(connectionString))
            {
                var sql = @"SELECT 
                                 convert(varchar, c.table_name) as table_name
                                ,convert(varchar, c.column_name) as column_name
                            	,c.data_type
                                ,c.is_nullable
                                ,KeyConstraints.constraint_type
                                ,convert(varchar, KeyConstraints.referenced_table_name) as referenced_table_name                                
                            FROM information_schema.columns AS c 
                            LEFT JOIN 
                                (
                                    SELECT 
                                         FK.table_schema AS TABLE_SCHEMA
                                        ,FK.table_name
                                        ,CU.column_name
                                        ,FK.constraint_type
                                        ,c.constraint_schema
                                        ,C.constraint_name
                                        ,PK.table_schema AS REFERENCED_TABLE_SCHEMA
                                        ,PK.table_name AS REFERENCED_TABLE_NAME
                                        ,CCU.column_name AS REFERENCED_COLUMN_NAME
                                        ,C.update_rule
                                        ,C.delete_rule
                                    FROM information_schema.referential_constraints AS C 
                                    INNER JOIN information_schema.table_constraints AS FK 
                                        ON C.constraint_name = FK.constraint_name 
                                    INNER JOIN information_schema.table_constraints AS PK 
                                        ON C.unique_constraint_name = PK.constraint_name 
                                    INNER JOIN information_schema.key_column_usage AS CU 
                                        ON C.constraint_name = CU.constraint_name 
                                    INNER JOIN information_schema.constraint_column_usage AS CCU 
                                        ON PK.constraint_name = CCU.constraint_name 
                                    WHERE ( FK.constraint_type = 'FOREIGN KEY' )                                    
                                ) AS KeyConstraints 
                                ON c.table_schema = KeyConstraints.table_schema 
                                AND c.table_name = KeyConstraints.table_name 
                                AND c.column_name = KeyConstraints.column_name 
                            WHERE c.table_name <> 'sysdiagrams' 
                            ORDER BY  c.table_name  ";

                var cmd = new SqlCommand(sql, conn);

                try
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            InformationSchema informationSchema = new InformationSchema();
                            informationSchema.TableName = reader["table_name"].ToString();
                            informationSchema.ColumnName = reader["column_name"].ToString();
                            informationSchema.DataType = reader["data_type"].ToString();
                            informationSchema.IsNullable = reader["is_nullable"].ToString();
                            informationSchema.ConstraintType = reader["constraint_type"] != DBNull.Value ? reader["constraint_type"].ToString() : string.Empty;
                            informationSchema.ReferencedTableName = reader["referenced_table_name"] != DBNull.Value ? reader["referenced_table_name"].ToString() : string.Empty;                           

                            informationSchemas.Add(informationSchema);
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Close();
                }
            }

            var tableNames = informationSchemas.GroupBy(i => i.TableName).Select(g => g.Key);

            foreach (var name in tableNames)
            {
                ltvTableNames.Items.Add(name);
            }
        }

        private void cbxAuth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var display = cbxAuth.SelectedItem.Equals("Autenticação do SQL Server");
            txbLogon.Enabled = display;
            txbPassword.Enabled = display;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var tableNames = informationSchemas.GroupBy(i => i.TableName).Select(g => g.Key);

                foreach (var name in tableNames)
                {
                    CreateFile(name);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void CreateFile(string tableName)
        {
            var tableNameCc = ConvertToCamelCase(tableName);
            StreamWriter sw = new StreamWriter($"{txbPathToFile.Text}\\{tableNameCc}.cs");

            sw.WriteLine("using System;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine("");
            sw.WriteLine($"namespace {txbNamespace.Text}");
            sw.WriteLine("{");
            sw.WriteLine($"public class {tableNameCc}");
            sw.WriteLine("{");
            var columns = informationSchemas.Where(i => i.TableName.Equals(tableName));
            foreach (var col in columns)
            {
                sw.WriteLine($"public {ConvertDataTypeToCLR(col.DataType)} {ConvertToCamelCase(col.ColumnName)} {{ get; set; }}");

                if (col.ConstraintType.Equals("FOREIGN KEY"))
                {
                    var refTableName = ConvertToCamelCase(col.ReferencedTableName);
                    sw.WriteLine($"public {refTableName} {refTableName} {{ get; set; }}");
                }
            }

            // monta lista dos relacionamentos 1 pra N
            var references = informationSchemas.FindAll(i => i.ReferencedTableName.Equals(tableName));            
            foreach (var reference in references)
            {
                var refTableName = ConvertToCamelCase(reference.TableName);
                sw.WriteLine($"public List<{refTableName}> {refTableName}s {{ get; set; }}");
            }

            sw.WriteLine("}");
            sw.WriteLine("}");
            sw.Close();
        }

        private string ConvertToCamelCase(string name)
        {
            string camelCase = null;

            var words = name.Split('_');
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i].ToLower();
                camelCase += $"{word.ToUpper().First()}{word.Substring(1)}";
            }

            return camelCase;
        }

        private string ConvertDataTypeToCLR(string dataType)
        {
            string converted = null;

            switch (dataType.ToUpper())
            {
                case "CHAR":
                case "NCHAR":
                case "NTEXT":
                case "NVARCHAR":
                case "TEXT":
                case "VARCHAR":
                    converted = "string";
                    break;
                case "BIT":
                    converted = "boolean";
                    break;
                case "TINYINT":
                    converted = "byte";
                    break;
                case "SMALLINT":
                    converted = "Int16";
                    break;
                case "INT":
                    converted = "int";
                    break;
                case "BIGINT":
                    converted = "long";
                    break;
                case "DECIMAL":
                    converted = "decimal";
                    break;
                case "REAL":
                    converted = "single";
                    break;
                case "FLOAT":
                    converted = "double";
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                case "DATETIME2":
                case "DATE":
                    converted = "DateTime";
                    break;
                case "DATETIMEOFFSET":
                    converted = "DateTimeOffset";
                    break;
                case "TIME":
                    converted = "TimeSpan";
                    break;
                case "UNIQUEIDENTIFIER":
                    converted = "Guid";
                    break;
                default:
                    break;
            }

            return converted is null ? dataType : converted;
        }
    }
}
