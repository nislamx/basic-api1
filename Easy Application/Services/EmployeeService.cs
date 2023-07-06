using Easy_Application.Exceptions;
using Easy_Application.Models;
using Easy_Application.Repositories;

namespace Easy_Application.Services;

public interface IEmployeeService{

    Employee GetById(int id);
    void UpdateName(int id, string newName);
    void DeleteById(int id);
}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository employeeRepo;

    public EmployeeService(IEmployeeRepository employeeRepository)
    {
        employeeRepo = employeeRepository;
    }

    public Employee GetById(int id)
    {
        Employee? myEmployee = employeeRepo.getById(id);
        if (myEmployee == null)
        {
            throw new NoEmployeeException(id);
        }
        return myEmployee;     
    }

    public void UpdateName(int id, string newName)
    {
        Employee? employee = employeeRepo.getById(id);
        if (employee == null)
        {
            throw new NoEmployeeException(id);
        }
        employee.FirstName = newName;
        employeeRepo.Update(employee);
    }


    public void DeleteById(int id)
    {
        Employee? employee = employeeRepo.getById(id);
        if (employee == null)
        {
            throw new NoEmployeeException(id);
        }
        employeeRepo.Delete(employee);
    }

}