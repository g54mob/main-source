using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XPackageInstallationMonitorHandle
	{
		internal XGamingRuntime.Interop.XPackageInstallationMonitorHandle InteropHandle { get; set; }

		internal XPackageInstallationMonitorHandle(XGamingRuntime.Interop.XPackageInstallationMonitorHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XPackageInstallationMonitorHandle interopHandle, out XPackageInstallationMonitorHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XPackageInstallationMonitorHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}
	}
}
