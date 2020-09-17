using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Exercise5
{
    public class Menu
    {
        public string MenuName { get; set; }
        private ConsoleUI UI { get; set; }
        public List<MenuOption> Options { get; }

        private int currentIndex; // zero-based

        public Menu(string name, ConsoleUI ui)
        {
            MenuName = name;
            UI = ui;
            Options = new List<MenuOption>();
        }

        public void Add(MenuOption option)
        {
            Options.Add(option);
        }

        /// <summary>
        /// Runs the menu until user makes a choice
        /// </summary>
        /// <returns>Returns user's choice</returns>
        public MenuOption Run()
        {
            currentIndex = 0;
            MenuOption option = null;
            while(option == null)
            {
                UI.DisplayMenu(this, currentIndex);
                var key = UI.GetKey();
                switch(key)
                {
                    case ConsoleKey.UpArrow:
                        if(currentIndex > 0)
                        {
                            currentIndex--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (currentIndex < Options.Count-1)
                        {
                            currentIndex++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        option = Options[currentIndex];
                        break;
                }
            }
            return option;
        }
    }
}
