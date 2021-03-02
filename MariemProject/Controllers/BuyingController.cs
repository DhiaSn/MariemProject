using MariemProject.Data;
using MariemProject.Entities;
using MariemProject.Models;
using MariemProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace MariemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuyingController : ControllerBase
    {
        private readonly MariemProjectDbContext _context;
        private ICarsServices _services;

        public BuyingController(MariemProjectDbContext context, ICarsServices services)
        {
            _context = context;
            _services = services;
        }

        [HttpPost]
        public async Task<IActionResult> PayCar(BuyRequest buyRequest)
        {
            if (_services.IsCarAvailable(buyRequest.CarId))
            {
                try
                {
                    var user = await _context.User.Include(c=>c.Cars).FirstOrDefaultAsync(u=>u.Id == buyRequest.UserId);
                    var car = await _context.Car.FindAsync(buyRequest.CarId);

                    if (user != null && car != null)
                    {
                        var buyCar = new SelledCar { CarId = car.Id, ClientId = user.Id, SalledDate = DateTime.Now };
                        _context.SelledCar.Add(buyCar);
                         
                        car.IsAvailable = false;
                        _context.Entry(car).State = EntityState.Modified;
                        user.Cars.Add(car);
                        _context.Entry(user).State = EntityState.Modified;
                        await _context.SaveChangesAsync();

                        return Ok("payment is done successfully!");
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

                return BadRequest();

            }

            return BadRequest("car isn't avaibale anymore");
        }
    }
}
