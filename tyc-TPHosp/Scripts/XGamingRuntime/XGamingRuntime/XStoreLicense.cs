using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreLicense
	{
		internal XStoreLicenseHandle Handle { get; set; }

		internal XStoreLicense(XStoreLicenseHandle interopHandle)
		{
			Handle = interopHandle;
		}
	}
}
