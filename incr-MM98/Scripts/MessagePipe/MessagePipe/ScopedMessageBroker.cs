using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class ScopedMessageBroker<TMessage> : MessageBroker<TMessage>, IScopedPublisher<TMessage>, IPublisher<TMessage>, IScopedSubscriber<TMessage>, ISubscriber<TMessage>
	{
		[Preserve]
		public ScopedMessageBroker(ScopedMessageBrokerCore<TMessage> core, FilterAttachedMessageHandlerFactory handlerFactory)
			: base((MessageBrokerCore<TMessage>)core, handlerFactory)
		{
		}
	}
	[Preserve]
	public class ScopedMessageBroker<TKey, TMessage> : MessageBroker<TKey, TMessage>, IScopedPublisher<TKey, TMessage>, IPublisher<TKey, TMessage>, IScopedSubscriber<TKey, TMessage>, ISubscriber<TKey, TMessage>
	{
		public ScopedMessageBroker(ScopedMessageBrokerCore<TKey, TMessage> core, FilterAttachedMessageHandlerFactory handlerFactory)
			: base((MessageBrokerCore<TKey, TMessage>)core, handlerFactory)
		{
		}
	}
}
