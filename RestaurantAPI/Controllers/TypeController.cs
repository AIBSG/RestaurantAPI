using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TypeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TypeController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            var result = await _context.Set<Models.Type>().ToListAsync();
            return Ok(result);

        }

    }
}
