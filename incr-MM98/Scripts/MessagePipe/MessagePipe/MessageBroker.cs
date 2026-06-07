using System;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class MessageBroker<TMessage> : IPublisher<TMessage>, ISubscriber<TMessage>
	{
		private readonly MessageBrokerCore<TMessage> core;

		private readonly FilterAttachedMessageHandlerFactory handlerFactory;

		[Preserve]
		public MessageBroker(MessageBrokerCore<TMessage> core, FilterAttachedMessageHandlerFactory handlerFactory)
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
	[Preserve]
	public class MessageBroker<TKey, TMessage> : IPublisher<TKey, TMessage>, ISubscriber<TKey, TMessage>
	{
		private readonly MessageBrokerCore<TKey, TMessage> core;

		private readonly FilterAttachedMessageHandlerFactory handlerFactory;

		[Preserve]
		public MessageBroker(MessageBrokerCore<TKey, TMessage> core, FilterAttachedMessageHandlerFactory handlerFactory)
		{
			this.core = core;
			this.handlerFactory = handlerFactory;
		}

		public void Publish(TKey key, TMessage message)
		{
			core.Publish(key, message);
		}

		public IDisposable Subscribe(TKey key, IMessageHandler<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return core.Subscribe(key, handlerFactory.CreateMessageHandler(handler, filters));
		}
	}
}
