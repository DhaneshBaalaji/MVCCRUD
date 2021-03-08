using RESTAURANTCRUDAUTH.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAURANTCRUDAUTH.Data.Services
{
    public class RestaurantDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }//Collection of all entities in the context
    }

}
