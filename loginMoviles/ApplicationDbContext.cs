
using loginMoviles.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace loginMoviles
{
    public class ApplicationDbContext:IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions options):base(options) 
		{ 
		}

        public DbSet<Departamento> Departamentos { get; set; }
    }
}
