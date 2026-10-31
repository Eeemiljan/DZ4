using System;

enum GrumpLevel
{
    Low,
    Medium,
    High
}

struct Grandpa
{
    public string Name;
    public GrumpLevel Level;
    public string[] Words;
    public int Bruises;

    public static int CountBruises(Grandpa grandpa, params string[] badWords)
    {
        int count = 0;

        foreach (string phrase in grandpa.Words)
        {
            foreach (string bad in badWords)
            {
                if (phrase.ToLower().Contains(bad))
                {
                    count++;
                }
            }
        }

        return count;
    }
}

class Program
{
    // Задача 2
    static int Calculate(ref int product, out double average, params int[] numbers)
    {
        int sum = 0;
        product = 1;
        average = 0;

        foreach (int number in numbers)
        {
            sum = sum + number;
            product = product * number;
        }

        if (numbers.Length > 0)
        {
            average = (double)sum / numbers.Length;
        }

        return sum;
    }

    static void Main()
    {
        Console.WriteLine("Проект PRJ. Домашнее задание 4.");
        Console.WriteLine("1 - Обмен чисел в массиве");
        Console.WriteLine("2 - Сумма, произведение и среднее");
        Console.WriteLine("3 - Рисование цифр");
        Console.WriteLine("4 - Ворчливые деды");

        Console.Write("Выберите задачу от 1 до 4: ");
        int task = int.Parse(Console.ReadLine());

        switch (task)
        {
            case 1:
            {
                Console.WriteLine("Задача 1. Обмен чисел в массиве.");

                Random random = new Random();
                int[] numbers = new int[20];

                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = random.Next(1, 31);
                }

                Console.WriteLine("Исходный массив:");

                foreach (int number in numbers)
                {
                    Console.Write(number + " ");
                }

                Console.WriteLine();

                Console.Write("Введите первое число из массива: ");
                int first = int.Parse(Console.ReadLine());

                Console.Write("Введите второе число из массива: ");
                int second = int.Parse(Console.ReadLine());

                int index1 = -1;
                int index2 = -1;

                for (int i = 0; i < numbers.Length; i++)
                {
                    if (numbers[i] == first && index1 == -1)
                    {
                        index1 = i;
                    }

                    if (numbers[i] == second && index2 == -1)
                    {
                        index2 = i;
                    }
                }

                if (index1 == -1 || index2 == -1)
                {
                    Console.WriteLine("Ошибка: число не найдено в массиве.");
                }
                else
                {
                    int temp = numbers[index1];
                    numbers[index1] = numbers[index2];
                    numbers[index2] = temp;

                    Console.WriteLine("Массив после обмена:");

                    foreach (int number in numbers)
                    {
                        Console.Write(number + " ");
                    }

                    Console.WriteLine();
                }

                break;
            }

            case 2:
            {
                Console.WriteLine("Задача 2. Вычисления с массивом.");

                int[] numbers = { 2, 3, 4, 5 };

                Console.WriteLine("Массив: 2 3 4 5");

                int product = 1;
                double average;

                int sum = Calculate(ref product, out average, numbers);

                Console.WriteLine($"Сумма: {sum}");
                Console.WriteLine($"Произведение: {product}");
                Console.WriteLine($"Среднее арифметическое: {average}");

                break;
            }

            case 3:
            {
                Console.WriteLine("Задача 3. Рисование цифр.");
                Console.WriteLine("Введите цифру от 0 до 9.");
                Console.WriteLine("Для выхода введите exit или закрыть.");

                while (true)
                {
                    Console.Write("Введите цифру: ");
                    string text = Console.ReadLine();

                    if (text == "exit" || text == "закрыть")
                    {
                        Console.WriteLine("Программа завершена.");
                        return;
                    }

                    int number = int.Parse(text);

                    if (number < 0 || number > 9)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Clear();

                        Console.WriteLine("Ошибка! Введите цифру от 0 до 9.");

                        System.Threading.Thread.Sleep(3000);

                        Console.ResetColor();
                        Console.Clear();

                        continue;
                    }

                    switch (number)
                    {
                        case 0:
                            Console.WriteLine(" ### \n#   #\n#   #\n#   #\n ### ");
                            break;

                        case 1:
                            Console.WriteLine("  #  \n ##  \n  #  \n  #  \n ### ");
                            break;

                        case 2:
                            Console.WriteLine(" ### \n#   #\n   # \n  #  \n#####");
                            break;

                        case 3:
                            Console.WriteLine("#### \n    #\n ### \n    #\n#### ");
                            break;

                        case 4:
                            Console.WriteLine("#   #\n#   #\n#####\n    #\n    #");
                            break;

                        case 5:
                            Console.WriteLine("#####\n#    \n#### \n    #\n#### ");
                            break;

                        case 6:
                            Console.WriteLine(" ### \n#    \n#### \n#   #\n ### ");
                            break;

                        case 7:
                            Console.WriteLine("#####\n   # \n  #  \n #   \n#    ");
                            break;

                        case 8:
                            Console.WriteLine(" ### \n#   #\n ### \n#   #\n ### ");
                            break;

                        case 9:
                            Console.WriteLine(" ### \n#   #\n ####\n    #\n ### ");
                            break;
                    }

                    Console.WriteLine();
                }
            }

