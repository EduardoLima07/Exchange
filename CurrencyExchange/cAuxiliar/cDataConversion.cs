using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace CurrencyExchange.cAuxiliar
{
    public class cDataConversion
    {
		public String ConvertToString(object pValue)
		{
			string vResult = "";

			try
			{
				if (!string.IsNullOrEmpty(pValue?.ToString()))
				{
					vResult = Convert.ToString(pValue?.ToString());
					
				}

				return vResult;

			}
			catch (Exception)
			{
				return vResult;
			}
		}

		public Int32 ConvertToInt32(object pValue)
		{
			Int32 vResult = 0;

			try
			{
				if(pValue != null)
				{
					vResult = Convert.ToInt32(pValue?.ToString());
				}

				return vResult;
			}
			catch (Exception)
			{
				return vResult;
			}
		}

		public Int64 ConvertToInt64(object pValue)
		{
			Int64 vResult = 0;

			try
			{
				if (pValue != null)
				{
					vResult = Convert.ToInt64(pValue);
				}

				
				return vResult;
			}
			catch (Exception)
			{
				return vResult;
			}
		}

		public Double ConvertToDouble(object pValue)
		{
			double vResult = 0;

			try
			{
				if(pValue != null)
				{
					vResult = Convert.ToDouble(pValue);
				}
				
				return vResult;
			}
			catch (Exception)
			{
				return vResult;
			}

		}

		public DateTime ConvertToDateTime(object pValue)
		{
			DateTime vResult = new DateTime(1900, 1, 1);

			try
			{
				if(pValue != null)
				{
					vResult = Convert.ToDateTime(pValue);
				}
				
				return vResult;
			}
			catch (Exception)
			{
				return vResult;
			}
		}

		public dynamic ConvertJson(string pValue)
		{
			try
			{
				JavaScriptSerializer objJSS = new JavaScriptSerializer();
				var vResult = objJSS.Deserialize<dynamic>(pValue);

				return vResult;
			}
			catch (Exception)
			{

				return null;
			}
		
		}

	}
}
