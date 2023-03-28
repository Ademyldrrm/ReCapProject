using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntiyFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> CarDetails()
        {
            using (ReCapContext reCapContext = new ReCapContext())
            {
                var result = from c in reCapContext.Cars
                    join b in reCapContext.Brands
                        on c.BrandId equals b.BrandId
                    join co in reCapContext.Colors
                        on c.ColorId equals co.ColorId
                    join ca in reCapContext.Cars
                        on c.CarName equals ca.CarName
                    select new CarDetailDto
                    {
                        CarId = c.CarId,
                        CarName = c.CarName,
                        ColorName = co.ColorName,
                        DailyPrice = c.DailyPrice,
                        BrandName = b.BrandName

                    };
                return result.ToList();
            
        }
        }
    }
}
