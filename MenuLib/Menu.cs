using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuLib
{
    public delegate void ExecutePointMenu();
    public class Menu
    {
        List<PointMenu> pointsMenu = new List<PointMenu>();
        bool isWorking = true;
        int currentMenu = 0;
        public void Execute()
        {
            do
            {
                ShowMenu();
                HandlerEvent(ref isWorking);
            }
            while (isWorking);
        }
        public void HandlerEvent(ref bool flag)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            if (key.Key != ConsoleKey.F4)
            {
                Console.Clear();
                PressHandler(key.Key);
            }
            else
                flag = false;
        }
        public void PressHandler(ConsoleKey key)
        {
            if (key == ConsoleKey.W && currentMenu != 0)
                currentMenu--;
            if (key == ConsoleKey.S && currentMenu != pointsMenu.Count - 1)
                currentMenu++;
            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                ShowPointMenu(pointsMenu[currentMenu]);
            }
            if (key == ConsoleKey.F5)
            {
                Console.WriteLine("Переключаться вверх по меню - W\n" +
                    "Переключаться вниз по меню - S\n" +
                    "Выбрать пункт меню - Enter\n" +
                    "Перейти к меню - нажмите Enter");
                Console.ReadLine();
                Console.Clear();
            }
        }
        public void AddMenu(PointMenu pointMenu)
        {
            pointsMenu.Add(pointMenu);
        }
        public void ShowMenu()
        {
            for (int i = 0; i < pointsMenu.Count; i++)
            {
                if (i == currentMenu)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(pointsMenu[i].TextMenu + " <");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.WriteLine(pointsMenu[i].TextMenu);
            }
            Console.WriteLine("\nЧтобы выйти нажмите F4");
            Console.WriteLine("Помощь в управлении меню F5");
        }
        void ShowPointMenu(PointMenu p)
        {
            if (p.Dependence == 0)
            {
                p.Menu();
                p.IsPressed = true;
                Console.WriteLine("Нажмите Enter для переключения на меню");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                if (pointsMenu[p.Dependence - 1].IsPressed)
                {
                    p.Menu();
                    Console.WriteLine("Нажмите Enter для переключения на меню");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine($"Сначала выберете пункт \"{pointsMenu[p.Dependence - 1].TextMenu}\"");
                    Console.WriteLine("Перейти к меню - нажмите Enter");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
    public class PointMenu
    {
        public void AddValue(string textMenu, ExecutePointMenu valueMenu)
        {
            TextMenu = textMenu;
            Menu = valueMenu;
        }
        public void AddValue(string textMenu, ExecutePointMenu valueMenu, int dependence)
        {
            TextMenu = textMenu;
            Menu = valueMenu;
            IsPressed = false;
            Dependence = dependence;
        }
        public string TextMenu { get; private set; }
        public ExecutePointMenu Menu { get; private set; }
        public bool IsPressed { get; set; }
        public int Dependence { get; private set; }
    }
}
