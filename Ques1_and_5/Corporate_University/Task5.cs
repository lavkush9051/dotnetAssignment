using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    abstract class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }

        public abstract void GetSalary(int EmpId);
        
    }
    class PermanentEmployee : Employee
    {
        decimal ProvidentFund = 1200;
        public override void GetSalary(int EmpId)
        {
            //base.GetSalary(EmpId);
            
            Salary = Salary - ProvidentFund;
            Console.WriteLine("For Permanent EmpID {0}, Salary : {1}", EmpId, Salary);

        }
    } 

    class ContractEmployee : Employee
    {
        
        decimal Perks = 1000;
        public override void GetSalary(int EmpId)
        {
            Salary = Salary + Perks;
            Console.WriteLine("For ContractEpmloyee EmpID {0}, Salary : {1}", EmpId, Salary);
        }
    }

    internal class Task5
    {
        static void Main(string[] args)
        {
            /*Employee emp;
            List<Employee> EmpList = new List<Employee>();*/
            PermanentEmployee pe = new PermanentEmployee { EmpId = 101,EmpName = "Radha", Address = "TamilNadu", City = "Chennai", Department="Finance",Salary=25000};
            pe.GetSalary(101);
        }
    }
}
