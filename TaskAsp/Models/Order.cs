using System.ComponentModel.DataAnnotations;
using TaskAsp.Models;

namespace TaskAsp.Models;

public class Order
{
    public int Id { get; set; }

    [Required] public int ClientId { get; set; }
    public Client? Client { get; set; }

    [Required] public int ProductId { get; set; }
    public Product? Product { get; set; }

    [Range(1, 100000)] public int Quantity { get; set; }
    [Required] public OrderStatus Status { get; set; }
}
