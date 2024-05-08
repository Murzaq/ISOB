namespace Lab45
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


        private List<TextBox> loginFields = new();
        private List<TextBox> passwordsFields = new();
        private List<TextBox> messageFields = new();
        private List<Button> signInButtons = new();
        private List<Button> sendButtons = new();





        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        /// 
        private void InitializeComponent()
        {
            this.SignIn1 = new System.Windows.Forms.Button();
            this.Message1 = new System.Windows.Forms.TextBox();
            this.MessagesListBox = new System.Windows.Forms.ListBox();
            this.Message2 = new System.Windows.Forms.TextBox();
            this.SignIn2 = new System.Windows.Forms.Button();
            this.Message3 = new System.Windows.Forms.TextBox();
            this.SignIn3 = new System.Windows.Forms.Button();
            this.Message4 = new System.Windows.Forms.TextBox();
            this.SignIn4 = new System.Windows.Forms.Button();
            this.Message5 = new System.Windows.Forms.TextBox();
            this.SignIn5 = new System.Windows.Forms.Button();
            this.Message6 = new System.Windows.Forms.TextBox();
            this.SignIn6 = new System.Windows.Forms.Button();
            this.Login1 = new System.Windows.Forms.TextBox();
            this.Password1 = new System.Windows.Forms.TextBox();
            this.Login2 = new System.Windows.Forms.TextBox();
            this.Password2 = new System.Windows.Forms.TextBox();
            this.Login3 = new System.Windows.Forms.TextBox();
            this.Password3 = new System.Windows.Forms.TextBox();
            this.Login4 = new System.Windows.Forms.TextBox();
            this.Password4 = new System.Windows.Forms.TextBox();
            this.Login5 = new System.Windows.Forms.TextBox();
            this.Password5 = new System.Windows.Forms.TextBox();
            this.Login6 = new System.Windows.Forms.TextBox();
            this.Password6 = new System.Windows.Forms.TextBox();
            this.Send6 = new System.Windows.Forms.Button();
            this.Send5 = new System.Windows.Forms.Button();
            this.Send4 = new System.Windows.Forms.Button();
            this.Send3 = new System.Windows.Forms.Button();
            this.Send2 = new System.Windows.Forms.Button();
            this.Send1 = new System.Windows.Forms.Button();
            this.AttackDefensesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.SignOut6 = new System.Windows.Forms.Button();
            this.SignOut5 = new System.Windows.Forms.Button();
            this.SignOut4 = new System.Windows.Forms.Button();
            this.SignOut3 = new System.Windows.Forms.Button();
            this.SignOut2 = new System.Windows.Forms.Button();
            this.SignOut1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SignIn1
            // 
            this.SignIn1.Location = new System.Drawing.Point(162, 35);
            this.SignIn1.Name = "SignIn1";
            this.SignIn1.Size = new System.Drawing.Size(82, 23);
            this.SignIn1.TabIndex = 2;
            this.SignIn1.Text = "Sign In";
            this.SignIn1.UseVisualStyleBackColor = true;
            this.SignIn1.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // Message1
            // 
            this.Message1.Location = new System.Drawing.Point(330, 50);
            this.Message1.Name = "Message1";
            this.Message1.Size = new System.Drawing.Size(168, 23);
            this.Message1.TabIndex = 3;
            // 
            // MessagesListBox
            // 
            this.MessagesListBox.FormattingEnabled = true;
            this.MessagesListBox.ItemHeight = 15;
            this.MessagesListBox.Location = new System.Drawing.Point(626, 26);
            this.MessagesListBox.Name = "MessagesListBox";
            this.MessagesListBox.Size = new System.Drawing.Size(271, 409);
            this.MessagesListBox.TabIndex = 4;
            // 
            // Message2
            // 
            this.Message2.Location = new System.Drawing.Point(330, 139);
            this.Message2.Name = "Message2";
            this.Message2.Size = new System.Drawing.Size(168, 23);
            this.Message2.TabIndex = 8;
            // 
            // SignIn2
            // 
            this.SignIn2.Location = new System.Drawing.Point(162, 124);
            this.SignIn2.Name = "SignIn2";
            this.SignIn2.Size = new System.Drawing.Size(82, 23);
            this.SignIn2.TabIndex = 7;
            this.SignIn2.Text = "Sign In";
            this.SignIn2.UseVisualStyleBackColor = true;
            this.SignIn2.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // Message3
            // 
            this.Message3.Location = new System.Drawing.Point(330, 218);
            this.Message3.Name = "Message3";
            this.Message3.Size = new System.Drawing.Size(168, 23);
            this.Message3.TabIndex = 12;
            // 
            // SignIn3
            // 
            this.SignIn3.Location = new System.Drawing.Point(162, 203);
            this.SignIn3.Name = "SignIn3";
            this.SignIn3.Size = new System.Drawing.Size(82, 23);
            this.SignIn3.TabIndex = 11;
            this.SignIn3.Text = "Sign In";
            this.SignIn3.UseVisualStyleBackColor = true;
            this.SignIn3.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // Message4
            // 
            this.Message4.Location = new System.Drawing.Point(330, 304);
            this.Message4.Name = "Message4";
            this.Message4.Size = new System.Drawing.Size(168, 23);
            this.Message4.TabIndex = 16;
            // 
            // SignIn4
            // 
            this.SignIn4.Location = new System.Drawing.Point(162, 289);
            this.SignIn4.Name = "SignIn4";
            this.SignIn4.Size = new System.Drawing.Size(82, 23);
            this.SignIn4.TabIndex = 15;
            this.SignIn4.Text = "Sign In";
            this.SignIn4.UseVisualStyleBackColor = true;
            this.SignIn4.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // Message5
            // 
            this.Message5.Location = new System.Drawing.Point(330, 397);
            this.Message5.Name = "Message5";
            this.Message5.Size = new System.Drawing.Size(168, 23);
            this.Message5.TabIndex = 20;
            // 
            // SignIn5
            // 
            this.SignIn5.Location = new System.Drawing.Point(162, 382);
            this.SignIn5.Name = "SignIn5";
            this.SignIn5.Size = new System.Drawing.Size(82, 23);
            this.SignIn5.TabIndex = 19;
            this.SignIn5.Text = "Sign In";
            this.SignIn5.UseVisualStyleBackColor = true;
            this.SignIn5.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // Message6
            // 
            this.Message6.Location = new System.Drawing.Point(330, 488);
            this.Message6.Name = "Message6";
            this.Message6.Size = new System.Drawing.Size(168, 23);
            this.Message6.TabIndex = 24;
            // 
            // SignIn6
            // 
            this.SignIn6.Location = new System.Drawing.Point(162, 473);
            this.SignIn6.Name = "SignIn6";
            this.SignIn6.Size = new System.Drawing.Size(82, 23);
            this.SignIn6.TabIndex = 23;
            this.SignIn6.Text = "Sign In";
            this.SignIn6.UseVisualStyleBackColor = true;
            this.SignIn6.Click += new System.EventHandler(this.SignIn_Click);
            // 
            // Login1
            // 
            this.Login1.Location = new System.Drawing.Point(44, 35);
            this.Login1.Name = "Login1";
            this.Login1.Size = new System.Drawing.Size(100, 23);
            this.Login1.TabIndex = 0;
            // 
            // Password1
            // 
            this.Password1.Location = new System.Drawing.Point(44, 64);
            this.Password1.Name = "Password1";
            this.Password1.Size = new System.Drawing.Size(100, 23);
            this.Password1.TabIndex = 1;
            // 
            // Login2
            // 
            this.Login2.Location = new System.Drawing.Point(44, 124);
            this.Login2.Name = "Login2";
            this.Login2.Size = new System.Drawing.Size(100, 23);
            this.Login2.TabIndex = 5;
            // 
            // Password2
            // 
            this.Password2.Location = new System.Drawing.Point(44, 153);
            this.Password2.Name = "Password2";
            this.Password2.Size = new System.Drawing.Size(100, 23);
            this.Password2.TabIndex = 6;
            // 
            // Login3
            // 
            this.Login3.Location = new System.Drawing.Point(44, 203);
            this.Login3.Name = "Login3";
            this.Login3.Size = new System.Drawing.Size(100, 23);
            this.Login3.TabIndex = 9;
            // 
            // Password3
            // 
            this.Password3.Location = new System.Drawing.Point(44, 232);
            this.Password3.Name = "Password3";
            this.Password3.Size = new System.Drawing.Size(100, 23);
            this.Password3.TabIndex = 10;
            // 
            // Login4
            // 
            this.Login4.Location = new System.Drawing.Point(44, 289);
            this.Login4.Name = "Login4";
            this.Login4.Size = new System.Drawing.Size(100, 23);
            this.Login4.TabIndex = 13;
            // 
            // Password4
            // 
            this.Password4.Location = new System.Drawing.Point(44, 318);
            this.Password4.Name = "Password4";
            this.Password4.Size = new System.Drawing.Size(100, 23);
            this.Password4.TabIndex = 14;
            // 
            // Login5
            // 
            this.Login5.Location = new System.Drawing.Point(44, 382);
            this.Login5.Name = "Login5";
            this.Login5.Size = new System.Drawing.Size(100, 23);
            this.Login5.TabIndex = 17;
            // 
            // Password5
            // 
            this.Password5.Location = new System.Drawing.Point(44, 411);
            this.Password5.Name = "Password5";
            this.Password5.Size = new System.Drawing.Size(100, 23);
            this.Password5.TabIndex = 18;
            // 
            // Login6
            // 
            this.Login6.Location = new System.Drawing.Point(44, 473);
            this.Login6.Name = "Login6";
            this.Login6.Size = new System.Drawing.Size(100, 23);
            this.Login6.TabIndex = 21;
            // 
            // Password6
            // 
            this.Password6.Location = new System.Drawing.Point(44, 502);
            this.Password6.Name = "Password6";
            this.Password6.Size = new System.Drawing.Size(100, 23);
            this.Password6.TabIndex = 22;
            // 
            // Send6
            // 
            this.Send6.Location = new System.Drawing.Point(514, 487);
            this.Send6.Name = "Send6";
            this.Send6.Size = new System.Drawing.Size(82, 23);
            this.Send6.TabIndex = 30;
            this.Send6.Text = "Send";
            this.Send6.UseVisualStyleBackColor = true;
            this.Send6.Click += new System.EventHandler(this.Send_Click);
            // 
            // Send5
            // 
            this.Send5.Location = new System.Drawing.Point(514, 396);
            this.Send5.Name = "Send5";
            this.Send5.Size = new System.Drawing.Size(82, 23);
            this.Send5.TabIndex = 29;
            this.Send5.Text = "Send";
            this.Send5.UseVisualStyleBackColor = true;
            this.Send5.Click += new System.EventHandler(this.Send_Click);
            // 
            // Send4
            // 
            this.Send4.Location = new System.Drawing.Point(514, 303);
            this.Send4.Name = "Send4";
            this.Send4.Size = new System.Drawing.Size(82, 23);
            this.Send4.TabIndex = 28;
            this.Send4.Text = "Send";
            this.Send4.UseVisualStyleBackColor = true;
            this.Send4.Click += new System.EventHandler(this.Send_Click);
            // 
            // Send3
            // 
            this.Send3.Location = new System.Drawing.Point(514, 217);
            this.Send3.Name = "Send3";
            this.Send3.Size = new System.Drawing.Size(82, 23);
            this.Send3.TabIndex = 27;
            this.Send3.Text = "Send";
            this.Send3.UseVisualStyleBackColor = true;
            this.Send3.Click += new System.EventHandler(this.Send_Click);
            // 
            // Send2
            // 
            this.Send2.Location = new System.Drawing.Point(514, 138);
            this.Send2.Name = "Send2";
            this.Send2.Size = new System.Drawing.Size(82, 23);
            this.Send2.TabIndex = 26;
            this.Send2.Text = "Send";
            this.Send2.UseVisualStyleBackColor = true;
            this.Send2.Click += new System.EventHandler(this.Send_Click);
            // 
            // Send1
            // 
            this.Send1.Location = new System.Drawing.Point(514, 49);
            this.Send1.Name = "Send1";
            this.Send1.Size = new System.Drawing.Size(82, 23);
            this.Send1.TabIndex = 25;
            this.Send1.Text = "Send";
            this.Send1.UseVisualStyleBackColor = true;
            this.Send1.Click += new System.EventHandler(this.Send_Click);
            // 
            // AttackDefensesCheckedListBox
            // 
            this.AttackDefensesCheckedListBox.FormattingEnabled = true;
            this.AttackDefensesCheckedListBox.Items.AddRange(new object[] {
            "Minimize Privilege",
            "Canonization",
            "DoS",
            "XSS"});
            this.AttackDefensesCheckedListBox.Location = new System.Drawing.Point(626, 431);
            this.AttackDefensesCheckedListBox.Name = "AttackDefensesCheckedListBox";
            this.AttackDefensesCheckedListBox.Size = new System.Drawing.Size(271, 94);
            this.AttackDefensesCheckedListBox.TabIndex = 31;
            // 
            // SignOut6
            // 
            this.SignOut6.Location = new System.Drawing.Point(162, 502);
            this.SignOut6.Name = "SignOut6";
            this.SignOut6.Size = new System.Drawing.Size(82, 23);
            this.SignOut6.TabIndex = 37;
            this.SignOut6.Text = "Sign Out";
            this.SignOut6.UseVisualStyleBackColor = true;
            this.SignOut6.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // SignOut5
            // 
            this.SignOut5.Location = new System.Drawing.Point(162, 411);
            this.SignOut5.Name = "SignOut5";
            this.SignOut5.Size = new System.Drawing.Size(82, 23);
            this.SignOut5.TabIndex = 36;
            this.SignOut5.Text = "Sign Out";
            this.SignOut5.UseVisualStyleBackColor = true;
            this.SignOut5.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // SignOut4
            // 
            this.SignOut4.Location = new System.Drawing.Point(162, 318);
            this.SignOut4.Name = "SignOut4";
            this.SignOut4.Size = new System.Drawing.Size(82, 23);
            this.SignOut4.TabIndex = 35;
            this.SignOut4.Text = "Sign Out";
            this.SignOut4.UseVisualStyleBackColor = true;
            this.SignOut4.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // SignOut3
            // 
            this.SignOut3.Location = new System.Drawing.Point(162, 232);
            this.SignOut3.Name = "SignOut3";
            this.SignOut3.Size = new System.Drawing.Size(82, 23);
            this.SignOut3.TabIndex = 34;
            this.SignOut3.Text = "Sign Out";
            this.SignOut3.UseVisualStyleBackColor = true;
            this.SignOut3.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // SignOut2
            // 
            this.SignOut2.Location = new System.Drawing.Point(162, 153);
            this.SignOut2.Name = "SignOut2";
            this.SignOut2.Size = new System.Drawing.Size(82, 23);
            this.SignOut2.TabIndex = 33;
            this.SignOut2.Text = "Sign Out";
            this.SignOut2.UseVisualStyleBackColor = true;
            this.SignOut2.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // SignOut1
            // 
            this.SignOut1.Location = new System.Drawing.Point(162, 64);
            this.SignOut1.Name = "SignOut1";
            this.SignOut1.Size = new System.Drawing.Size(82, 23);
            this.SignOut1.TabIndex = 32;
            this.SignOut1.Text = "Sign Out";
            this.SignOut1.UseVisualStyleBackColor = true;
            this.SignOut1.Click += new System.EventHandler(this.SignOut_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(936, 559);
            this.Controls.Add(this.SignOut6);
            this.Controls.Add(this.SignOut5);
            this.Controls.Add(this.SignOut4);
            this.Controls.Add(this.SignOut3);
            this.Controls.Add(this.SignOut2);
            this.Controls.Add(this.SignOut1);
            this.Controls.Add(this.AttackDefensesCheckedListBox);
            this.Controls.Add(this.Send6);
            this.Controls.Add(this.Send5);
            this.Controls.Add(this.Send4);
            this.Controls.Add(this.Send3);
            this.Controls.Add(this.Send2);
            this.Controls.Add(this.Send1);
            this.Controls.Add(this.Message6);
            this.Controls.Add(this.SignIn6);
            this.Controls.Add(this.Password6);
            this.Controls.Add(this.Login6);
            this.Controls.Add(this.Message5);
            this.Controls.Add(this.SignIn5);
            this.Controls.Add(this.Password5);
            this.Controls.Add(this.Login5);
            this.Controls.Add(this.Message4);
            this.Controls.Add(this.SignIn4);
            this.Controls.Add(this.Password4);
            this.Controls.Add(this.Login4);
            this.Controls.Add(this.Message3);
            this.Controls.Add(this.SignIn3);
            this.Controls.Add(this.Password3);
            this.Controls.Add(this.Login3);
            this.Controls.Add(this.Message2);
            this.Controls.Add(this.SignIn2);
            this.Controls.Add(this.Password2);
            this.Controls.Add(this.Login2);
            this.Controls.Add(this.MessagesListBox);
            this.Controls.Add(this.Message1);
            this.Controls.Add(this.SignIn1);
            this.Controls.Add(this.Password1);
            this.Controls.Add(this.Login1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button SignIn1;
        private TextBox Message1;
        private ListBox MessagesListBox;
        private TextBox Message2;
        private Button SignIn2;
        private TextBox Message3;
        private Button SignIn3;
        private TextBox Message4;
        private Button SignIn4;
        private TextBox Message5;
        private Button SignIn5;
        private TextBox Message6;
        private Button SignIn6;
        private TextBox Login1;
        private TextBox Password1;
        private TextBox Login2;
        private TextBox Password2;
        private TextBox Login3;
        private TextBox Password3;
        private TextBox Login4;
        private TextBox Password4;
        private TextBox Login5;
        private TextBox Password5;
        private TextBox Login6;
        private TextBox Password6;
        private Button Send6;
        private Button Send5;
        private Button Send4;
        private Button Send3;
        private Button Send2;
        private Button Send1;
        private CheckedListBox AttackDefensesCheckedListBox;
        private Button SignOut6;
        private Button SignOut5;
        private Button SignOut4;
        private Button SignOut3;
        private Button SignOut2;
        private Button SignOut1;
    }
}