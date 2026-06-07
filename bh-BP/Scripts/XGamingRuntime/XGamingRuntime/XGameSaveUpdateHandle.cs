using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveUpdateHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XGameSaveUpdateHandle InteropHandle { get; private set; }

		internal XGameSaveUpdateHandle(XGamingRuntime.Interop.XGameSaveUpdateHandle interopHandle)
		{
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XGameSaveUpdateHandle interopHandle, out XGameSaveUpdateHandle userHandle)
		{
			userHandle = null;
			return 0;
		}

		internal override IntPtr GetInternalPtr()
		{
			return (IntPtr)0;
		}
	}
}
