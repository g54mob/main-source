namespace BestHTTP.SignalR.Messages
{
	public sealed class KeepAliveMessage : IServerMessage
	{
		MessageTypes IServerMessage.Type => default(MessageTypes);

		void IServerMessage.Parse(object data)
		{
		}
	}
}
