using System.Text;

namespace Lab
{
    public partial class Form1 : Form
    {
        // Метод для шифрования с помощью Шифра Цезаря
        static string CaesarCipherEncrypt(string text, int key)
        {
            StringBuilder result = new StringBuilder();

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char baseChar = char.IsUpper(ch) ? 'A' : 'a'; // Определяем базовый символ для регистра
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

        // Метод для дешифрования с помощью Шифра Цезаря
        static string CaesarCipherDecrypt(string text, int key)
        {
            return CaesarCipherEncrypt(text, 26 - key); // Для дешифрования используется обратный ключ
        }

        // Метод для шифрования с помощью шифра Виженера
        static string VigenereCipherEncrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char baseChar = char.IsUpper(ch) ? 'A' : 'a'; // Определяем базовый символ для регистра
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
        // Метод для дешифрования шифра Виженера
        static string VigenereCipherDecrypt(string text, string key)
        {
            StringBuilder result = new StringBuilder();
            int keyIndex = 0;

            foreach (char ch in text)
            {
                if (char.IsLetter(ch))
                {
                    char baseChar = char.IsUpper(ch) ? 'A' : 'a'; // Определяем базовый символ для регистра
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
            string filePath = FilePathTextBox.Text; // Получить путь к файлу из текстового поля

            bool isCaesar = CaesarRadioButton.Checked; // Проверить, выбран ли Шифр Цезаря

            try
            {
                string originalText = File.ReadAllText(filePath);
                string encryptedText;

                if (isCaesar)
                {
                    int caesarKey = int.Parse(CaesarKeyTextBox.Text); // Получить ключ Шифра Цезаря из текстового поля
                    encryptedText = CaesarCipherEncrypt(originalText, caesarKey);
                    CaesarRadioButton.Checked = false;
                }
                else
                {
                    string key = KeyTextBox.Text; // Получить ключ из текстового поля
                    encryptedText = VigenereCipherEncrypt(originalText, key); // Использовать ключ для шифра Виженера
                }

                EncryptedTextBox.Text = encryptedText; // Отобразить зашифрованный текст в текстовом поле
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\"; // Начальная директория для диалога
                openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"; // Фильтр для файлов
                openFileDialog.FilterIndex = 1; // Начальный индекс фильтра

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePathTextBox.Text = openFileDialog.FileName; // Установка выбранного пути в текстовое поле
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
            string filePath = FilePathTextBox.Text; // Получить путь к файлу из текстового поля
            string key = KeyTextBox.Text; // Получить ключ из текстового поля

            bool isCaesar = CaesarRadioButton.Checked; // Проверить, выбран ли Шифр Цезаря

            try
            {
                string encryptedText = File.ReadAllText(filePath);
                string decryptedText;

                if (isCaesar)
                {
                    int caesarKey = int.Parse(CaesarKeyTextBox.Text); // Получить ключ Шифра Цезаря из текстового поля
                    decryptedText = CaesarCipherDecrypt(encryptedText, caesarKey);
                    CaesarRadioButton.Checked = false;
                }
                else
                {
                    decryptedText = VigenereCipherDecrypt(encryptedText, key);
                }

                DecryptedTextBox.Text = decryptedText; // Отобразить расшифрованный текст в текстовом поле
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
