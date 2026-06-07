using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPresenceRecordHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XblPresenceRecordHandle InteropHandle { get; private set; }

		internal XblPresenceRecordHandle(XGamingRuntime.Interop.XblPresenceRecordHandle interopHandle)
		{
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XblPresenceRecordHandle interopHandle, out XblPresenceRecordHandle handle)
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
