//using MVC5.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;

//namespace MVC5.DAL
//{
//    public class ItemContext : DbContext
//    {
//        public ItemContext() : base("name=ItemCatalogueConnectionString")
//        {
//            //Disable initializer
//            Database.SetInitializer<ItemContext>(null);
//        }

//        public DbSet<Item> Items { get; set; }
//    }
//}