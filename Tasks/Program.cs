using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Logging.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using ClassLibrary;

namespace Tasks
{
    internal class Program
    {
        private static object config;

        static void Main(string[] args)
        {
            // Создание ServiceProvider и настройка логирования
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder =>
                {
                    builder.AddConsole();
                    builder.SetMinimumLevel(LogLevel.Information);
                }
                )
                .BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();

            // Логируем начало работы программы
            logger.LogInformation("Программа запущена.");

            //1 Задание
            int[] oddNumbers = { 5, 7, 9, 11, 13, 15, 17, 19 };


            //2 задание
            double[] randomValues = new double[13];
            Random rand = new Random();

            for (int i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = rand.NextDouble() * (15.0 + 12.0) - 12.0;
                randomValues[i] = Math.Round(randomValues[i], 4);                       //сократим значение так, чтобы было 4 знака поосле ,
            }


            //Ззадание 3
            double[,] k = new double[8, 13];

            for (int i = 0; i < k.GetLength(0); i++)
            {
                for (int j = 0; j < k.GetLength(1); j++)
                {
                    double x = randomValues[j];
                    if (oddNumbers[i] == 9)
                    {
                        k[i, j] = Math.Sin(Math.Sin(Math.Pow(x / (x + (1 / 2)), x)));
                    }

                    else if (oddNumbers[i] == 9 || oddNumbers[i] == 7 || oddNumbers[i] == 11 || oddNumbers[i] == 15)
                    {
                        k[i, j] = Math.Pow((0.5 / Math.Tan(2 * x) + 2 / 3), Math.Pow(x, 1 / 3));
                    }

                    else
                    {
                        k[i, j] = Math.Pow(Math.Tan(Math.Pow(Math.Exp((1 - x) / Math.PI) / (3 * 4), 3)), 3);
                    }
                }
            }


            //проверка работоспсобности 
            for (int i = 0; i < k.GetLength(0); i++)
            {
                for (int j = 0; j < k.GetLength(1); j++)
                {
                    Console.Write($"{k[i, j]:F4}"); //4 знака после запятой
                }
                Console.WriteLine();
            }

            //Задание 4

            //создаем json файл и добавляем в него данные
            var fileName = "MLstartConfig.json";
            var Znach = @"{""N"": ""Юлия"",
                            ""L"": ""Филатова""}";

            //принимаем данные из файла
            File.WriteAllText(fileName, Znach);
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(fileName).Build();

            //перемнные для имя и фамилии
            string N = configuration["N"];
            string L = configuration["L"];

            //считаем количество букв в имени и фамилии
            int NCount = N.Replace(" ", "").Length;
            int LCount = L.Replace(" ", "").Length;

            //Результат
            Console.WriteLine($"Количество букв в имени {N}: {NCount}");
            Console.WriteLine($"Количество букв в фамилии {L}: {LCount}");

            //Задание 5
            int n = NCount; // буквы в имени
            int l = LCount; // буквы в фамилии

            // Индексы
            int iValue = n % 8; // i = (N % 8)
            int jValue = l % 13; // j = (L % 13)

            // минимальный элемент k[i] 
            double minElement = double.MaxValue;
            for (int j = 0; j < k.GetLength(1); j++)
            {
                if (k[iValue, j] < minElement)
                {
                    minElement = k[iValue, j];
                }
            }

            // среднее значение k[j]
            double sum = 0;
            for (int i = 0; i < k.GetLength(0); i++)
            {
                sum += k[i, jValue];
            }
            double average = sum / k.GetLength(0);

            //Сумма значений
            double result = minElement + average;

            // Рзультат
            Console.WriteLine($"Результат: {result:F4}");
            logger.LogInformation("Программа завершила свою работу.");


            //----------------------------------------------- ДЗ №2


            var figure = new List<Kingdom>    //создание переменных для общего класса
            {
                new Circle(result),
                new Triangle(),
                new Square(),
                new Rectangle()
            };

            //создаем json файл и добавляем в него данные
            var fileName2 = "Delay.json";
            var Znach2 = @"{""Settings"": 1000}";

            //принимаем данные из файла
            File.WriteAllText(fileName2, Znach2);
            IConfiguration configuration2 = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(fileName2).Build();

            int delay = configuration2.GetValue<int>("Settings");

            while (true)
            {
                foreach (var kingdom in figure)
                {
                    try
                    {
                        kingdom.Task();
                        Thread.Sleep(delay);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Произошла ошибка при выполнении задачи фигуры {kingdom.Name}: {ex.Message}");
                    }
                }
                Console.WriteLine("Цикл завершен\n");
            }





        }
    }
}
