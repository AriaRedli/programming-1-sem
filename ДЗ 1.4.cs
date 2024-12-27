using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод трёх целых чисел
        Console.Write("Введите a: ");
        int number1 = ConvertToInt32();

        Console.Write("Введите b: ");
        int number2 = ConvertToInt32();

        Console.Write("Введите c: ");
        int number3 = ConvertToInt32();

        // Переменная для нового числа
        int newNumber = 0;

        // Обработка каждого бита
        for (int bitPosition = 0; bitPosition < 32; bitPosition++)
        {
            // Подсчёт количества единиц и нулей 
            int count1 = (number1 >> bitPosition) & 1; // бит в первом числе
            int count2 = (number2 >> bitPosition) & 1; // бит во втором числе
            int count3 = (number3 >> bitPosition) & 1; // бит в третьем числе

            // Сложение 
            int onesCount = count1 + count2 + count3;

            // Если единиц больше или равно половине, ставим 1, иначе ставим 0
            if (onesCount >= 2) // Если 2 или 3 единицы, то записываем 1
            {
                newNumber |= (1 << bitPosition); // бит в новое число
            }
        }

        // Вывод
        Console.WriteLine($"Новое число: {newNumber}");

        // Ожидание ввода от пользователя перед выходом
        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine(); // Ждем, пока пользователь нажмет Enter
    }

    static int ConvertToInt32()
    {
        while (true)
        {
            try
            {
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка ввода. Пожалуйста, введите целое число.");
            }
        }
    }
}