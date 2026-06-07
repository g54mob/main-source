using System;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class BufferedMessageBroker<TMessage> : IBufferedPublisher<TMessage>, IBufferedSubscriber<TMessage>
	{
		private readonly BufferedMessageBrokerCore<TMessage> core;

		private readonly FilterAttachedMessageHandlerFactory handlerFactory;

		[Preserve]
		public BufferedMessageBroker(BufferedMessageBrokerCore<TMessage> core, FilterAttachedMessageHandlerFactory handlerFactory)
		{
			this.core = core;
			this.handlerFactory = handlerFactory;
		}

		public void Publish(TMessage message)
		{
			core.Publish(message);
		}

		public IDisposable Subscribe(IMessageHandler<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return core.Subscribe(handlerFactory.CreateMessageHandler(handler, filters));
		}
	}
}
