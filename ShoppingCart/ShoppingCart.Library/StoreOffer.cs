using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Library
{
    /// <summary>
    /// This class represents item offers
    /// </summary>
    public class StoreOffer
    {
        private int itemsInOffer;
        private int itemsPaidFor;
        private int itemsBoughtSoFar = 0;

        private StoreOffer()
        {
        }

        private StoreOffer(int itemsInOffer, int itemsPaidFor)
        {
            this.itemsInOffer = itemsInOffer;
            this.itemsPaidFor = itemsPaidFor;
        }

        public static StoreOffer create(int itemsInOffer, int itemsPaidFor)
        {
            return new StoreOffer(itemsInOffer, itemsPaidFor);
        }

        public bool isItemFree()
        {
            bool itemIsFree;
            // Was previous item on or over the offer limit
            int itemCount = itemsBoughtSoFar % itemsInOffer;

            itemIsFree = itemCount >= itemsPaidFor;

            itemsBoughtSoFar++;
            return itemIsFree;
        }
    }
}
