using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Library;
using System.Collections.Generic;

namespace ShoppingCart.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {
        Cart _shoppingcart;
        Store _store;

        [TestInitialize]
        public void Setup()
        {
            //Create Store
            _store = Store.Instance();

            //Create shopping cart
            _shoppingcart = Cart.Instance();

        }

        [TestMethod]
        [Priority(0)]
        [ExpectedException(typeof(Exception), "No item in shopping cart")]
        public void TestOfCheckOutEmptyShoppingCart()
        {
            decimal amount = _shoppingcart.checkout();
        }


        [TestMethod]
        [Priority(1)]
        public void TestNumberOfItemsAddedWithPricetoStockList()
        {

            //Add items to the store
            _store.addStockItem("Apple", 0.60m); //Apples cost 60p
            _store.addStockItem("Orange", 0.25m); //oranges cost 25p

            Assert.AreEqual(2, _store.GetStockList().Count);
        }

        [TestMethod]
        [Priority(2)]
        public void TestInStockItemsPrice()
        {
            //Add items to the store
            //   _store.addStockItem("Apple", 0.60m); //Apples cost 60p
            //  _store.addStockItem("Orange", 0.25m); //oranges cost 25p

            Assert.AreEqual(0.60m, _store.GetPrice("Apple"));

            Assert.AreEqual(0.25m, _store.GetPrice("Orange"));

        }

        [TestMethod]
        [Priority(3)]
        [ExpectedException(typeof(Exception), "Banana not in stock")]
        public void TestOutOfStockItemsPrice()
        {

            Assert.AreEqual(0.60m, _store.GetPrice("Banana"));

        }

        [TestMethod]
        [Priority(4)]
        public void TestTotalItemsAddedtoShoppingCart()
        {

            List<string> shoppingList = new List<string> { "Apple", "Orange", "Apple", "Orange", "Apple", "Orange" }; //For example: [ Apple, Apple, Orange, Apple ]
            _shoppingcart.addItems(shoppingList);

            Assert.AreEqual(6, _shoppingcart.GetItemsCount());
        }

        [TestMethod]
        [Priority(5)]
        public void TestTotalAmountAtCheckOutShoppingCart()
        {
            //Add items to the store
            /*  _store.addStockItem("Apple", 0.60m); //Apples cost 60p
              _store.addStockItem("Orange", 0.25m); //oranges cost 25p

               List<string> shoppingList = new List<string> { "Apple", "Orange", "Apple", "Orange", "Apple", "Orange" }; 
               _shoppingcart.addItems(shoppingList);
              */
            Assert.AreEqual(2.55m, _shoppingcart.checkout());
        }

        [TestMethod]
        [Priority(6)]
        public void TestSameCartInstanceSingleton()
        {
            Cart _newinstance = Cart.Instance();

            Assert.AreEqual(_shoppingcart, _newinstance);
        }


        [TestMethod]
        [Priority(7)]
        public void TestOffer3forthepriceof2()
        {
            StoreOffer offer = StoreOffer.create(3, 2);

            Assert.IsFalse(false, "1st Item not free", offer.isItemFree());
            Assert.IsFalse(false, "2nd Item not free", offer.isItemFree());
            Assert.IsTrue(true, "3rd Item free", offer.isItemFree());
            Assert.IsFalse(false, "4th Item not free", offer.isItemFree());
            Assert.IsFalse(false, "5th Item not free", offer.isItemFree());
            Assert.IsTrue(true, "6th Item free", offer.isItemFree());
        }

        [TestMethod]
        [Priority(8)]
        public void TestOfferBuyOneGetOneFree()
        {
            StoreOffer offer = StoreOffer.create(2, 1);

            Assert.IsFalse(false, "1st Item not free", offer.isItemFree());
            Assert.IsTrue(true, "2nd Item is free", offer.isItemFree());

        }

        [TestMethod]
        [Priority(9)]
        public void TestNumberOfOffersAddedToItems()
        {
            //Add store item offer
            _store.addStoreItemOffer("Apple", 2, 1); //buy one, get one free on Apples
            _store.addStoreItemOffer("Orange", 3, 2); //3 for the price of 2 on Oranges

            Assert.AreEqual(2, _store.GetStoreOffers().Count);

        }

        [TestMethod]
        [Priority(10)]
        public void TestTotalAmountAtCheckOutShoppingCartAfteOfferAdded()
        {
            //Add items to the store
            /*  _store.addStockItem("Apple", 0.60m); //Apples cost 60p
              _store.addStockItem("Orange", 0.25m); //oranges cost 25p

               List<string> shoppingList = new List<string> { "Apple", "Orange", "Apple", "Orange", "Apple", "Orange" }; 
               _shoppingcart.addItems(shoppingList);
            
              //Add store item offer
            _store.addStoreItemOffer("Apple", 2, 1); //buy one, get one free on Apples
            _store.addStoreItemOffer("Orange", 3, 2); //3 for the price of 2 on Oranges

              */


            Assert.AreEqual(1.7m, _shoppingcart.checkout());
        }

       

    }
}
