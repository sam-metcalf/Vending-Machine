using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Purchase
    {
        #region Constructor
        //passes through contructed VendingMachine from launch of program to private VendingMAchine within class
        public Purchase(VendingMachine vm)
        {
            this.vm = vm;
            this.audit = new Audit();            
        }
        private VendingMachine vm;
        private Audit audit;        
        #endregion
        #region Methods
        //Updates customer balance
        public void AddMoney(string fundsDeposited, VendingMachine vm)
        {
            if (fundsDeposited == "1" || fundsDeposited == "2" || fundsDeposited == "5" || fundsDeposited == "10")
            {                
                vm.Balance += decimal.Parse(fundsDeposited);
                audit.AuditMoneyFed(fundsDeposited, vm.Balance);

            }
            else
            {
                Console.Clear();
                Console.WriteLine("\r\n\t\r\n\t Feed money into the machine with whole dollar amounts (e.g. $1, $2, $5, or $10).\r\n\t\r\n\t");
            }
        }
        //Handles purchase and updates item inventory and remaining balance of customer
        public void PurchaseProcess(VendingMachine vm)
        {
            bool makingSelection = true;
            while (makingSelection)
            {
                string quantity = "";

                foreach (KeyValuePair<string, IBuyable> item in vm.InventoryList)
                {                   
                    if (item.Value.Quantity == 0)
                    {
                        quantity = "SOLD OUT";
                    }
                    else
                    {
                        quantity = item.Value.Quantity.ToString();
                    }
                    Console.WriteLine($"\t\t{item.Key} {item.Value.Name} ${item.Value.Price} Qty. ({quantity})");                    
                }
                string customerSelection = Console.ReadLine();
                if (!vm.InventoryList.ContainsKey(customerSelection))
                {
                    Console.WriteLine("Product code does not exist");
                }
                else if (vm.InventoryList.ContainsKey(customerSelection) && quantity == "SOLD OUT")
                {
                    Console.WriteLine("Product is sold out. We apologize for the inconvenience.");                    
                }
                else if (vm.InventoryList.ContainsKey(customerSelection))
                {
                    IBuyable buyable = vm.InventoryList[customerSelection];
                    if (buyable.Price > vm.Balance)
                    {
                        Console.WriteLine("INSUFFICIENT FUNDS");
                        makingSelection = false;
                    }
                    else if (buyable.Price < vm.Balance)
                    {
                        buyable.Quantity--;
                        vm.Balance -= buyable.Price;
                        Console.WriteLine($"{buyable.Name} {buyable.Price} Balance: {vm.Balance}");
                        Console.WriteLine(buyable.MakeYum());
                        makingSelection = false;
                        audit.AuditPurchases(buyable.Name, customerSelection, vm.Balance);
                    }

                }
            }
        }
        //dispenses change to customer when leaving transaction in coins
        public string MakeChange(VendingMachine vm)
        {
            decimal nickel = .05m;
            decimal dime = .10m;
            decimal quarter = .25m;
            
            int nickelsReturned = 0;
            int dimesReturned = 0;
            int quartersReturned = 0;

            if (vm.Balance >= nickel)
            {
                decimal initialBalance = vm.Balance;

                quartersReturned = (int)(vm.Balance / quarter);

                vm.Balance = vm.Balance % quarter;

                dimesReturned = (int)(vm.Balance / dime);

                vm.Balance = vm.Balance % dime;

                nickelsReturned = (int)(vm.Balance / nickel);

                vm.Balance = vm.Balance % nickel;

                audit.AuditChangeMade(initialBalance, vm.Balance);
            }
            return $"Quarters: {quartersReturned}  Dimes: {dimesReturned}  Nickels: {nickelsReturned}";
            
        }
        #endregion
    }
}


