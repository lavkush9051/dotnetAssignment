using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCaseStudy
{
    public enum BankAccountTypeEnum
    {
        Current = 1,
        Saving = 2
    }

    public interface IBankAccount
    {
        double GetBalance();
        void Deposit(double amount);
        bool Withdraw(double amount);
        bool Transfer(IBankAccount toAccount, double amount);
        BankAccountTypeEnum AccountType { get; set; }
        void CalculateInterest();
    }
    public abstract class BankAccount:IBankAccount
    {
        protected double balance;

        public BankAccountTypeEnum AccountType { get ; set ; }

        public double GetBalance()
        {
            return balance;
        }
        public void Deposit(double amount)
        {
            balance += amount;
        }
        public abstract bool Withdraw(double amount);
        public abstract bool Transfer(IBankAccount toAccount, double amount);
        public abstract void CalculateInterest();

    }

    public class ICICI:BankAccount
    {
        public override bool Withdraw(double amount)
        {
            if(balance - amount > 0)
            {
                balance -= amount;
                Console.WriteLine("Closing Balance: {0}",balance);
                return true;
            }
            else
            {
                Console.WriteLine("Account Balance is low");
                return false;
            }
        }
        
        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            if(balance - amount > 1000) { 
                balance -= amount;
                toAccount.Deposit(amount);

                Console.WriteLine("Transferred Successfully");

                return true;
            }
            else
            {
                Console.WriteLine("Account Balance is low");
                return false;
            }
        }
        public ICICI(BankAccountTypeEnum Btype)
        {
            this.AccountType = Btype;
        }

        
        public override void CalculateInterest()
        {
            if ((int)this.AccountType == 2)
            {
                Console.WriteLine("7%");
            }
            else
            {
                Console.WriteLine("Its Current Account");
            }
        }
    }
    public class HSBC : BankAccount
    {
        public override bool Withdraw(double amount)
        {
            if (balance - amount > 0)
            {
                balance -= amount;
                Console.WriteLine("Closing Balance: {0}", balance);
                return true;
            }
            else
            {
                Console.WriteLine("Account Balance is low");
                return false;
            }
        }
        public override bool Transfer(IBankAccount toAccount, double amount)
        {
            if (balance - amount > 1000)
            {
                toAccount.Deposit(amount);
                balance-= amount;
                Console.WriteLine("Transfered Successfully");
                return true;
            }
            else
            {
                Console.WriteLine("Account Balance is low");
                return false;
            }
        }
        public HSBC(BankAccountTypeEnum Btype)
        {
            this.AccountType = Btype;
        }
        public override void CalculateInterest()
        {
            if((int)this.AccountType == 2)
            {
                Console.WriteLine("5%");
            }
            else
            {
                Console.WriteLine("Its Current Account");
            }
        }
    }
}
