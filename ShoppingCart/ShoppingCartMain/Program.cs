using ShoppingCart.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCartMain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("To include offers Enter 'Y' otherise 'N'");
            string ans = Console.ReadLine();
            
            
            //Create Store
            Store shoppingstore = Store.Instance();

            //Add items to the store
            shoppingstore.addStockItem("Apple", 0.60m); //Apples cost 60p
            shoppingstore.addStockItem("Orange", 0.25m); //oranges cost 25p

            if (ans.ToLower() == "y")
            {
                //Add store item offer
                shoppingstore.addStoreItemOffer("Apple", 2, 1); //buy one, get one free on Apples
                shoppingstore.addStoreItemOffer("Orange", 3, 2); //3 for the price of 2 on Oranges
            }
            //Add items to Shopping list
            List<string> shoppingList = new List<string> { "Apple", "Orange", "Apple", "Orange", "Apple", "Orange" }; //For example: [ Apple, Apple, Orange, Apple ]
            Cart shoppingcart = Cart.Instance();
            shoppingcart.addItems(shoppingList);

            //Check out
            decimal totalPrice = shoppingcart.checkout();
            Console.WriteLine(shoppingcart.DisplayItems() + totalPrice);
            Console.ReadLine();
        }
    }
}
