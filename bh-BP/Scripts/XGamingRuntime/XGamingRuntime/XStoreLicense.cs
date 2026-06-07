using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XStoreLicense : EquatableHandle
	{
		internal XStoreLicenseHandle Handle { get; set; }

		internal XStoreLicense(XStoreLicenseHandle interopHandle)
		{
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
