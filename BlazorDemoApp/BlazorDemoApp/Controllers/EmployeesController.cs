using BlazorApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeesController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _applicationDbContext.Employees.Include(s => s.Country).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<Employee> GetById(int id)
        {
            return await _applicationDbContext.Employees.Include(s => s.Country).SingleOrDefaultAsync(s => s.Id == id);
        }
    }
}
