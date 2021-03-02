using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime Birthday { get; set; }
        public string Rule { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
