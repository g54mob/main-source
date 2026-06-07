using System;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class BufferedMessageBrokerCore<TMessage>
	{
		private static readonly bool IsValueType = typeof(TMessage).IsValueType;

		private readonly MessageBrokerCore<TMessage> core;

		private TMessage lastMessage;

		[Preserve]
		public BufferedMessageBrokerCore(MessageBrokerCore<TMessage> core)
		{
			this.core = core;
			lastMessage = default(TMessage);
		}

		public void Publish(TMessage message)
		{
			lastMessage = message;
			core.Publish(message);
		}

		public IDisposable Subscribe(IMessageHandler<TMessage> handler)
		{
			if (IsValueType || lastMessage != null)
			{
				handler.Handle(lastMessage);
			}
			return core.Subscribe(handler);
		}
	}
}
