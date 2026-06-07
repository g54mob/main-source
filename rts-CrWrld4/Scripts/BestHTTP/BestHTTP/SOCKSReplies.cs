namespace BestHTTP
{
	internal enum SOCKSReplies : byte
	{
		Succeeded = 0,
		GeneralSOCKSServerFailure = 1,
		ConnectionNotAllowedByRuleset = 2,
		NetworkUnreachable = 3,
		HostUnreachable = 4,
		ConnectionRefused = 5,
		TTLExpired = 6,
		CommandNotSupported = 7,
		AddressTypeNotSupported = 8
	}
}
