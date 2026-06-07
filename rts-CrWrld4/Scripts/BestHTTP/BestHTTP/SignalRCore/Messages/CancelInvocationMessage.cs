namespace BestHTTP.SignalRCore.Messages
{
	public struct CancelInvocationMessage
	{
		public string invocationId;

		public MessageTypes type => default(MessageTypes);
	}
}
