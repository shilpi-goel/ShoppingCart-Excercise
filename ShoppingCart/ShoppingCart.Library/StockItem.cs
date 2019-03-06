using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Library
{
    /// <summary>
    /// This class represnts item
    /// </summary>
   public class StockItem
    {

        private String itemName;
        private decimal price;

        private StockItem()
        {
        }
       
        private StockItem(String fruit, decimal value)
        {
            itemName = fruit;
            price = value;
        }
       
        public static StockItem create(String fruit, decimal value)
        {
            return new StockItem(fruit, value);
        }

        public decimal getPrice()
        {
            return price;
        }

        public string getItemName()
        {
            return itemName;
        }
    }
}
