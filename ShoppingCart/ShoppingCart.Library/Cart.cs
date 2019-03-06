using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Library
{
    /// <summary>
    /// implemented Singelton pattern 
    /// </summary>
    public class Cart
    {
        private static Cart _instance;

        private List<StockItem> _items;
        private List<StockItem> _paidItems;
        private Store _store;
        

        protected Cart()
        {
            _store = Store.Instance();
            _items = new List<StockItem>();
            _paidItems = new List<StockItem>();

        }

        public static Cart Instance()
        {
            //Uses lazy Initialization
            if (_instance == null)
                _instance = new Cart();


            return _instance;
        }

        public void addItems(List<string> itemNames)
        {
            Dictionary<string, StockItem> stockList = _store.GetStockList();
            if (stockList.Count <= 0)
                throw new Exception("No item in store");

            foreach (var itemName in itemNames)
            {
                StockItem item = stockList[itemName];
                if (item == null)
                {
                    throw new Exception(itemName + " not in stock");
                }
                _items.Add(item);
            }
        }

        public void removeItems(List<string> itemNames)
        {

            Dictionary<string, StockItem> stockList = _store.GetStockList();
            if (stockList.Count <= 0)
                throw new Exception("No item in store");

            foreach (var itemName in itemNames)
            {
                StockItem item = stockList[itemName];
                if (item == null)
                {
                    throw new Exception(itemName + " not in stock");
                }
                _items.Remove(item);
            }
        }


        public decimal checkout()
        {
            if (_items.Count <= 0)
                throw new Exception("No item in shopping cart");

            decimal totalPrice = 0;

            //Updated checkout functions accordingly
            Dictionary<string, StoreOffer> itemOffers = _store.GetStoreOffers();

            foreach (StockItem item in _items)
            {

                StoreOffer offer = itemOffers.FirstOrDefault(t => t.Key == item.getItemName()).Value;
                if ((offer == null) || (!offer.isItemFree()))
                {
                    totalPrice += item.getPrice();
                }
            }
            return totalPrice;
        }

        public int GetItemsCount()
        {
            return _items.Count;
        }

        public string DisplayItems()
        {
            string inputItems = string.Empty;
            foreach (StockItem item in _items)
            {
                inputItems = inputItems + item.getItemName() + ", ";
            }

            return string.Concat(inputItems, " -> ");
        }

    }
}
