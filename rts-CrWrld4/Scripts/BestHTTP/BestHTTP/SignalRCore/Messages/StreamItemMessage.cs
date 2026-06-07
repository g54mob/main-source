namespace BestHTTP.SignalRCore.Messages
{
	public struct StreamItemMessage
	{
		public MessageTypes type;

		public string invocationId;

		public object item;
	}
}
