using System.Collections.Generic;

namespace BestHTTP.SignalR.Messages
{
	public sealed class FailureMessage : IServerMessage, IHubMessage
	{
		MessageTypes IServerMessage.Type => default(MessageTypes);

		public ulong InvocationId { get; private set; }

		public bool IsHubError { get; private set; }

		public string ErrorMessage { get; private set; }

		public IDictionary<string, object> AdditionalData { get; private set; }

		public string StackTrace { get; private set; }

		public IDictionary<string, object> State { get; private set; }

		void IServerMessage.Parse(object data)
		{
		}
	}
}
