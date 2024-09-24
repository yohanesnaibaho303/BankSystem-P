using BankSystem_P.Classes;
using BankSystem_P.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem_P
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an object then print current balance
            BankAccount bankAccount = new BankAccount();
            Console.WriteLine(Information(bankAccount));


            CultureInfo culture = new CultureInfo("id-ID");

            //user input the deposit money
            Console.Write("Add money: ");

            string sMoney = Console.ReadLine();

            double depositMoney = 0;

            try
            {
                if (sMoney.Contains("."))
                {
                    sMoney = sMoney.Replace(".", ",");
                    
                    Console.WriteLine("Calculation: " + bankAccount.balanceProperties.ToString("c2", culture) + " + " + Convert.ToDouble(sMoney).ToString("c2", culture) + " =");

                    depositMoney = Convert.ToDouble(sMoney);
                }
                else
                {
                    depositMoney = Convert.ToDouble(sMoney);
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
                //test
            }
            

            //pass it to AddToBalance methods
            bankAccount.AddToBalance(depositMoney);

            //print the newest money
            Console.WriteLine("Recently Added, " + Information(bankAccount));

            Console.ReadLine(); 
        }

        private static string Information(IGetInformation information)
        {
            return information.GetInformation();
        }
    }
}
