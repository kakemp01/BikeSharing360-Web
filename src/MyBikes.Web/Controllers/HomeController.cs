﻿using ReportGenerationLib;
using MyBikes.Web.Models.Home;
using System;
using System.Web.Mvc;

namespace MyBikes.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetClients()
        {
            var ticks = DateTime.Now.Ticks;
            var cityRouter = (int)(ticks % 2);

            var cityName = CityLookup.Lookup(cityRouter);

            return View("ClientsView", new ClientsViewModel { CityName = cityName });
        }
    }


}