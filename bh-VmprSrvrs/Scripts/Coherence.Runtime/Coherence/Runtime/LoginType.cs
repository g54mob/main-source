namespace Coherence.Runtime
{
	internal enum LoginType
	{
		Guest = 1,
		Password = 2,
		SessionToken = 4,
		OneTimeCode = 8,
		Jwt = 16,
		Steam = 32,
		EpicGames = 64,
		PlayStation = 128,
		Xbox = 256,
		Nintendo = 512,
		LegacyGuest = -2147483648
	}
}
