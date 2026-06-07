using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XPackageDetails
	{
		public string PackageIdentifier { get; private set; }

		public XVersion Version { get; private set; }

		public XPackageKind Kind { get; private set; }

		public string DisplayName { get; private set; }

		public string Description { get; private set; }

		public string Publisher { get; private set; }

		public string StoreId { get; private set; }

		public bool Installing { get; private set; }

		public uint Index { get; private set; }

		public uint Count { get; private set; }

		internal XPackageDetails(XGamingRuntime.Interop.XPackageDetails interopStruct)
		{
		}
	}
}
