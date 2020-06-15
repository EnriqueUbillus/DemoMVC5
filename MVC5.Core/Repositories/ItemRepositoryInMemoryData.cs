using MVC5.DAL.Repositories.Interfaces;
using MVC5.BLL.Models;
using MVC5.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MVC5.DAL.Context;
//using System.Web.Http.ModelBinding;

namespace MVC5.DAL.Repositories
{
    public class ItemRepositoryInMemoryData : IItemRepository
    {

        public List<Item> Items = new List<Item>();
        public ItemRepositoryInMemoryData()
        {

            Items = new List<Item>()
            {
                new Item { Id = 1, ObjectType = ItemType.Film, Description = "Film 01" },
                new Item { Id = 2, ObjectType = ItemType.Pdf, Description = "Cooking book" },
                new Item { Id = 3, ObjectType = ItemType.Other, Description = "Keyboard" },
                new Item { Id = 4, ObjectType = ItemType.Serie, Description = "Fargo" },
                new Item { Id = 5, ObjectType = ItemType.Film, Description = "New days" },
                new Item { Id = 6, ObjectType = ItemType.Film, Description = "IN MEMORY" }
            };

        }

        public IEnumerable<Item> GetItems()
        {
            return from i in Items
                   orderby i.ObjectType
                   select i;
        }

        public Item GetItemById(int? id)
        {
            return Items.FirstOrDefault(x => x.Id == id);
        }

        public void InsertItem(Item newItem)
        {
            newItem.Id = Items.Max(r => r.Id) + 1;
            Items.Add(newItem);
        }

        public void DeleteItem(Item item)
        {
            var itemToRemove = GetItemById(item.Id);

            Items.Remove(itemToRemove);
        }

        public void UpdateItem(Item item)
        {
            var itemToUpdate = GetItemById(item.Id);
            if (itemToUpdate != null)
            {
                itemToUpdate.Description = item.Description;
                itemToUpdate.ObjectType = item.ObjectType;
            }
        }

        public void Save()
        {

        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
