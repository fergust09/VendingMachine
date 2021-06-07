using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    class Program
    {
        public static List<VendingItem> VMItems = new List<VendingItem>();
        static void Main(string[] args)
        {
            //VendingMachine list = new VendingMachine();
            VMItems = DisplayVendingMachineItemsMainMenuOption1();
            

            string menuOptionSelected = "";
            while (menuOptionSelected != "3")
            {
                Console.WriteLine("Enter 1 to Display Vending Machine Items");
                Console.WriteLine("Enter 2 to Purchase");
                Console.WriteLine("Enter 3 to Exit");
                menuOptionSelected = Console.ReadLine();
                if (menuOptionSelected == "1")
                {
                    Console.Clear();
                    foreach (VendingItem vendingItem in VMItems)
                    {

                        Console.WriteLine($"{vendingItem.SlotLocation}|{vendingItem.ProductName}|{vendingItem.Price}|{vendingItem.ProductType}|{vendingItem.AmountOfProduct}");

                    }
                    Console.WriteLine();
                    //needs to have qty remaining
                    //need to split file into list
                }
                else if (menuOptionSelected == "2")
                {
                    Console.Clear();
                    Purchase.PurchaseMenu();
                    DisplayVendingMachineItemsMainMenuOption1();
                    
                }
                else
                {
                    Console.WriteLine("exit");
                }
            }
        }


        public static List<VendingItem> DisplayVendingMachineItemsMainMenuOption1()
        {
            //this method is called when option 1 from main menu is selected
            //need to have the menu items diplay within this code block
            //Presented with a LIST of all items
            //needs: QTY Remaining
            //if amount of product == 0, display SOLD OUT
            //slot number
            //purchase price
            string beginningPath = @"C:\Users\Student\git\dotnet-capstone-1-team-0";
            string fileName = "vendingmachine.csv";
            string fullPathName = Path.Combine(beginningPath, fileName);
            List<VendingItem> itemsInVendingMachine = new List<VendingItem>();

            try
            {
                using (StreamReader streamReader = new StreamReader(fullPathName))
                {
                    string itemName = "";
                    string slotLocation = "";
                    string itemPrice = "";
                    decimal newItemPrice = 0.00M;
                    string itemType = "";
                    //loop over the file until there are no more lines
                    while (!streamReader.EndOfStream)
                    {
                        VendingItem vendingItem = new VendingItem();
                        string inputLine = streamReader.ReadLine();
                        string[] specificItemInfo = inputLine.Split("|");
                        vendingItem.SlotLocation = specificItemInfo[0];
                        vendingItem.ProductName = specificItemInfo[1];
                        vendingItem.Price = decimal.Parse(specificItemInfo[2]);
                        vendingItem.ProductType = specificItemInfo[3];

                        itemsInVendingMachine.Add(vendingItem);
                    }
                }
                return itemsInVendingMachine;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("The file does not exist.");
            }
            return itemsInVendingMachine;
        }


       


















    }
}


