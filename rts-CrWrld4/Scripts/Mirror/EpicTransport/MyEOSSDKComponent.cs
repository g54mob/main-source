using Epic.OnlineServices.Connect;

namespace EpicTransport
{
	public class MyEOSSDKComponent : EOSSDKComponent
	{
		private ulong authExpirationHandle;

		private void Awake()
		{
		}

		protected override void OnConnectInterfaceLogin(LoginCallbackInfo loginCallbackInfo)
		{
		}

		private void OnAuthExpiration(AuthExpirationCallbackInfo authExpirationCallbackInfo)
		{
		}
	}
}
