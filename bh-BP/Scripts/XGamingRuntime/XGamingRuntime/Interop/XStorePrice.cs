namespace XGamingRuntime.Interop
{
	internal struct XStorePrice
	{
		internal readonly float basePrice;

		internal readonly float price;

		internal readonly float recurrencePrice;

		internal readonly UTF8StringPtr currencyCode;

		private unsafe fixed byte formattedBasePrice[16];

		private unsafe fixed byte formattedPrice[16];

		private unsafe fixed byte formattedRecurrencePrice[16];

		internal readonly NativeBool isOnSale;

		internal readonly TimeT saleEndDate;

		internal string GetFormattedBasePrice()
		{
			return null;
		}

		internal string GetFormattedPrice()
		{
			return null;
		}

		internal string GetFormattedRecurrencePrice()
		{
			return null;
		}

		internal XStorePrice(XGamingRuntime.XStorePrice publicObject, DisposableCollection disposableCollection)
		{
			basePrice = 0f;
			price = 0f;
			recurrencePrice = 0f;
			currencyCode = default(UTF8StringPtr);
			isOnSale = default(NativeBool);
			saleEndDate = default(TimeT);
		}
	}
}
