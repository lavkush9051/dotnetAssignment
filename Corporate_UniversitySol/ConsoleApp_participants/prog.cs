using Corporate_University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_participants
{
    internal class prog
    {
        public static void Main(string[] args)
        {
            

            Console.WriteLine("Give Employee Details");
            try {
                Console.Write("Employee ID : ");
                int Id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Foundation Marks : ");
                int FoundMarks = Convert.ToInt32(Console.ReadLine());

                Console.Write("WebBasic Marks : ");
                int WebMarks = Convert.ToInt32(Console.ReadLine());

                Console.Write(".Net Marks : ");
                int DotNetMarks = Convert.ToInt32(Console.ReadLine());

                Participants emp = new Participants { _EmpId =  Id, _FoundationMarks = FoundMarks, _WebBasicMarks = WebMarks, _DotNetMarks = DotNetMarks };
                Console.WriteLine("TotalObtainedMarks : {0}", emp.TotalMarks());
                Console.WriteLine("Percentage : {0}", emp.Percentage());
            }
            catch(FormatException)
            {
                Console.WriteLine("Only Type Integer Value");
            }
            catch {
                Console.WriteLine("SomeThing Broken");
            }
            
            
            
        }
    }
}
