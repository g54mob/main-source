using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblPresenceRecordHandle
	{
		internal XGamingRuntime.Interop.XblPresenceRecordHandle InteropHandle { get; }

		internal XblPresenceRecordHandle(XGamingRuntime.Interop.XblPresenceRecordHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}

		internal static int WrapInteropHandleAndReturnHResult(int hresult, XGamingRuntime.Interop.XblPresenceRecordHandle interopHandle, out XblPresenceRecordHandle handle)
		{
			if (HR.SUCCEEDED(hresult))
			{
				handle = new XblPresenceRecordHandle(interopHandle);
			}
			else
			{
				handle = null;
			}
			return hresult;
		}
	}
}
