using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalsService
    {
        IDataResult<List<Rentals>> GetAll();
        IDataResult<Rentals> GetById(int id);
        IResult Add(Rentals rentals);
        IResult Update(Rentals rentals);
        IResult Delete(Rentals rentals);
    }
}
