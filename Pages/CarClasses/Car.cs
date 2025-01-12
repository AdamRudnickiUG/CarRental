namespace CarRental.Pages.CarClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Car
{
    // [Key]
    // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    // [Key, Column(Order = 0)]
    public int CarID { get; set; }

    public string Model { get; set; } = "MODEL NOT INITIALIZED";
    public string CurrentHolder { get; set; } = "DEALERSHIP";
    public virtual string CarType { get; set; }
    // public virtual string CarType { get; set; } = "Oops default";
}