using System.ComponentModel.DataAnnotations;

namespace TaskAsp.Models;

public class Product
{
    public int Id { get; set; }

    [Required] 
    public string Code { get; set; } = "";
    [Required] 
    public string Title { get; set; } = "";
    [Range(0, 1_000_000)] 
    public decimal Price { get; set; }
}
