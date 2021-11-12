namespace GeradorClasses
{
    public class InformationSchema
    {
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public string IsNullable { get; set; }
        public string ConstraintType { get; set; }
        public string ReferencedTableName { get; set; }
    }
}
