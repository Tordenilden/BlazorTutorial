//using BlazorTutorialConsole.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorTutorialConsole.DataModel;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Data Source=TEC-8220-LA0025;Initial Catalog=H2Tutorial002;Integrated Security=True");
    }
    // this is our tables in virtually form
    public DbSet<BlazorTutorialConsole.Model.Horse> Horse { get; set; } //Our Horse table....
}
