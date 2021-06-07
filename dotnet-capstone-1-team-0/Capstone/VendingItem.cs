using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class VendingItem
    {
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public decimal Price { get; set; }
        public string SlotLocation { get; set; }
        public int AmountOfProduct { get; set; } = 5;
        public string SoldOutMessage
        {
            get
            {
                return "Item is Sold Out.";
            }
        }

        public string ItemTypeDispenseMessage

        {
            get
            {
                if (ProductType == "Chip")
                {
                    return "Crunch Crunch, Yum!";
                }
                else if (ProductType == "Candy")
                {
                    return "Munch Munch, Yum!";
                }
                else if (ProductType == "Drink")
                {
                    return "Glug Glug, Yum!";
                }
                else if (ProductType == "Gum")
                {
                    return "Chew Chew, Yum!";

                }
                else
                {
                    return "null";
                }
            }
        }
        

        public VendingItem()
        {

        }
        public VendingItem(string slotLocation, string productName, decimal price, int amountOfProduct)
        {
            ProductName = productName;
            Price = price;
            SlotLocation = slotLocation;
            AmountOfProduct = amountOfProduct;
        }
        //add message when vended 

        public bool RemoveItem()
        {
            if (this.AmountOfProduct > 0)
            {
                this.AmountOfProduct--;
                return true;
            }
            return false;
        }


    }
}
