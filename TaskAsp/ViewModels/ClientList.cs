namespace TaskAsp.ViewModels;

public class ClientList
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime Birthdate { get; set; }
    public int OrdersCount { get; set; }
    public decimal? AvgOrderAmount { get; set; } 
}
