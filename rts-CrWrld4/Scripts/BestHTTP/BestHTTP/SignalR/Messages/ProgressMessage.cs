namespace BestHTTP.SignalR.Messages
{
	public sealed class ProgressMessage : IServerMessage, IHubMessage
	{
		MessageTypes IServerMessage.Type => default(MessageTypes);

		public ulong InvocationId { get; private set; }

		public double Progress { get; private set; }

		void IServerMessage.Parse(object data)
		{
		}
	}
}
