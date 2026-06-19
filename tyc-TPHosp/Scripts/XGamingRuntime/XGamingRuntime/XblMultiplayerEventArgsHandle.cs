using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblMultiplayerEventArgsHandle
	{
		internal XGamingRuntime.Interop.XblMultiplayerEventArgsHandle InteropHandle { get; set; }

		internal XblMultiplayerEventArgsHandle(XGamingRuntime.Interop.XblMultiplayerEventArgsHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XblMultiplayerEventArgsHandle interopHandle, out XblMultiplayerEventArgsHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XblMultiplayerEventArgsHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}
	}
}
