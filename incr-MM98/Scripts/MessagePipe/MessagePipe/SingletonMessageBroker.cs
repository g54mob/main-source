using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class SingletonMessageBroker<TMessage> : MessageBroker<TMessage>, ISingletonPublisher<TMessage>, IPublisher<TMessage>, ISingletonSubscriber<TMessage>, ISubscriber<TMessage>
	{
		[Preserve]
		public SingletonMessageBroker(SingletonMessageBrokerCore<TMessage> core, FilterAttachedMessageHandlerFactory handlerFactory)
			: base((MessageBrokerCore<TMessage>)core, handlerFactory)
		{
		}
	}
	[Preserve]
	public class SingletonMessageBroker<TKey, TMessage> : MessageBroker<TKey, TMessage>, ISingletonPublisher<TKey, TMessage>, IPublisher<TKey, TMessage>, ISingletonSubscriber<TKey, TMessage>, ISubscriber<TKey, TMessage>
	{
		public SingletonMessageBroker(SingletonMessageBrokerCore<TKey, TMessage> core, FilterAttachedMessageHandlerFactory handlerFactory)
			: base((MessageBrokerCore<TKey, TMessage>)core, handlerFactory)
		{
		}
	}
}
