using System.Text;

namespace Lab
{
    public partial class Form1 : Form
    {
        // ����� ��� ���������� � ������� ����� ������
        static string CaesarCipherEncrypt(string text, int key)
        {
            StringBuilder result = new StringBuilder();

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char baseChar = char.IsUpper(ch) ? 'A' : 'a'; // ���������� ������� ������ ��� ��������
                    char shiftedChar = (char)((((ch - baseChar) + key) % 26) + baseChar);
                    result.Append(shiftedChar);
                }
                else
                {
                    result.Append(ch);
                }
            }

            return result.ToString();
        }

        // ����� ��� ������������ � ������� ����� ������
        static string CaesarCipherDecrypt(string text, int key)
        {
            return CaesarCipherEncrypt(text, 26 - key); // ��� ������������ ������������ �������� ����
        }

        // ����� ��� ���������� � ������� ����� ��������
        static string VigenereCipherEncrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char baseChar = char.IsUpper(ch) ? 'A' : 'a'; // ���������� ������� ������ ��� ��������
                    char shiftedChar = (char)((((ch - baseChar) + (key[keyIndex % key.Length] - baseChar)) % 26) + baseChar);
                    result.Append(shiftedChar);
                    keyIndex++;
                }
                else
                {
                    result.Append(ch);
                }
            }

            return result.ToString();
        }
        // ����� ��� ������������ ����� ��������
        static string VigenereCipherDecrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char baseChar = char.IsUpper(ch) ? 'A' : 'a'; // ���������� ������� ������ ��� ��������
                    char shiftedChar = (char)((((ch - baseChar) - (key[keyIndex % key.Length] - baseChar) + 26) % 26) + baseChar);
                    result.Append(shiftedChar);
                    keyIndex++;
                }
                else
                {
                    result.Append(ch);
                }
            }

            return result.ToString();
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void EncryptDecryptButton_Click_Click(object sender, EventArgs e)
        {
            string filePath = FilePathTextBox.Text; // �������� ���� � ����� �� ���������� ����

            bool isCaesar = CaesarRadioButton.Checked; // ���������, ������ �� ���� ������

            try
            {
                string originalText = File.ReadAllText(filePath);
                string encryptedText;

                if (isCaesar)
                {
                    int caesarKey = int.Parse(CaesarKeyTextBox.Text); // �������� ���� ����� ������ �� ���������� ����
                    encryptedText = CaesarCipherEncrypt(originalText, caesarKey);
                    CaesarRadioButton.Checked = false;
                }
                else
                {
                    string key = KeyTextBox.Text; // �������� ���� �� ���������� ����
                    encryptedText = VigenereCipherEncrypt(originalText, key); // ������������ ���� ��� ����� ��������
                }

                EncryptedTextBox.Text = encryptedText; // ���������� ������������� ����� � ��������� ����
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("���� �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; // ��������� ���������� ��� �������
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // ������ ��� ������
                openFileDialog.FilterIndex = 1; // ��������� ������ �������

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePathTextBox.Text = openFileDialog.FileName; // ��������� ���������� ���� � ��������� ����
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CaesarKeyTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DecryptButton_Click_Click(object sender, EventArgs e)
        {
            string filePath = FilePathTextBox.Text; // �������� ���� � ����� �� ���������� ����
            string key = KeyTextBox.Text; // �������� ���� �� ���������� ����

            bool isCaesar = CaesarRadioButton.Checked; // ���������, ������ �� ���� ������

            try
            {
                string encryptedText = File.ReadAllText(filePath);
                string decryptedText;

                if (isCaesar)
                {
                    int caesarKey = int.Parse(CaesarKeyTextBox.Text); // �������� ���� ����� ������ �� ���������� ����
                    decryptedText = CaesarCipherDecrypt(encryptedText, caesarKey);
                    CaesarRadioButton.Checked = false;
                }
                else
                {
                    decryptedText = VigenereCipherDecrypt(encryptedText, key);
                }

                DecryptedTextBox.Text = decryptedText; // ���������� �������������� ����� � ��������� ����
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("���� �� ������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"��������� ������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void richTextBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void CaesarRadioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
