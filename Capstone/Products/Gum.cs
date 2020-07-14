using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : IBuyable
    {
        #region Properties
        public string Name { get; set; }

        public decimal Price { get; }

        public int Quantity { get; set; }
        #endregion

        #region Constructor
        public Gum(string name, decimal price)
        {
            Quantity = 5;
            Name = name;
            Price = price;
        }
        #endregion

        #region Method(s)
        public string MakeYum()
        {
            return "Chew Chew, Yum!";
        }
        #endregion
    }
}
