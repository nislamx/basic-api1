using Easy_Application.Models;
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

        [HttpGet("{id:int}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            if (id <= 0)
            {
                return NotFound();
            }

            return Ok(_employeeService.GetById(id));
        }
        
        [HttpPut("Charles/{id:int}")]
        public ActionResult<Employee> UpdateCharles(int id)
        {
            Employee myEmployee = _employeeService.GetById(id);
            
            if (myEmployee.Position == "Senior Charles")
            {
                _employeeService.UpdateName(id, "Charles Macgoo");
                return Ok(myEmployee);
            }
            return NotFound();
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