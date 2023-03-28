using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        
        private List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars= new List<Car>()
            {
                //new Car{CarId = 1,BrandId = 1,CarName = "Ford",ColorId = 2,ModelYear = "2020",DailyPrice = "1500",Description = "Güzel Beyaz Araba"},
                //new Car{CarId = 1,BrandId = 1,CarName = "Toyota",ColorId = 2,ModelYear = "2022",DailyPrice = "2500",Description = "Güzel Kırmızı Araba"},
                //new Car{CarId = 1,BrandId = 1,CarName = "Hyundai",ColorId = 2,ModelYear = "2023",DailyPrice = "3500",Description = "Güzel Sarı Araba"},
                //new Car{CarId = 1,BrandId = 1,CarName = "Volvo",ColorId = 2,ModelYear = "2024",DailyPrice = "4500",Description = "Güzel Mavi Araba"}
            };
        }

        public void Add(Car car)
        {

            _cars.Add(car);
            
        }

        public List<CarDetailDto> CarDetails()
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.CarId==p.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(p => p.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.CarId == p.CarId);

            carToUpdate.CarId = car.CarId;
            carToUpdate.BrandId = car.BrandId;
            //carToUpdate.CarName= car.CarName;
            carToUpdate.ColorId= car.ColorId;
            carToUpdate.DailyPrice= car.DailyPrice;
            carToUpdate.Description= car.Description;

        }
    }

    
}
