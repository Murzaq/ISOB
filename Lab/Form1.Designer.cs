namespace Lab
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
            EncryptDecryptButton = new Button();
            EncryptedTextBox = new RichTextBox();
            openFileDialog1 = new OpenFileDialog();
            BrowseButton = new Button();
            FilePathTextBox = new TextBox();
            label1 = new Label();
            CaesarKeyTextBox = new TextBox();
            KeyTextBox = new TextBox();
            CaesarRadioButton = new RadioButton();
            DecryptButton_Click = new Button();
            DecryptedTextBox = new RichTextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // EncryptDecryptButton
            // 
            EncryptDecryptButton.Location = new Point(35, 9);
            EncryptDecryptButton.Name = "EncryptDecryptButton";
            EncryptDecryptButton.Size = new Size(250, 104);
            EncryptDecryptButton.TabIndex = 0;
            EncryptDecryptButton.Text = "Шифрование";
            EncryptDecryptButton.UseVisualStyleBackColor = true;
            EncryptDecryptButton.Click += EncryptDecryptButton_Click_Click;
            // 
            // EncryptedTextBox
            // 
            EncryptedTextBox.Location = new Point(35, 258);
            EncryptedTextBox.Name = "EncryptedTextBox";
            EncryptedTextBox.Size = new Size(434, 336);
            EncryptedTextBox.TabIndex = 1;
            EncryptedTextBox.Text = "";
            EncryptedTextBox.TextChanged += richTextBox1_TextChanged;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // BrowseButton
            // 
            BrowseButton.Location = new Point(723, 618);
            BrowseButton.Name = "BrowseButton";
            BrowseButton.Size = new Size(266, 46);
            BrowseButton.TabIndex = 2;
            BrowseButton.Text = "Указать путь к файлу";
            BrowseButton.UseVisualStyleBackColor = true;
            BrowseButton.Click += BrowseButton_Click;
            // 
            // FilePathTextBox
            // 
            FilePathTextBox.Location = new Point(35, 625);
            FilePathTextBox.Name = "FilePathTextBox";
            FilePathTextBox.Size = new Size(634, 39);
            FilePathTextBox.TabIndex = 3;
            FilePathTextBox.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(35, 223);
            label1.Name = "label1";
            label1.Size = new Size(263, 32);
            label1.TabIndex = 5;
            label1.Text = "Зашифрованный текст";
            // 
            // CaesarKeyTextBox
            // 
            CaesarKeyTextBox.Location = new Point(555, 57);
            CaesarKeyTextBox.Name = "CaesarKeyTextBox";
            CaesarKeyTextBox.Size = new Size(326, 39);
            CaesarKeyTextBox.TabIndex = 7;
            CaesarKeyTextBox.Text = "Ввод ключа Шифра Цезаря";
            CaesarKeyTextBox.TextChanged += CaesarKeyTextBox_TextChanged;
            // 
            // KeyTextBox
            // 
            KeyTextBox.Location = new Point(555, 12);
            KeyTextBox.Name = "KeyTextBox";
            KeyTextBox.Size = new Size(326, 39);
            KeyTextBox.TabIndex = 8;
            KeyTextBox.Text = "Ввод ключа";
            KeyTextBox.TextChanged += KeyTextBox_TextChanged;
            // 
            // CaesarRadioButton
            // 
            CaesarRadioButton.AutoSize = true;
            CaesarRadioButton.Location = new Point(35, 135);
            CaesarRadioButton.Name = "CaesarRadioButton";
            CaesarRadioButton.Size = new Size(195, 36);
            CaesarRadioButton.TabIndex = 9;
            CaesarRadioButton.Text = "Шифр цезаря";
            CaesarRadioButton.UseVisualStyleBackColor = true;
            CaesarRadioButton.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // DecryptButton_Click
            // 
            DecryptButton_Click.Location = new Point(299, 9);
            DecryptButton_Click.Name = "DecryptButton_Click";
            DecryptButton_Click.Size = new Size(250, 104);
            DecryptButton_Click.TabIndex = 10;
            DecryptButton_Click.Text = "Дешифрование";
            DecryptButton_Click.UseVisualStyleBackColor = true;
            DecryptButton_Click.Click += DecryptButton_Click_Click;
            // 
            // DecryptedTextBox
            // 
            DecryptedTextBox.Location = new Point(539, 258);
            DecryptedTextBox.Name = "DecryptedTextBox";
            DecryptedTextBox.Size = new Size(434, 336);
            DecryptedTextBox.TabIndex = 11;
            DecryptedTextBox.Text = "";
            DecryptedTextBox.TextChanged += richTextBox1_TextChanged_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(555, 223);
            label2.Name = "label2";
            label2.Size = new Size(284, 32);
            label2.TabIndex = 12;
            label2.Text = "!(Зашифрованный текст)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 704);
            Controls.Add(label2);
            Controls.Add(DecryptedTextBox);
            Controls.Add(DecryptButton_Click);
            Controls.Add(CaesarRadioButton);
            Controls.Add(KeyTextBox);
            Controls.Add(CaesarKeyTextBox);
            Controls.Add(label1);
            Controls.Add(FilePathTextBox);
            Controls.Add(BrowseButton);
            Controls.Add(EncryptedTextBox);
            Controls.Add(EncryptDecryptButton);
            Name = "Form1";
            Text = "Шифр Цезаря, Шифр Виженера";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button EncryptDecryptButton;
        private RichTextBox EncryptedTextBox;
        private OpenFileDialog openFileDialog1;
        private Button BrowseButton;
        private TextBox FilePathTextBox;
        private Label label1;
        private TextBox CaesarKeyTextBox;
        private TextBox KeyTextBox;
        private Button DecryptButton_Click;
        private RichTextBox DecryptedTextBox;
        private Label label2;
        protected RadioButton CaesarRadioButton;
    }
}
