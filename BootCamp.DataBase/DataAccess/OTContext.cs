using BootCamp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace BootCamp.DataBase.DataAccess
{
    public class OTContext : DbContext
    {
        public OTContext(DbContextOptions<OTContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

 
    }
    
}

