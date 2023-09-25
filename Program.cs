
using OneToMany.Data;
using OneToMany.Domain;
using static System.Console;

namespace OneToMany;

class Program
{
    public static void Main()
    {
        Title = "OneToMany"; //sätter namnet på tabben
        CursorVisible = false; //stänger av markör

        while (true) //Loop som körs tills vi stänger ner den
        {
            WriteLine("1. Registrera projekt");
            WriteLine("2. Registrera medlem");

            var keyPressed = ReadKey(true); //hämtar in värdet

            Clear();


            switch (keyPressed.Key)//Case för varje knapptryck
            {
                case ConsoleKey.D1: //case för menyval1
                case ConsoleKey.NumPad1:

                    RegisterProjektView();

                    break;

                case ConsoleKey.D2: //case för menyval1
                case ConsoleKey.NumPad2:

                    RegisterMemberView();

                    break;

            }
            Clear();

        }
    }

    private static void RegisterMemberView()
    {
        Write("Förnamn: ");

        var firstName = ReadLine();

        Write("Efternamn: ");

        var lastName = ReadLine();


        Write("E-post: ");

        var email = ReadLine();

        Write("Telefonnummer: ");

        var phone = ReadLine();

        Member member = new Member
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone

        };

        WriteLine("Vill du lägga till medlemmen till ett projekt? (J/N)");

        var keyPressed = ReadKey(true);

        if (keyPressed.Key == ConsoleKey.J)
        {

            WriteLine("Projekt (ID)");

            var projectId = int.Parse(ReadLine()); // Hämta in projekt id

            member.ProjectId = projectId;//Sätter projekt id på medlemmen 

        }

        SaveMember(member);//Metod som sparar information ovan

        Clear();

        WriteLine("Medlem sparad");

        Thread.Sleep(2000);
    }

    private static void SaveMember(Member member)
    {
        //Här behöver vi dbContex med DbSet + database/tabell
        using var context = new ApplicationDbContext();

        context.Member.Add(member);

        //Kommer generera en INSERT INTO för "Member-tabellen" och skicka till databashanteraren (databasen)
        context.SaveChanges();
    }

    private static void RegisterProjektView()
    {
        Write("Namn: ");

        var name = ReadLine();

        Write("Beskrivning: ");

        var description = ReadLine();

        Write("Deadline (YYYY-MM-DD): ");

        var deadline = DateTime.Parse(ReadLine());//Använder parse för att deadline ska bli en datetime

        var project = new Project
        {
            Name = name,
            Description = description,
            Deadline = deadline
        };

        SaveProject(project);//Metod som sparar information ovan

        Clear();

        WriteLine("Projekt sparat");

        Thread.Sleep(2000);

    }

    private static void SaveProject(Project project)
    {
        //Här behöver vi dbContex med DbSet + database/tabell
        using var context = new ApplicationDbContext();

        context.Project.Add(project);

        //Kommer generera en INSERT INTO och skicka till databashanteraren (databasen)
        context.SaveChanges();
    }
}

