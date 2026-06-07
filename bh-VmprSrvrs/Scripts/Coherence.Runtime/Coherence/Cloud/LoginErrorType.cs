namespace Coherence.Cloud
{
	public enum LoginErrorType
	{
		None = 0,
		ServerError = 1,
		InvalidCredentials = 2,
		InvalidResponse = 4,
		TooManyRequests = 5,
		AlreadyLoggedIn = 6,
		ConcurrentConnection = 7,
		InvalidConfig = 8,
		OneTimeCodeExpired = 10,
		OneTimeCodeNotFound = 11,
		ConnectionError = 12,
		IdentityLimit = 13,
		IdentityNotFound = 14,
		IdentityTaken = 16,
		IdentityTotalLimit = 17,
		InvalidInput = 18,
		PasswordNotSet = 19,
		UsernameNotAvailable = 20
	}
}
