using System;

class Program
{
    static void Main()
    {
        const int rows = 5;
        const int columns = 8;
        int[,] matrix = GenerateMatrix(rows, columns);
        Console.WriteLine("Згенерована матриця:");
        PrintMatrix(matrix);
        (int lastNegRow, int lastNegCol, int lastNegValue) = FindLastNegativeElement(matrix);

        if (lastNegValue != int.MaxValue)
        {
            Console.WriteLine($"Останній негативний елемент: {lastNegValue}");
            Console.WriteLine($"Його позиція: рядок {lastNegRow + 1}, колонка {lastNegCol + 1}");
        }
        else
        {
            Console.WriteLine("У матриці немає негативних елементів.");
        }
        Console.ReadKey();
    }
    static int[,] GenerateMatrix(int rows, int columns)
    {
        Random random = new Random();
        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(-50, 51); 
            }
        }

        return matrix;
    }
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            Console.WriteLine();
        }
    }
    static (int, int, int) FindLastNegativeElement(int[,] matrix)
    {
        int lastNegRow = -1;
        int lastNegCol = -1;
        int lastNegValue = int.MaxValue;

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                if (matrix[i, j] < 0)
                {
                    lastNegRow = i;
                    lastNegCol = j;
                    lastNegValue = matrix[i, j];
                }
            }
        }

        return (lastNegRow, lastNegCol, lastNegValue);
    }
}
