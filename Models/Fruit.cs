using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace myFruits.Models;

public class Fruit
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, MinimumLength = 3)]
    [Display(Name= "Nom")]
    public string Name { get; set; }
    public string Description { get; set; }

    public Image Image { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    [DataType(DataType.Currency)]
    [Required]
    [Range(1, 100)]
    [Display(Name = "Prix")]
    public decimal Price { get; set; } = decimal.One;


}
