namespace Coherence.Runtime
{
	public enum Result
	{
		Success = 1,
		ServerError = 2,
		InvalidCredentials = 3,
		FeatureDisabled = 4,
		InvalidResponse = 5,
		TooManyRequests = 6,
		AlreadyLoggedIn = 7,
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
