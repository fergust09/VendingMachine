using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Purchase
    {
        public static decimal totalAmountInserted = 0.00M;
        public static decimal updatedBalance = 0.00M;
        public static DateTime dateString = DateTime.Now;
        public static void PurchaseMenu()
        {
            
            Console.Clear();
            Console.WriteLine("(1) Feed Money");
            Console.WriteLine("(2) Select Product");
            Console.WriteLine("(3) Finish Transaction");
            Console.WriteLine("Please select an option: ");

            string userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Purchase.FeedMoney();
                
            }
            else if (userInput == "2")
            {
               
                
                foreach (VendingItem vendingItem in Program.VMItems)
                {

                    Console.WriteLine($"{vendingItem.SlotLocation}|{vendingItem.ProductName}|{vendingItem.Price}|{vendingItem.ProductType}|{vendingItem.AmountOfProduct}");

                }
                    

                SelectProductSubMenu();
            }
            else if (userInput == "3")
            {
                
                AuditLog auditLog = new AuditLog();
                AuditLog.AuditLogReport(dateString, "GIVE CHANGE: ", totalAmountInserted, 0.00M);

                DispenseChange();

            }
            else
            {
                PurchaseMenu();
            }
        }
        public static void FeedMoney()
        {
            decimal amountInserted = 0.00M;


            Console.WriteLine($"Current money provided ${totalAmountInserted}");
            Console.WriteLine("Please enter money in whole dollars ($1, $2, $5, $10)");
            try
            {
                amountInserted = decimal.Parse(Console.ReadLine());
                if (amountInserted > 0.00M)
                {
                    totalAmountInserted += amountInserted;
                    AuditLog auditLog = new AuditLog();
                    AuditLog.AuditLogReport(dateString, "FEED MONEY: ", amountInserted, totalAmountInserted);
                }
                Console.WriteLine($"Current money provided ${totalAmountInserted}");
                PurchaseMenu();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please insert a valid amount.");
                Console.ReadLine();
                PurchaseMenu();
            }
        }

        public static void SelectProductSubMenu()
        {
            //calls OPTION 2 from main menu
            //calls a subMENU
            //show the available list



            Console.WriteLine($"Current money provided ${totalAmountInserted}\n");
            //prompt user to enter a code to purchase item
            Console.WriteLine("Please enter Slot Location for your desired item: ");
            string userSelection = Console.ReadLine();
            //if item code does not exist
            foreach (VendingItem vendingItem in Program.VMItems)
            {
                if (userSelection == vendingItem.SlotLocation && vendingItem.AmountOfProduct > 0 && totalAmountInserted >= vendingItem.Price)
                {
                    vendingItem.AmountOfProduct--;
                    AuditLog auditLog = new AuditLog();
                    AuditLog.AuditLogReport(dateString, vendingItem.ProductName, vendingItem.SlotLocation, totalAmountInserted, totalAmountInserted - vendingItem.Price);
                    totalAmountInserted -= vendingItem.Price;
                    Console.WriteLine($"Dispensing {vendingItem.ProductName} at ${vendingItem.Price}\n {vendingItem.ItemTypeDispenseMessage}");
                    Console.ReadLine();
                    PurchaseMenu();
                }
                else if (userSelection == vendingItem.SlotLocation && vendingItem.AmountOfProduct > 0 && totalAmountInserted < vendingItem.Price)
                {
                    Console.WriteLine("Please enter more money");
                    Console.ReadLine();
                    PurchaseMenu();
                }
                else if (userSelection == vendingItem.SlotLocation && vendingItem.AmountOfProduct == 0)
                {
                    Console.WriteLine($"{vendingItem.SoldOutMessage}. Insert more money or Exit Program.");
                    Console.ReadLine();
                    PurchaseMenu();
                }
            }
            if (!Program.VMItems.Exists(userItemChoice => userItemChoice.SlotLocation.ToLower() == userSelection.ToLower()))
            {
                Console.WriteLine("Selected item does not exist. Please choose another option.");
                Console.ReadLine();
                PurchaseMenu();
            }

        }

        //customer is informed & returned to Purchase Menu
        //if sold out
        //customer is informed and returned to Purchase menu
        //if valid item selected
        //dispense item to customer & print the item name, cost, and balance
        //also returns a message for each type of item
        //machine must update balance 
        //return customer to Purchase menu



        public static void DispenseChange()
        {
            int dollars = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;

            while (totalAmountInserted >= 1.00M)
            {
                dollars = dollars + 1;
                totalAmountInserted = totalAmountInserted - 1.00M;
            }
            while (totalAmountInserted >= 0.25M)
            {
                quarters = quarters + 1;
                totalAmountInserted = totalAmountInserted - 0.25M;
            }
            while (totalAmountInserted >= 0.1M)
            {
                dimes = dimes + 1;
                totalAmountInserted = totalAmountInserted - 0.10M;
            }
            while (totalAmountInserted >= 0.05M)
            {
                nickels = nickels + 1;
                totalAmountInserted = totalAmountInserted - 0.05M;
            }
            Console.WriteLine($"Your change due is: {dollars} dollars, {quarters} quarters, {dimes} dimes, {nickels} nickels.");

























        }
    }
}
