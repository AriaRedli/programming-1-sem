// в массиве целых чисел найти число, сумма которого была наибольшей. 
// Если таких чисел несколько, вывести на экран все эти числа. 
// массив [4,1,5,-1,8,4,6,7,6,3,3,9]

using System;
using System.Collections.Generic;

class Program
{
    private static void Main()
    {
        //массив целых чисел
        int[] numbers = { 4, 1, 5, -1, 8, 4, 6, 7, 6, 3, 3, 9 };

        // адаптация переменных для нахождения максимальной суммы
        int maxSum = int.MinValue; // Минимально возможное значение
        List<Tuple<int, int>> pairsWithMaxSum = new List<Tuple<int, int>>(); // Список пар чисел

        //Перебираем числа
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length; j++)
            {
                if (i != j) //не складывать число само с собой
                {
                    int sum = numbers[i] + numbers[j];

                    //Проверка, является ли эта сумма максимальной
                    if (sum > maxSum)
                    {
                        maxSum = sum; // Обновляем максимальную сумму
                        pairsWithMaxSum.Clear(); // Очищаем список, так как нашли новую максимальную сумму
                        pairsWithMaxSum.Add(Tuple.Create(numbers[i], numbers[j])); // Добавляем пару
                    }
                    else if (sum == maxSum)
                    {
                        pairsWithMaxSum.Add(Tuple.Create(numbers[i], numbers[j])); // Добавляем пару, если сумма равна максимальной
                    }
                }
            }
        }

        //результаты
        Console.WriteLine("Наибольшая сумма: {0}", maxSum);
        Console.WriteLine("Пары чисел, дающие эту сумму:");
        foreach (var pair in pairsWithMaxSum)
        {
            Console.WriteLine("{0} + {1}", pair.Item1, pair.Item2);
        }
    }
}