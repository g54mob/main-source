using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XUserSignOutDeferralHandle
	{
		internal XGamingRuntime.Interop.XUserSignOutDeferralHandle InteropHandle { get; }

		internal XUserSignOutDeferralHandle(XGamingRuntime.Interop.XUserSignOutDeferralHandle interopHandle)
		{
			InteropHandle = interopHandle;
		}
	}
}
