using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class SingletonAsyncMessageBroker<TMessage> : AsyncMessageBroker<TMessage>, ISingletonAsyncPublisher<TMessage>, IAsyncPublisher<TMessage>, ISingletonAsyncSubscriber<TMessage>, IAsyncSubscriber<TMessage>
	{
		[Preserve]
		public SingletonAsyncMessageBroker(SingletonAsyncMessageBrokerCore<TMessage> core, FilterAttachedAsyncMessageHandlerFactory handlerFactory)
			: base((AsyncMessageBrokerCore<TMessage>)core, handlerFactory)
		{
		}
	}
	[Preserve]
	public class SingletonAsyncMessageBroker<TKey, TMessage> : AsyncMessageBroker<TKey, TMessage>, ISingletonAsyncPublisher<TKey, TMessage>, IAsyncPublisher<TKey, TMessage>, ISingletonAsyncSubscriber<TKey, TMessage>, IAsyncSubscriber<TKey, TMessage>
	{
		public SingletonAsyncMessageBroker(SingletonAsyncMessageBrokerCore<TKey, TMessage> core, FilterAttachedAsyncMessageHandlerFactory handlerFactory)
			: base((AsyncMessageBrokerCore<TKey, TMessage>)core, handlerFactory)
		{
		}
	}
}
