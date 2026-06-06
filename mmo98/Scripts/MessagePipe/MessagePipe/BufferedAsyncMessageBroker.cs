using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class BufferedAsyncMessageBroker<TMessage> : IBufferedAsyncPublisher<TMessage>, IBufferedAsyncSubscriber<TMessage>
	{
		private readonly BufferedAsyncMessageBrokerCore<TMessage> core;

		private readonly FilterAttachedAsyncMessageHandlerFactory handlerFactory;

		[Preserve]
		public BufferedAsyncMessageBroker(BufferedAsyncMessageBrokerCore<TMessage> core, FilterAttachedAsyncMessageHandlerFactory handlerFactory)
		{
			this.core = core;
			this.handlerFactory = handlerFactory;
		}

		public void Publish(TMessage message, CancellationToken cancellationToken)
		{
			core.Publish(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, CancellationToken cancellationToken)
		{
			return core.PublishAsync(message, cancellationToken);
		}

		public UniTask PublishAsync(TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			return core.PublishAsync(message, publishStrategy, cancellationToken);
		}

		public UniTask<IDisposable> SubscribeAsync(IAsyncMessageHandler<TMessage> handler, CancellationToken cancellationToken)
		{
			return SubscribeAsync(handler, Array.Empty<AsyncMessageHandlerFilter<TMessage>>(), cancellationToken);
		}

		public UniTask<IDisposable> SubscribeAsync(IAsyncMessageHandler<TMessage> handler, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken)
		{
			handler = handlerFactory.CreateAsyncMessageHandler(handler, filters);
			return core.SubscribeAsync(handler, cancellationToken);
		}
	}
}
