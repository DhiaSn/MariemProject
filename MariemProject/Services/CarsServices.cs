using MariemProject.Data;
using MariemProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Services
{
    public class CarsServices : ICarsServices
    {

        private readonly MariemProjectDbContext _context;

        public CarsServices(MariemProjectDbContext context)
        {
            _context = context;
        }

        public bool IsCarAvailable(int carID)
        {
            var car = _context.Car.Where(c => c.IsAvailable).FirstOrDefault(c => c.Id == carID);

            if (car != null)
                return true;

            return false;
        }

    }
}
