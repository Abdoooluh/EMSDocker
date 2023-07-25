using EMSDocker.Data;
using EMSDocker.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EMSDocker.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EMSDockerDbContext _dbContext;

        public EmployeesController(EMSDockerDbContext dbContext)
        {
            
            this._dbContext = dbContext;
        }
        // GET: api/<EmployeesController>
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetEmployees()
        {
             return Ok(_dbContext.Employees.ToList());
        }
        
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddEmployee(NewEmployeeRecord newRecord)
        {
            var employee = new Employee(newRecord);
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpGet]
        [Route("GetEmployee/{id:Guid}")]
        public async Task<IActionResult> GetUser([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
        
        [HttpPut]
        [Route("Update/{id:Guid}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] Guid id, NewEmployeeRecord updatedRecord)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                employee = new Employee(updatedRecord);
                await _dbContext.Employees.AddAsync(employee);
                await _dbContext.SaveChangesAsync();
                return Ok(employee);
            }
            else 
            {
                employee.UpdateEmployee(updatedRecord);
                await _dbContext.SaveChangesAsync();
                return Ok(employee);
            }
        }

        [HttpDelete]
        [Route("Delete/{id:Guid}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Remove(employee);
                await _dbContext.SaveChangesAsync();
                return Ok(employee);
            }
        }
    }
}
