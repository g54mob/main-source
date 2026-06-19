using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStorePrice
	{
		public float BasePrice { get; }

		public float Price { get; }

		public float RecurrencePrice { get; }

		public string CurrencyCode { get; }

		public string FormattedBasePrice { get; }

		public string FormattedPrice { get; }

		public string FormattedRecurrencePrice { get; }

		public bool IsOnSale { get; }

		public DateTime SaleEndDate { get; }

		internal XStorePrice(XGamingRuntime.Interop.XStorePrice rawPrice)
		{
			BasePrice = rawPrice.basePrice;
			Price = rawPrice.price;
			RecurrencePrice = rawPrice.recurrencePrice;
			CurrencyCode = rawPrice.currencyCode.GetString();
			FormattedBasePrice = Converters.ByteArrayToString(rawPrice.formattedBasePrice);
			FormattedPrice = Converters.ByteArrayToString(rawPrice.formattedPrice);
			FormattedRecurrencePrice = Converters.ByteArrayToString(rawPrice.formattedRecurrencePrice);
			IsOnSale = rawPrice.isOnSale;
			SaleEndDate = rawPrice.saleEndDate.DateTime;
		}
	}
}
