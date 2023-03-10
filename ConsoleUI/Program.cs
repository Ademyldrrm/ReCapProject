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

            CarManager carManager=new CarManager(new EfCarDal());

             //carManager.Add(new Car{BrandId = 2,ColorId = 3,ModelYear = "2022",DailyPrice ="15.00",Description = "çok güzel araba"});
             carManager.Update(new Car{ CarId = 1,BrandId = 2, ColorId = 3, ModelYear = "2022", DailyPrice = "20.00", Description = "Harika Araba" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }


            
        }
    }
}