using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStoreAddonLicense
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
		internal byte[] skuStoreId;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
		internal byte[] inAppOfferToken;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isActive;

		internal TimeT expirationDate;
	}
}
