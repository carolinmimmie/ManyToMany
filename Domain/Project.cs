using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToMany.Domain;//gruppera domain klasser 

public class Project//Skapar upp en klass
{
    public int Id { get; set; }//primärnyckel

    [MaxLength(50)]//begränsar längden på en sträng - påverkar hur migreringen ser ut 
    public required string Name { get; set; }

    [MaxLength(50)]//begränsar längden på en sträng - påverkar hur migreringen ser ut 
    public required string Description { get; set; }

    public required DateTime Deadline { get; set; }

    //Nacigation property 
    public ICollection<Member> Members { get; set; }
    //ICollection<Member>: Detta är typen av egenskapen. Det är en samling (collection) 
    //av objekt av typen Member. I detta fall antas det att Member är en annan klass i din databasmodell.

    //Members: Detta är namnet på egenskapen.

    //{get; set;}  är en automatisk egenskap (auto-implemented property), då kan du kan få och
    // sätta värdet för Members utan att behöva definiera egna getter- och setter-metoder.
}