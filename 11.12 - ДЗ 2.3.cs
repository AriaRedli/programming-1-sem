using System;

class Program
{
    static void Main()
    {
        // Ввод радиуса окружности с клавиатуры
        int radius;
        while (true)
        {
            Console.WriteLine("Введите радиус окружности (положительное целое число):");
            string input = Console.ReadLine();

            if (int.TryParse(input, out radius) && radius > 0)
            {
                break; // Корректный ввод - выходим из цикла
            }
            else
            {
                Console.WriteLine("Ошибка: радиус должен быть положительным целым числом. Пожалуйста, попробуйте снова.");
            }
        }

        // Два вложенных цикла для создания сетки символов
        for (int y = -radius; y <= radius; y++)
        {
            for (int x = -radius; x <= radius; x++)
            {
                // Проверяем, принадлежит ли точка (x, y) окружности с данным радиусом
                if (Math.Abs(x * x + y * y - radius * radius) <= radius)
                {
                    Console.Write("*"); // Рисуем символ "*", если точка близка к окружности
                }
                else
                {
                    Console.Write(" "); // В противном случае рисуем пробел
                }
            }
            Console.WriteLine(); // Переходим на следующую строку
        }

        // Ожидание ввода от пользователя перед завершением программы
        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine();
    }
}