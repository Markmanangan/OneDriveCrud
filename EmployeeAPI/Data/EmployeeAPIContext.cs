using Microsoft.EntityFrameworkCore;
using EmployeeAPI.Models;

namespace EmployeeAPI.Data
{
    public class EmployeeAPIContext : DbContext
    {
        public EmployeeAPIContext(DbContextOptions<EmployeeAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employee => Set<Employee>();
    }
}
