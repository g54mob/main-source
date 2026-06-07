using System.Collections.Generic;

namespace BestHTTP.SignalR.Messages
{
	public sealed class MethodCallMessage : IServerMessage
	{
		MessageTypes IServerMessage.Type => default(MessageTypes);

		public string Hub { get; private set; }

		public string Method { get; private set; }

		public object[] Arguments { get; private set; }

		public IDictionary<string, object> State { get; private set; }

		void IServerMessage.Parse(object data)
		{
		}
	}
}
