using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SweetandSavory.Models
{
  public class SweetandSavoryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Treat> Treat { get; set; }
    public DbSet<Flavor> Flavor { get; set; }
    public DbSet<TreatFlavor> TreatFlavor { get; set; }

    public SweetandSavoryContext(DbContextOptions options) : base(options) { }
  }
}