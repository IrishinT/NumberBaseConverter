using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class NumberValidator
    {

        /// <summary>
        /// Проверяет корректность входных параметров для конвертации чисел.
        /// </summary>
        /// <param name="number">Проверяемое число.</param>
        /// <param name="fromBase">Исходное основание.</param>
        /// <param name="toBase">Целевое основание.</param>
        /// <exception cref="ArgumentException">Число пустое или основания вне диапазона 2-16.</exception>
        /// <exception cref="FormatException">Число содержит недопустимые для основания символы.</exception>
        public static void ValidateParameters(string number, int fromBase, int toBase)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Число не может быть пустым");

            if (fromBase < 2 || fromBase > 16 || toBase < 2 || toBase > 16)
                throw new ArgumentException("Система счисления должна быть от 2 до 16");

            // Используем NumberValidator для проверки числа
            if (!NumberValidator.IsValidForBase(number, fromBase))
                throw new FormatException(NumberValidator.GetValidationError(number, fromBase));
        }

        /// <summary>
        /// Проверяет, содержит ли строка только допустимые для данного основания символы.
        /// </summary>
        /// <param name="number">Проверяемое число.</param>
        /// <param name="numberBase">Основание системы счисления.</param>
        /// <returns>true, если число корректно; иначе false.</returns>
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
        /// Возвращает строку допустимых символов для указанного основания.
        /// </summary>
        /// <param name="numberBase">Основание системы счисления (2-16).</param>
        /// <returns>Строка допустимых цифр или пустую строку при некорректном основании.</returns>
        private static string GetAllowedDigits(int numberBase)
        {
            if (numberBase < 2 || numberBase > 16)
                return "";

            const string allDigits = "0123456789ABCDEF";
            return allDigits.Substring(0, numberBase);
        }


        /// <summary>
        /// Возвращает сообщение об ошибке валидации числа.
        /// </summary>
        /// <param name="number">Проверяемое число.</param>
        /// <param name="numberBase">Основание системы счисления.</param>
        /// <returns>Текстовое описание ошибки или сообщение об успехе.</returns>
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
        /// Возвращает название системы счисления по её основанию.
        /// </summary>
        /// <param name="numberBase">Основание системы.</param>
        /// <returns>Название системы (двоичная, восьмеричная, десятичная, шестнадцатеричная или n-ричная).</returns>
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