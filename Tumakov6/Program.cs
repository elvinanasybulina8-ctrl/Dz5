using System.IO;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Tumakov6;

class Program
{
    static (int CountGlas, int CountSoglas)
CalculateLetters(string FilePath)
    {
        string result = File.ReadAllText(FilePath);

        char[] glasn = ['А', 'а', 'Е', 'е', 'Ё', 'ё', 'И', 'и', 'О', 'о', 'У', 'у', 'Ы', 'ы', 'Э', 'э', 'Ю', 'ю', 'Я', 'я'];
        char[] soglas = ['Б', 'б', 'В', 'в', 'Г', 'г', 'Д', 'д', 'Ж', 'ж', 'З', 'з', 'Й', 'й', 'К', 'к', 'Л', 'л', 'М', 'м', 'Н', 'н', 'П', 'п', 'Р', 'р', 'С', 'с', 'Т', 'т', 'Ф', 'ф', 'Х', 'х', 'Ц', 'ц', 'Ч', 'ч', 'Ш', 'ш', 'Щ', 'щ'];
        int countGlas = 0;
        int countSoglas = 0;
        foreach (char item in result)
        {
            char c = char.ToLowerInvariant(item);
            if (glasn.Contains(item))
            {
                countGlas++;
            }
            else if (soglas.Contains(item))
            {
                countSoglas++;
            }
            else
            {

            }
        }
        return (countGlas, countSoglas);
    }
    static void Task1()

    {
        string filePath = "..\\..\\..\\laba6.txt";
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"\"Ошибка: Файл не найден по пути: {filePath}");
            return;
            {
            }
        }
        Console.WriteLine("Упражнение 6.1");
        List<char> text = new List<char>(File.ReadAllText(filePath));

        var result = CalculateLetters(filePath);

        Console.WriteLine("Гласные :" + result.CountGlas);
        Console.WriteLine("Согласные :" + result.CountSoglas);
    }
    static void Task2()
    {
        Console.WriteLine("Упражнение 6.2");

        int str1 = Helper.ReadInt("Строк 1-й матрицы: ");
        int col1 = Helper.ReadInt("Столбцов 1-й матрицы: ");
        int str2 = Helper.ReadInt("Строк 2-й матрицы: ");
        int col2 = Helper.ReadInt("Столбцов 2-й матрицы: ");

        if (col1 != str2)
        {
            Console.WriteLine("Ошибка: столбцы 1-й должны равняться строкам 2-й");
            return;
        }

        int min = Helper.ReadInt("Минимум: ");
        int max = Helper.ReadInt("Максимум: ");

        int[,] a = new int[str1, col1];
        int[,] b = new int[str2, col2];

        Fill(a, min, max);
        Fill(b, min, max);

        Console.WriteLine("\nМатрица A:");
        Print(a);
        Console.WriteLine("\nМатрица B:");
        Print(b);
        Console.WriteLine("\nРезультат A * B:");
        Print(Mult(a, b));
    }

    // Заполнение случайными числами
    static void Fill(int[,] m, int min, int max)
    {
        Random r = new Random();
        for (int i = 0; i < m.GetLength(0); i++)
            for (int j = 0; j < m.GetLength(1); j++)
                m[i, j] = r.Next(min, max + 1);
    }

    // Печать матрицы
    static void Print(int[,] m)
    {
        for (int i = 0; i < m.GetLength(0); i++)
        {
            for (int j = 0; j < m.GetLength(1); j++)
                Console.Write($"{m[i, j],4}");
            Console.WriteLine();
        }
    }

    // Умножение матриц
    static int[,] Mult(int[,] a, int[,] b)
    {
        if (a.GetLength(1) != b.GetLength(0))
            throw new ArgumentException("Несовместимые размеры");

        int[,] result = new int[a.GetLength(0), b.GetLength(1)];

        for (int i = 0; i < a.GetLength(0); i++)
            for (int j = 0; j < b.GetLength(1); j++)
            {
                int sum = 0;
                for (int k = 0; k < a.GetLength(1); k++)
                    sum += a[i, k] * b[k, j];
                result[i, j] = sum;
            }
        return result;
    }

    static void Task3()

    {
        Console.WriteLine("Упражнение 6.3");

        int[,] temperature = new int[12, 30];
        Random rnd = new Random();

        for (int i = 0; i < 12; i++)
        {
            for (int j = 0; j < 30; j++)
            {
                temperature[i, j] = rnd.Next(-30, 31);
            }
        }

        double[] averages = AverageTemp(temperature);

        Console.WriteLine("Средняя температура по месяцам:");
        for (int i = 0; i < averages.Length; i++)
        {
            Console.WriteLine("Месяц " + (i + 1) + ": " + averages[i].ToString("F1"));
        }

        Array.Sort(averages);

        Console.WriteLine();
        Console.WriteLine("После сортировки:");
        for (int i = 0; i < averages.Length; i++)
        {
            Console.Write(averages[i].ToString("F1") + " ");
        }
        Console.WriteLine();
    }

    static double[] AverageTemp(int[,] matrix)
    {
        double[] result = new double[12];

        for (int i = 0; i < 12; i++)
        {
            int sum = 0;

            for (int j = 0; j < 30; j++)
            {
                sum += matrix[i, j];
            }

            result[i] = (double)sum / 30;
        }

        return result;
    }
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();

        Console.ReadKey();
    }
}