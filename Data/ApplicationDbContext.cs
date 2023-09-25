using OneToMany.Domain;
using Microsoft.EntityFrameworkCore;

namespace OneToMany.Data;//Återspeglar vart filen ligger

public class ApplicationDbContext : DbContext//Möjligör kommikationen med modellen och databasen
{

    private string connectionString = "Server=.;Database=ManyToMany;Integrated Security=False;Encrypt=False;User ID=SA;Password=Dinoaugust123456!;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
    }
    //Kunna prata med tabellen som skapades
    public DbSet<Project> Project { get; set; }
    public DbSet<Member> Member { get; set; }

}