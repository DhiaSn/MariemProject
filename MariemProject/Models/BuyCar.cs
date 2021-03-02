using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Models
{
    public class BuyCar
    {
        public BuyCar(int clientId, int carId, DateTime salledDate)
        {
            ClientId = clientId;
            CarId = carId;
            SalledDate = salledDate;
        }

        public int ClientId { get; set; }
        public int CarId { get; set; }
        public DateTime SalledDate { get; set; }
    }
}
