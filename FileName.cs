using System;
using System.Collections.Generic;

namespace FileName
{
    public class Math
    {
        public double Sum(double a, double b) => a + b; 
        public double Sub(double a, double b) => a - b;
        public double Mult(double a, double b) => a * b;

        public double Div(double a, double b)
        {
            if (b == 0) return 0;
            return a / b;
        }

        public double Sum(double[] numbers)
        {
            double result = 0;
            foreach (var n in numbers) result += n;
            return result;
        }

        public double Max(double[] numbers)
        {
            if (numbers.Length == 0) return 0;
            double max = numbers[0];
            foreach (var n in numbers) if (n > max) max = n;
            return max;
        }

        public double Min(double[] numbers)
        {
            if (numbers.Length == 0) return 0;
            double min = numbers[0];
            foreach (var n in numbers) if (n < min) min = n;
            return min;
        }

        public int Count(double[] numbers) => numbers.Length;

      
        public int Factorial(int n)
        {
            if (n < 0) return 0;
            int result = 1;
            for (int i = 1; i <= n; i++) result *= i;
            return result;
        }

        public double Percent(double num, double percent)
        {
            return num * (percent / 100.0);
        }
    }

    internal class GUIConsoleApp
    {
        public enum Command
        {
            Exit = 0, Sum = 1, Sub = 2, Mult = 3, Div = 4,
            Max = 5, Min = 6, Count = 8,
            Factorial = 9, Percent = 10
        }

        Math clsMath = new Math();

        static void Main(string[] args)
        {
            GUIConsoleApp gui = new GUIConsoleApp();
            gui.GetGUI();
        }

        internal void GetGUI()
        {
            while (true)
            {
                Console.WriteLine("\nМеню");
                Console.WriteLine("0 - Выход");
                Console.WriteLine("1 - Сумма ");
                Console.WriteLine("2 - Вычитание");
                Console.WriteLine("3 - Умножение");
                Console.WriteLine("4 - Деление");
                Console.WriteLine("5 - Максимум в массиве");
                Console.WriteLine("6 - Минимум в массиве");
                Console.WriteLine("8 - Количество элементов");
                Console.WriteLine("9 - Факториал");
                Console.WriteLine("10 - Процент от числа");
                Console.Write("Выберите команду: ");

                if (!int.TryParse(Console.ReadLine(), out int input))
                {
                    Console.WriteLine("Ошибка");
                    continue;
                }

                Command command = (Command)input;

                if (command == Command.Exit) return;

            
                if (command == Command.Max || command == Command.Min || command == Command.Count)
                {
                    double[] numbers = InputArray();

                    if (numbers.Length == 0)
                    {
                        Console.WriteLine("Вы не ввели ни одного числа!");
                        continue;
                    }

                    if (command == Command.Max) Console.WriteLine($"Максимум: {clsMath.Max(numbers)}");
                    else if (command == Command.Min) Console.WriteLine($"Минимум: {clsMath.Min(numbers)}");
                    else if (command == Command.Count) Console.WriteLine($"Количество: {clsMath.Count(numbers)}");
                }

                else if (command == Command.Sum || command == Command.Sub ||
                         command == Command.Mult || command == Command.Div || command == Command.Percent)
                {
                    Console.Write("Введите первое число: ");
                    if (!double.TryParse(Console.ReadLine(), out double a))
                    {
                        Console.WriteLine("Ошибка ввода!");
                        continue;
                    }

                    Console.Write("Введите второе число: ");
                    if (!double.TryParse(Console.ReadLine(), out double b))
                    {
                        Console.WriteLine("Ошибка ввода!");
                        continue;
                    }

                    if (command == Command.Sum)
                        Console.WriteLine($"Результат: {clsMath.Sum(a, b)}");
                    else if (command == Command.Sub)
                        Console.WriteLine($"Результат: {clsMath.Sub(a, b)}");
                    else if (command == Command.Mult)
                        Console.WriteLine($"Результат: {clsMath.Mult(a, b)}");
                    else if (command == Command.Div)
                        Console.WriteLine($"Результат: {clsMath.Div(a, b)}");
                    else if (command == Command.Percent)
                        Console.WriteLine($"Результат: {clsMath.Percent(a, b)}");
                }
    
                else if (command == Command.Factorial)
                {
                    Console.Write("Введите число: ");
                    if (int.TryParse(Console.ReadLine(), out int n))
                    {
                        Console.WriteLine($"Результат: {clsMath.Factorial(n)}");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка");
                    }
                }
                else
                {
                    Console.WriteLine("Неизвестная команда.");
                }
            }
        }

        private double[] InputArray()
        {
            List<double> numbers = new List<double>();
            Console.WriteLine("Вводите числа по одному. Чтобы закончить, нажмите Enter.");

            while (true)
            {
                Console.Write("Число: ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input)) break;

                if (double.TryParse(input, out double num))
                {
                    numbers.Add(num);
                }
                else
                {
                    Console.WriteLine("Попробуйте снова.");
                }
            }
            return numbers.ToArray();
        }
    }
}