using System;

namespace MessagePipe
{
	public abstract class MessageHandlerFilter<TMessage> : IMessageHandlerFilter, IMessagePipeFilter
	{
		public int Order { get; set; }

		public abstract void Handle(TMessage message, Action<TMessage> next);
	}
}
