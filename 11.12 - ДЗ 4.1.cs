using System;

class Program
{
    static bool IsPrime(int num)
    {
        if (num <= 1)
        {
            return false;
        }
        for (int i = 2; i * i <= num; i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }
        return true;
    }

    static void Main(string[] args)
    {
        Console.Write("Введите число: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Простые числа до " + n + ":");
        for (int i = 2; i < n; i++) // Используем int i = 2; i < n; i++
        {
            if (IsPrime(i))
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();

        // Ожидание ввода от пользователя перед выходом
        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine(); // Ждем, пока пользователь нажмет Enter
    }
}