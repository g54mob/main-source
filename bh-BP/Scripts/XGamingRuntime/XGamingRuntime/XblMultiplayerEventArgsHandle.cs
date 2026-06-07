using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerEventArgsHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblMultiplayerEventArgsHandle InteropHandle { get; set; }

		internal XblMultiplayerEventArgsHandle(XGamingRuntime.Interop.XblMultiplayerEventArgsHandle interopHandle)
		{
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XblMultiplayerEventArgsHandle interopHandle, out XblMultiplayerEventArgsHandle handle)
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
