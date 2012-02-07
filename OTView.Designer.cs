namespace ObvTrojanClient
{
    partial class ObvTrojanView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ObvTrojanView));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.myDomainsTabPage = new System.Windows.Forms.TabPage();
            this.statusTextBox = new System.Windows.Forms.RichTextBox();
            this.toggleHeartbeatButton = new System.Windows.Forms.Button();
            this.refreshButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.useCurrentIPCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.domainComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsTabPage = new System.Windows.Forms.TabPage();
            this.passwordTextbox = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.usernameTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.startAutomaticallyCheckBox = new System.Windows.Forms.CheckBox();
            this.trojanLogo = new System.Windows.Forms.PictureBox();
            this.tabControl.SuspendLayout();
            this.myDomainsTabPage.SuspendLayout();
            this.settingsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trojanLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.myDomainsTabPage);
            this.tabControl.Controls.Add(this.settingsTabPage);
            this.tabControl.Location = new System.Drawing.Point(-1, 51);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(216, 225);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // myDomainsTabPage
            // 
            this.myDomainsTabPage.Controls.Add(this.statusTextBox);
            this.myDomainsTabPage.Controls.Add(this.toggleHeartbeatButton);
            this.myDomainsTabPage.Controls.Add(this.refreshButton);
            this.myDomainsTabPage.Controls.Add(this.updateButton);
            this.myDomainsTabPage.Controls.Add(this.ipTextBox);
            this.myDomainsTabPage.Controls.Add(this.useCurrentIPCheckBox);
            this.myDomainsTabPage.Controls.Add(this.label2);
            this.myDomainsTabPage.Controls.Add(this.domainComboBox);
            this.myDomainsTabPage.Controls.Add(this.label1);
            this.myDomainsTabPage.Location = new System.Drawing.Point(4, 22);
            this.myDomainsTabPage.Name = "myDomainsTabPage";
            this.myDomainsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.myDomainsTabPage.Size = new System.Drawing.Size(208, 199);
            this.myDomainsTabPage.TabIndex = 0;
            this.myDomainsTabPage.Text = "My Domains";
            this.myDomainsTabPage.UseVisualStyleBackColor = true;
            // 
            // statusTextBox
            // 
            this.statusTextBox.Enabled = false;
            this.statusTextBox.Location = new System.Drawing.Point(9, 144);
            this.statusTextBox.Name = "statusTextBox";
            this.statusTextBox.Size = new System.Drawing.Size(189, 46);
            this.statusTextBox.TabIndex = 8;
            this.statusTextBox.Text = "";
            // 
            // toggleHeartbeatButton
            // 
            this.toggleHeartbeatButton.Location = new System.Drawing.Point(9, 99);
            this.toggleHeartbeatButton.Name = "toggleHeartbeatButton";
            this.toggleHeartbeatButton.Size = new System.Drawing.Size(90, 23);
            this.toggleHeartbeatButton.TabIndex = 6;
            this.toggleHeartbeatButton.Text = "Enable Heartbeat";
            this.toggleHeartbeatButton.UseVisualStyleBackColor = true;
            this.toggleHeartbeatButton.Click += new System.EventHandler(this.toggleHeartbeatButton_Click);
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(108, 99);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(90, 23);
            this.refreshButton.TabIndex = 5;
            this.refreshButton.Text = "Refresh List";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButtonClick);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(9, 128);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(90, 23);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButtonClick);
            // 
            // ipTextBox
            // 
            this.ipTextBox.Location = new System.Drawing.Point(9, 72);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(189, 20);
            this.ipTextBox.TabIndex = 3;
            // 
            // useCurrentIPCheckBox
            // 
            this.useCurrentIPCheckBox.AutoSize = true;
            this.useCurrentIPCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.useCurrentIPCheckBox.Location = new System.Drawing.Point(120, 50);
            this.useCurrentIPCheckBox.Name = "useCurrentIPCheckBox";
            this.useCurrentIPCheckBox.Size = new System.Drawing.Size(82, 17);
            this.useCurrentIPCheckBox.TabIndex = 2;
            this.useCurrentIPCheckBox.Text = "Use Current";
            this.useCurrentIPCheckBox.UseVisualStyleBackColor = true;
            this.useCurrentIPCheckBox.CheckedChanged += new System.EventHandler(this.useCurrentIPCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP:";
            // 
            // domainComboBox
            // 
            this.domainComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domainComboBox.FormattingEnabled = true;
            this.domainComboBox.Location = new System.Drawing.Point(9, 23);
            this.domainComboBox.Name = "domainComboBox";
            this.domainComboBox.Size = new System.Drawing.Size(189, 21);
            this.domainComboBox.TabIndex = 1;
            this.domainComboBox.SelectedIndexChanged += new System.EventHandler(this.domainComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Domain:";
            // 
            // settingsTabPage
            // 
            this.settingsTabPage.Controls.Add(this.passwordTextbox);
            this.settingsTabPage.Controls.Add(this.loginButton);
            this.settingsTabPage.Controls.Add(this.usernameTextbox);
            this.settingsTabPage.Controls.Add(this.label5);
            this.settingsTabPage.Controls.Add(this.label4);
            this.settingsTabPage.Controls.Add(this.startAutomaticallyCheckBox);
            this.settingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.settingsTabPage.Name = "settingsTabPage";
            this.settingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.settingsTabPage.Size = new System.Drawing.Size(208, 199);
            this.settingsTabPage.TabIndex = 1;
            this.settingsTabPage.Text = "My Account";
            this.settingsTabPage.UseVisualStyleBackColor = true;
            // 
            // passwordTextbox
            // 
            this.passwordTextbox.Location = new System.Drawing.Point(72, 43);
            this.passwordTextbox.Name = "passwordTextbox";
            this.passwordTextbox.PasswordChar = '*';
            this.passwordTextbox.Size = new System.Drawing.Size(124, 20);
            this.passwordTextbox.TabIndex = 8;
            this.passwordTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordOrUsernameTextboxKeyPress);
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(9, 78);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(188, 23);
            this.loginButton.TabIndex = 9;
            this.loginButton.Text = "Log In";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // usernameTextbox
            // 
            this.usernameTextbox.Location = new System.Drawing.Point(72, 15);
            this.usernameTextbox.Name = "usernameTextbox";
            this.usernameTextbox.Size = new System.Drawing.Size(124, 20);
            this.usernameTextbox.TabIndex = 7;
            this.usernameTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordOrUsernameTextboxKeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Username:";
            // 
            // startAutomaticallyCheckBox
            // 
            this.startAutomaticallyCheckBox.AutoSize = true;
            this.startAutomaticallyCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startAutomaticallyCheckBox.Location = new System.Drawing.Point(9, 173);
            this.startAutomaticallyCheckBox.Name = "startAutomaticallyCheckBox";
            this.startAutomaticallyCheckBox.Size = new System.Drawing.Size(113, 17);
            this.startAutomaticallyCheckBox.TabIndex = 3;
            this.startAutomaticallyCheckBox.Text = "Start Automatically";
            this.startAutomaticallyCheckBox.UseVisualStyleBackColor = true;
            this.startAutomaticallyCheckBox.CheckedChanged += new System.EventHandler(this.startAutomaticallyCheckBox_CheckedChanged);
            // 
            // trojanLogo
            // 
            this.trojanLogo.Image = ((System.Drawing.Image)(resources.GetObject("trojanLogo.Image")));
            this.trojanLogo.Location = new System.Drawing.Point(18, 7);
            this.trojanLogo.Name = "trojanLogo";
            this.trojanLogo.Size = new System.Drawing.Size(187, 42);
            this.trojanLogo.TabIndex = 1;
            this.trojanLogo.TabStop = false;
            this.trojanLogo.DoubleClick += new System.EventHandler(this.trojanLogo_DoubleClick);
            // 
            // ObvTrojanView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 273);
            this.Controls.Add(this.trojanLogo);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(218, 340);
            this.MinimumSize = new System.Drawing.Size(218, 270);
            this.Name = "ObvTrojanView";
            this.Text = "Trojan DNS";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ObvTrojanView_FormClosing);
            this.Load += new System.EventHandler(this.ObvTrojanView_Load);
            this.Resize += new System.EventHandler(this.ObvTrojanView_Resize);
            this.tabControl.ResumeLayout(false);
            this.myDomainsTabPage.ResumeLayout(false);
            this.myDomainsTabPage.PerformLayout();
            this.settingsTabPage.ResumeLayout(false);
            this.settingsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trojanLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage myDomainsTabPage;
        private System.Windows.Forms.TabPage settingsTabPage;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.TextBox ipTextBox;
        private System.Windows.Forms.CheckBox useCurrentIPCheckBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox domainComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox startAutomaticallyCheckBox;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button toggleHeartbeatButton;
        private System.Windows.Forms.RichTextBox statusTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox usernameTextbox;
        private System.Windows.Forms.TextBox passwordTextbox;
        private System.Windows.Forms.PictureBox trojanLogo;
    }
}

