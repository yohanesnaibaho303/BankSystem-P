using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem_P.Interfaces;
using System.Globalization;

namespace BankSystem_P.Classes
{
    public class BankAccount : Interfaces.IGetInformation
    {
        //Access modifier = The code is only accessible within the same class, to ensure security
        private double privateBalance; //field

        //Properties GetSet
        public double balanceProperties //properties
        {
            get
            {
                if (privateBalance < 1000) // max balance is 1000
                {
                    return privateBalance;
                }
                return 1000;
            }
            protected set
            {
                if (value > 0)
                {
                    privateBalance = value;
                } else 
                {
                    privateBalance = 0;
                }
            }
        }

        //class constructor
        public BankAccount()
        {
            balanceProperties = 10;
        }

        // overloading constructor
        public BankAccount(double initialBalance)
        {
            balanceProperties = initialBalance;
        }

        //Base class (parents) overriding methods = polymorphism 
        public virtual double AddToBalance (double balanceToBeAdded)
        {
            balanceProperties += balanceToBeAdded;
            return balanceProperties;
        }

        public string GetInformation()
        {
            //Console.WriteLine(balanceProperties);

            //var cInfo = new System.Globalization.CultureInfo("id-ID");

            return $"Your current balance is: {balanceProperties.ToString("c2")}";
        }

    }
}
