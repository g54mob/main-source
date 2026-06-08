namespace Kitchen.NetworkSupport
{
	public enum TransportSendResult
	{
		Null = 0,
		Success = 1,
		FailedNotConnected = 2,
		FailedError = 3,
		FailedMissingArgument = 4
	}
}
