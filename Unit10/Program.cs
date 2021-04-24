using System;

namespace Unit10
{
    class Program
    {
        static ILogger logger { get; set; }
        static ICalculator calculator { get; set; }

        static void Main(string[] args)
        {
            bool OkEnter = false;
            decimal num1, num2;
            string Snum1, Snum2;
            bool oknum1, oknum2;
            CheckEnter chekent = new CheckEnter();
            logger = new Logger();
            var worker1 = new Worker1(logger);

            worker1.Work();

            calculator = new Calculator();
            
            do
            {
                Console.WriteLine("Введите первое число: ");
                Snum1 = Console.ReadLine();
                Console.WriteLine("Введите второе число: ");
                Snum2 = Console.ReadLine();
                oknum1 = chekent.CheckEnterNum(Snum1);
                oknum2 = chekent.CheckEnterNum(Snum2);
                if (oknum1 == true && oknum2 == true)
                { OkEnter = true; }
                else
                { OkEnter = false;
                    worker1.Error("Вы ввели не верные данные, повторим ввод:");
                }
                
            }
            while (OkEnter == false);

            num1 = decimal.Parse(Snum1);
            num2 = decimal.Parse(Snum2);

            calculator.SumNumber(num1, num2);

            
            worker1.Stop();
            
            Console.ReadKey();
        }

        public interface ICalculator
        {
            void SumNumber(decimal num1, decimal num2);
            void Error(string message);
        }

        public class Calculator : ICalculator
        {
            
            void ICalculator.Error(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            void ICalculator.SumNumber(decimal num1, decimal num2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Сумма двух чисел: {1} + {2}  = {0} ", num1 + num2, num1, num2);
                Console.ResetColor();
            }
        }

        public interface ILogger
        {
            void Event(string message);
            void Error(string message);
        }

        public class Logger : ILogger
        {
            public void Error(string message)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }

            public void Event(string message)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        public interface IWorker
        { 
            void Work();
            void Stop();

            void Error(string mes);


        }



    }
}
