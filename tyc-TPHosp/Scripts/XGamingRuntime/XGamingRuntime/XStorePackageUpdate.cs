using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStorePackageUpdate
	{
		public string PackageIdentifier { get; }

		public bool IsMandatory { get; }

		internal XStorePackageUpdate(XGamingRuntime.Interop.XStorePackageUpdate interopPackageUpdate)
		{
			PackageIdentifier = Converters.ByteArrayToString(interopPackageUpdate.packageIdentifier);
			IsMandatory = interopPackageUpdate.isMandatory;
		}
	}
}
