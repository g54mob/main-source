using System.Runtime.InteropServices;
using XGamingRuntime.Interop;

namespace XGamingRuntime
{
	public class XRegistrationToken
	{
		internal GCHandle CallbackHandle { get; }

		internal XTaskQueueRegistrationToken Token { get; }

		internal XRegistrationToken(GCHandle callbackHandle, XTaskQueueRegistrationToken token)
		{
			CallbackHandle = callbackHandle;
			Token = token;
		}
	}
}
