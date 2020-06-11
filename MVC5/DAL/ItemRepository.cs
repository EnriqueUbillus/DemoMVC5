//using MVC5.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;

//namespace MVC5.DAL
//{
    //public class ItemRepository : IItemRepository
    //{
    //    private readonly ItemContext _itemContext;

    //    public ItemRepository(ItemContext itemContext)
    //    {
    //        _itemContext = itemContext;
    //    }

    //    public void DeleteItem(int id)
    //    {
    //        var item = GetItemByID(id);
    //        _itemContext.Items.Remove(item);
    //    }

    //    public Item GetItemByID(int id)
    //    {
    //        return _itemContext.Items.FirstOrDefault(x => x.Id == id);
    //    }

    //    public IEnumerable<Item> GetItems()
    //    {
    //        return _itemContext.Items.ToList();
    //    }

    //    public void InsertItem(Item item)
    //    {
    //        _itemContext.Items.Add(item);
    //    }

    //    public void Save()
    //    {
    //        _itemContext.SaveChanges();
    //    }

    //    public void UpdateItem(Item item)
    //    {
    //        _itemContext.Entry(item).State = EntityState.Modified;
    //    }

    //    private bool disposed = false;

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!this.disposed)
    //        {
    //            if (disposing)
    //            {
    //                _itemContext.Dispose();
    //            }
    //        }
    //        this.disposed = true;
    //    }
    //    public void Dispose()
    //    {
    //        Dispose(true);
    //        GC.SuppressFinalize(this);
    //    }
    //}
//}