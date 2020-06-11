using MVC5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC5.Repository
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItemById(int? id);
        void InsertItem(Item  item);
        void UpdateItem(Item  item);
        void DeleteItem(Item  item);
    }
}
