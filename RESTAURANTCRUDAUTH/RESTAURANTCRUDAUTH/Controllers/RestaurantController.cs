using RESTAURANTCRUDAUTH.Data.Model;
using RESTAURANTCRUDAUTH.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANTCRUDAUTH.Controllers
{
    public class RestaurantController : Controller
    {
        IRestaurant db;
        public RestaurantController(IRestaurant db)
        {
            this.db = db;
        }
        public RestaurantController()
        {

        }
        // GET: Restaurant

        [HttpGet]
        public ActionResult Index()
        {
            var model = db.GetAll();
            if (User.IsInRole("CanViewDetails"))
            {
                return View("OperatorIndex",model);
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");//pass a string to the view which corresponds to a particular view in the Views folder
                //return RedirectToAction("Index")
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        public bool DateValidation(Restaurant restaurant)
        {
            if (!((restaurant.Date - DateTime.Now).TotalDays < 0))
            {
                return true;
            }
            return false;

        }
        public bool PhoneValidation(Restaurant restaurant)
        {
            var model = db.GetAll();

            foreach (var entry in model)
            {

                if (entry.Id != restaurant.Id && entry.Phone == restaurant.Phone)
                {
                    return true;

                }

            }
            return false;

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            ////Low-level attempt at Validations, DATA ANNOTATIONS ARE USED FOR COMMON VALIDATION CHECKS

            bool phoneCheck = PhoneValidation(restaurant);
            if (phoneCheck)
            {
                ModelState.AddModelError(nameof(restaurant.Phone), "Phone number already exists!!");//Validation check for Existing Phone numbers
            }
            bool dateCheck = DateValidation(restaurant);
            if (dateCheck)
            {
                ModelState.AddModelError(nameof(restaurant.Date), "Invalid Date --> Future dates!!");
            }

            if (ModelState.IsValid)
            {
                TempData["message"] = "You have created a Restaurant!";
                db.Add(restaurant);
                return RedirectToAction("Details", new { id = restaurant.Id });//The parameters to the redirect action is passed as an anonymous type
            }
            return View();//View with all the errors

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");//pass a string to the view which corresponds to a particular view in the Views folder
                //return RedirectToAction("Index")
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            bool phoneCheck = PhoneValidation(restaurant);
            if (phoneCheck)
            {
                ModelState.AddModelError(nameof(restaurant.Phone), "Phone number already exists!!");//Validation check for Existing Phone numbers
            }
            bool dateCheck = DateValidation(restaurant);
            if (dateCheck)
            {
                ModelState.AddModelError(nameof(restaurant.Date), "Invalid Date --> Future dates!!");
            }
            if (ModelState.IsValid)
            {
                db.Edit(restaurant.Id, restaurant);
                TempData["message"] = "You have saved the Restaurant!";
                return RedirectToAction("Details", new { id = restaurant.Id });//The parameters to the redirect action is passed as an anonymous type
            }
            return View(restaurant);//View with all the errors

        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if (model == null)
            {
                return View("NotFound");//pass a string to the view which corresponds to a particular view in the Views folder
                //return RedirectToAction("Index")
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)//Two methods with same name and parameters, we can use a throwaway parameter to segregate them
        {
            TempData["message"] = "You have Deleted the Restaurant!";
            db.Delete(id);
            return RedirectToAction("Index");


        }
    }

}