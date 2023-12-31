#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Dish
{
    [Key]
    public int DishId{get;set;}
    [Required]
    [MinLength(3)]
    public string Name {get;set;}
    [Required]
    public int Tastiness {get;set;}
    [Required]
    public int Calories {get;set;}

    // Navigation 
    [Required]
    public int ChefId{get;set;}
    public Chef? Maker {get;set;}
}