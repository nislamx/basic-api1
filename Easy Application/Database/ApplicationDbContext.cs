using Microsoft.EntityFrameworkCore;
using Easy_Application.Models;

namespace Easy_Application.Database;

public class ApplicationDbContext : DbContext
{
   public DbSet<Employee> Employees { get; set; }
      
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseInMemoryDatabase("EmployeeDb");
   }
}