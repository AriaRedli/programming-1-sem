using System;

class Program
{
    static void Main(string[] args)
    {
        int N;

        // Запрашиваем у пользователя нечетное число
        while (true)
        {
            Console.Write("Введите нечетное число для размерности массива N x N: ");
            if (int.TryParse(Console.ReadLine(), out N) && N % 2 != 0)
            {
                break; // Если введено корректное нечетное число, выходим из цикла
            }
            Console.WriteLine("Ошибка: Введите корректное нечетное число.");
        }

        int[,] array = GenerateArray(N);
        PrintArray(array);

        Console.WriteLine("Элементы массива при обходе по спирали, начиная с центра:");
        Console.WriteLine(SpiralOrder(array));

        // Ожидание ввода от пользователя перед выходом
        Console.WriteLine("Нажмите Enter для выхода.");
        Console.ReadLine();
    }

    // Метод для генерации массива N x N
    static int[,] GenerateArray(int size)
    {
        int[,] array = new int[size, size];
        int value = 1;

        // Заполняем массив числами от 1 до N*N
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                array[i, j] = value++;
            }
        }

        return array;
    }

    // Метод для вывода массива в консоль
    static void PrintArray(int[,] array)
    {
        int size = array.GetLength(0);
        Console.WriteLine("Сгенерированный массив:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Метод для обхода массива по спирали, начиная с центра
    static string SpiralOrder(int[,] array)
    {
        int size = array.GetLength(0);
        string result = "";

        // Центральные координаты
        int centerX = size / 2;
        int centerY = size / 2;

        // Начинаем с центрального элемента
        result += array[centerX, centerY];

        // Переменные для управления обходом
        int[] directionsX = { 0, 1, 0, -1 }; // Направления по X (право, вниз, влево, вверх)
        int[] directionsY = { 1, 0, -1, 0 }; // Направления по Y (право, вниз, влево, вверх)

        int steps = 1; // Шаги для обхода
        int dir = 0; // Текущее направление
        int x = centerX, y = centerY; // Начальные координаты

        // Увеличиваем обход шагов
        while (steps < size)
        {
            // Обходим в текущем направлении
            for (int i = 0; i < steps; i++)
            {
                x += directionsX[dir];
                y += directionsY[dir];
                result += " " + array[x, y]; // Добавляем элемент в результат с пробелом
            }

            // Переходим к следующему направлению
            dir = (dir + 1) % 4;

            // Увеличиваем количество шагов (кратные направления)
            if (dir % 2 == 0) steps++;
        }

        // Обрабатываем последний набор шагов
        for (int i = 0; i < steps; i++)
        {
            x += directionsX[dir];
            y += directionsY[dir];
            if (x >= 0 && x < size && y >= 0 && y < size)
            {
                result += " " + array[x, y]; // Добавляем элемент в результат с пробелом
            }
        }

        return result.Trim(); // Удаляем лишние пробелы в начале и в конце строки
    }
}