using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public void Add(Car car)
        {
            if (car.Description.Length > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Bilgileri yanlış girdiniz");
            }

            if (car.ModelYear.Length > 2010)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Bilgileri yanlış girdiniz");
            }
            //_carDal.Add(car);

        }




        public void Delete(Car car)
        {
            throw new NotImplementedException();
        }



        public List<Car> GetAll(int i)
        {
            return _carDal.GetAll();
        }





        public List<Car> GetAll()
        {
            return _carDal.GetAll();

        }





        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }





        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }





        public void Update(Car car)
        {
             _carDal.Update(car);
        }


    }
}