            case 4:
            {
                Console.WriteLine("Задача 4. Ворчливые деды.");

                Grandpa[] grandpas = new Grandpa[5];

                grandpas[0].Name = "Петрович";
                grandpas[0].Level = GrumpLevel.Low;
                grandpas[0].Words = new string[]
                {
                    "Опять будильник!"
                };
                grandpas[0].Bruises = 0;

                grandpas[1].Name = "Иваныч";
                grandpas[1].Level = GrumpLevel.Medium;
                grandpas[1].Words = new string[]
                {
                    "Блядь, где тапки?",
                    "Где газета?"
                };
                grandpas[1].Bruises = 0;

                grandpas[2].Name = "Михалыч";
                grandpas[2].Level = GrumpLevel.High;
                grandpas[2].Words = new string[]
                {
                    "Сука, где пульт?",
                    "Чай остыл!",
                    "Блядь, опять дождь!"
                };
                grandpas[2].Bruises = 0;

                grandpas[3].Name = "Степаныч";
                grandpas[3].Level = GrumpLevel.Medium;
                grandpas[3].Words = new string[]
                {
                    "Соседи шумят!",
                    "Пиздец, цены!",
                    "Гады!",
                    "Сука, опять очередь!"
                };
                grandpas[3].Bruises = 0;

                grandpas[4].Name = "Кузьмич";
                grandpas[4].Level = GrumpLevel.High;
                grandpas[4].Words = new string[]
                {
                    "Блядь, нет интернета!",
                    "Сука, пробка!",
                    "Пиздец, снег!",
                    "Эх, молодёжь!",
                    "Где очки?"
                };
                grandpas[4].Bruises = 0;

                for (int i = 0; i < grandpas.Length; i++)
                {
                    grandpas[i].Bruises = Grandpa.CountBruises(
                        grandpas[i], "блядь", "сука", "пиздец"
                    );

                    Console.WriteLine();
                    Console.WriteLine($"Дед: {grandpas[i].Name}");
                    Console.WriteLine($"Уровень ворчливости: {grandpas[i].Level}");
                    Console.WriteLine("Фразы:");

                    foreach (string phrase in grandpas[i].Words)
                    {
                        Console.WriteLine(phrase);
                    }

                    Console.WriteLine($"Количество фингалов: {grandpas[i].Bruises}");
                }

                break;
            }

            default:
            {
                Console.WriteLine("Ошибка: такой задачи нет.");
                break;
            }
        }
    }
}
