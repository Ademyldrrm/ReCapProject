using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

        //1:42 de kaldım
        public IResult Add(Car car)
        {
            var context =  new ValidationContext<Car>(car);
            CarValidator carValidator=new CarValidator();
            var result=carValidator.Validate(context);

            if (!result.IsValid)
            {
                throw new FluentValidation.ValidationException(result.Errors);
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

        public IResult Delete(Car car)
        {
            return new SuccessResult(Messages.CarAdded);

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
            return new SuccesDataResult<Car>(_carDal.Get(c=>c.CarId==carId));
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return  new SuccesDataResult<List<Car>> (_carDal.GetAll(p => p.BrandId == id));
        }



        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccesDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }




        public IResult Update(Car car)
        {
          
            _carDal.Update(car);
            return new SuccessResult(Messages.CarAdded);
        }


    }
}
