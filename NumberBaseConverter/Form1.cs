namespace NumberBaseConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void convertButton_Click(object sender, EventArgs e)
        {
            string input = inputTextBox.Text.Trim();

            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Введите число", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fromComboBox.SelectedItem == null || toComboBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите системы счисления", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(!int.TryParse(fromComboBox.SelectedItem.ToString(), out int inputBase))
            {
                MessageBox.Show("""
                    Произошла внутренняя ошибка в ходе выполнения данной операции!
                    Ошибка перевода входной СС в число.
                    """, 
                    "Критическая ошибка!", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Stop);
                return;
            }

            if (!int.TryParse(toComboBox.SelectedItem.ToString(), out int outputBase))
            {
                MessageBox.Show("""
                    Произошла внутренняя ошибка в ходе выполнения данной операции!
                    Ошибка перевода выходной СС в число.
                    """,
                    "Критическая ошибка!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                return;
            }

            // Используем класс NumberValidator
            // Проверяем валидность ввода для выбранной системы счисления
            if (!NumberValidator.IsValidForBase(input, inputBase))
            {
                string errorMessage = NumberValidator.GetValidationError(input, inputBase);
                MessageBox.Show(errorMessage, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Выполняем конвертацию
            try
            {
                string result = NumberValidator.ConvertNumber(input, inputBase, outputBase);
                resultTextBox.Text = result;
            }
            catch (FormatException)
            {
                MessageBox.Show("Входное значение не является числом для заданной системы счисления",
                    "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Входное значение слишком большое",
                    "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при конвертации: {ex.Message}",
                    "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


        }


    }
}
