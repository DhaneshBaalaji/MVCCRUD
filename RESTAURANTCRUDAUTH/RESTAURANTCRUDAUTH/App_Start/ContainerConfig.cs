using Autofac;
using Autofac.Integration.Mvc;
using RESTAURANTCRUDAUTH.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RESTAURANTCRUDAUTH
{
    public class ContainerConfig
    {
        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SqlRestaurantData>().As<IRestaurant>().InstancePerRequest();
            builder.RegisterType<RestaurantDbContext>().InstancePerRequest();//Context Injected into constructor
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}