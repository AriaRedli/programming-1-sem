using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main()
    {
        // Пользователь вводит выражение
        Console.WriteLine("Введите математическое выражение: ");
        string input = Console.ReadLine();

        try
        {
            // Преобразуем в обратную польскую запись
            string output = ConvertToReversePolishNotation(input);
            Console.WriteLine("Обратная польская запись: " + output);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        // Ожидаем ввода, чтобы окно не закрылось
        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey();
    }

    static string ConvertToReversePolishNotation(string expression)
    {
        // Список для выходной строки
        List<string> output = new List<string>();

        // Стек для операторов
        Stack<string> operators = new Stack<string>();

        // Словарь для приоритетов операторов
        Dictionary<string, int> precedence = new Dictionary<string, int>
        {
            { "+", 1 },
            { "-", 1 },
            { "*", 2 },
            { "/", 2 },
            { "^", 3 },
            { "exp", 4 },
            { "sin", 4 },
            { "cos", 4 },
            { "abs", 4 },
            { "ln", 4 },
            { "log", 4 }
        };

        // Разбиваем входное выражение на токены (операторы, числа, скобки)
        string[] tokens = Tokenize(expression);

        foreach (string token in tokens)
        {
            if (double.TryParse(token, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
            {
                // Если это число, добавляем его в выходную строку
                output.Add(token);
            }
            else if (precedence.ContainsKey(token))
            {
                // Если это оператор
                while (operators.Count > 0 && precedence.ContainsKey(operators.Peek()) &&
                       ((token != "^" && precedence[token] <= precedence[operators.Peek()]) ||
                        (token == "^" && precedence[token] < precedence[operators.Peek()])))
                {
                    // Перемещаем операторы из стека в выходную строку
                    output.Add(operators.Pop());
                }
                // Кладём текущий оператор в стек
                operators.Push(token);
            }
            else if (token == "(")
            {
                // Если это открывающая скобка, кладём её в стек
                operators.Push(token);
            }
            else if (token == ")")
            {
                // Если это закрывающая скобка
                while (operators.Count > 0 && operators.Peek() != "(")
                {
                    // Перемещаем всё из стека в выходную строку до открывающей скобки
                    output.Add(operators.Pop());
                }
                if (operators.Count == 0 || operators.Peek() != "(")
                {
                    throw new ArgumentException("Несоответствие скобок в выражении.");
                }
                // Убираем открывающую скобку из стека
                operators.Pop();
            }
            else
            {
                throw new ArgumentException($"Неизвестный токен: {token}");
            }
        }

        // Перемещаем оставшиеся операторы из стека в выходную строку
        while (operators.Count > 0)
        {
            string op = operators.Pop();
            if (op == "(" || op == ")")
            {
                throw new ArgumentException("Несоответствие скобок в выражении.");
            }
            output.Add(op);
        }

        // Возвращаем результат как строку
        return string.Join(" ", output);
    }

    static string[] Tokenize(string expression)
    {
        // Простая токенизация строки (учитываем пробелы, числа, функции и операторы)
        List<string> tokens = new List<string>();
        string token = "";
        foreach (char c in expression)
        {
            if (char.IsWhiteSpace(c))
            {
                continue; // Игнорируем пробелы
            }
            if (char.IsLetter(c))
            {
                token += c; // Составляем функцию (например, "sin", "exp")
            }
            else if (char.IsDigit(c) || c == '.' || c == ',')
            {
                token += c; // Составляем число
            }
            else
            {
                if (!string.IsNullOrEmpty(token))
                {
                    tokens.Add(token);
                    token = "";
                }
                if (c == '(' || c == ')')
                {
                    tokens.Add(c.ToString()); // Добавляем скобки
                }
                else
                {
                    tokens.Add(c.ToString()); // Добавляем операторы
                }
            }
        }
        if (!string.IsNullOrEmpty(token))
        {
            tokens.Add(token);
        }
        return tokens.ToArray();
    }
}