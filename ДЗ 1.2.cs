﻿using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите целое число a (делимое):");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Введите целое число b (делитель):");
        int b = Convert.ToInt32(Console.ReadLine());

        if (b == 0)
        {
            Console.WriteLine("Ошибка: Деление на ноль.");
            return;
        }

        int n = 0;
        int N = Math.Abs(a);
        int K = Math.Abs(b);

        // Обработка деления с учетом знаков
        while (N >= K)
        {
            N -= K;
            n++;
        }

        // Устанавливаем знак результата
        if ((a < 0) ^ (b < 0))
        {
            n = -n; // Если только одно из чисел отрицательное, то результат отрицательный
        }

        Console.WriteLine($"Неполное частное от деления {a} на {b} равно: {n}");

        // Ожидание ввода от пользователя перед выходом
        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine(); // Ждем, пока пользователь нажмет Enter
    }
}