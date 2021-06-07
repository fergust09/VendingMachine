using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public abstract class VendingMachine
    {
        //private AuditLog auditLog = new AuditLog();


      

        //FileReader ReadFiles = new FileReader();

        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string SlotLocation { get; set; }
        public string ProductType { get; set; }
        public int AmountOfProductToVend { get; set; } = 5;
        public decimal Balance { get; set; } = 0.00M;

        public VendingMachine(string slotLocation, string productName, decimal price, int amtOfProductToVend)//constructor 
        {
            this.ProductName = productName;
            this.Price = price;
            this.SlotLocation = slotLocation;
            this.AmountOfProductToVend = amtOfProductToVend;
        }


        



             



        

       



        


        

        
    } 
}


