using System;

namespace VampireSurvivors.Framework.Platforms
{
	[Flags]
	public enum LoginState
	{
		LoggedOut = 0,
		LoggingIn = 1,
		LoggedIn = 2,
		OnlineLoggedIn = 4,
		OnlineLoggingIn = 8
	}
}
