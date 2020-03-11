using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
 
namespace PO_LAB1
{
    public static class Calculator
    {
        
        public static void Do(string str, double a = 0, double b = 0)
        {
            try
            {
                char[] actions = new[] { '+', '-', '/', '*' };
                char z = str.First(c => actions.Any(r => r == c));
 
                try
                {
                    switch (z)
                    {
                        case '+':
                            Console.WriteLine(a + " + " + b + " = " + "{0}", a + b);
                            break;
                        case '-':
                            Console.WriteLine(a + " - " + b + " = " + "{0}", a - b);
                            break;
                        case '*':
                            Console.WriteLine(a + " * " + b + " = " + "{0}", a * b);
                            break;
                        case '/':
                            if (b != 0)
                            {
                                Console.WriteLine(a + " / " + b + " = " + "{0}", a / b);
                            }
                            else
                            {
                                Console.WriteLine("Делить на ноль нельзя!");
                            }
                            break;
                        default:
                            Console.WriteLine("Введите верный знак");
                            break;
                    }
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Делить на ноль нельзя");
 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Operation does not support.{0}{1}", Environment.NewLine, e.Message);
            }
 
 
 
 
        }
 
    }
    class Main
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("uk-UA");
            double a;
            double b;
 
            Console.WriteLine("Укажите дейсвия которое вы хотите сделать и нажмите Enter");
 
            string str = Console.ReadLine();
            if (str != null)
            {
                str = str.Replace(".", ",");
                string[] variables = str.Split('+', '-', '/', '*');
 
                try
                {
                    a = double.Parse(variables[0], NumberStyles.AllowDecimalPoint);
                    b = double.Parse(variables[1], NumberStyles.AllowDecimalPoint);
 
                    Calculator.Do(str, a, b);
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
 
            Console.ReadKey();
        }
    }
}