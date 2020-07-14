using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    class Chips : IBuyable
    {
        #region Properties
        public string Name { get; set; }

        public decimal Price { get; }

        public int Quantity { get; set; }
        #endregion
        #region Contructor
        public Chips(string name, decimal price)
        {
            Quantity = 5;
            Name = name;
            Price = price;
        }
        #endregion
        #region Method(s)
        public string MakeYum()
        {
            return "Crunch Crunch, Yum!";
        }
        #endregion
    }
}
