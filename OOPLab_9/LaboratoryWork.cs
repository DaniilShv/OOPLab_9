using MenuLib;
using UravnenieLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLab_9
{
    public class LaboratoryWork
    {
        UravnenieArray arr = new UravnenieArray();
        public void Execute()
        {
            Menu menu = new Menu();
            menu.AddMenu(AddPointMenu("Создать уравнение", ExecPointMenu1));
            menu.AddMenu(AddPointMenu("Показать решения уравнений", ExecPointMenu2, 1));
            menu.AddMenu(AddPointMenu("Преобразовать уравение к bool", ExecPointMenu3, 1));
            menu.AddMenu(AddPointMenu("Преобразовать уравение к double", ExecPointMenu4, 1));
            menu.AddMenu(AddPointMenu("Сравнить уравнения", ExecPointMenu5, 1));
            menu.AddMenu(AddPointMenu("Показать уравнения", ExecPointMenu6, 1));
            menu.Execute();
        }
        PointMenu AddPointMenu(string text, ExecutePointMenu func)
        {
            PointMenu p = new PointMenu();
            p.AddValue(text, func);
            return p;
        }
        PointMenu AddPointMenu(string text, ExecutePointMenu func, int dependence)
        {
            PointMenu p = new PointMenu();
            p.AddValue(text, func, dependence);
            return p;
        }
        Uravnenie CreateUravnenie()
        {
            Input_A_B_C(out double a, out double b, out double c);
            Uravnenie u = new Uravnenie(a,b,c);
            return u;
        }
        void Input_A_B_C(out double a, out double b, out double c)
        {
            while(!InputDouble(out a,"Введите коэфицент A: "));
            while(!InputDouble(out b, "Введите коэфицент B: "));
            while(!InputDouble(out c, "Введите коэфицент C: "));
        }
        bool InputDouble(out double a, string name)
        {
            Console.Write(name);
            if (double.TryParse(Console.ReadLine(), out a))
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(Введите число) ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
        }
        bool InputInt(out int a, string name)
        {
            Console.Write(name);
            if (int.TryParse(Console.ReadLine(), out a))
                return true;
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("(Введите целое число) ");
                Console.ForegroundColor = ConsoleColor.Gray;
                return false;
            }
        }
        void ShowRootsUravnenie(ref Uravnenie u)
        {
            foreach (var item in u.SolveEquation())
            {
                Console.WriteLine(item);
            }
        }
        void ExecPointMenu1()
        {
            Uravnenie u = CreateUravnenie();
            arr.Add(ref u);
        }
        void ExecPointMenu2()
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"Корни {i + 1} уравнения = [");
                for (int j = 0; j < arr[i].SolveEquation().Length; j++)
                {
                    if (j == 0)
                        Console.Write(arr[i].SolveEquation()[j] + "; ");
                    else
                        Console.Write(arr[i].SolveEquation()[j]);

                }
                Console.WriteLine("]");
                if (arr[i].SolveEquation()[0] == -10E20)
                    Console.WriteLine("Решение в комплексных числах");
            }
        }
        void ExecPointMenu3()
        {
            int number;
            while (!InputInt(out number, "Какое уравнение преобразовать к bool (номер): ")) ;
            try
            {
                Console.WriteLine($"Уравнение в типе bool: {(bool)arr[number - 1]}");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        void ExecPointMenu4()
        {
            int number;
            while (!InputInt(out number, "Какое уравнение преобразовать к double (номер): ")) ;
            try
            {
                double equation = arr[number - 1];
                Console.WriteLine($"Уравнение в типе bool: {equation}");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        void ExecPointMenu5()
        {
            if (arr.Length > 1)
            {
                int number, number2;
                while (!InputInt(out number, "Номер первого уравнения: ")) ;
                while (!InputInt(out number2, "Номер второго уравнения: ")) ;
                try
                {
                    Console.WriteLine(arr[number - 1] == arr[number2 - 1]);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
                Console.WriteLine("Создайте хотя бы два уравнения");
        }
        void ExecPointMenu6()
        {
            Console.WriteLine("ax^2 + bx + c = 0");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine($"Уравнение {i+1} {arr[i]}");
            }
        }
    }
}
