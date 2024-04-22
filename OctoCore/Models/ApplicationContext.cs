using Microsoft.EntityFrameworkCore;
using OctoCore.Secrets;

namespace OctoCore.Models;

public class ApplicationContext : DbContext
{
    public DbSet<Member> Members { get; set; }
    
    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(OctoCore.Secrets.Secret.PsqlAuth);
    }
}