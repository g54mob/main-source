namespace BestHTTP.SignalRCore.Messages
{
	public struct CompletionWithResult
	{
		public MessageTypes type;

		public string invocationId;

		public object result;
	}
}
