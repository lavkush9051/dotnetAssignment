using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BankCaseStudy;

namespace BankApp
{
    class Program2
    {
        static void Main(string[] args)
        {
            ICICI newIcic = new ICICI(BankAccountTypeEnum.Saving);
            newIcic.Deposit(50000);
            //Console.WriteLine(newIcic.AccountType);
            //newIcic.Withdraw(25000);
            //Console.WriteLine();
            //newIcic.AccountType = BankAccountTypeEnum.Saving;
            newIcic.CalculateInterest();



            //newIcic.AccountType =;
            HSBC newHsbc = new HSBC(BankAccountTypeEnum.Current);
            newHsbc.Deposit(20000);
            newHsbc.Transfer(newIcic, 5000);
            newHsbc.CalculateInterest();


            Console.WriteLine(newHsbc.GetBalance());
            Console.WriteLine(newIcic.GetBalance());


        }
    }
}

