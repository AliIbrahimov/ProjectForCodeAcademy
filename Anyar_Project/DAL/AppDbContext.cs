using Anyar_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Anyar_Project.DAL
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)   {   }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Icon> Icons { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
