using RESTAURANTCRUDAUTH.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAURANTCRUDAUTH.Data.Services
{
    public class SqlRestaurantData : IRestaurant
    {
        private readonly RestaurantDbContext db;
        public SqlRestaurantData(RestaurantDbContext db)//Dependency injection with Autofac
        {
            this.db = db;//Instead of instantiating the context inside the constructor of another class - causing tight coupling, we use a container to tackle this

        }
        public void Add(Restaurant restaurant)
        {
            db.Restaurants.Add(restaurant);//Unit of Work Design pattern(records the changes but no save), we need to save changes
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
            db.SaveChanges();
        }

        public void Edit(int id, Restaurant restaurant)
        {
            var res = db.Restaurants.Where(rest => rest.Id == id);
            foreach (var r in res)
            {
                r.Name = restaurant.Name;
                r.Cuisine = restaurant.Cuisine;
                r.Address = restaurant.Address;
                r.Pin = restaurant.Pin;
                r.Phone = restaurant.Phone;
                r.Date = restaurant.Date;
            }
            //Optimistic concurrency for edit is prefered, Multiple users cannot override each others data
            //We can check if the restauarnt has'nt changed since the user entered the data
            //var entry = db.Entry(restaurant);//Providing access to the info about the entity
            //entry.State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public Restaurant Get(int id)
        {
            return db.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return db.Restaurants.OrderBy(rest => rest.Name);
        }
    }

}
