using Epic.OnlineServices.Auth;

namespace PlayEveryWare.EpicOnlineServices
{
	public interface IEOSOnAuthLogin : IEOSSubManager
	{
		void OnAuthLogin(LoginCallbackInfo loginCallbackInfo);
	}
}
