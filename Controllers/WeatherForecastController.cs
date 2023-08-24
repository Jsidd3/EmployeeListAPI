using EmployeeListAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeListAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private readonly IEmployeeRepository _employeeRepository;

        public WeatherForecastController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeRepository.GetAllEmployeesAsync();
            return Ok(employees);
        }
    }
}