using System;
using System.Linq;
using System.Text;

namespace Exercise5
{
    public class ConsoleUI
    {
        ConsoleColor normalFG = ConsoleColor.Gray;
        ConsoleColor normalBG = ConsoleColor.Black;
        ConsoleColor menuBG = ConsoleColor.Black;
        ConsoleColor menuBGcursor = ConsoleColor.Blue;
        ConsoleColor menuFG = ConsoleColor.Green;
        ConsoleColor menuFGcursor = ConsoleColor.White;
        ConsoleColor listFG = ConsoleColor.Yellow;
        ConsoleColor listHeaderFG = ConsoleColor.Green;
        ConsoleColor listHeaderBG = ConsoleColor.DarkGreen;
        ConsoleColor inputHeaderFG = ConsoleColor.Yellow;
        ConsoleColor inputHeaderBG = ConsoleColor.DarkRed;
        ConsoleColor warningFG = ConsoleColor.Red;
        ConsoleColor successFG = ConsoleColor.Green;
        ConsoleColor logFG = ConsoleColor.Cyan;
        ConsoleColor logHeaderBG = ConsoleColor.DarkCyan;
        string menuDivider = "****************************************";
        string menuFeed    = "*                                      *";

        public ConsoleUI()
        {
        }

        public void Clear()
        {
            Console.Clear();
        }

        public void SetColor(ConsoleColor foreground, ConsoleColor background)
        {
            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

        public void SetColorNormal()
        {
            Console.ForegroundColor = normalFG;
            Console.BackgroundColor = normalBG;
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void Write(string text, ConsoleColor foreground)
        {
            Console.ForegroundColor = foreground;
            Console.Write(text);
            Console.ForegroundColor = normalFG;
        }

        public void WriteWarning(string text)
        {
            Write(text, warningFG);
        }

        public void WriteSuccess(string text)
        {
            Write(text, successFG);
        }

        public void DisplayLog(EventLog log)
        {
            var logs = log.GetLogEntries();
            if(logs.Length > 0)
            {
                SetColor(logFG, logHeaderBG);
                Console.WriteLine("Time     Description".PadRight(40));
                SetColor(logFG, normalBG);
                for (int i = logs.Length - 1; i >= 0; i--)
                {
                    Console.WriteLine(logs[i]);
                }
            }
            SetColorNormal();
        }

        public void DisplayMenu(Menu menu, int cursor)
        {
            SetColor(menuFG, menuBG);
            Console.SetCursorPosition(0,0);
            Console.CursorVisible = false;
            Console.WriteLine(menuDivider);
            Console.WriteLine(GetMenuHeader(menu.MenuName));
            Console.WriteLine(menuDivider);
            Console.WriteLine(menuFeed);
            for (int i=0; i < menu.Options.Count;i++)
            {
                SetColor(menuFG, menuBG);
                Console.Write("*  ");
                if (i == cursor)
                    SetColor(menuFGcursor, menuBGcursor);
                else
                    SetColor(menuFG, menuBG);
                var name = $" {menu.Options[i].OptionName.PadRight(32, ' ')} ";
                Console.Write(name);
                SetColor(menuFG, menuBG);
                Console.WriteLine("  *");
            }
            var feeds = 6 - menu.Options.Count;
            while(feeds>0)
            {
                Console.WriteLine(menuFeed);
                feeds--;
            }
            Console.WriteLine(menuFeed);
            Console.WriteLine(menuDivider);
            SetColorNormal();
        }

        private string GetMenuHeader(string name)
        {
            int spaces = 38 - name.Length;
            string header = new String(' ', spaces / 2) + name;
            return $"*{header.PadRight(38)}*";
        }

        public string GetTextFromUser(string message)
        {
            Console.CursorVisible = true;
            Console.Write(message);
            var input = Console.ReadLine();
            Console.CursorVisible = false;
            return input;
        }

        public int GetIntegerFromUser(string message)
        {
            bool success = false;
            int result = 0;
            while(success == false)
            {
                var input = GetTextFromUser(message);
                success = int.TryParse(input, out result);
                WriteWarning(success ? "" : "Skriv ett heltal!\n");
            }
            return result;
        }

        public void PromptForKey(string prefix = "")
        {
            Console.WriteLine("\nPress a key to return to menu!");
            Console.ReadKey();
        }

        public ConsoleKey GetKeyFromUser()
        {
            return Console.ReadKey(true).Key; // intercept read
        }

        public void DisplayInputHeader(string header)
        {
            SetColor(inputHeaderFG, inputHeaderBG);
            int pads = (40 - header.Length) / 2;
            string text = header.PadLeft(pads + header.Length, ' ');
            text = text.PadRight(40, ' ');
            Console.WriteLine(text);
            SetColorNormal();
        }

        public void DisplayGarage(Garage<Vehicle> garage)
        {
            var free = garage.Capacity - garage.Count;
            Console.ForegroundColor = normalFG;
            Console.Clear();
            DisplayVehicleList(garage);
            Console.WriteLine($"\nThis makes a total of {garage.Count} parked vehicles in the garage.");
            Console.WriteLine($"{(free==0 ? "No more" : $"Another {garage.Capacity - garage.Count}")} vehicles can be parked.\n");
            PromptForKey();
            Console.Clear();
        }

        public void DisplayVehicleList(Garage<Vehicle> vehicleList)
        {
            SetColor(listHeaderFG, listHeaderBG);
            Console.WriteLine(" Regnr       Type        Color       Wheels    Fueltype    Extra info        ");
            SetColorNormal();
            var sb = new StringBuilder();
            Console.ForegroundColor = listFG;
            foreach (var v in vehicleList)
            {
                sb.Append(" ");
                sb.Append(v.RegNo.PadRight(12, ' '));
                sb.Append(v.ToString().Split('.').Last().PadRight(12, ' '));
                sb.Append(v.Color.PadRight(12, ' '));
                sb.Append(v.NrOfWheels.ToString().PadRight(10, ' '));
                sb.Append(v.FuelType.PadRight(12, ' '));
                sb.Append(v.GetDescription().PadRight(12, ' '));
                Console.WriteLine(sb);
                sb.Clear();
            }
            Console.ForegroundColor = normalFG;
        }

        public void DisplayVehicleList(Garage<Vehicle> vehicleList, string typeName)
        {
            var list = new Garage<Vehicle>(vehicleList.Count);
            foreach (var v in vehicleList)
            {
                if (v.GetType().Name == typeName)
                {
                    list.ParkVehicle(v);
                }
            }

            Clear();
            DisplayVehicleList(list);
            if (list.Count > 0)
            {
                Write($"\nA total number of {list.Count} vehicles of the type {typeName}.");
            }
            else
            {
                WriteWarning($"\nThere are no vehicles of the type {typeName} in the garage.");
            }
            PromptForKey();
            Console.Clear();
        }
    }
}
