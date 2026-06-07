using System.Collections.Generic;

namespace BestHTTP.SignalR.Messages
{
	public sealed class ResultMessage : IServerMessage, IHubMessage
	{
		MessageTypes IServerMessage.Type => default(MessageTypes);

		public ulong InvocationId { get; private set; }

		public object ReturnValue { get; private set; }

		public IDictionary<string, object> State { get; private set; }

		void IServerMessage.Parse(object data)
		{
		}
	}
}
