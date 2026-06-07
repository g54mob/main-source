namespace BestHTTP.SignalRCore.Messages
{
	public struct CompletionWithError
	{
		public MessageTypes type;

		public string invocationId;

		public string error;
	}
}
