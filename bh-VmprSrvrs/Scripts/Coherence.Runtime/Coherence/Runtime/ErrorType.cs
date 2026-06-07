namespace Coherence.Runtime
{
	public enum ErrorType
	{
		ServerError = 1,
		InvalidCredentials = 2,
		FeatureDisabled = 3,
		InvalidResponse = 4,
		TooManyRequests = 5,
		AlreadyLoggedIn = 6,
		ConcurrentConnection = 7,
		InvalidConfig = 8,
		InvalidApp = 9,
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
