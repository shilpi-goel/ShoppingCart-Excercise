using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Library
{
    /// <summary>
    /// This class represent store
    /// You can add stock to the store
    /// You can get price of a particular item
    /// You can buy items, add items to your basket
    /// you can checkout
    /// 
    ///    
    /// implemented Singelton pattern
    /// </summary>
    public class Store
    {
        private static Store _instance;

        private static Dictionary<String, StockItem> stockList = new Dictionary<String, StockItem>();
        private static Dictionary<String, StoreOffer> storeOffers = new Dictionary<String, StoreOffer>();

        //Constructor is protected
        protected Store()
        {
        }

        public static Store Instance()
        {
            //Uses lazy initilisation
            if (_instance == null)
                _instance = new Store();

            return _instance;
        }

        public void addStockItem(String itemName, decimal value)
        {
            if (!stockList.ContainsKey(itemName))
            {
                StockItem stockItem = StockItem.create(itemName, value);
                stockList.Add(itemName, stockItem);
            }
            else
            {
                throw new Exception("Item alredy added in the store");
            }
        }

        public void removeStockItem(String itemName)
        {
            if (stockList.ContainsKey(itemName))
            {
                stockList.Remove(itemName);
            }
            else
            {
                throw new Exception("Item does not exists in the store");
            }
        }

        public void addStoreItemOffer(String itemName, int itemsInOffer, int vaitemsPaidForlue)
        {
            if (!storeOffers.ContainsKey(itemName))
            {
                StoreOffer storeOffer = StoreOffer.create(itemsInOffer, vaitemsPaidForlue);
                storeOffers.Add(itemName, storeOffer);
            }
            else
            {
                throw new Exception("Offer already added for this item");
            }
        }

        public void removeStoreItemOffer(String itemName)
        {
            if (storeOffers.ContainsKey(itemName))
            {

                storeOffers.Remove(itemName);
            }
            else
            {
                throw new Exception("There is no offer for this item");
            }
        }


        public Dictionary<String, StockItem> GetStockList()
        {
            return stockList;
        }

        public Dictionary<String, StoreOffer> GetStoreOffers()
        {
            return storeOffers;
        }

        public decimal GetPrice(string itemName)
        {
            StockItem item = stockList.FirstOrDefault(t => t.Key == itemName).Value;
            if (item == null)
            {
                throw new Exception(itemName + " not in stock");
            }
            return (item.getPrice());
        }

    }
}
