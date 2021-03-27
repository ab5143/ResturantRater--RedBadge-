using ResturantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        // GET: Resturant/Delete/{ID}

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Resturant resturant = _db.Resturants.Find(id);
            if (resturant == null)
            {
                return HttpNotFound();
            }
            return View(resturant);
        }


        //post: resturant/create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult create(Resturant resturant)
        {
            if (ModelState.IsValid)
            {
                _db.Resturants.Add(resturant);
                _db.SaveChanges();

                return RedirectToAction("index");
            }
            return View(resturant);

        }

        // Post: Resturant/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult Delete(int id)
        {
            Resturant resturant = _db.Resturants.Find(id);
            _db.Resturants.Remove(resturant);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }


}
