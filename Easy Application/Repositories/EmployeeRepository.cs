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
}

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ApplicationDbContext context;

    public EmployeeRepository(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Employee? getById(int id)
    {
        return context.Employees.Find(id);
    }

    public void Update(Employee employee)
    {
        context.Employees.Update(employee);
        context.SaveChanges();
    }

    
    public void Delete(Employee employee)
    {
        context.Employees.Remove(employee);
        context.SaveChanges();
    }

}