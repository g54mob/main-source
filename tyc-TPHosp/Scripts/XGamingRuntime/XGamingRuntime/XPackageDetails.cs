using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XPackageDetails
	{
		public string PackageIdentifier { get; }

		public XVersion Version { get; }

		public XPackageKind Kind { get; }

		public string DisplayName { get; }

		public string Description { get; }

		public string Publisher { get; }

		public string StoreId { get; }

		public bool Installing { get; }

		internal XPackageDetails(XGamingRuntime.Interop.XPackageDetails rawDetails)
		{
			PackageIdentifier = rawDetails.packageIdentifier.GetString();
			Version = new XVersion(rawDetails.version);
			Kind = rawDetails.kind;
			DisplayName = rawDetails.displayName.GetString();
			Description = rawDetails.description.GetString();
			Publisher = rawDetails.publisher.GetString();
			StoreId = rawDetails.storeId.GetString();
			Installing = rawDetails.installing;
		}
	}
}
