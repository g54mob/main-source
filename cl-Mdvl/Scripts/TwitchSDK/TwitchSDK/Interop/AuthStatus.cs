namespace TwitchSDK.Interop
{
	public enum AuthStatus : byte
	{
		LoggedOut = 0,
		Loading = 1,
		WaitingForCode = 2,
		LoggedIn = 3
	}
}
