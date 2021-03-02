using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Entities
{
    public class SelledCar
    {
        public int Id { get; set; }
        public int ClientId { get; set; } 
        public int CarId { get; set; }
        public DateTime SalledDate { get; set; }
    }
}
