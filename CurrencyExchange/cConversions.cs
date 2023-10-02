using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    class cConversions
    {
        public string Currency1 { get; set; }
        public string Currency2 { get; set; }
        public double Rate { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }


        public cConversions AddFeed(string pCurrency1, string pCurrency2, double pRate, double pValue1, double pValue2)
        {
            cConversions cConversion = null;

            try
            {
                cConversion = new cConversions()
                {
                    Currency1 = pCurrency1,
                    Currency2 = pCurrency2,
                    Rate = pRate,
                    Value1 = pValue1,
                    Value2 = pValue2,

                };

                return cConversion;

            }
            catch (Exception)
            {
                return cConversion;
            }

            

        }

    }
}
