using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStorePrice
	{
		public float BasePrice { get; private set; }

		public float Price { get; private set; }

		public float RecurrencePrice { get; private set; }

		public string CurrencyCode { get; private set; }

		public string FormattedBasePrice { get; private set; }

		public string FormattedPrice { get; private set; }

		public string FormattedRecurrencePrice { get; private set; }

		public bool IsOnSale { get; private set; }

		public DateTime SaleEndDate { get; private set; }

		internal XStorePrice(XGamingRuntime.Interop.XStorePrice interopStruct)
		{
		}
	}
}
