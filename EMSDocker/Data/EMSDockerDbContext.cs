using EMSDocker.Model;
using Microsoft.EntityFrameworkCore;

namespace EMSDocker.Data
{
    public class EMSDockerDbContext : DbContext
    {
        public EMSDockerDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
