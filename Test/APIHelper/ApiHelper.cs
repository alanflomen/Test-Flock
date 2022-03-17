using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Test.APIHelper
{
    public class ApiHelper
    {
        public Root CallAuth(string provincia)

        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://apis.datos.gob.ar/georef/api/provincias?nombre=" + provincia);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                httpWebRequest.Timeout = 20000;
                
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                var streamReader = new StreamReader(httpResponse.GetResponseStream());

                var streamResponse = streamReader.ReadToEnd();

                return JsonConvert.DeserializeObject<Root>(streamResponse);
            }
            catch (Exception exc)
            {
                throw new Exception(exc.Message);
            }


        }
    }
}