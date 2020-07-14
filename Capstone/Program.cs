using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initializes Vending Machine
            VendingMachine vm = new VendingMachine();
            vm.GetInventory();
            #endregion

            #region Calls Main Display
            Display display = new Display(vm); 
            display.Greeting();
            display.MainMenuOptions();
            #endregion
        }
    }
}
