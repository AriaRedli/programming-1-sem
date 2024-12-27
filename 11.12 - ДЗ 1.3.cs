using System;

class Program
{
    static void Main()
    {
        double x;

        // Ввод числа x с проверкой на диапазон [-1, 1]
        while (true)
        {
            Console.WriteLine("Введите число x (-1 <= x <= 1):");
            string input = Console.ReadLine();

            if (double.TryParse(input, out x) && x >= -1 && x <= 1)
            {
                break; // Корректный ввод - выходим из цикла
            }
            else
            {
                Console.WriteLine("Ошибка: x должен быть в диапазоне от -1 до 1.");
            }
        }

        // Инициализация переменных для вычисления e^x
        double term = 1; // Первое слагаемое (1)
        double sum = term; // Сумма ряда, начинаем с первого слагаемого
        int n = 1; // Текущий факториал (n!) и степень (x^n)

        // Итеративный подсчет ряда до достижения точности 10^-6
        while (Math.Abs(term) >= 1e-6)
        {
            term *= x / n; // Вычисляем следующее слагаемое: term = term * (x / n)
            sum += term; // Добавляем его к сумме
            n++; // Увеличиваем степень и факториал
        }

        // Вывод результата
        Console.WriteLine($"Приближение для e^x: {sum}");

        // Ожидание ввода от пользователя перед завершением программы
        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine();
    }
}