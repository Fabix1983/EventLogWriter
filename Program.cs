using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace EventLogWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INIZIO");

            string Testo = "";
            string AppName = "My C# console APP per scrittura nell'event Log di windows";

            try
            {
                Testo = "Questo è un log event di tipo informazione";
                EventLogWriter(1, AppName + " - " + Testo);

                Testo = "Questo è un log event di tipo warning";
                EventLogWriter(2, AppName + " - " + Testo);

                Testo = "Questo è un log event di tipo errore";
                EventLogWriter(3, AppName + " - " + Testo);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errore catch " + ex.Message.ToString());
            }

            Console.WriteLine("FINE");
            Console.ReadLine();
        }

        public static void EventLogWriter(int type, string Testo)
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                eventLog.Source = "Application";

                if (type == 1) // Information
                {
                    eventLog.WriteEntry(Testo, EventLogEntryType.Information);
                }

                if (type == 2) // Warning
                {
                    eventLog.WriteEntry(Testo, EventLogEntryType.Warning);
                }

                if (type == 3) // Error
                {
                    eventLog.WriteEntry(Testo, EventLogEntryType.Error);
                }
            }
        }


    }
}
