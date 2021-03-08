using RESTAURANTCRUDAUTH.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTAURANTCRUDAUTH.Data.Services
{
    public interface IRestaurant
    {
        IEnumerable<Restaurant> GetAll();//Returns an enumerator which can be iterated
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        void Edit(int id, Restaurant restaurant);
        void Delete(int id);
    }

}
