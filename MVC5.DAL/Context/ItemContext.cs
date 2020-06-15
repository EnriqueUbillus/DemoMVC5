using MVC5.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.DAL.Context
{
    public class ItemContext : DbContext
    {
        public ItemContext() : base("name=ItemContext")
        {
            //Disable initializer
            //Database.SetInitializer<ItemContext>(null);
           
        }

        public DbSet<Item> Items { get; set; }
    }
}
