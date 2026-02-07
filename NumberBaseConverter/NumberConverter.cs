using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberBaseConverter
{
    internal static class NumberConverter
    {
        public static string ConvertNumber(string number, int fromBase, int toBase)
        {
            // Валидация входных параметров
            ValidateParameters(number, fromBase, toBase);

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
        private static int CharToValue(char digit)
        {
            digit = char.ToUpper(digit);

            if (char.IsDigit(digit))
                return digit - '0';
            else
                return digit - 'A' + 10;
        }
        private static void ValidateParameters(string number, int fromBase, int toBase)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Число не может быть пустым");

            if (fromBase < 2 || fromBase > 16 || toBase < 2 || toBase > 16)
                throw new ArgumentException("Система счисления должна быть от 2 до 16");

            // Используем NumberValidator для проверки числа
            if (!NumberValidator.IsValidForBase(number, fromBase))
                throw new FormatException(NumberValidator.GetValidationError(number, fromBase));
        }
    }
}