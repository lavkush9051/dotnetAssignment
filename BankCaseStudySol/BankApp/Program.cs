using System;
using BankCaseStudy;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICICI newIcic = new ICICI(BankAccountTypeEnum.Saving);
            newIcic.Deposit(50000);
            newIcic.GetBalance();
            
            //newIcic.AccountType =;
            HSBC newHsbc = new HSBC(BankAccountTypeEnum.Current);
            newHsbc.Deposit(2000);
            newHsbc.GetBalance();

        }
    }
}
