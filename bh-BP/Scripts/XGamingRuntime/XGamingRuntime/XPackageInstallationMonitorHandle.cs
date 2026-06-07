using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XPackageInstallationMonitorHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XPackageInstallationMonitorHandle InteropHandle { get; set; }

		internal XPackageInstallationMonitorHandle(XGamingRuntime.Interop.XPackageInstallationMonitorHandle interopHandle)
		{
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XPackageInstallationMonitorHandle interopHandle, out XPackageInstallationMonitorHandle handle)
		{
			handle = null;
			return 0;
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
