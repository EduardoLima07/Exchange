using CurrencyExchange.cAuxiliar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyExchange
{
    public class cCurrency
    {

        public string CurrencyName { get; set; }

        public double Rate { get; set; } 


        public enum Currency
        {
            USD,
            EUR,
            AUD,
            CAD,
            CHF,
            CNY,
            GBP,
            HKD,
            RON,
            JPY,
            NZD,
            SEK,
            KRW,
            SGD,
            NOK,
            MXN,
            INR,
            RUB,
            ZAR,
            TRY,
            BRL,
            TWD,
            DKK,
            PLN,
            THB,
            IDR,
            HUF,
            CZK,
            ILS,
            CLP,
            PHP,
            AED,
            COP,
            SAR,
            MYR
        }

        public double Convert(double pValue1, double pRate)
        {
            try
            {
                Rate = (pValue1 * pRate);

                return Rate;
            }
            catch (Exception)
            {

                return 0;
            }

        }




    }
}
