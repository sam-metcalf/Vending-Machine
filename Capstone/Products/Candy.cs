using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Candy : IBuyable
    {
        #region Properties
        public string Name { get; set; }

        public decimal Price { get; }

        public int Quantity { get; set; }
        #endregion

        #region Constructor
        public Candy(string name, decimal price)
        {
            Quantity = 5;
            Name = name;
            Price = price;
        }
        #endregion

        #region Method(s)
        public string MakeYum()
        {
            return "Munch Munch, Yum!";
        }
        #endregion
    }
}
