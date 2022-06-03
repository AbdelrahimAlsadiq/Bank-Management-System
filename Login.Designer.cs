namespace BankSystemForms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BankPic = new System.Windows.Forms.PictureBox();
            this.BankManagementSystem = new System.Windows.Forms.Label();
            this.LoginBTN = new System.Windows.Forms.Button();
            this.QuitBTN = new System.Windows.Forms.Button();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelForename = new System.Windows.Forms.Label();
            this.usernameText = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.roleBox = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.LoginPic = new System.Windows.Forms.PictureBox();
            this.QuitPic = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelUsernameValid = new System.Windows.Forms.Label();
            this.labelPasswordValid = new System.Windows.Forms.Label();
            this.labelRoleValid = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BankPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuitPic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.BankPic);
            this.panel1.Controls.Add(this.BankManagementSystem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 76);
            this.panel1.TabIndex = 67;
            // 
            // BankPic
            // 
            this.BankPic.Image = ((System.Drawing.Image)(resources.GetObject("BankPic.Image")));
            this.BankPic.Location = new System.Drawing.Point(440, 0);
            this.BankPic.Name = "BankPic";
            this.BankPic.Size = new System.Drawing.Size(154, 83);
            this.BankPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.BankPic.TabIndex = 14;
            this.BankPic.TabStop = false;
            // 
            // BankManagementSystem
            // 
            this.BankManagementSystem.AutoSize = true;
            this.BankManagementSystem.Font = new System.Drawing.Font("Cairo ExtraBold", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankManagementSystem.ForeColor = System.Drawing.Color.White;
            this.BankManagementSystem.Location = new System.Drawing.Point(28, 9);
            this.BankManagementSystem.Name = "BankManagementSystem";
            this.BankManagementSystem.Size = new System.Drawing.Size(418, 56);
            this.BankManagementSystem.TabIndex = 13;
            this.BankManagementSystem.Text = "BANK MANAGEMENT SYSTEM";
            // 
            // LoginBTN
            // 
            this.LoginBTN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LoginBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginBTN.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBTN.ForeColor = System.Drawing.SystemColors.Control;
            this.LoginBTN.Location = new System.Drawing.Point(456, 286);
            this.LoginBTN.Name = "LoginBTN";
            this.LoginBTN.Size = new System.Drawing.Size(146, 56);
            this.LoginBTN.TabIndex = 76;
            this.LoginBTN.Text = "LOGIN";
            this.LoginBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LoginBTN.UseVisualStyleBackColor = false;
            this.LoginBTN.Click += new System.EventHandler(this.LoginBTN_Click);
            // 
            // QuitBTN
            // 
            this.QuitBTN.BackColor = System.Drawing.Color.Maroon;
            this.QuitBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuitBTN.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuitBTN.ForeColor = System.Drawing.SystemColors.Control;
            this.QuitBTN.Location = new System.Drawing.Point(304, 286);
            this.QuitBTN.Name = "QuitBTN";
            this.QuitBTN.Size = new System.Drawing.Size(146, 56);
            this.QuitBTN.TabIndex = 77;
            this.QuitBTN.Text = "QUIT";
            this.QuitBTN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QuitBTN.UseVisualStyleBackColor = false;
            this.QuitBTN.Click += new System.EventHandler(this.QuitBTN_Click);
            // 
            // passwordText
            // 
            this.passwordText.Font = new System.Drawing.Font("Cairo", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordText.Location = new System.Drawing.Point(156, 177);
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = 'x';
            this.passwordText.Size = new System.Drawing.Size(179, 28);
            this.passwordText.TabIndex = 81;
            this.passwordText.TextChanged += new System.EventHandler(this.passwordText_TextChanged);
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSurname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelSurname.Location = new System.Drawing.Point(32, 165);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(116, 42);
            this.labelSurname.TabIndex = 80;
            this.labelSurname.Text = "Password:";
            // 
            // labelForename
            // 
            this.labelForename.AutoSize = true;
            this.labelForename.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelForename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelForename.Location = new System.Drawing.Point(32, 110);
            this.labelForename.Name = "labelForename";
            this.labelForename.Size = new System.Drawing.Size(118, 42);
            this.labelForename.TabIndex = 79;
            this.labelForename.Text = "Username:";
            // 
            // usernameText
            // 
            this.usernameText.Font = new System.Drawing.Font("Cairo", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameText.Location = new System.Drawing.Point(156, 122);
            this.usernameText.Name = "usernameText";
            this.usernameText.Size = new System.Drawing.Size(179, 28);
            this.usernameText.TabIndex = 78;
            this.usernameText.TextChanged += new System.EventHandler(this.usernameText_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.Font = new System.Drawing.Font("Cairo", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label19.Location = new System.Drawing.Point(35, 218);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 42);
            this.label19.TabIndex = 82;
            this.label19.Text = "Role:";
            // 
            // roleBox
            // 
            this.roleBox.DisplayMember = "Manager";
            this.roleBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleBox.Font = new System.Drawing.Font("Cairo", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roleBox.FormattingEnabled = true;
            this.roleBox.Items.AddRange(new object[] {
            "Agent",
            "Manager"});
            this.roleBox.Location = new System.Drawing.Point(156, 230);
            this.roleBox.Margin = new System.Windows.Forms.Padding(2);
            this.roleBox.Name = "roleBox";
            this.roleBox.Size = new System.Drawing.Size(179, 28);
            this.roleBox.TabIndex = 83;
            this.roleBox.Tag = "";
            this.roleBox.SelectedIndexChanged += new System.EventHandler(this.roleBox_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(10, 278);
            this.panel3.TabIndex = 85;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(604, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 278);
            this.panel4.TabIndex = 86;
            // 
            // LoginPic
            // 
            this.LoginPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.LoginPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LoginPic.Image = ((System.Drawing.Image)(resources.GetObject("LoginPic.Image")));
            this.LoginPic.Location = new System.Drawing.Point(545, 292);
            this.LoginPic.Name = "LoginPic";
            this.LoginPic.Size = new System.Drawing.Size(49, 45);
            this.LoginPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LoginPic.TabIndex = 15;
            this.LoginPic.TabStop = false;
            this.LoginPic.Click += new System.EventHandler(this.LoginPic_Click);
            // 
            // QuitPic
            // 
            this.QuitPic.BackColor = System.Drawing.Color.Maroon;
            this.QuitPic.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuitPic.Image = ((System.Drawing.Image)(resources.GetObject("QuitPic.Image")));
            this.QuitPic.Location = new System.Drawing.Point(392, 291);
            this.QuitPic.Name = "QuitPic";
            this.QuitPic.Size = new System.Drawing.Size(49, 45);
            this.QuitPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.QuitPic.TabIndex = 87;
            this.QuitPic.TabStop = false;
            this.QuitPic.Click += new System.EventHandler(this.QuitPic_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(10, 344);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 10);
            this.panel2.TabIndex = 88;
            // 
            // labelUsernameValid
            // 
            this.labelUsernameValid.AutoSize = true;
            this.labelUsernameValid.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUsernameValid.Location = new System.Drawing.Point(362, 121);
            this.labelUsernameValid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelUsernameValid.Name = "labelUsernameValid";
            this.labelUsernameValid.Size = new System.Drawing.Size(0, 30);
            this.labelUsernameValid.TabIndex = 89;
            // 
            // labelPasswordValid
            // 
            this.labelPasswordValid.AutoSize = true;
            this.labelPasswordValid.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPasswordValid.Location = new System.Drawing.Point(363, 176);
            this.labelPasswordValid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPasswordValid.Name = "labelPasswordValid";
            this.labelPasswordValid.Size = new System.Drawing.Size(0, 30);
            this.labelPasswordValid.TabIndex = 90;
            // 
            // labelRoleValid
            // 
            this.labelRoleValid.AutoSize = true;
            this.labelRoleValid.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRoleValid.Location = new System.Drawing.Point(364, 229);
            this.labelRoleValid.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelRoleValid.Name = "labelRoleValid";
            this.labelRoleValid.Size = new System.Drawing.Size(0, 30);
            this.labelRoleValid.TabIndex = 91;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 354);
            this.Controls.Add(this.labelRoleValid);
            this.Controls.Add(this.labelPasswordValid);
            this.Controls.Add(this.labelUsernameValid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.QuitPic);
            this.Controls.Add(this.LoginPic);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.roleBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.usernameText);
            this.Controls.Add(this.labelForename);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.QuitBTN);
            this.Controls.Add(this.LoginBTN);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BankPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoginPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuitPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button LoginBTN;
        private System.Windows.Forms.Button QuitBTN;
        private System.Windows.Forms.Label BankManagementSystem;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelForename;
        private System.Windows.Forms.TextBox usernameText;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox roleBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox BankPic;
        private System.Windows.Forms.PictureBox LoginPic;
        private System.Windows.Forms.PictureBox QuitPic;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelUsernameValid;
        private System.Windows.Forms.Label labelPasswordValid;
        private System.Windows.Forms.Label labelRoleValid;
    }
}