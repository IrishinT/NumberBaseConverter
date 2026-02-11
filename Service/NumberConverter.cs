using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class NumberConverter
    {
        /// <summary>
        /// Преобразует число из одной системы счисления в другую.
        /// </summary>
        /// <param name="number">Строковое представление числа.</param>
        /// <param name="fromBase">Основание исходной системы (2-16).</param>
        /// <param name="toBase">Основание целевой системы (2-16).</param>
        /// <returns>Число в целевой системе счисления.</returns>
        public static string ConvertNumber(string number, int fromBase, int toBase)
        {
            // Если системы счисления одинаковые
            if (fromBase == toBase)
                return number;

            // Обработка отрицательных чисел
            bool isNegative = number.StartsWith("-");
            string numberToConvert = isNegative ? number.Substring(1) : number;

            // Конвертация через десятичную систему
            int decimalValue = ToDecimal(numberToConvert, fromBase);
            string result = FromDecimal(decimalValue, toBase);

            // Возвращаем знак
            return isNegative ? "-" + result : result;
        }

        /// <summary>
        /// Преобразует число из произвольной системы счисления в десятичную.
        /// </summary>
        /// <param name="number">Число в исходной системе счисления.</param>
        /// <param name="fromBase">Основание исходной системы.</param>
        /// <returns>Десятичное представление числа.</returns>
        private static int ToDecimal(string number, int fromBase)
        {
            int result = 0;
            int power = 1;

            // Обрабатываем справа налево
            for (int i = number.Length - 1; i >= 0; i--)
            {
                char digit = number[i];
                int digitValue = CharToValue(digit);

                // Проверка на корректность цифры
                if (digitValue >= fromBase)
                    throw new FormatException($"Цифра '{digit}' недопустима для системы счисления {fromBase}");

                checked
                {
                    result += digitValue * power;
                    power *= fromBase;
                }
            }

            return result;
        }

        /// <summary>
        /// Преобразует число из десятичной системы в произвольную систему счисления.
        /// </summary>
        /// <param name="decimalNumber">Десятичное число.</param>
        /// <param name="toBase">Основание целевой системы.</param>
        /// <returns>Число в целевой системе счисления.</returns>
        private static string FromDecimal(int decimalNumber, int toBase)
        {
            if (decimalNumber == 0)
                return "0";

            string result = "";
            const string digits = "0123456789ABCDEF";

            while (decimalNumber > 0)
            {
                int remainder = decimalNumber % toBase;
                result = digits[remainder] + result;
                decimalNumber /= toBase;
            }

            return result;
        }


        /// <summary>
        /// Преобразует символ цифры в его числовое значение.
        /// </summary>
        /// <param name="digit">Символ (0-9, A-F).</param>
        /// <returns>Числовое значение от 0 до 15.</returns>
        private static int CharToValue(char digit)
        {
            digit = char.ToUpper(digit);

            if (char.IsDigit(digit))
                return digit - '0';
            else
                return digit - 'A' + 10;
        }
    }
}