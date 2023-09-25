using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OneToMany.Domain;//gruppera domain klasser 

public class Member//Skapar upp en klass
{
    public int Id { get; set; }//primärnyckel

    [MaxLength(50)]//begränsar längden på en sträng - påverkar hur migreringen ser ut 
    public required string FirstName { get; set; }

    [MaxLength(50)]//begränsar längden på en sträng - påverkar hur migreringen ser ut 
    public required string LastName { get; set; }

    [MaxLength(50)]//begränsar längden på en sträng - påverkar hur migreringen ser ut 
    public required string Email { get; set; }

    [MaxLength(20)]//begränsar längden på en sträng - påverkar hur migreringen ser ut 
    public required string Phone { get; set; }

    //ändra nullable till false i migrerigen - kommer inte kunna lägga till en medlem utan att tilldela medlemmen dirket till ett projekt.

    public int ProjectId { get; set; }



}