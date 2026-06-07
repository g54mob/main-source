using System;
using System.Collections.Generic;

namespace BestHTTP.SignalR.Messages
{
	public sealed class MultiMessage : IServerMessage
	{
		MessageTypes IServerMessage.Type => default(MessageTypes);

		public string MessageId { get; private set; }

		public bool IsInitialization { get; private set; }

		public string GroupsToken { get; private set; }

		public bool ShouldReconnect { get; private set; }

		public TimeSpan? PollDelay { get; private set; }

		public List<IServerMessage> Data { get; private set; }

		void IServerMessage.Parse(object data)
		{
		}
	}
}
