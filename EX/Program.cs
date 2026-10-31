using System;

class Program
{
    // Упражнение 5.1
    static int Max(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }

    // Упражнение 5.2
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Упражнение 5.3
    static bool Factorial(int number, out int result)
    {
        result = 1;

        if (number < 0)
        {
            return false;
        }

        try
        {
            checked
            {
                for (int i = 1; i <= number; i++)
                {
                    result = result * i;
                }
            }

            return true;
        }
        catch (OverflowException)
        {
            result = 0;
            return false;
        }
    }

    // Упражнение 5.4
    static int FactorialRec(int number)
    {
        if (number <= 1)
        {
            return 1;
        }

        return number * FactorialRec(number - 1);
    }

    static void Main()
    {
        Console.WriteLine("Упражнение 5.1. Максимум двух чисел.");

        int a = 10;
        int b = 20;

        Console.WriteLine($"Числа: {a} и {b}");
        Console.WriteLine($"Максимум: {Max(a, b)}");

        Console.WriteLine();

        Console.WriteLine("Упражнение 5.2. Обмен двух чисел.");

        a = 10;
        b = 20;

        Console.WriteLine($"До обмена: a = {a}, b = {b}");
        Swap(ref a, ref b);
        Console.WriteLine($"После обмена: a = {a}, b = {b}");

        Console.WriteLine();

        Console.WriteLine("Упражнение 5.3. Факториал и проверка переполнения.");

        int result;
        bool success = Factorial(5, out result);

        if (success)
        {
            Console.WriteLine($"5! = {result}");
        }
        else
        {
            Console.WriteLine("Ошибка вычисления факториала.");
        }

        success = Factorial(13, out result);

        if (success)
        {
            Console.WriteLine($"13! = {result}");
        }
        else
        {
            Console.WriteLine("13! не помещается в int.");
        }

        Console.WriteLine();

        Console.WriteLine("Упражнение 5.4. Рекурсивный факториал.");

        Console.WriteLine($"5! = {FactorialRec(5)}");
    }
}
