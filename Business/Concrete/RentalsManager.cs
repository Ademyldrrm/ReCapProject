using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        private IRentalDal _rentalDal;

        public RentalsManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;

        }

        public IResult Add(Rentals rentals)
        {
            if (rentals.ReturnDate!=null)
            {
                _rentalDal.Add(rentals);
                return new ErrorResult(Messages.CarAdded);
            }

            else
            {
                return new ErrorResult(Messages.CarNotAdded);
            }
        }


        public IResult Delete(Rentals rentals)
        {
            _rentalDal.Delete(rentals);
            return new SuccessResult();
        }

        public IDataResult<List<Rentals>> GetAll()
        {
            return new SuccesDataResult<List<Rentals>>(_rentalDal.GetAll());
        }

        public IDataResult<Rentals> GetById(int id)
        {
            return new SuccesDataResult<Rentals>(_rentalDal.Get(r => r.Id == id));
        }

        public IResult Update(Rentals rentals)
        {
            _rentalDal.Update(rentals);
            return new SuccessResult();
        }
    }
}
