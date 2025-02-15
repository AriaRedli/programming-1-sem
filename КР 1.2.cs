﻿//написать алгоритм быстрого возведения в степень (n^k)


using System;

class Program
{
    static void Main()
    {
        //ввод
        Console.Write("Введите основание:");
        int n = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите степень:");
        int k = Convert.ToInt32(Console.ReadLine());

        // Проверка, чтобы степень не была отрицательной
        if (k < 0)
        {
            Console.WriteLine("Степень должна быть неотрицательной.");
        }
        else
        {
            //результат с использованием функции быстрого возведения в степень
            long result = FastExponentiation(n, k);

            //результат
            Console.WriteLine($"{n}^{k} = {result}");
        }
    }

    static long FastExponentiation(int baseNum, int exponent)
    {
     
        long result = 1;
        long baseValue = baseNum;

        // пока exponent больше 0
        while (exponent > 0)
        {
            if (exponent % 2 == 1) // Если exponent нечетный
            {
                result *= baseValue; // результат на основание
            }
            baseValue *= baseValue; // основание в квадрат
            exponent /= 2; // степень на 2
        }

        return result; // результат
    }
}