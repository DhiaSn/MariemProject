using MariemProject.Data;
using MariemProject.Entities;
using MariemProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MariemProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentificationController : ControllerBase
    {
        #region Local Variables + Constructor
        private readonly MariemProjectDbContext _context;
        public IdentificationController(MariemProjectDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Methods

        #region CRUD
        [HttpPost("login")]
        public async Task<ActionResult<User>> Login(Login login)
        {
            var user = await _context.User.Include(u => u.Cars).FirstOrDefaultAsync(c => c.UserName == login.UserName);
            try
            {
                if (user.Password == login.Password)
                {
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                BadRequest(ex.Message);
            }

            return NoContent();
        }
        #endregion

        #region Others

        #endregion

        #endregion
    }
}
