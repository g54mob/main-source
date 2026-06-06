using System.Threading;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class EventFactory
	{
		private readonly MessagePipeOptions options;

		private readonly MessagePipeDiagnosticsInfo diagnosticsInfo;

		private readonly FilterAttachedMessageHandlerFactory handlerFactory;

		private readonly FilterAttachedAsyncMessageHandlerFactory asyncHandlerFactory;

		[Preserve]
		public EventFactory(MessagePipeOptions options, MessagePipeDiagnosticsInfo diagnosticsInfo, FilterAttachedMessageHandlerFactory handlerFactory, FilterAttachedAsyncMessageHandlerFactory asyncHandlerFactory)
		{
			this.options = options;
			this.diagnosticsInfo = diagnosticsInfo;
			this.handlerFactory = handlerFactory;
			this.asyncHandlerFactory = asyncHandlerFactory;
		}

		public (IDisposablePublisher<T>, ISubscriber<T>) CreateEvent<T>()
		{
			MessageBrokerCore<T> core = new MessageBrokerCore<T>(diagnosticsInfo, options);
			DisposablePublisher<T> item = new DisposablePublisher<T>(core);
			MessageBroker<T> item2 = new MessageBroker<T>(core, handlerFactory);
			return (item, item2);
		}

		public (IDisposableAsyncPublisher<T>, IAsyncSubscriber<T>) CreateAsyncEvent<T>()
		{
			AsyncMessageBrokerCore<T> core = new AsyncMessageBrokerCore<T>(diagnosticsInfo, options);
			DisposableAsyncPublisher<T> item = new DisposableAsyncPublisher<T>(core);
			AsyncMessageBroker<T> item2 = new AsyncMessageBroker<T>(core, asyncHandlerFactory);
			return (item, item2);
		}

		public (IDisposableBufferedPublisher<T>, IBufferedSubscriber<T>) CreateBufferedEvent<T>(T initialValue)
		{
			MessageBrokerCore<T> messageBrokerCore = new MessageBrokerCore<T>(diagnosticsInfo, options);
			BufferedMessageBroker<T> bufferedMessageBroker = new BufferedMessageBroker<T>(new BufferedMessageBrokerCore<T>(messageBrokerCore), handlerFactory);
			DisposableBufferedPublisher<T> disposableBufferedPublisher = new DisposableBufferedPublisher<T>(bufferedMessageBroker, messageBrokerCore);
			BufferedMessageBroker<T> item = bufferedMessageBroker;
			disposableBufferedPublisher.Publish(initialValue);
			return (disposableBufferedPublisher, item);
		}

		public (IDisposableBufferedAsyncPublisher<T>, IBufferedAsyncSubscriber<T>) CreateBufferedAsyncEvent<T>(T initialValue)
		{
			AsyncMessageBrokerCore<T> asyncMessageBrokerCore = new AsyncMessageBrokerCore<T>(diagnosticsInfo, options);
			BufferedAsyncMessageBroker<T> bufferedAsyncMessageBroker = new BufferedAsyncMessageBroker<T>(new BufferedAsyncMessageBrokerCore<T>(asyncMessageBrokerCore), asyncHandlerFactory);
			DisposableBufferedAsyncPublisher<T> disposableBufferedAsyncPublisher = new DisposableBufferedAsyncPublisher<T>(bufferedAsyncMessageBroker, asyncMessageBrokerCore);
			BufferedAsyncMessageBroker<T> item = bufferedAsyncMessageBroker;
			disposableBufferedAsyncPublisher.Publish(initialValue, CancellationToken.None);
			return (disposableBufferedAsyncPublisher, item);
		}
	}
}
