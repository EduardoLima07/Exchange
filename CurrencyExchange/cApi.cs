using CurrencyExchange.cAuxiliar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CurrencyExchange
{
    public class cApi
    {

        public static string GetRequest(string pCurrency)
        {
            string vURL = "https://api.exchangerate-api.com/v4/latest/";

            try
            {
                if (string.IsNullOrEmpty(pCurrency))
                {
                    return null;
                }

                vURL += pCurrency;

                WebRequest vRequestObjGet = WebRequest.Create(vURL);
                vRequestObjGet.Method = "GET";

                HttpWebResponse vResponseObjGet = null;
                vResponseObjGet = (HttpWebResponse)vRequestObjGet.GetResponse();

                string vStrResult = null;
                using (Stream stream = vResponseObjGet.GetResponseStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    vStrResult = sr.ReadToEnd();
                    sr.Close();
                }

                if (string.IsNullOrEmpty(vStrResult))
                {
                    return null;
                }


                return vStrResult;
               

            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;

            }

        }


    }
}
