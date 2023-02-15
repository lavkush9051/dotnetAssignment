using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_pvt_ltd
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
    }

    internal class prog2
    {
        static void Main(string[] args)
        {
            Employee emp;
            List<Employee> EmpList = new List<Employee>();

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("Enter Employee {0} details", i + 1);
                    Console.Write("Enter Employee Id: ");
                    int empId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Employee Name: ");
                    string empName = Console.ReadLine();

                    Console.Write("Enter Employee Address: ");
                    string empAdd = Console.ReadLine();

                    Console.Write("Enter Employee City: ");
                    string empCity = Console.ReadLine();

                    Console.Write("Enter Employee Department: ");
                    string empDept = Console.ReadLine();

                    Console.Write("Enter Employee Salary: ");
                    decimal empSalary = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("******************************");

                    emp = new Employee { EmpId = empId, EmpName = empName, Address = empAdd, City = empCity, Department = empDept, Salary = empSalary };
                    EmpList.Add(emp);
                }

                foreach (Employee e in EmpList)
                {
                    Console.WriteLine("Employee Name : {0}, Salary : {1}", e.EmpName, e.Salary);
                    Console.WriteLine("-------------------------------");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Input string was not in a correct format");
            }
            catch
            {
                Console.WriteLine("Something Is Broken");
            }

            finally
            {
                Console.WriteLine("Please Try Again, Have a Nice Day");
            }
                
            

        }
    }
}
