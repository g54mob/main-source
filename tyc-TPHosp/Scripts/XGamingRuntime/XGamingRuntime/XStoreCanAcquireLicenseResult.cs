using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreCanAcquireLicenseResult
	{
		public string LicensableSku { get; }

		public XStoreCanLicenseStatus Status { get; }

		internal XStoreCanAcquireLicenseResult(XGamingRuntime.Interop.XStoreCanAcquireLicenseResult interopResult)
		{
			LicensableSku = Converters.ByteArrayToString(interopResult.licensableSku);
			Status = interopResult.status;
		}
	}
}
