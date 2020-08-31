using System;
using System.Collections.Generic;   
using BartenderApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BartenderApp.Controllers
{

    public class HomeController : Controller
    {

       

        private static int id = 0;


       
        public static List<Drink> Orders = new List<Drink>();
       


        
        private static List<Drink> drinks
            = new List<Drink>()
            {
                new Drink {Name = "New Yorker", Description = "Vodak, Gin, Rum", Price = 10},
                new Drink {Name = "Rum and Coke", Description = "Rum mostly coke", Price = 6},
                new Drink {Name = "Mojito", Description = "Mint and vodka", Price = 9},
                new Drink {Name = "Moscow Mule", Description = "Ginger Beer and vodka", Price = 8}
            };


        
        public ActionResult Index() 
        {

            return View(drinks);
        }


        
        public RedirectToRouteResult Order(Drink drink) 
        {
            drink.Id = ++id;
            Orders.Add(drink);
            return RedirectToActionResult("Index");
        }

        private RedirectToRouteResult RedirectToActionResult(string v)
        {
            throw new NotImplementedException();
        }
    }
}
