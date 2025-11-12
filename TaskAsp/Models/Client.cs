using System.ComponentModel.DataAnnotations;

namespace TaskAsp.Models;

public class Client
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = "";

    [Required, EmailAddress]
    public string Email { get; set; } = "";

    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    [Required]
    public Gender Gender { get; set; }

    public List<Order> Orders { get; set; } = new();
}
