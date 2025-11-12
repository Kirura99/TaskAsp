using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskAsp.Data;
using TaskAsp.Models;
using TaskAsp.ViewModels;

namespace TaskAsp.Controllers;

public class OrdersController(AppDbContext db) : Controller
{
    private readonly AppDbContext _db = db;

    public async Task<IActionResult> Index()
    {
        var model = await _db.Orders
            .Select(o => new OrderList
            {
                Id = o.Id,
                ProductTitle = o.Product!.Title,
                Quantity = o.Quantity,
                OrderAmount = o.Product.Price * o.Quantity,
                Status = o.Status
            })
            .ToListAsync();

        return View(model);
    }

    private void FillSelects(object? selectedClientId = null, object? selectedProductId = null)
    {
        ViewBag.ClientId = new SelectList(_db.Clients.AsNoTracking(), nameof(Client.Id), nameof(Client.Name), selectedClientId);
        ViewBag.ProductId = new SelectList(_db.Products.AsNoTracking(), nameof(Product.Id), nameof(Product.Title), selectedProductId);
    }

    public IActionResult Create()
    {
        FillSelects();
        return View(new Order { Quantity = 1, Status = OrderStatus.Created });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Order order)
    {
        if (!ModelState.IsValid)
        {
            FillSelects(order.ClientId, order.ProductId);
            return View(order);
        }
        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order is null) return NotFound();
        FillSelects(order.ClientId, order.ProductId);
        return View(order);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Order order)
    {
        if (id != order.Id) return BadRequest();
        if (!ModelState.IsValid)
        {
            FillSelects(order.ClientId, order.ProductId);
            return View(order);
        }
        _db.Update(order);
        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var order = await _db.Orders.Include(o => o.Product).Include(o => o.Client).FirstOrDefaultAsync(o => o.Id == id);
        if (order is null) return NotFound();
        return View(order);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var order = await _db.Orders.FindAsync(id);
        if (order is not null)
        {
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}

