namespace BestHTTP.SignalRCore
{
	public enum ConnectionStates
	{
		Initial = 0,
		Authenticating = 1,
		Negotiating = 2,
		Redirected = 3,
		Reconnecting = 4,
		Connected = 5,
		CloseInitiated = 6,
		Closed = 7
	}
}
