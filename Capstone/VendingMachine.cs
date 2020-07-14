using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Capstone
{
    public class VendingMachine
    {
        #region Properties
        public decimal Balance { get; set; }
        //InventoryList set by Getinventory method. Holds sloit identifier and each item as an object of name, price, inventory count.
        public Dictionary<string, IBuyable> InventoryList { get; set; } = new Dictionary<string, IBuyable>();
        #endregion
        #region Constructor
        public VendingMachine()
        {
            Balance = 0.00M;
        }
        #endregion
        #region Methods
        //Sets inventory from provided csv file
        public void GetInventory()
        {
            using (StreamReader sr = new StreamReader("C:\\Users\\Student\\workspace\\week-4-pair-exercises-c-team-6\\19_Capstone\\dotnet\\vendingmachine.csv"))
            {
                while (!sr.EndOfStream) //read to the end of the csv
                {
                    string lines = sr.ReadLine(); //reading lines of the csv
                    string[] temparray = lines.Split('|'); //splitting to an array

                    if (temparray.Contains("Chip"))
                    {
                        Chips chips = new Chips(temparray[1], decimal.Parse(temparray[2]));
                        InventoryList.Add(temparray[0], chips);

                    }
                    if (temparray.Contains("Drink"))
                    {
                        Drinks drinks = new Drinks(temparray[1], decimal.Parse(temparray[2]));
                        InventoryList.Add(temparray[0], drinks);

                    }
                    if (temparray.Contains("Candy"))
                    {
                        Candy candy = new Candy(temparray[1], decimal.Parse(temparray[2]));
                        InventoryList.Add(temparray[0], candy);

                    }
                    if (temparray.Contains("Gum"))
                    {
                        Gum gum = new Gum(temparray[1], decimal.Parse(temparray[2]));
                        InventoryList.Add(temparray[0], gum);

                    }

                    //adding the array to our list
                }
            }
        }
        //presents customer with VendingMachine inventory
        public void DisplayVendingOptions()
        {
            Console.Clear();
            foreach (KeyValuePair<string, IBuyable> item in InventoryList)
            {
                string quantity = "";
               
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
            Console.Write("\r\n");
        }
        #endregion
    }
}
