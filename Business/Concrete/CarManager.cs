using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.VisualBasic;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IResult Add(Car car)
        {
            if (car.CarName.Length<2)
            {
                return new ErrorResult(Messages.CarNameInvalid);

            }
              _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);

        }

        public IDataResult<List<CarDetailDto>> CarDetails()
        {
            if (DateAndTime.Now.Hour == 01)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.MaintenanceTime);
            }

            return new SuccesDataResult<List<CarDetailDto>>(_carDal.CarDetails(),Messages.CarListed);
        }

        public void Delete(Car car)
        {
            
        }



        public IDataResult<List<Car>> GetAll()
        {
            if (DateAndTime.Now.Hour==01)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }

            return new SuccesDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);

        }

        public IDataResult<Car> GetById(int carId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return  new SuccesDataResult<List<Car>> (_carDal.GetAll(p => p.BrandId == id));
        }



        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }





        public void Update(Car car)
        {
             _carDal.Update(car);
        }


    }
}
