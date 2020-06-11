//using MVC5.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Http.ModelBinding;

//namespace MVC5.DAL
//{
//    public class InMemoryRepoData : IItemRepository
//    {

//        public List<Item> Items = new List<Item>();
//        public InMemoryRepoData()
//        {
//            Items = new List<Item>()
//            {
//                new Item { Id = 1, ObjectType = ItemType.Film, Description = "Film 01" },
//                new Item { Id = 2, ObjectType = ItemType.Pdf, Description = "Cooking book" },
//                new Item { Id = 3, ObjectType = ItemType.Other, Description = "Keyboard" },
//                new Item { Id = 4, ObjectType = ItemType.Serie, Description = "Fargo" },
//                new Item { Id = 5, ObjectType = ItemType.Film, Description = "New days" }
//            };
//        }

//        public IEnumerable<Item> GetItems()
//        {
//            return from i in Items
//                   orderby i.ObjectType
//                   select i;
//        }

//        public Item GetItemByID(int id)
//        {
//            return Items.FirstOrDefault(x => x.Id == id);
//        }

//        public void InsertItem(Item newItem)
//        {
//            newItem.Id = Items.Max(r => r.Id) + 1;
//            Items.Add(newItem);
//        }

//        public void DeleteItem(int id)
//        {
//            var itemToRemove = GetItemByID(id);

//            Items.Remove(itemToRemove);
//        }

//        public void UpdateItem(Item item)
//        {
//            var itemToUpdate = GetItemByID(item.Id);
//            if (itemToUpdate != null)
//            {
//                itemToUpdate.Description = item.Description;
//                itemToUpdate.ObjectType = item.ObjectType;
//            }
//        }

//        public void Save()
//        {
                        
//        }

//        public void Dispose()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
