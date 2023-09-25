using OneToMany.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace OneToMany.Data;//Återspeglar vart filen ligger

public class ApplicationDbContext : DbContext//Möjligör kommikationen med modellen och databasen
{

    private string connectionString = "Server=.;Database=ManyToMany;Integrated Security=False;Encrypt=False;User ID=SA;Password=Dinoaugust123456!;";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(connectionString);
        optionsBuilder.LogTo(message => Debug.WriteLine(message));// se sql:n som genereras 
    }
    //Kunna prata med tabellen som skapades
    public DbSet<Project> Project { get; set; }
    public DbSet<Member> Member { get; set; }

}