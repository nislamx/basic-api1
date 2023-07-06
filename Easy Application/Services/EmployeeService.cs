using AutoMapper;
using Easy_Application.DTOs;
using Easy_Application.Exceptions;
using Easy_Application.Models;
using Easy_Application.Repositories;

namespace Easy_Application.Services;

public interface IEmployeeService{

    Employee GetById(int id);
    void UpdateName(int id, string newName);
    void DeleteById(int id);
    List<EmployeeDto> GetAllEmployees();

}

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepo;
    private readonly IMapper _mapper;


    public EmployeeService(IEmployeeRepository employeeRepo, IMapper mapper)
    {
        _employeeRepo = employeeRepo;
        _mapper = mapper;
    }

    public Employee GetById(int id)
    {
        Employee? myEmployee = _employeeRepo.getById(id);
        if (myEmployee == null)
        {
            throw new NoEmployeeException(id);
        }
        return myEmployee;     
    }
    
    public List<EmployeeDto> GetAllEmployees()
    {
        var employees = _employeeRepo.GetAllEmployees();
        var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
        return employeeDtos;
    }

    public void UpdateName(int id, string newName)
    {
        Employee? employee = _employeeRepo.getById(id);
        if (employee == null)
        {
            throw new NoEmployeeException(id);
        }
        employee.FirstName = newName;
        _employeeRepo.Update(employee);
    }


    public void DeleteById(int id)
    {
        Employee? employee = _employeeRepo.getById(id);
        if (employee == null)
        {
            throw new NoEmployeeException(id);
        }
        _employeeRepo.Delete(employee);
    }

}