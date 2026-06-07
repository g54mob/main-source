namespace BestHTTP.SignalRCore.Messages
{
	public enum MessageTypes
	{
		Handshake = 0,
		Invocation = 1,
		StreamItem = 2,
		Completion = 3,
		StreamInvocation = 4,
		CancelInvocation = 5,
		Ping = 6,
		Close = 7
	}
}
