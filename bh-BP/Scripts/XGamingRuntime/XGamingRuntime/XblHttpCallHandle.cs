using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblHttpCallHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblHttpCallHandle InteropHandle { get; set; }

		internal XblHttpCallHandle(XGamingRuntime.Interop.XblHttpCallHandle interopHandle)
		{
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XblHttpCallHandle interopHandle, out XblHttpCallHandle handle)
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
