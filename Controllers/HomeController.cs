using Maiboroda_Flowers.Migrations;
using Maiboroda_Flowers.Models;
using Maiboroda_Flowers.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maiboroda_Flowers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        List<Order> orders = new List<Order>();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOrder()
        {
            return View();
        }
        public IActionResult Orders()
        {
            DbOrderContext context = new DbOrderContext();
            orders = context.Orders.ToList().OrderBy(a => a.Id).ToList();

            return View(orders);
        }
        public IActionResult OrderItem(int Id)
        {
            DbOrderContext context = new DbOrderContext();
            var model = context.Orders.Where(s => s.Id == Id).FirstOrDefault();
            return View(model);
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult CreateOrder_AddNewItem(OrderRequest request)
        {

            using (var db = new DbOrderContext())
            {
                try
                {
                    Order order = db.Orders.FirstOrDefault(s => s.Id == request.Id);
                    if (order == null)
                    {
                        order = new Order
                        {
                            CitySender = request.CitySender,
                            AddressSender = request.AddressSender,
                            CityRecipient = request.CityRecipient,
                            AddressRecipient = request.AddressRecipient,
                            ProductWeight = request.ProductWeight,
                            DateReceipt = request.DateReceipt
                        };
                        db.Add(order);
                        db.SaveChanges();
                    }

                    return new EmptyResult();
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}