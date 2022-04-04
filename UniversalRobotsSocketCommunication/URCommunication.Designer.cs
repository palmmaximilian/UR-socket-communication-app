namespace UniversalRobotsSocketCommunication
{
    partial class URCommunication
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dashboardOutput = new System.Windows.Forms.TextBox();
            this.dashboardConnectButton = new System.Windows.Forms.Button();
            this.dashboardIpInput = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.dashboardServerConnected = new System.Windows.Forms.CheckBox();
            this.button10 = new System.Windows.Forms.Button();
            this.popup = new System.Windows.Forms.Button();
            this.custom = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.popopMessage = new System.Windows.Forms.TextBox();
            this.customMessage = new System.Windows.Forms.TextBox();
            this.unlockProtectiveStop = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1289, 644);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.unlockProtectiveStop);
            this.tabPage1.Controls.Add(this.customMessage);
            this.tabPage1.Controls.Add(this.popopMessage);
            this.tabPage1.Controls.Add(this.button13);
            this.tabPage1.Controls.Add(this.custom);
            this.tabPage1.Controls.Add(this.popup);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.dashboardServerConnected);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.button8);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.dashboardOutput);
            this.tabPage1.Controls.Add(this.dashboardConnectButton);
            this.tabPage1.Controls.Add(this.dashboardIpInput);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1281, 618);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dashboard Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // dashboardOutput
            // 
            this.dashboardOutput.Location = new System.Drawing.Point(32, 263);
            this.dashboardOutput.Multiline = true;
            this.dashboardOutput.Name = "dashboardOutput";
            this.dashboardOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dashboardOutput.Size = new System.Drawing.Size(1217, 326);
            this.dashboardOutput.TabIndex = 2;
            this.dashboardOutput.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // dashboardConnectButton
            // 
            this.dashboardConnectButton.Location = new System.Drawing.Point(1044, 23);
            this.dashboardConnectButton.Name = "dashboardConnectButton";
            this.dashboardConnectButton.Size = new System.Drawing.Size(96, 23);
            this.dashboardConnectButton.TabIndex = 1;
            this.dashboardConnectButton.Text = "Connect";
            this.dashboardConnectButton.UseVisualStyleBackColor = true;
            this.dashboardConnectButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // dashboardIpInput
            // 
            this.dashboardIpInput.AcceptsReturn = true;
            this.dashboardIpInput.Location = new System.Drawing.Point(833, 24);
            this.dashboardIpInput.Name = "dashboardIpInput";
            this.dashboardIpInput.Size = new System.Drawing.Size(180, 20);
            this.dashboardIpInput.TabIndex = 0;
            this.dashboardIpInput.Text = "127.0.0.1";
            this.dashboardIpInput.TextChanged += new System.EventHandler(this.dashboardIpInput_TextChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1281, 618);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "2. Page";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(894, 90);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Play";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(991, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Shutdown";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1092, 90);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(147, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Clear Operational Mode";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1164, 24);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Quit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(894, 129);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "Pause";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(991, 90);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Stop";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(32, 90);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Power On";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(32, 129);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(103, 23);
            this.button8.TabIndex = 10;
            this.button8.Text = "Power Off";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(32, 167);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(103, 23);
            this.button9.TabIndex = 11;
            this.button9.Text = "Break Release";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // dashboardServerConnected
            // 
            this.dashboardServerConnected.AutoSize = true;
            this.dashboardServerConnected.Enabled = false;
            this.dashboardServerConnected.Location = new System.Drawing.Point(32, 28);
            this.dashboardServerConnected.Name = "dashboardServerConnected";
            this.dashboardServerConnected.Size = new System.Drawing.Size(78, 17);
            this.dashboardServerConnected.TabIndex = 12;
            this.dashboardServerConnected.Text = "Connected";
            this.dashboardServerConnected.UseVisualStyleBackColor = true;
            this.dashboardServerConnected.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(32, 589);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 13;
            this.button10.Text = "clear";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // popup
            // 
            this.popup.Location = new System.Drawing.Point(197, 90);
            this.popup.Name = "popup";
            this.popup.Size = new System.Drawing.Size(75, 23);
            this.popup.TabIndex = 14;
            this.popup.Text = "Popup";
            this.popup.UseVisualStyleBackColor = true;
            this.popup.Click += new System.EventHandler(this.popup_Click);
            // 
            // custom
            // 
            this.custom.Location = new System.Drawing.Point(197, 129);
            this.custom.Name = "custom";
            this.custom.Size = new System.Drawing.Size(75, 23);
            this.custom.TabIndex = 15;
            this.custom.Text = "Custom";
            this.custom.UseVisualStyleBackColor = true;
            this.custom.Click += new System.EventHandler(this.custom_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(1092, 167);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(147, 23);
            this.button13.TabIndex = 16;
            this.button13.Text = "Close Safety Popup";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // popopMessage
            // 
            this.popopMessage.AcceptsReturn = true;
            this.popopMessage.Location = new System.Drawing.Point(306, 92);
            this.popopMessage.Name = "popopMessage";
            this.popopMessage.Size = new System.Drawing.Size(180, 20);
            this.popopMessage.TabIndex = 17;
            this.popopMessage.Text = "Message";
            // 
            // customMessage
            // 
            this.customMessage.AcceptsReturn = true;
            this.customMessage.Location = new System.Drawing.Point(306, 131);
            this.customMessage.Name = "customMessage";
            this.customMessage.Size = new System.Drawing.Size(180, 20);
            this.customMessage.TabIndex = 18;
            // 
            // unlockProtectiveStop
            // 
            this.unlockProtectiveStop.Location = new System.Drawing.Point(1092, 129);
            this.unlockProtectiveStop.Name = "unlockProtectiveStop";
            this.unlockProtectiveStop.Size = new System.Drawing.Size(147, 23);
            this.unlockProtectiveStop.TabIndex = 19;
            this.unlockProtectiveStop.Text = "Unlock Protective Stop";
            this.unlockProtectiveStop.UseVisualStyleBackColor = true;
            this.unlockProtectiveStop.Click += new System.EventHandler(this.unlockProtectiveStop_Click);
            // 
            // URCommunication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1313, 659);
            this.Controls.Add(this.tabControl1);
            this.Name = "URCommunication";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button dashboardConnectButton;
        private System.Windows.Forms.TextBox dashboardOutput;
        private System.Windows.Forms.TextBox dashboardIpInput;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.CheckBox dashboardServerConnected;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.TextBox customMessage;
        private System.Windows.Forms.TextBox popopMessage;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button custom;
        private System.Windows.Forms.Button popup;
        private System.Windows.Forms.Button unlockProtectiveStop;
    }
}

