using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XblContextHandle
	{
		internal XGamingRuntime.Interop.XblContextHandle InteropHandle { get; set; }

		internal XblContextHandle(XGamingRuntime.Interop.XblContextHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}
	}
}
