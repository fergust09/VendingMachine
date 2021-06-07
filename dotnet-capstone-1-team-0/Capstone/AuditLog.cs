using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class AuditLog
    {
        //everytime action is taken, the AuditLog is called 
        //Two diff types of Log
        //purchase log (money coming in/out)
        //sales report in Log.txt
       //public static string auditLogLine = $"{dateString} {message} ${totalMoneyInserted} ${moneyAfterTransaction}";
        public static void AuditLogReport(DateTime dateString, string message, decimal totalMoneyInserted,  decimal moneyAfterTransaction)
        {

            ExtraAuditLog($"{dateString} {message} ${totalMoneyInserted} ${moneyAfterTransaction}");

          
        }

        public static void AuditLogReport(DateTime dateString, string message, string slotLocation, decimal totalMoneyInserted, decimal moneyAfterTransaction)
        {

            ExtraAuditLog($"{dateString} {message} {slotLocation} ${totalMoneyInserted} ${moneyAfterTransaction}");
            

        }

        public static void ExtraAuditLog(string logMessage)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\Student\git\dotnet-capstone-1-team-0\Log.txt", true))
                {
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
