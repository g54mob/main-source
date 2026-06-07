namespace BestHTTP.Connections
{
	public enum HTTPConnectionStates
	{
		Initial = 0,
		Processing = 1,
		WaitForProtocolShutdown = 2,
		Recycle = 3,
		Free = 4,
		Closed = 5,
		ClosedResendRequest = 6
	}
}
