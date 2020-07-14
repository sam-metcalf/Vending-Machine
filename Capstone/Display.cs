using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Capstone
{
    class Display
    {
        #region Contructor
        //passes through contructed VendingMachine from launch of program to private VendingMAchine within class
        public Display(VendingMachine vm)
        {
            this.vm = vm;
            this.sales = new SalesReport(vm.InventoryList);
        }
        private SalesReport sales;
        private VendingMachine vm;
        #endregion
        #region Methods
        //runs greeting message
        public void Greeting()
        {
            Console.WriteLine("\t\t\t  Welcome to Umbrella Corp Vendo-Matic 800 \r\n");
            Console.WriteLine("\t This application allows you to make electronic purchases our delectable treats");
            Console.WriteLine("\t directly from our vending machine, all from the convenience of your home or business. \r\n\r\n");
        }
        //handles main menu options and tests input validity
        public void MainMenuOptions()
        {            
            bool selecting = true;
            while (selecting)
            {
                try
                {
                    Console.WriteLine("\t Please select from our menu of options. \r\n");
                    Console.WriteLine("\t Main Menu: \r\n\t (1) Display Vending Machine Items \r\n\t (2) Purchase \r\n\t (3) Exit\r\n\t");
                    Console.WriteLine("\t Please enter your selection: ");

                    int userMainMenuSelection = int.Parse(Console.ReadLine());
                    if (userMainMenuSelection == 1)
                    {
                        vm.DisplayVendingOptions(); //run display of items method
                    }
                    else if (userMainMenuSelection == 2)
                    {
                        PurchaseMenuOptions();
                    }
                    else if (userMainMenuSelection == 3)
                    {
                        //Console.WriteLine("Thank you for your business.);
                        selecting = false;//run exit method
                    }
                    else if (userMainMenuSelection == 4)
                    {
                        sales.VendingSalesReport();
                    }
                    else
                    {
                        Console.WriteLine("You're a bad person that deserves no cookies.");
                    }
                } 
                catch (Exception)
                    {
                    Console.Clear();
                    Console.WriteLine("\t Invalid entry, please enter either a 1, 2 or 3.\r\n\t");
                    }
            }
        }
        //handles puchase menu options and tests input validity
        public void PurchaseMenuOptions()
        {
            Console.Clear();
            bool purchasing = true;
            while (purchasing)
            {
                Console.WriteLine("\t Purchase Menu: \r\n\t (1) Add Money To Account \r\n\t (2) Select Product \r\n\t (3) Finish Transaction\r\n\t");
                Console.WriteLine($"\t Current Money Provided: ${vm.Balance}\r\n\t\r\n\t");
                Console.WriteLine("\t Please make your selection:");
                string purchaseInputResponse = Console.ReadLine();
                Console.Clear();

                Purchase pur = new Purchase(vm);
                if (purchaseInputResponse == "1") // adding funds
                {
                    Console.WriteLine("Please enter amount of $1, $2, $5 or $10.");
                    string fundsDeposited = Console.ReadLine();
                    pur.AddMoney(fundsDeposited, vm); //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                }
                else if (purchaseInputResponse == "2") // make the purchase
                {                    
                    pur.PurchaseProcess(vm);//to a list of items
                    Console.Clear();
                }
                else if (purchaseInputResponse == "3")//kick out
                {
                    Console.WriteLine(pur.MakeChange(vm));
                    purchasing = false;
                }
                
            }
        }
        #endregion
    }
}
