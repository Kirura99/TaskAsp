namespace TaskAsp.ViewModels;

public class OrderList
{
    public int Id { get; set; }
    public string ProductTitle { get; set; } = "";
    public int Quantity { get; set; }
    public decimal OrderAmount { get; set; }
    public TaskAsp.Models.OrderStatus Status { get; set; }
}
