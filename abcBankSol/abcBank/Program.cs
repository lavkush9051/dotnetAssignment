using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace abcBank
{
    class Account
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Address { get; set; }
        //public DateTime date { get; set; }
        public int Balance { get; set; }
        //public int TransactionId { get; set; }
        //public DateTime TransactionDate { get; set; }
        public char TransactionType { get; set; }
        public int TransactionAmount { get; set; }

    }
    class AccountMethod
    {
        public void AccountOpen(Account newAc)
        {
            string conStr = "server=localhost\\sqlexpress;database=abcBankDb;integrated security=true";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_AccountOpen", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountName", newAc.AccountName);
                cmd.Parameters.AddWithValue("@Address", newAc.Address);
                cmd.Parameters.AddWithValue("@DepositeAmount", newAc.Balance);
                SqlParameter AccountNbr = new SqlParameter("AccountNumber", System.Data.SqlDbType.SmallInt);
                AccountNbr.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(AccountNbr);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Emp inserted with ID : {0}", AccountNbr.Value);
            }
            Console.WriteLine("New Account Created");

        }
        public void Transactions(int accNo, char transType, int amount)
        {
            string conStr = "server=localhost\\sqlexpress;database=abcBankDb;integrated security=true";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Proc_Transactions", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@AccountNumber", accNo);
                cmd.Parameters.AddWithValue("@TransactionType", transType);
                cmd.Parameters.AddWithValue("@TransactionAmount", amount);
                SqlParameter TransId = new SqlParameter("TransactionId", System.Data.SqlDbType.SmallInt);
                TransId.Direction = System.Data.ParameterDirection.Output;
                cmd.Parameters.Add(TransId);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Transaction ID : {0}", TransId.Value);
            }
        }
    }
    class program
    {
        static void Main(string[] args)
        {
            /*Account newAc1 = new Account { AccountName = "Rohan", Address = "Kolkata", Balance = 10000 };
            Account newAc2 = new Account { AccountName = "Aditya", Address = "Hyderabad", Balance = 10000 };
            Account newAc3 = new Account { AccountName = "Mannu", Address = "Agra", Balance = 10000 };
            Account newAc4 = new Account { AccountName = "prabhat", Address = "Bihar", Balance = 10000 };
            AccountMethod accountMethod = new AccountMethod();
            accountMethod.AccountOpen(newAc1);
            accountMethod.AccountOpen(newAc2);
            accountMethod.AccountOpen(newAc3);
            accountMethod.AccountOpen(newAc4);*/

            //////////////////////Transaction
            /*AccountMethod accountMethod = new AccountMethod();
            accountMethod.Transactions(4, 'D', 6000);*/

            Console.WriteLine("Choose Action to Perform");
            Console.WriteLine("1: Open new Account ");
            Console.WriteLine("2: Deposite or Withdraw ");
            int val = Convert.ToInt32(Console.ReadLine());

            switch (val)
            {
                case 1:
                    AccountOpenMethod();
                    break;
                case 2:
                    TransactionMethod();
                    break;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        public static void AccountOpenMethod()
        {
            Console.WriteLine("Add New Account");
            Console.Write("Name: ");
            string acName = Console.ReadLine();
            Console.Write("Address: ");
            string add = Console.ReadLine();
            Console.Write("Balance: ");
            int bal = Convert.ToInt32( Console.ReadLine());

            Account newAc = new Account { AccountName = acName, Address = add, Balance =bal  };
            AccountMethod accountMethod = new AccountMethod();
            accountMethod.AccountOpen(newAc);
        }
        public static void TransactionMethod()
        {
            Console.Write("Account No :");
            int accNum = Convert.ToInt32( Console.ReadLine());
            Console.Write("Transaction Type (W/D) :");
            char ch =Convert.ToChar( Console.ReadLine());
            Console.Write("Amount :");
            int amt = Convert.ToInt32( Console.ReadLine());
            AccountMethod accountMethod = new AccountMethod();
            accountMethod.Transactions(accNum, ch, amt);
        }
    }
}