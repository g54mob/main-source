using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblContextHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblContextHandle InteropHandle { get; set; }

		internal XblContextHandle(XGamingRuntime.Interop.XblContextHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal override IntPtr GetInternalPtr()
		{
			return InteropHandle.handle;
		}
	}
}
