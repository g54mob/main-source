using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XGameSaveProviderHandle
	{
		internal XGamingRuntime.Interop.XGameSaveProviderHandle InteropHandle { get; }

		internal XGameSaveProviderHandle(XGamingRuntime.Interop.XGameSaveProviderHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XGameSaveProviderHandle interopHandle, out XGameSaveProviderHandle userHandle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				userHandle = new XGameSaveProviderHandle(interopHandle);
			}
			else
			{
				userHandle = null;
			}
			return hresult;
		}
	}
}
