using System;
using System.ComponentModel;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVC5.DAL.Repositories;
using MVC5.DAL.Repositories.Interfaces;

using MVC5.BLL.Common;
using Moq;
using MVC5.BLL.Models;
using System.Collections;
using System.Collections.Generic;

namespace MVC5.DAL.Tests
{
    [TestClass]
    public class ItemCRUDTest
    {

        private readonly IItemRepository db = new ItemRepository();
        
        //private readonly ItemRepositoryInMemoryData dbInMemory = new ItemRepositoryInMemoryData();


        //private List<Item> items = ;

        [TestMethod]
        public void GetAllItems_Test()
        {

            var repoMock = new Mock<IItemRepository>();

            repoMock.Setup(x => x.GetItems()).Returns(new List<Item>());

            repoMock.Verify(s => s.GetItems(), Times.Once());
        }


        [TestMethod]
        public void GetItemById_Test()
        {
            // Arrange
            int id = 7;
            //Assert

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
            Console.WriteLine(item.Description);

            // ACT
            item.Description = expected;
            db.UpdateItem(item);
            // Assert
            Assert.AreEqual(expected, item.Description);
            Console.WriteLine(item.Description);

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
