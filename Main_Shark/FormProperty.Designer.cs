namespace Main_Shark
{
    partial class FormProperty
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProperty));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.LstIp = new System.Windows.Forms.ListBox();
            this.BtnEditUser = new System.Windows.Forms.Button();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TbxIpUser = new System.Windows.Forms.TextBox();
            this.TbxIp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TbxPort = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TbxForeginPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TbxMainPath = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.BtnDelUsers = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(464, 506);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(97)))), ((int)(((byte)(118)))));
            this.tabPage1.Controls.Add(this.BtnDelUsers);
            this.tabPage1.Controls.Add(this.LstIp);
            this.tabPage1.Controls.Add(this.BtnEditUser);
            this.tabPage1.Controls.Add(this.BtnSave);
            this.tabPage1.Controls.Add(this.TbxIpUser);
            this.tabPage1.Controls.Add(this.TbxIp);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.BtnEdit);
            this.tabPage1.Controls.Add(this.BtnAdd);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.TbxPort);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(456, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Настройки сервера";
            // 
            // LstIp
            // 
            this.LstIp.FormattingEnabled = true;
            this.LstIp.ItemHeight = 19;
            this.LstIp.Location = new System.Drawing.Point(23, 173);
            this.LstIp.Name = "LstIp";
            this.LstIp.ScrollAlwaysVisible = true;
            this.LstIp.Size = new System.Drawing.Size(222, 194);
            this.LstIp.TabIndex = 16;
            // 
            // BtnEditUser
            // 
            this.BtnEditUser.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnEditUser.Location = new System.Drawing.Point(269, 286);
            this.BtnEditUser.Name = "BtnEditUser";
            this.BtnEditUser.Size = new System.Drawing.Size(147, 37);
            this.BtnEditUser.TabIndex = 15;
            this.BtnEditUser.Text = "Редактировать";
            this.BtnEditUser.UseVisualStyleBackColor = true;
            this.BtnEditUser.Click += new System.EventHandler(this.BtnEditUser_Click);
            // 
            // BtnSave
            // 
            this.BtnSave.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnSave.Location = new System.Drawing.Point(108, 392);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(234, 56);
            this.BtnSave.TabIndex = 14;
            this.BtnSave.Text = "Сохранить";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TbxIpUser
            // 
            this.TbxIpUser.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxIpUser.Location = new System.Drawing.Point(258, 198);
            this.TbxIpUser.Name = "TbxIpUser";
            this.TbxIpUser.Size = new System.Drawing.Size(176, 28);
            this.TbxIpUser.TabIndex = 13;
            this.TbxIpUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxIpUser_KeyPress);
            // 
            // TbxIp
            // 
            this.TbxIp.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxIp.Location = new System.Drawing.Point(23, 39);
            this.TbxIp.Name = "TbxIp";
            this.TbxIp.Size = new System.Drawing.Size(176, 28);
            this.TbxIp.TabIndex = 12;
            this.TbxIp.TextChanged += new System.EventHandler(this.TbxIp_TextChanged);
            this.TbxIp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbxIpUser_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(19, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Ip - адрес";
            // 
            // BtnEdit
            // 
            this.BtnEdit.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnEdit.Location = new System.Drawing.Point(269, 84);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(147, 37);
            this.BtnEdit.TabIndex = 8;
            this.BtnEdit.Text = "Редактировать";
            this.BtnEdit.UseVisualStyleBackColor = true;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnAdd.Location = new System.Drawing.Point(269, 243);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(147, 37);
            this.BtnAdd.TabIndex = 7;
            this.BtnAdd.Text = "Добавить";
            this.BtnAdd.UseVisualStyleBackColor = true;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(19, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пользователи:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(244, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Порт";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(265, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ip - адрес";
            // 
            // TbxPort
            // 
            this.TbxPort.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TbxPort.Location = new System.Drawing.Point(248, 39);
            this.TbxPort.Name = "TbxPort";
            this.TbxPort.Size = new System.Drawing.Size(156, 28);
            this.TbxPort.TabIndex = 1;
            this.TbxPort.TextChanged += new System.EventHandler(this.TbxIp_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(97)))), ((int)(((byte)(118)))));
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.TbxForeginPath);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.TbxMainPath);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(456, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки клиента";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 37);
            this.button1.TabIndex = 4;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(190, 21);
            this.label6.TabIndex = 3;
            this.label6.Text = "Путь для файла клиента:";
            // 
            // TbxForeginPath
            // 
            this.TbxForeginPath.Location = new System.Drawing.Point(20, 154);
            this.TbxForeginPath.Name = "TbxForeginPath";
            this.TbxForeginPath.ReadOnly = true;
            this.TbxForeginPath.Size = new System.Drawing.Size(383, 28);
            this.TbxForeginPath.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 21);
            this.label5.TabIndex = 1;
            this.label5.Text = "Путь для файла сервера:";
            // 
            // TbxMainPath
            // 
            this.TbxMainPath.Location = new System.Drawing.Point(20, 55);
            this.TbxMainPath.Name = "TbxMainPath";
            this.TbxMainPath.ReadOnly = true;
            this.TbxMainPath.Size = new System.Drawing.Size(383, 28);
            this.TbxMainPath.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckFileExists = true;
            this.saveFileDialog1.FileName = "Foregin";
            this.saveFileDialog1.Filter = "Ключ для клиента(*.key)|*.key";
            this.saveFileDialog1.ValidateNames = false;
            // 
            // BtnDelUsers
            // 
            this.BtnDelUsers.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnDelUsers.Location = new System.Drawing.Point(269, 329);
            this.BtnDelUsers.Name = "BtnDelUsers";
            this.BtnDelUsers.Size = new System.Drawing.Size(147, 37);
            this.BtnDelUsers.TabIndex = 17;
            this.BtnDelUsers.Text = "Удалить";
            this.BtnDelUsers.UseVisualStyleBackColor = true;
            this.BtnDelUsers.Click += new System.EventHandler(this.BtnDelUsers_Click);
            // 
            // FormProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 506);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fox- настройки";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProperty_FormClosing);
            this.Load += new System.EventHandler(this.FormProperty_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TbxPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TbxForeginPath;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TbxMainPath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox TbxIpUser;
        private System.Windows.Forms.TextBox TbxIp;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnEditUser;
        private System.Windows.Forms.ListBox LstIp;
        private System.Windows.Forms.Button BtnDelUsers;
    }
}