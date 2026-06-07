namespace BestHTTP.SignalRCore.Messages
{
	public struct UploadInvocationMessage
	{
		public MessageTypes type;

		public string invocationId;

		public bool nonblocking;

		public string target;

		public object[] arguments;

		public string[] streamIds;
	}
}
