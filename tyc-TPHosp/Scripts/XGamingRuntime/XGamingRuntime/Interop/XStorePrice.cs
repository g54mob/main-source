using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStorePrice
	{
		internal float basePrice;

		internal float price;

		internal float recurrencePrice;

		internal UTF8StringPtr currencyCode;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		internal byte[] formattedBasePrice;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		internal byte[] formattedPrice;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		internal byte[] formattedRecurrencePrice;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isOnSale;

		internal TimeT saleEndDate;
	}
}
