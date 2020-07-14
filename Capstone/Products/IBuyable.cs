using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public interface IBuyable
    {
        #region Properties
        string Name { get; }

        decimal Price { get; }

        int Quantity { get; set; }
        #endregion
        #region Method
        string MakeYum();
        #endregion
    }
}
