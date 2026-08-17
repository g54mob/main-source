namespace VampireSurvivors.Framework.Platforms;

public enum LoginState
{
	LoggedOut = 0,
	LoggingIn = 1,
	LoggedIn = 2,
	OnlineLoggedIn = 4,
	OnlineLoggingIn = 8
}
