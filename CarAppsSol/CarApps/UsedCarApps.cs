using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApps
{
    //car's make, model, year, and sale price.
    class Car
    {
        public string _Brand;
        public string _Model;
        public int _Year;
        public int _SalePrice;

        public Car(string Brand, string Model, int Year, int SalePrice)
        {
            this._Brand = Brand;
            this._Model = Model;
            this._Year = Year;
            this._SalePrice = SalePrice;
        }
    }
    internal class UsedCarApps
    {
        public static void Main(string[] args)
        {
            List<Car> carlist = new List<Car>();

            Car car1 = new Car(Brand: "Maruti", Model:"800", Year:2020, SalePrice:400000);
            Car car2 = new Car("Rolls_Royce", "phantom", 2019, 50000000);
            
            carlist.Add(car1);
            carlist.Add(car2);

            Console.WriteLine("Select Your Choice :");
            Console.WriteLine("CarList");
            
            //AddNewCar(carlist);

            //GetCarList(carlist);

            Console.Write("Brand: ");
            string QueryBrand = Console.ReadLine();
            Console.Write("Model: ");
            string QueryModel =Console.ReadLine();
            //SearchCar(carlist, QueryModel, QueryBrand);
            DeleteCar(carlist, QueryModel, QueryBrand);
            GetCarList(carlist);

        }

        public static void GetCarList(List<Car> carlist)
        {
            foreach(Car c in carlist)
            {
                Console.WriteLine("{0},{1},{2},{3} ", c._Brand, c._Model, c._Year, c._SalePrice);
                Console.WriteLine("-------------------------------------------------");
            }
        }

        public static void AddNewCar(List<Car> carlist)
        {
            Console.WriteLine("Write Details to add new Car in list");

            Console.Write("Brand : ");
            string brand = Console.ReadLine();

            Console.Write("Model : ");
            string model = Console.ReadLine();

            Console.Write("Manufactured year : ");
            int year  =Convert.ToInt32( Console.ReadLine());

            Console.Write("saleprice : ");
            int salePrice = Convert.ToInt32(Console.ReadLine());

            Car newcar = new Car(brand, model, year, salePrice);
            carlist.Add(newcar);

        }

        public static void SearchCar(List<Car> carlist, string Qmodel, string Qbrand)
        {
            foreach(Car c in carlist)
            {
                if(c._Model.Equals(Qmodel) && c._Brand.Equals(Qbrand))
                {
                    Console.WriteLine("{0},{1},{2},{3} ", c._Brand, c._Model, c._Year, c._SalePrice);
                    Console.WriteLine("-------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("No car founds in the List");
                    
                }
            }
        }

        public static void DeleteCar(List<Car> carlist, string Qmodel, string Qbrand)
        {
            foreach(Car c in carlist)
            {
                if(c._Model.Equals(Qmodel) && c._Brand.Equals(Qbrand))
                {
                    carlist.Remove(c);
                    Console.WriteLine("Car Record Deleted successfully");
                }
                else
                {
                    Console.WriteLine("Invalid Car Model or Brand");
                }
            }
        }
        
    }
}
