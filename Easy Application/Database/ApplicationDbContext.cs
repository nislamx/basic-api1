using Microsoft.EntityFrameworkCore;
using Easy_Application.Models;

namespace Easy_Application.Database;

public class ApplicationDbContext : DbContext
{
   
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
   {
   }
   public DbSet<Employee> Employees { get; set; }
   
}