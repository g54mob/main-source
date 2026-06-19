using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStoreCanAcquireLicenseResult
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
		internal byte[] licensableSku;

		internal XStoreCanLicenseStatus status;
	}
}
