using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new EfCarDal());

           // carManager.Add(new Car { BrandId = 3,CarName = "Corolla",ColorId = 3, ModelYear = "2023", DailyPrice = "45.00", Description = "çok güzel araba" });
           ///* carManager.Update(new Car { CarId = 1, BrandId = 2, ColorId = 3, ModelYear = "2022", DailyPrice = "20.00", Description = "Harika Araba" });
            foreach (var car in carManager.CarDetails())
            {
                Console.WriteLine(car.BrandName+" "+car.DailyPrice);
            }
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            ////brandManager.Add(new Brand { BrandName = "Audi" });
            ////brandManager.Delete(new Brand{BrandId = 4});
            //foreach (var brand in brandManager.GetAll())
            //{
            //    Console.WriteLine(brand.BrandName);
            //}

            //ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Color { ColorName = "Mor" });
            //foreach (var color in colorManager.GetAll())
            //{
            //    Console.WriteLine(color.ColorName);
            //}



        }
    }
}