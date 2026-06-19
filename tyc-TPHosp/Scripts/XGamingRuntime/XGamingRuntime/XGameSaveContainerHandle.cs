using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveContainerHandle
	{
		internal XGamingRuntime.Interop.XGameSaveContainerHandle InteropHandle { get; }

		internal XGameSaveContainerHandle(XGamingRuntime.Interop.XGameSaveContainerHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XGameSaveContainerHandle interopHandle, out XGameSaveContainerHandle userHandle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				userHandle = new XGameSaveContainerHandle(interopHandle);
			}
			else
			{
				userHandle = null;
			}
			return hresult;
		}
	}
}
