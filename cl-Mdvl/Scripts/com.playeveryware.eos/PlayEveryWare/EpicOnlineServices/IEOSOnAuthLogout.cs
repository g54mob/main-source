using Epic.OnlineServices.Auth;

namespace PlayEveryWare.EpicOnlineServices
{
	public interface IEOSOnAuthLogout : IEOSSubManager
	{
		void OnAuthLogout(ref LogoutCallbackInfo logoutCallbackInfo);
	}
}
