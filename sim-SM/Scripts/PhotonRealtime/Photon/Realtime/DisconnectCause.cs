namespace Photon.Realtime
{
	public enum DisconnectCause
	{
		None = 0,
		ExceptionOnConnect = 1,
		DnsExceptionOnConnect = 2,
		ServerAddressInvalid = 3,
		Exception = 4,
		SendException = 16,
		ReceiveException = 15,
		ServerTimeout = 1040,
		ClientTimeout = 1041,
		DisconnectByServerLogic = 6,
		DisconnectByServerReasonUnknown = 7,
		InvalidAuthentication = 8,
		CustomAuthenticationFailed = 9,
		AuthenticationTicketExpired = 10,
		MaxCcuReached = 11,
		InvalidRegion = 12,
		OperationNotAllowedInCurrentState = 13,
		DisconnectByClientLogic = 14,
		DisconnectByOperationLimit = 17,
		DisconnectByDisconnectMessage = 1042,
		ApplicationQuit = 18
	}
}
