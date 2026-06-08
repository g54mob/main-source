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

		internal unsafe string GetFormattedBasePrice()
		{
			fixed (byte* bytePointer = formattedBasePrice)
			{
				return Converters.BytePointerToString(bytePointer, 16);
			}
		}

		internal unsafe string GetFormattedPrice()
		{
			fixed (byte* bytePointer = formattedPrice)
			{
				return Converters.BytePointerToString(bytePointer, 16);
			}
		}

		internal unsafe string GetFormattedRecurrencePrice()
		{
			fixed (byte* bytePointer = formattedRecurrencePrice)
			{
				return Converters.BytePointerToString(bytePointer, 16);
			}
		}

		internal unsafe XStorePrice(XGamingRuntime.XStorePrice publicObject, DisposableCollection disposableCollection)
		{
			basePrice = publicObject.BasePrice;
			price = publicObject.Price;
			recurrencePrice = publicObject.RecurrencePrice;
			currencyCode = new UTF8StringPtr(publicObject.CurrencyCode, disposableCollection);
			fixed (byte* bytePointer = formattedBasePrice)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.FormattedBasePrice, bytePointer, 16);
			}
			fixed (byte* bytePointer2 = formattedPrice)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.FormattedPrice, bytePointer2, 16);
			}
			fixed (byte* bytePointer3 = formattedRecurrencePrice)
			{
				Converters.StringToNullTerminatedUTF8FixedPointer(publicObject.FormattedRecurrencePrice, bytePointer3, 16);
			}
			isOnSale = new NativeBool(publicObject.IsOnSale);
			saleEndDate = new TimeT(publicObject.SaleEndDate);
		}
	}
}
