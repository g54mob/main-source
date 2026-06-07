namespace BestHTTP.SignalRCore.Messages
{
	public struct CloseWithErrorMessage
	{
		public string error;

		public MessageTypes type => default(MessageTypes);
	}
}
