using Microsoft.EntityFrameworkCore;
using USWildfireProject.Models;

namespace USWildfireProject.Data;

public class WildfireContext : DbContext
{
    protected readonly IConfiguration Configuration;
    public WildfireContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(Configuration.GetConnectionString("WildfireDB"));
    }
    public DbSet<Wildfire> Wildfires { get; set; }
}
