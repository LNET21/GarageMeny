using System;

namespace Exercise5
{
    public class ConsoleUI
    {
        ConsoleColor menuBG = ConsoleColor.Black;
        ConsoleColor menuBGcursor = ConsoleColor.Blue;
        ConsoleColor menuFG = ConsoleColor.Gray;
        ConsoleColor menuFGcursor = ConsoleColor.White;
        public void DisplayLog(EventLog log)
        {
            var logs = log.GetLogEntries();
            for(int i=logs.Length-1; i >= 0; i--)
            {
                Console.WriteLine(logs[i]);
            }
        }

        public void DisplayMenu(Menu menu, int cursor)
        {
            string wholeline = "****************************************";
            string newline = "*                                      *";
            Console.BackgroundColor = menuBG;
            Console.ForegroundColor = menuFG;
            Console.SetCursorPosition(0,0);
            Console.CursorVisible = false;
            Console.WriteLine(wholeline);
            Console.WriteLine(GetMenuHeader(menu.MenuName));
            Console.WriteLine(wholeline);
            Console.WriteLine(newline);
            for (int i=0; i < menu.Options.Count;i++)
            {
                Console.ForegroundColor = menuFG;
                Console.BackgroundColor = menuBG;
                Console.Write("*  ");
                Console.ForegroundColor = (i == cursor) ? menuFGcursor : menuFG ;
                Console.BackgroundColor = (i == cursor) ? menuBGcursor : menuBG ;
                var name = $" {menu.Options[i].OptionName.PadRight(32, ' ')} ";
                Console.Write(name);
                Console.ForegroundColor = menuFG;
                Console.BackgroundColor = menuBG;
                Console.WriteLine("  *");
            }
            Console.WriteLine(newline);
            Console.WriteLine(wholeline);
        }

        private string GetMenuHeader(string name)
        {
            int spaces = 38 - name.Length;
            string header = new String(' ', spaces / 2) + name;
            return $"*{header.PadRight(38)}*";
        }

        public void Clear()
        {
            Console.Clear();
        }

        public ConsoleKey GetKey()
        {
            return Console.ReadKey(true).Key; // intercept read
        }
    }
}
