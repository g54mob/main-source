namespace XGamingRuntime.Interop
{
	internal struct XPackageDetails
	{
		internal readonly UTF8StringPtr packageIdentifier;

		internal readonly XVersion version;

		internal readonly XPackageKind kind;

		internal readonly UTF8StringPtr displayName;

		internal readonly UTF8StringPtr description;

		internal readonly UTF8StringPtr publisher;

		internal readonly UTF8StringPtr storeId;

		internal readonly NativeBool installing;

		internal readonly uint index;

		internal readonly uint count;

		internal XPackageDetails(XGamingRuntime.XPackageDetails publicObject, DisposableCollection disposableCollection)
		{
			packageIdentifier = default(UTF8StringPtr);
			version = default(XVersion);
			kind = default(XPackageKind);
			displayName = default(UTF8StringPtr);
			description = default(UTF8StringPtr);
			publisher = default(UTF8StringPtr);
			storeId = default(UTF8StringPtr);
			installing = default(NativeBool);
			index = 0u;
			count = 0u;
		}
	}
}
