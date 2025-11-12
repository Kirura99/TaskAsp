using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskAsp.Data;
using TaskAsp.Models;
using TaskAsp.ViewModels;

namespace TaskAsp.Controllers;

public class ClientsController(AppDbContext db) : Controller
{
    private readonly AppDbContext _db = db;

    //View block 
    public async Task<IActionResult> Index()
    {
        var model = await _db.Clients
            .Select(c => new ClientList
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Birthdate = c.Birthdate,
                OrdersCount = c.Orders.Count(),
                AvgOrderAmount = c.Orders.Any()
                ? c.Orders.Average(o => (decimal?)(o.Product!.Price * o.Quantity))
                : 0
            })
            .ToListAsync();

        return View(model);
    }
    //CRUD
    public IActionResult Create() => View(new Client { Birthdate = DateTime.Today });

    [HttpPost]
    public async Task<IActionResult> Create(Client client)
    {
        if (!ModelState.IsValid) return View(client);
        _db.Clients.Add(client);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var client = await _db.Clients.FindAsync(id);
        if (client is null) return NotFound();
        return View(client);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Client client)
    {
        if (id != client.Id) return BadRequest();
        if (!ModelState.IsValid) return View(client);
        _db.Update(client);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Delete(int id)
    {
        var client = await _db.Clients.FindAsync(id);
        if (client is null) return NotFound();
        return View(client);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var client = await _db.Clients.FindAsync(id);
        if (client is not null)
        {
            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

