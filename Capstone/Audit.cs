using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    class Audit
    {
        #region Method(s)
        //keeps track of money fed and updated balance
        public void AuditMoneyFed(string fundsDeposited, decimal totalBalance)
        {
            string path = Environment.CurrentDirectory;
            string fileName = "Log.txt";
            string fullPath = Path.Combine(path, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {

                sw.WriteLine($"{DateTime.Now} FEED MONEY: ${fundsDeposited}.00 {totalBalance.ToString("C2")}");
            }
        }

        //tracks item purchsed, slot ID and updated balance
        public void AuditPurchases(string productName, string slot, decimal totalBalance)
        {
            string path = Environment.CurrentDirectory;
            string fileName = "Log.txt";
            string fullPath = Path.Combine(path, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {

                sw.WriteLine($"{DateTime.Now} {productName} {slot} {totalBalance.ToString("C2")}");
            }
        }

        //tracks balance before change dispensed and if appropriate change was dispensed
        public void AuditChangeMade(decimal initialBalance, decimal finalBalance)
        {
            string path = Environment.CurrentDirectory;
            string fileName = "Log.txt";
            string fullPath = Path.Combine(path, fileName);

            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine($"{DateTime.Now} GIVE CHANGE: {initialBalance.ToString("C2")} {finalBalance.ToString("C2")}");
            }
        }
        #endregion     

    }
}
