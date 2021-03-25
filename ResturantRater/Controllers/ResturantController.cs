using ResturantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantRater.Controllers
{
    public class ResturantController : Controller
    {
        // GET: Resturant
        
        private ResturantDbContext _db = new ResturantDbContext();
    
        public ActionResult Index()
        {
            return View(_db.Resturants.ToList());
        }

        // Get Resturant/Create

        public ActionResult Create()
        {
            return View();
        }
    }
}