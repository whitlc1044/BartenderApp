using System;
using System.Collections.Generic;
using System.Linq;
using BartenderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BartenderApp.Controllers
{
    // This Controller contains methods to add a drink to the "ready" List and remove it from "Orders" List
    // To remove the drink from the ready List once served,  To display the Ordered View, And the Prepared View
    public class QueueController : Controller
    {
        // This list is used to hold the drinks that are ready to be served
        private static List<Drink> ready = new List<Drink>();

        // This method is used to display the ordered drinks view in tabular format
        public ActionResult ViewOrdersTable()

        {
            return View(HomeController.Orders);
        }

        public RedirectToRouteResult Prepared(Drink drink)
        {
            ready.Add(drink);

            
            var drinkToRemove = HomeController.Orders.Where(x => x.Id == drink.Id);         
            HomeController.Orders.Remove(drinkToRemove.FirstOrDefault());

            return RedirectToActionResult ("ViewOrdersTable");
        }


       
        public ActionResult ViewPreparedTable()

        {
            return View(ready); 
        }


       
        public RedirectToRouteResult Served(Drink drink)
        {
            ready.RemoveAll(x => x.Id == drink.Id);
            return RedirectToActionResult ("ViewPreparedTable");
        }

        private RedirectToRouteResult RedirectToActionResult(string v)
        {
            throw new NotImplementedException();
        }
    }
}