using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class ScopedAsyncMessageBroker<TMessage> : AsyncMessageBroker<TMessage>, IScopedAsyncPublisher<TMessage>, IAsyncPublisher<TMessage>, IScopedAsyncSubscriber<TMessage>, IAsyncSubscriber<TMessage>
	{
		[Preserve]
		public ScopedAsyncMessageBroker(ScopedAsyncMessageBrokerCore<TMessage> core, FilterAttachedAsyncMessageHandlerFactory handlerFactory)
			: base((AsyncMessageBrokerCore<TMessage>)core, handlerFactory)
		{
		}
	}
	[Preserve]
	public class ScopedAsyncMessageBroker<TKey, TMessage> : AsyncMessageBroker<TKey, TMessage>, IScopedAsyncPublisher<TKey, TMessage>, IAsyncPublisher<TKey, TMessage>, IScopedAsyncSubscriber<TKey, TMessage>, IAsyncSubscriber<TKey, TMessage>
	{
		public ScopedAsyncMessageBroker(ScopedAsyncMessageBrokerCore<TKey, TMessage> core, FilterAttachedAsyncMessageHandlerFactory handlerFactory)
			: base((AsyncMessageBrokerCore<TKey, TMessage>)core, handlerFactory)
		{
		}
	}
}
