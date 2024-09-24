using BankSystem_P.Classes;
using BankSystem_P.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BankSystem_P
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();

            bool isMenuActive = true; 

            while (isMenuActive)
            {
                Console.Clear();
                Console.WriteLine("===== Bank Konoha =====");
                Console.WriteLine("Menu");
                Console.WriteLine("1. Informasi Saldo");
                Console.WriteLine("2. Tambah Saldo");
                Console.WriteLine("3. Keluar");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1": //informasi saldo
                        Console.WriteLine("Selected Menu : " + input + " Informasi Saldo");
                        Console.WriteLine(Information(bankAccount));
                        Information(bankAccount);

                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.ReadKey();
                        break;

                    case "2": // add balance
                        Console.WriteLine("Selected Menu : " + input + " Tambah Saldo" );
                        depositMoney(bankAccount);

                        Console.WriteLine("\nPress any key to go back to main menu...");
                        Console.ReadKey();
                        break;

                        // exit program
                    case "3": isMenuActive = false;
                        Console.WriteLine("ok bye");
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
           
            Console.ReadLine(); 
        }

        private static void depositMoney(BankAccount bankAccount)
        {
            //BankAccount bankAccountToAdded = new BankAccount();
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
            }


            //pass it to AddToBalance methods
            bankAccount.AddToBalance(depositMoney);

            //print the newest money
            Console.WriteLine("Recently Added, " + Information(bankAccount));

        }

        private static string Information(IGetInformation information)
        {
            return information.GetInformation();
        }
    }
}
