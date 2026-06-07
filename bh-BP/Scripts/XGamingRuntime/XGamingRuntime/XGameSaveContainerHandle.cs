using System;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveContainerHandle : EquatableHandle
	{
		internal XGamingRuntime.Interop.XGameSaveContainerHandle InteropHandle { get; private set; }

		internal XGameSaveContainerHandle(XGamingRuntime.Interop.XGameSaveContainerHandle interopHandle)
		{
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XGameSaveContainerHandle interopHandle, out XGameSaveContainerHandle userHandle)
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
