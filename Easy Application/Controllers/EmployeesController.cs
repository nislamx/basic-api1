using Easy_Application.DTOs;
using Easy_Application.Exceptions;
using Easy_Application.Models;
using Easy_Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Easy_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        
        [HttpGet]
        public ActionResult<List<EmployeeDto>> GetEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet("{id:int}")]
        
        
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            try
            {
                return Ok(_employeeService.GetById(id));
            }
            catch (NoEmployeeException e)
            {
                Console.WriteLine(e);
                return NotFound();
            }

            
        }
        
        [HttpPut("Charles/{id:int}")]
        public ActionResult<Employee> UpdateCharles(int id)
        {
            try
            {
                Employee myEmployee = _employeeService.GetById(id);
                if (myEmployee.Position == "Senior Charles")
                {
                    _employeeService.UpdateName(id, "Charles Macgoo");
                    return Ok(myEmployee);
                }
                return NotFound();
            }
            catch (NoEmployeeException e)
            {
                Console.WriteLine(e);
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteEmployee(int id)
        {
            Employee myEmployee = _employeeService.GetById(id);
            if (myEmployee.FirstName == "Bertrand")
            {
                _employeeService.DeleteById(id);
                return Ok();
            }
            return NotFound();
        }
    }
}