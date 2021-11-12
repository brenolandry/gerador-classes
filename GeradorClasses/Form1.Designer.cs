
namespace GeradorClasses
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txbServerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxAuth = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbLogon = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txbDataBaseName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ltvTableNames = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txbPathToFile = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbNamespace = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txbServerName
            // 
            this.txbServerName.Location = new System.Drawing.Point(208, 15);
            this.txbServerName.Name = "txbServerName";
            this.txbServerName.Size = new System.Drawing.Size(508, 27);
            this.txbServerName.TabIndex = 0;
            this.txbServerName.Text = "localhost\\sqlexpress";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do Servidor:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(102, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Autenticação:";
            // 
            // cbxAuth
            // 
            this.cbxAuth.FormattingEnabled = true;
            this.cbxAuth.Items.AddRange(new object[] {
            "Autenticação do Windows",
            "Autenticação do SQL Server"});
            this.cbxAuth.Location = new System.Drawing.Point(207, 81);
            this.cbxAuth.Name = "cbxAuth";
            this.cbxAuth.Size = new System.Drawing.Size(508, 28);
            this.cbxAuth.TabIndex = 3;
            this.cbxAuth.Text = "Autenticação do SQL Server";
            this.cbxAuth.SelectedIndexChanged += new System.EventHandler(this.cbxAuth_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Logon:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(148, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Senha:";
            // 
            // txbLogon
            // 
            this.txbLogon.Location = new System.Drawing.Point(207, 115);
            this.txbLogon.Name = "txbLogon";
            this.txbLogon.Size = new System.Drawing.Size(507, 27);
            this.txbLogon.TabIndex = 4;
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(207, 151);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(507, 27);
            this.txbPassword.TabIndex = 5;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(207, 185);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(94, 29);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Conectar";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(307, 185);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(91, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Nome da Base:";
            // 
            // txbDataBaseName
            // 
            this.txbDataBaseName.Location = new System.Drawing.Point(207, 48);
            this.txbDataBaseName.Name = "txbDataBaseName";
            this.txbDataBaseName.Size = new System.Drawing.Size(508, 27);
            this.txbDataBaseName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(139, 241);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Tabelas:";
            // 
            // ltvTableNames
            // 
            this.ltvTableNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.ltvTableNames.HideSelection = false;
            this.ltvTableNames.Location = new System.Drawing.Point(208, 241);
            this.ltvTableNames.Name = "ltvTableNames";
            this.ltvTableNames.Size = new System.Drawing.Size(506, 180);
            this.ltvTableNames.TabIndex = 8;
            this.ltvTableNames.UseCompatibleStateImageBehavior = false;
            this.ltvTableNames.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nome das tabelas";
            this.columnHeader1.Width = 250;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(206, 518);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(116, 29);
            this.btnGenerate.TabIndex = 13;
            this.btnGenerate.Text = "Gerar Classes";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txbPathToFile
            // 
            this.txbPathToFile.Location = new System.Drawing.Point(206, 452);
            this.txbPathToFile.Name = "txbPathToFile";
            this.txbPathToFile.Size = new System.Drawing.Size(508, 27);
            this.txbPathToFile.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(71, 455);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Caminho arquivos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(110, 488);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Namespace:";
            // 
            // txbNamespace
            // 
            this.txbNamespace.Location = new System.Drawing.Point(206, 485);
            this.txbNamespace.Name = "txbNamespace";
            this.txbNamespace.Size = new System.Drawing.Size(508, 27);
            this.txbNamespace.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 580);
            this.Controls.Add(this.txbNamespace);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txbPathToFile);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.ltvTableNames);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbDataBaseName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbLogon);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxAuth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbServerName);
            this.Name = "Form1";
            this.Text = "Gerador de Classes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbServerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAuth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbLogon;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbDataBaseName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListView ltvTableNames;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.TextBox txbPathToFile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbNamespace;
    }
}

