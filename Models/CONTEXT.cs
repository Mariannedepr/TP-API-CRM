using Microsoft.EntityFrameworkCore;
namespace TP.CRM;

public class CRMContext : DbContext
{    


    public CRMContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
        
        Console.WriteLine("Database créée");

    }
    public DbSet<User> Users { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Order> Orders { get; set; }

    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("Server=Localhost;Database=Cerise;User=admin;Password=admin;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<User>(entity =>
       {
        entity.HasKey(u => u.ID).HasName("PRIMARY");
       });
       
        modelBuilder.Entity<Client>(entity => 
        {
            //la PK
            entity.HasKey(c => c.ID).HasName("PRIMARY");
            //Le client a 1 user
            entity.HasOne(c => c.user)
            //et plusieurs orders
            .WithMany(c => c.ListClients)
            .HasForeignKey(d =>d.id_user);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(o => o.ID).HasName("PRIMARY");
            //un order appartient à un seul client
            entity.HasOne(e => e.bob)
            //avec plusieurs orders possibles
            .WithMany(o => o.ListOrders)
            //FK : id_clients
            .HasForeignKey(e => e.id_clients);
        });
    }
}