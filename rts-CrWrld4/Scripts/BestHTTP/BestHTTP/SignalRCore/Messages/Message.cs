namespace BestHTTP.SignalRCore.Messages
{
	public struct Message
	{
		public MessageTypes type;

		public string invocationId;

		public bool nonblocking;

		public string target;

		public object[] arguments;

		public string[] streamIds;

		public object item;

		public object result;

		public string error;

		public bool allowReconnect;

		public override string ToString()
		{
			return null;
		}
	}
}
