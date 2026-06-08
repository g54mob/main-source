using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblMultiplayerSessionHandle InteropHandle { get; set; }

		internal XblMultiplayerSessionHandle(XGamingRuntime.Interop.XblMultiplayerSessionHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal override IntPtr GetInternalPtr()
		{
			return InteropHandle.handle;
		}
	}
}
