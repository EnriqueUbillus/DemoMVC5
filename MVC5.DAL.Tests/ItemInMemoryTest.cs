using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC5.DAL.Repositories;
using MVC5.DAL.Repositories.Interfaces;

using MVC5.BLL.Common;

namespace MVC5.DAL.Tests
{
    [TestClass]
    public class ItemInMemoryTest
    {

        private readonly IItemRepository db = new ItemRepositoryInMemoryData();

        [TestMethod]
        public void GetAllItems_Test()
        {
            // Arrange
            var items = db.GetItems();

            int expected = 7;

            //Assert
            Assert.AreEqual(expected, items.Count());
        }


        [TestMethod]
        public void GetItemById_Test()
        {
            // Arrange
            int id = 7;

            var item = db.GetItemById(id);

            //Assert
            Assert.IsNotNull(item);
            Assert.AreEqual(item.Description, "Fargo I");
            Assert.AreEqual(item.ObjectType, ItemType.Serie);
        }


        [TestMethod]
        public void UpdateItemDescription_Test()
        {
            // Arrange
            int id = 7;

            var item = db.GetItemById(id);

            string expected = "Fargo I - Updated";

            //Assert
            Assert.IsNotNull(item);

            // ACT
            item.Description = expected;
            // Assert
            Assert.AreEqual(expected, item.Description);
        }

        [TestMethod]
        public void DeleteOneItem_Test()
        {
            // Arrange
            var items = db.GetItems();
            int expected = 7;


            // ACT
            var item = db.GetItemById(7);

            //Assert
            Assert.AreEqual(expected, items.Count());
            
            // ACT
            db.DeleteItem(item);

            //Assert
            Assert.AreEqual(expected - 1, items.Count());
        }
    }
}
