using Microsoft.AspNetCore.Mvc;

namespace ViewTask.Controllers;

public class TasksController : Controller
{
    private const int ShippingDaysCount = 3;

    private static readonly string[] Supermarkets = ["WellMart", "Silpo", "ATB", "Furshet", "Metro"];

    private static readonly IReadOnlyDictionary<string, int> ShoppingListItems = new Dictionary<string, int>
    {
        ["Milk"] = 2,
        ["Bread"] = 2,
        ["Cake"] = 1,
        ["Ice Cream"] = 5,
        ["Cola"] = 10,
    };

    public IActionResult SprintTasks() => View();

    public IActionResult Greetings() => View();

    public IActionResult ProductInfo() => View();

    public IActionResult SuperMarkets()
    {
        ViewBag.Supermarkets = Supermarkets;
        return View();
    }

    public IActionResult ShoppingList() => View(ShoppingListItems);

    [HttpGet]
    public IActionResult ShoppingCart()
    {
        ViewBag.Supermarkets = Supermarkets;
        ViewBag.ShippingDates = Enumerable.Range(0, ShippingDaysCount)
            .Select(day => DateTime.Today.AddDays(day))
            .ToList();
        ViewBag.Products = ShoppingListItems.Keys;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ShoppingCart(string fullName, string address) =>
        Content($"Your products will be shipped at: {address}. Bon appetite, {fullName}!");
}
