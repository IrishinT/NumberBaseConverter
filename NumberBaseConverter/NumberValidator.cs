using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberBaseConverter
{
    internal static class NumberValidator
    {
        /// <summary>
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
    }
}