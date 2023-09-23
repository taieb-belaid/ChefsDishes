#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Chef
{
    [Key]
    public int ChefId {get; set;}
    [Required]
    [MinLength(3)]
    public string FirstName {get;set;}
    [Required]
    [MinLength(3)]
    public string LastName {get;set;}
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth {get;set;}

    // navigation
    public List<Dish> MakeDishes {get; set;} = new List<Dish>();

}