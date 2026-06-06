using System;

namespace MessagePipe
{
	internal sealed class AnonymousMessageHandler<TMessage> : IMessageHandler<TMessage>
	{
		private readonly Action<TMessage> handler;

		public AnonymousMessageHandler(Action<TMessage> handler)
		{
			this.handler = handler;
		}

		public void Handle(TMessage message)
		{
			handler(message);
		}
	}
}
