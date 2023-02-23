using System.Drawing;

Start();

void Start()
{
    while (true)
    {


        System.Console.WriteLine("\n47) Задача 47. Задайте двумерный массив размером mxn, заполненный случайными вещественными числами.");
        System.Console.WriteLine("\n50) Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,\r\n и возвращает значение этого элемента или же указание, что такого элемента нет.");
        System.Console.WriteLine("\n52) Задача 52. Задайте двумерный массив из целых чисел.\r\n Найдите среднее арифметическое элементов в каждом столбце.");
        System.Console.WriteLine("\n62) Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");

        System.Console.WriteLine("\n0) End");

        int numTask = EnterNumber("\ntask");

        switch (numTask)
        {
            case 0: return; break;



            case 47:
                Console.Clear();

                int Rows = EnterNumber("Enter row size: ");
                int Colums = EnterNumber("Enter colums size: ");

                int minValue = EnterNumber("\nEnter MinValue for array");
                int maxValue = EnterNumber("Enter MaxValue for array");


                var matrix = GetDoubleMatrix(Rows, Colums, minValue, maxValue);

                PrintDoubleMatrix(matrix);
                Console.WriteLine();
                break;

            case 50:
                Console.Clear();

                Rows = EnterNumber("Enter row size: ");
                Colums = EnterNumber("Enter colums size: ");

                minValue = EnterNumber("\nEnter MinValue for array");
                maxValue = EnterNumber("Enter MaxValue for array");

                var DoubleArray = GetMatrix(Rows, Colums, minValue, maxValue);

                CheckPosition(DoubleArray);
                Console.WriteLine();
                PrintMatrix(DoubleArray);
                System.Console.WriteLine();

                break;


            case 52:
                Console.Clear();

                Rows = EnterNumber("Enter row size: ");
                Colums = EnterNumber("Enter colums size: ");

                minValue = EnterNumber("\nEnter MinValue for array");
                maxValue = EnterNumber("Enter MaxValue for array");

                DoubleArray = GetMatrix(Rows, Colums, minValue, maxValue);

                PrintMatrix(DoubleArray);
                Console.WriteLine();

                MidSumInEachColumn(DoubleArray);
                System.Console.WriteLine();

                break;


            case 62:
                Console.Clear();

                int side = EnterNumber("Please Enter side of squer matrix");
                int[,] matrix62 = new int[side, side];
                SpiralMethod(matrix62);
                PrintMatrix(matrix62);

                break;


        }
    }
}


int EnterNumber(string number) // функция для ввода целочисленного значения пользователем
{
    Console.Write($"{number}: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}


int[] CreateArray(int size, int minValue, int maxValue) // функция по заполнению массива целочисленными значениями
{
    int[] res = new int[size];

    for (int i = 0; i < size; i++)
    {
        res[i] = new Random().Next(minValue, maxValue + 1);
    }
    return res;
}

void crossPoint(double b1, double k1, double b2, double k2) // функция по определению точки пересечения
{
    double x = (b2 - b1) / (k1 - k2);
    double y = k1 * x + b1;

    if (k1 == k2)
    {
        Console.WriteLine($"\nCurent lines dosen't cross.");
        return;
    }

    Console.WriteLine($"\nPoint of cross is ({x};{y})\n");
}

int Fibonachi(int n) // функция по посторению ряда чисел фибоначи
{
    if (n == 1 || n == 2) return 1;
    else return Fibonachi(n - 1) + Fibonachi(n - 2);
}

double EnterDoubleNumber(string number) // функция для ввода вещественного значения пользователем
{
    Console.Write($"Enter {number}: ");
    double num = Convert.ToInt32(Console.ReadLine());
    return num;
}

int[,] GetMatrix(int rows, int columns, int min, int max)
{
    int[,] matrix = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = new Random().Next(min, max + 1);
        }
    }
    return matrix;
}


double[,] GetDoubleMatrix(int rows, int columns, int minValue, int maxValue)
{
    double[,] matrix = new double[rows, columns];

    Random rdn = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = Math.Round(rdn.Next(minValue, maxValue + 1) + rdn.NextDouble(), 2);
        }
    }
    return matrix;
}


void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + " ");
        }
        System.Console.WriteLine();
    }
}


void PrintDoubleMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i, j] + " ");
        }
        System.Console.WriteLine();
    }
}

void CheckPosition(int[,] matrix) // проверяет по координатам есть такое значение в матрице или нет.
{

    int X = EnterNumber("Enter row index");
    int Y = EnterNumber("Enter column index");

    if (X >= matrix.GetLength(0) || Y >= matrix.GetLength(1))
    {
        System.Console.WriteLine("\nYou out of matrix");
    }
    else

    {
        System.Console.WriteLine($"\nOn position {X}.{Y} stay number {matrix[X, Y]}");
    }
}


void MidSumInEachColumn(int[,] matrix)  // метод для подсчета среднего арифмитического в каждой колонке
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    for (int j = 0; j < columns; j++)
    {
        double sum = 0;
        for (int i = 0; i < rows; i++)
        {
            sum += matrix[i, j];
        }
        System.Console.WriteLine($"\nMiddle sum of column {j} = {sum / rows}");
    }
}

int[,] SpiralMethod(int[,] matrix)  //  заполнение матрицы спиральным методом
{
    int sum = 1;
    int side = matrix.GetLength(0);
    int i = 0;
    int j = 0;
    // int step = 0;

    while (sum <= side * side)
    {
        matrix[i, j] = sum++;

        if (i <= j + 1 && i + j < side - 1)
            j++;
        else if (i < j && i + j >= side - 1)
            i++;
        else if (i >= j && i + j > side - 1)
            j--;
        else
            i--;

        // step++; - проверка движения по матрице
        // System.Console.WriteLine($"\r\n{step}. i = {i} j = {j} sum = {sum}");
        // System.Console.WriteLine();
    }
    return matrix;
}