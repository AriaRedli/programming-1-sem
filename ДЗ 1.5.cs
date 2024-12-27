using System;

class Program
{
    static void Main(string[] args)
    {
        // Ввод основной строки s
        Console.Write("Введите строку s: "); //сообщение1
        string s = Console.ReadLine(); // считать строку и сохранить на s

        // Ввод основной строки s1
        Console.Write("Введите подстроку s1: "); // сообщение2
        string s1 = Console.ReadLine(); // считать строку и сохранить на s1

        // Подсчет подстроки s1 в строке s
        int occurrences = CountOccurrences(s, s1); //количество и сохр. результат в переменной occurrences.

        // Вывод на экран
        Console.WriteLine($"Количество вхождений '{s1}' в строке '{s}' равно: {occurrences}");

        // Ожидание ввода от пользователя перед выходом
        Console.WriteLine("Нажмите Enter для выхода...");
        Console.ReadLine(); // Ждем, пока пользователь нажмет Enter
    }

    // Подсчет вхождений s1 в строке s
    static int CountOccurrences(string s, string s1) //принимаем две строки s и s1.
    {
        if (string.IsNullOrEmpty(s1)) // Проверка на пустую подстроку
        {
            return 0; // Или другое значение по вашему усмотрению
        }

        int count = 0; // count - количество вхождений.
        int index = 0; // index для с чего начинать поиск.

        // Цикл, пока ищем подстроку s1 в строке s
        while ((index = s.IndexOf(s1, index, StringComparison.Ordinal)) != -1) // Ищем, есть ли s1 в s, начиная с позиции index.
        {
            count++; // Если нашли, увеличиваем count.
            index += s1.Length; // Переходим на позицию, следующую после найденного вхождения
        }

        return count; // Общее количество
    }
}