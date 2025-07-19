using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer;
public class AppDbContext : DbContext
{
    public DbSet<Animal> Animals { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
        .Entity<Animal>()
        .HasDiscriminator<string>("Name")
        .HasValue<Lion>(nameof(Lion))
        .HasValue<Tiger>(nameof(Tiger))
        .HasValue<Eagle>(nameof(Eagle));


        modelBuilder
        .Entity<Animal>()
        .Property(x => x.MovementType)
        .HasConversion(
            v => v.ToString(),
            v => (MovementType)Enum.Parse(typeof(MovementType), v)
        );

        modelBuilder.Entity<Animal>().HasKey(a => a.Id);
        modelBuilder.Entity<Lion>().ToTable("Animals");
        modelBuilder.Entity<Eagle>().ToTable("Animals");
        modelBuilder.Entity<Tiger>().ToTable("Animals");




    }
}