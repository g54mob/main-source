namespace Kitchen.NetworkSupport
{
	public enum TransportSendStatus
	{
		Null = 0,
		Ready = 1,
		NoSendNoClients = 2,
		NoSendError = 3,
		NoSendNotConnected = 4,
		NoSendMissingArgument = 5
	}
}
