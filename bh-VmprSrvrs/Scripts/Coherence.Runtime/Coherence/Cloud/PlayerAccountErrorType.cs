namespace Coherence.Cloud
{
	public enum PlayerAccountErrorType
	{
		InternalException = 0,
		NotLoggedIn = 1,
		ServerError = 2,
		InvalidConfig = 3,
		InvalidApp = 4,
		FeatureDisabled = 5,
		InvalidCredentials = 6,
		InvalidResponse = 7,
		ConnectionError = 8,
		TooManyRequests = 9,
		ConcurrentConnection = 10,
		OneTimeCodeExpired = 11,
		OneTimeCodeNotFound = 12,
		IdentityLimit = 13,
		IdentityNotFound = 14,
		IdentityRemoval = 15,
		IdentityTaken = 16,
		IdentityTotalLimit = 17,
		InvalidInput = 18,
		PasswordNotSet = 19,
		UsernameNotAvailable = 20
	}
}
