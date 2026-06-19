using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveUpdateHandle
	{
		internal XGamingRuntime.Interop.XGameSaveUpdateHandle InteropHandle { get; }

		internal XGameSaveUpdateHandle(XGamingRuntime.Interop.XGameSaveUpdateHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XGameSaveUpdateHandle interopHandle, out XGameSaveUpdateHandle userHandle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				userHandle = new XGameSaveUpdateHandle(interopHandle);
			}
			else
			{
				userHandle = null;
			}
			return hresult;
		}
	}
}
