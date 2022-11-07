using Microsoft.AspNetCore.Mvc;
using SolidPrinciple.Models;
using System.Diagnostics;

namespace SolidPrinciple.Controllers
{
    public class HomeController : Controller
    {
        private readonly OrderValidator orderValidator;
        private readonly IOrderSaver[] orderSaver;
        private readonly OrderNotification orderNotification;

        /*public IActionResult Index()
{
return View();
}
*/

        public HomeController(OrderValidator orderValidator, IOrderSaver[] orderSaver, OrderNotification orderNotification)
        {
            this.orderValidator = orderValidator;
            this.orderSaver = orderSaver;
            this.orderNotification = orderNotification;
        }


        public void Process()
        {
            orderValidator.Validate();
            foreach (var order in orderSaver)
            {
                order.Save(null);
            }
            orderNotification.Notification();
        }


    }

    public class OrderValidator
    {
        public void Validate()
        {

        }
    }

    public interface IOrderSaver
    {
        void Save(string? order);
    }
    public class DbOrderSaver : IOrderSaver
    {
        public void Save( string? order )
        {

        }
    }

    public class CaceOrderSaver : IOrderSaver
    {
        public void Save(string? order)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderNotification
    {
        public void Notification()
        {

        }
    }
}