using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerSessionHandle : EquatableHandle
	{
		public XGamingRuntime.Interop.XblMultiplayerSessionHandle InteropHandle { get; set; }

		public XblMultiplayerSessionHandle(XGamingRuntime.Interop.XblMultiplayerSessionHandle interopHandle)
		{
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
