using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class SalesReport
    {
        #region Properties
        private Dictionary<string, IBuyable> saleItems;
        #endregion
        #region Contructor
        public SalesReport(Dictionary<string, IBuyable> valuePairs)
        {
            saleItems = valuePairs;
        }
        #endregion
        #region Method(s)
        public void VendingSalesReport()
        {
            decimal totalSales = 0;
            foreach (IBuyable item in saleItems.Values)
            {
                Console.WriteLine($"{item.Name} | {5 - item.Quantity}");
                totalSales += item.Price * (5 - item.Quantity);
            }
            Console.WriteLine($"TOTAL SALES: {totalSales.ToString("C2")}");
        }
        #endregion
    }
}
