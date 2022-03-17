using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Test.Logs
{
    public class LogsHelper
    {
        string FILE_NAME = @"D:\Log-Test-Tecnico.txt";
        public LogsHelper()
        {
            
            if (!File.Exists(FILE_NAME))
            {
                var file = FILE_NAME;
                File.WriteAllText(file, DateTime.Now.ToString() + " - INICIO DEL LOG" + Environment.NewLine);
            }
        }
        public void EscribirEnLog(string texto)
        {
            using (StreamWriter sw = new StreamWriter(FILE_NAME, true))
            {
                  sw.WriteLine(DateTime.Now.ToString() + " - " + texto);
            }
        }
    }
}