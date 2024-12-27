using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int firstNumber = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите второе число: ");
        int secondNumber = Convert.ToInt32(Console.ReadLine());

        // Перевод в двоичный код
        string binaryFirst = ConvertToBinary(firstNumber);
        string binarySecond = ConvertToBinary(secondNumber);

        Console.WriteLine($"Первое число в двоичном представлении: {binaryFirst}");
        Console.WriteLine($"Второе число в двоичном представлении: {binarySecond}");

        // Сложение
        int sum = firstNumber + secondNumber;

        // Сумма в двоичном представлении
        string binarySum = ConvertToBinary(sum);
        Console.WriteLine($"Сумма в двоичном коде: {binarySum}");

        // Обычная сумма
        Console.WriteLine($"Обычная сумма: {sum}");

        // Ожидание ввода от пользователя перед выходом
        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine(); // Ждем, пока пользователь нажмет Enter
    }

    // Преобразование числа в двоичный код
    static string ConvertToBinary(int number)
    {
        const int bits = 8;
        if (number < 0)
        {
            number = (1 << bits) + number;
        }
        return Convert.ToString(number, 2).PadLeft(bits, '0');
    }
}
