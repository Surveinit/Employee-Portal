using EmployeePortal.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
         }

        public DbSet<Employee> Employees { get; set; }
    }
}
