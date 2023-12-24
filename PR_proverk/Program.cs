using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PR_17
{
    internal class Program
    {
        class Utensil // Класс "Посуда"
        {
            int y;
            double quantity1; // кол-во стаканов
            double quantity2; // кол-во бокалов
            public double Quantity1
            {
                // св-ва для доступа к закрытым полям
                get { return quantity1; } // возвращает значение св-ва
                set { quantity1 = value; } // устанавливает новое значение св-ва
            }
            public double Quantity2
            {
                // св-ва для доступа к закрытым полям
                get { return quantity2; } // возвращает значение св-ва
                set { quantity1 = value; } // устанавливает новое значение св-ва
            }
            double Calculate1() // расчет, если стаканов больше, чем бокалов
            {
                double calculation1 = quantity1 - quantity2;
                return calculation1;
            }
            double Calculate2() // расчет, если бокалов больше, чем стаканов
            {
                double calculation2 = quantity2 - quantity1;
                return calculation2;
            }
            double Calculate_sum() // расчет суммы
            {
                double calculation_sum = quantity2 + quantity1;
                return calculation_sum;
            }
            void GetInfo() // метод вывода данных (расчет*)
            {
                if (y == 1)
                {
                    if (quantity1 == quantity2) Console.WriteLine($"\nСравнение/разница: стаканов столько же, сколько и бокалов. (" + quantity1 + " шт.)\n");
                    else
                    {
                        if (quantity1 > quantity2) Console.WriteLine($"\nСравнение/разница: стаканов больше, чем бокалов, на {Calculate1()}" + " шт.\n");
                        else Console.WriteLine($"\nСравнение/разница: бокалов больше, чем стаканов, на {Calculate2()}" + " шт.");
                    }
                }
                else Console.WriteLine($"\nСумма: Если сложить кол-во бокалов и стаканов, общее кол-во посуды составляет {Calculate_sum()}" + " шт.\n");
            }
            internal void SetInfo() // метод ввода данных
            {
                Console.WriteLine("Введите данные о посуде:\n");
                Console.Write("Количество стаканов: ");
                quantity1 = Double.Parse(Console.ReadLine());
                Console.Write("Количество бокалов: ");
                quantity2 = Double.Parse(Console.ReadLine());
                Console.WriteLine("\nРабота с посудой:");
                Console.Write("\nНапишите 1, чтобы сравнить/найти разницу, или 2, чтобы сложить и найти общее кол-во посуды: ");
                y = Convert.ToInt32(Console.ReadLine()); // ввод с клавиатуры*
                GetInfo();
            }
            ~Utensil() // деструктор для проверки*
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nДеструктор сработал.");
                Console.ReadKey();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать. Практическая работа №17");
                Console.WriteLine("\nЗадача: создание класса 'посуда'\n");
                int interest = 0;
                for (; ; ) // проверка для завершения работы программы
                {
                    interest++;
                    Utensil obj = new Utensil(); // создания экземпляра класса*
                    obj.SetInfo(); // переход к методу вводу данных
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nНажмите ESCAPE, чтобы завершить работу, или ENTER, чтобы продолжить.\n");
                    ConsoleKeyInfo btn = Console.ReadKey();
                    if (btn.Key == ConsoleKey.Escape)
                        break;
                    Console.Clear(); // задержка экрана консоли
                }
            }
            catch (FormatException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nВозникла ошибка: " + e.Message); // вывод типа ошибки при наличии таковой
            }
        }
    }
}