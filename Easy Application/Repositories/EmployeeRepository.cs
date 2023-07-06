using Easy_Application.Database;
using Easy_Application.Exceptions;
using Easy_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Easy_Application.Repositories;

public interface IEmployeeRepository
{
    Employee? getById(int id);

    void Update(Employee employee);
    void Delete(Employee employee);
    IEnumerable<Employee> GetAllEmployees();

}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext _context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Employee? getById(int id)
    {
        return _context.Employees.Find(id);
    }
    
    public IEnumerable<Employee> GetAllEmployees()
    {
        return _context.Employees.ToList();
    }

    public void Update(Employee employee)
    {
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    
    public void Delete(Employee employee)
    {
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }

}