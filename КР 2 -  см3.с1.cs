using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите выражение в обратной польской записи (например, '2 1 + 3 *'):");
        string input = Console.ReadLine(); // Считываем строку от пользователя
        string[] tokens = input.Split(' '); // Разделяем строку на токены по пробелам

        // Убираем пустые токены из результирующего массива
        tokens = Array.FindAll(tokens, token => !string.IsNullOrEmpty(token));

        try
        {
            int result = EvaluateRPN(tokens); // Вычисляем результат
            Console.WriteLine("Результат: " + result);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        // Ожидаем ввода, чтобы окно не закрылось
        Console.WriteLine("Нажмите любую клавишу для завершения...");
        Console.ReadKey(); // Ожидание нажатия клавиши
    }

    static int EvaluateRPN(string[] tokens)
    {
        Stack<int> stack = new Stack<int>(); // Создаем стек для хранения чисел

        foreach (string token in tokens) // Перебираем все токены
        {
            // Если токен - число, добавляем его в стек
            if (int.TryParse(token, out int number))
            {
                stack.Push(number); // Добавляем число в стек
            }
            else // Если токен - оператор
            {
                // Проверка, достаточно ли элементов в стеке для операции
                if (stack.Count < 2)
                {
                    throw new InvalidOperationException("Недостаточно операндов в стеке для выполнения операции.");
                }

                // Извлекаем два верхних элемента стека
                int b = stack.Pop(); // Убираем верхний элемент (второй операнд)
                int a = stack.Pop(); // Убираем следующий элемент (первый операнд)

                int result;
                // Проверяем, какой оператор, и выполняем соответствующее действие
                switch (token)
                {
                    case "+":
                        result = a + b; // Сложение
                        break;
                    case "-":
                        result = a - b; // Вычитание
                        break;
                    case "*":
                        result = a * b; // Умножение
                        break;
                    case "/":
                        if (b == 0) throw new DivideByZeroException("Деление на ноль."); // Проверка на деление на ноль
                        result = a / b; // Деление
                        break;
                    default:
                        throw new InvalidOperationException($"Неверный оператор: {token}."); // Ошибка, если оператор неизвестен
                }

                stack.Push(result); // Добавляем результат обратно в стек
            }
        }

        // Проверяем, остался ли единственный элемент в стеке как результат
        if (stack.Count != 1)
        {
            throw new InvalidOperationException("Ошибка в выражении: конечный результат отсутствует.");
        }

        return stack.Pop(); // Возвращаем результат
    }
}
