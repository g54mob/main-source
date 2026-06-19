using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XStorePackageUpdate
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
		internal byte[] packageIdentifier;

		[MarshalAs(UnmanagedType.U1)]
		internal bool isMandatory;
	}
}
