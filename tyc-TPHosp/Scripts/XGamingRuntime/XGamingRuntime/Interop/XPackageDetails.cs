using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	internal struct XPackageDetails
	{
		internal UTF8StringPtr packageIdentifier;

		internal XVersion version;

		internal XPackageKind kind;

		internal UTF8StringPtr displayName;

		internal UTF8StringPtr description;

		internal UTF8StringPtr publisher;

		internal UTF8StringPtr storeId;

		[MarshalAs(UnmanagedType.U1)]
		internal bool installing;
	}
}
