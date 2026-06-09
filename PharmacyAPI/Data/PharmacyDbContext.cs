using Microsoft.EntityFrameworkCore;
using PharmacyAPI.Models;

namespace PharmacyAPI.Data
{
	public class PharmacyDbContext : DbContext
	{
		public PharmacyDbContext(DbContextOptions<PharmacyDbContext> options) : base(options) 
		{ 
		}

		public DbSet<Medicine> Medicines { get; set; }
	}
}
