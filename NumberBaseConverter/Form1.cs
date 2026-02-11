using Service;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumberBaseConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Обрабатывает нажатие кнопки конвертации: выполняет валидацию ввода и преобразование числа.
        /// </summary>
        /// <param name="sender">Источник события (кнопка convertButton).</param>
        /// <param name="e">Аргументы события.</param>
        /// <remarks>
        /// Последовательность работы:
        /// 1. Проверяет, что поле ввода не пустое
        /// 2. Проверяет, выбраны ли системы счисления
        /// 3. Преобразует выбранные значения в числа
        /// 4. Валидирует число для исходной системы счисления
        /// 5. Выполняет конвертацию через NumberConverter
        /// 6. Отображает результат или сообщение об ошибке
        /// </remarks>
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
                // Валидация входных параметров
                NumberValidator.ValidateParameters(input, inputBase, outputBase);

                string result = NumberConverter.ConvertNumber(input, inputBase, outputBase);
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
