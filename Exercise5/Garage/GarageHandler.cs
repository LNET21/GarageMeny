using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace Exercise5
{
    class GarageHandler
    {
        private Garage<Vehicle> garage;
        private Stack<Menu> menuStack;
        private EventLog log;
        private ConsoleUI ui;

        public GarageHandler()
        {
            garage = new Garage<Vehicle>(25);
            log = new EventLog(12);
            menuStack = new Stack<Menu>();
            ui = new ConsoleUI();
        }

        public void Run()
        {
            Initialize();

            while (true)
            {
                var menu = menuStack.Peek();
                var choice = menu.Run();
                choice.Action?.Invoke(); // if the user selected choice has an action...
                if (choice.SubMenu != null) // ...or has a menu
                {
                    menuStack.Push(choice.SubMenu);
                    ui.Clear();
                }
            }
        }

        private void Initialize()
        {
            var mainMenu = GetMenuTree();
            menuStack.Push(mainMenu);
        }

        private void ListAllVehicles()
        {
            Console.Clear();
            Console.WriteLine("Ja, det här är alla bilar!");
            Console.ReadKey();
        }

        private void Quit()
        {
            Console.Clear();
            Console.WriteLine("Press a key to quit!");
            Console.ReadKey();
            Environment.Exit(0);
        }

        private void GoBack()
        {
            menuStack.Pop();
            ui.Clear();
        }

        void ParkSomeVehicles()
        {
            var fordon1 = new Car("ABC123", "Red", 4, Enum.FuelType.gasoline, Enum.CarMake.Nissan);
            var fordon2 = new Bus("XYZ456", "Green", 4, Enum.FuelType.diesel, 38);
            var fordon3 = new Airplane("SE-ABCD", "Blue", 4, Enum.FuelType.jetA1, 4);
            var fordon4 = new Boat("M/S Lagunia", "Yellow", 4, Enum.FuelType.diesel, 12);
            var fordon5 = new Motorcycle("HOJ345", "Maroon", 4, Enum.FuelType.diesel, Enum.MotorcycleMake.Harley);

            garage.ParkVehicle(fordon1);
            garage.ParkVehicle(fordon2);
            garage.ParkVehicle(fordon3);
            garage.ParkVehicle(fordon4);
            garage.ParkVehicle(fordon5);
        }

        /// <summary>
        /// Gets the entire navigation tree
        /// </summary>
        /// <returns>Returns the tree in the form of a menu object</returns>
        private Menu GetMenuTree()
        {
            var quitOption = new MenuOption("Quit the application", new Action(Quit));
            var backOption = new MenuOption("Go back", new Action(GoBack));

            var parkingMenu = new Menu("Parking new vehicles", ui);
            parkingMenu.Add(new MenuOption("Park a car", new Action(ParkCar)));
            parkingMenu.Add(new MenuOption("Park a bus", new Action(ParkBus)));
            parkingMenu.Add(new MenuOption("Park an airplane", new Action(ParkAirplane)));
            parkingMenu.Add(new MenuOption("Park a motorcycle", new Action(ParkMotorcycle)));
            parkingMenu.Add(new MenuOption("Park a boat", new Action(ParkBoat)));
            parkingMenu.Add(new MenuOption("Auto create and park 5 vehicles", new Action(ParkSomeVehicles)));
            parkingMenu.Add(backOption);

            var vehicleSearchMenu = new Menu("Search vehicles", ui);
            vehicleSearchMenu.Add(new MenuOption("Search via registration number", new Action(RegNoSearch)));
            vehicleSearchMenu.Add(new MenuOption("Search via parameters", new Action(ParametricSearch)));
            vehicleSearchMenu.Add(backOption);

            var garageAdminMenu = new Menu("Building construction", ui);
            garageAdminMenu.Add(new MenuOption("Create new garage", new Action(CreateGarage)));
            garageAdminMenu.Add(backOption);

            var mainMenu = new Menu("Garage ver 0.1    Main menu", ui);
            mainMenu.Add(new MenuOption("Park vehicle", parkingMenu));
            mainMenu.Add(new MenuOption("Unpark vehicle", new Action(UnparkVehicle)));
            mainMenu.Add(new MenuOption("List all parked vehicles", new Action(ListAllVehicles)));
            mainMenu.Add(new MenuOption("Search for vehicle", vehicleSearchMenu));
            mainMenu.Add(new MenuOption("Building management", garageAdminMenu));
            mainMenu.Add(quitOption);

            return mainMenu;
        }

        private void ParametricSearch()
        {
        }

        private void RegNoSearch()
        {
        }

        private void CreateGarage()
        {
        }

        private void ParkBoat()
        {
        }

        private void ParkMotorcycle()
        {
        }

        private void ParkAirplane()
        {
        }

        private void ParkBus()
        {
        }

        private void ParkCar()
        {
        }

        private void SimpleSearch()
        {
        }

        private void UnparkVehicle()
        {
        }
    }
}
