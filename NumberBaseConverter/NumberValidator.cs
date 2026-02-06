using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberBaseConverter
{
    internal static class NumberValidator
    {   /// <summary>
        /// Проверяет корректность числа для заданной системы счисления
        /// </summary>
        public static bool IsValidForBase(string number, int numberBase)
        {
            if (string.IsNullOrWhiteSpace(number))
                return false;

            // Убираем знак минуса для проверки
            string numberToCheck = number;
            if (number.StartsWith("-"))
                numberToCheck = number.Substring(1);

            // Определяем допустимые символы
            string allowedDigits = GetAllowedDigits(numberBase);
            if (string.IsNullOrEmpty(allowedDigits))
                return false;

            // Проверяем каждый символ
            foreach (char digit in numberToCheck.ToUpper())
            {
                if (!allowedDigits.Contains(digit))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Возвращает строку с допустимыми цифрами для системы счисления
        /// </summary>
        private static string GetAllowedDigits(int numberBase)
        {
            if (numberBase < 2 || numberBase > 16)
                return "";

            const string allDigits = "0123456789ABCDEF";
            return allDigits.Substring(0, numberBase);
        }

        /// <summary>
        /// Получает понятное сообщение об ошибке валидации
        /// </summary>
        public static string GetValidationError(string number, int numberBase)
        {
            if (string.IsNullOrWhiteSpace(number))
                return "Число не может быть пустым";

            if (numberBase < 2 || numberBase > 16)
                return $"Неподдерживаемая система счисления: {numberBase} (допустимо 2-16)";

            string allowedDigits = GetAllowedDigits(numberBase);
            string numberToCheck = number.StartsWith("-") ? number.Substring(1) : number;

            foreach (char digit in numberToCheck.ToUpper())
            {
                if (!allowedDigits.Contains(digit))
                {
                    string systemName = GetBaseName(numberBase);
                    return $"Недопустимый символ '{digit}' для {systemName} системы. " +
                           $"Допустимые символы: {string.Join(", ", allowedDigits.ToCharArray())}";
                }
            }

            return "Число корректно";
        }

        /// <summary>
        /// Получает название системы счисления
        /// </summary>
        private static string GetBaseName(int numberBase)
        {
            return numberBase switch
            {
                2 => "двоичной",
                8 => "восьмеричной",
                10 => "десятичной",
                16 => "шестнадцатеричной",
                _ => $"{numberBase}-ричной"
            };
        }

        /// <summary>
        /// Конвертирует число из одной системы счисления в другую
        /// </summary>
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

        /// <summary>
        /// Конвертирует число в десятичную систему
        /// </summary>
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
        /// Конвертирует число из десятичной системы в указанную
        /// </summary>
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
        /// Преобразует символ в числовое значение
        /// </summary>
        private static int CharToValue(char digit)
        {
            digit = char.ToUpper(digit);

            if (char.IsDigit(digit))
                return digit - '0';
            else
                return digit - 'A' + 10;
        }

        /// <summary>
        /// Валидация входных параметров конвертации
        /// </summary>
        private static void ValidateParameters(string number, int fromBase, int toBase)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Число не может быть пустым");

            if (fromBase < 2 || fromBase > 16 || toBase < 2 || toBase > 16)
                throw new ArgumentException("Система счисления должна быть от 2 до 16");

            if (!IsValidForBase(number, fromBase))
                throw new FormatException(GetValidationError(number, fromBase));
        }
    }
}
