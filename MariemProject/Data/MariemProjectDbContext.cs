using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MariemProject.Entities;

namespace MariemProject.Data
{
    public class MariemProjectDbContext : DbContext
    {
        public MariemProjectDbContext (DbContextOptions<MariemProjectDbContext> options)
            : base(options)
        {
        }

        public DbSet<MariemProject.Entities.User> User { get; set; }
        public DbSet<MariemProject.Entities.Car> Car { get; set; }
        public DbSet<MariemProject.Entities.SelledCar> SelledCar { get; set; }
    }
}
