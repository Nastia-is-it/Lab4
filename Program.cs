using System;
using System.Collections.Generic;
using System.Numerics;
using Lab4;
internal class Program
{
    private static void Main(string[] args)
    {
        string input;
        int n;
        Console.WriteLine("Выберете номер задания: ");
        Console.WriteLine("1. Удалить число из списка");
        Console.WriteLine("2. Переставить элементы в обратном порядке между вхождениями элемента");
        Console.WriteLine("3. Какие фильмы посмотрели все, некоторые или никто");
        Console.WriteLine("4. Напечатать в алфавитном порядке все звонкие и согласные буквы, которые входят более чем в одно слово");
        Console.WriteLine("5. Сколько в среднем сотрудников работает в одном подразделении данного учреждения");
        Console.WriteLine("6. Вхождение элемента в отрезок. Перегрузка операций");
        InputChecks inputCheck = new InputChecks();
        int a;
        string inputA;
        while (true)
        {
            Console.Write("Ваш выбор: ");
            inputA = Console.ReadLine();
            if (!inputCheck.ToNumbers(inputA))
            {
                Console.WriteLine("Некорректный ввод. Введите число от 1 до 6:");
                continue;
            }
            a = Convert.ToInt32(inputA);
            if ((a < 1) || (a > 6))
            {
                Console.WriteLine("Нет такого варианта выбора. Введите число от 1 до 5:");
                continue;
            }
            break;
        }
        switch (a)
        {
            case 1:
                List<int> list1 = new List<int>() { 1, 2, 3, 4, 2, 3, 4 };
                Console.WriteLine("Дан список: ");
                foreach (int i in list1)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                do
                {
                    Console.Write("Какое число удалить: ");
                    input = Console.ReadLine();
                    if (!inputCheck.ToNumbers(input))
                    {
                        Console.WriteLine("Ошибка! Введите целое число.");
                    }
                } while (!inputCheck.ToNumbers(input));
                n = Convert.ToInt32(input);
                ListClass.RemoveValue(list1, n);
                Console.WriteLine("Результат: ");
                foreach (int i in list1)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                break;
            case 2:
                List<int> list2 = new List<int>() { 1, 2, 3, 4, 2, 3, 4 };
                Console.WriteLine("Дан список: ");
                foreach (int i in list2)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                Console.Write("Переставить в обратном порядке между вхождениями элемента: ");
                do
                {
                    Console.Write("Переставить в обратном порядке между вхождениями элемента: ");
                    input = Console.ReadLine();
                    if (!inputCheck.ToNumbers(input))
                    {
                        Console.WriteLine("Ошибка! Введите целое число.");
                    }
                } while (!inputCheck.ToNumbers(input));

                n = Convert.ToInt32(input);
                ListClass.ReverseValue(list2, n);
                Console.WriteLine("Результат: ");
                foreach (int i in list2)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
                break;
            case 3:
                var films = new HashSet<string> { "Фильм1", "Фильм2", "Фильм3", "Фильм4", "Фильм5" };
                var viewers = new List<HashSet<string>>
                {
                    new HashSet<string> { "Фильм3", "Фильм4", "Фильм2" },
                    new HashSet<string> { "Фильм1", "Фильм2", "Фильм3" },
                    new HashSet<string> { "Фильм1", "Фильм2", "Фильм4"},
                    new HashSet<string> { "Фильм4", "Фильм2" }
                 };
                Console.WriteLine("Дан перечень фильмов:");
                Console.WriteLine(string.Join(", ", films));
                Console.WriteLine("И перечень просмотров у каждого зрителя: ");
                for (int i = 0; i < viewers.Count; i++)
                {
                    Console.WriteLine(string.Join(", ", viewers[i]));
                }
                var result = ListClass.ViewersFilms(films, viewers);
                Console.WriteLine("Информация о фильмах: ");
                Console.WriteLine("Фильмы, которые посмотрели все зрители: " + (string.Join(", ", result.all)));
                Console.WriteLine("Фильмы, которые посмотрел кто-то из зрителей: " + (string.Join(", ", result.some)));
                Console.WriteLine("Фильмы, которые никто не посмотрел: " + (string.Join(", ", result.none)));
                break;
            case 4:
                Console.WriteLine("Согласные, которые встречаются в более чем 1 слове: ");
                var consonants = ListClass.consonantsInText();
                Console.WriteLine(string.Join(", ", consonants));
                break;
            case 5:
                Console.WriteLine("В среднем в одном подразделении работают " + ListClass.companyEmployees());
                break;
            case 6:
                Console.WriteLine("Попадает ли заданное число в отрезок");
                int x;
                do
                {
                    Console.Write("Координата для x: ");
                    input = Console.ReadLine();
                    if (!inputCheck.ToNumbers(input))
                    {
                        Console.WriteLine("Ошибка! Введите целое число.");
                    }
                } while (!inputCheck.ToNumbers(input));
                x = Convert.ToInt32(input);

                int y;
                do
                {
                    Console.Write("Координата для y: ");
                    input = Console.ReadLine();
                    if (!inputCheck.ToNumbers(input))
                    {
                        Console.WriteLine("Ошибка! Введите целое число.");
                    }
                } while (!inputCheck.ToNumbers(input));
                y = Convert.ToInt32(input);

                do
                {
                    Console.Write("Число, принадлежащее отрезку: ");
                    input = Console.ReadLine();
                    if (!inputCheck.ToNumbers(input))
                    {
                        Console.WriteLine("Ошибка! Введите целое число.");
                    }
                } while (!inputCheck.ToNumbers(input));
                n = Convert.ToInt32(input);
                LineSegment lineSegment = new LineSegment(x, y);
                if (lineSegment.InTheSegment(n))
                {
                    Console.WriteLine("Число " + n + " попадает в отрезок от " + x + " до " + y);
                }
                else
                {
                    Console.WriteLine("Число " + n + " не принадлежит отрезку");
                }
                Console.WriteLine("Унарные операции: ");

                double length = !lineSegment;
                Console.WriteLine("Длина отрезка " + lineSegment + ": " + length);

                lineSegment++;
                Console.WriteLine("После увеличения границ на 1: " + lineSegment);

                Console.WriteLine("Операции приведения типа: ");

                int intStart = (int)lineSegment;
                Console.WriteLine("Целая часть координаты начала: " + intStart);
                
                double doubleEnd = lineSegment;
                Console.WriteLine("Координата конца: " + doubleEnd);

                Console.WriteLine("Бинарные операции: ");

                LineSegment rightOp = lineSegment + 4;
                Console.WriteLine("lineSegment + 4 = " + rightOp);

                LineSegment leftOp = 7 + lineSegment;
                Console.WriteLine("7 + lineSegment = " + leftOp);

                int number = 4;
                bool InSegment = lineSegment < number;
                Console.WriteLine($"Число {number} в отрезке {lineSegment}: {InSegment}");

                bool notInSegment = lineSegment > number;
                Console.WriteLine($"Число {number} НЕ в отрезке {lineSegment}: {notInSegment}");

                break;
        }

    }
        
}
