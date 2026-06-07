using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSearchHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblMultiplayerSearchHandle InteropHandle { get; set; }

		internal XblMultiplayerSearchHandle(XGamingRuntime.Interop.XblMultiplayerSearchHandle interopHandle)
		{
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
