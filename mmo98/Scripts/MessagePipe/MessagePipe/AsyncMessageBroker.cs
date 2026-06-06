using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class AsyncMessageBroker<TMessage> : IAsyncPublisher<TMessage>, IAsyncSubscriber<TMessage>
	{
		private readonly AsyncMessageBrokerCore<TMessage> core;

		private readonly FilterAttachedAsyncMessageHandlerFactory handlerFactory;

		[Preserve]
		public AsyncMessageBroker(AsyncMessageBrokerCore<TMessage> core, FilterAttachedAsyncMessageHandlerFactory handlerFactory)
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

		public IDisposable Subscribe(IAsyncMessageHandler<TMessage> handler, AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return core.Subscribe(handlerFactory.CreateAsyncMessageHandler(handler, filters));
		}
	}
	[Preserve]
	public class AsyncMessageBroker<TKey, TMessage> : IAsyncPublisher<TKey, TMessage>, IAsyncSubscriber<TKey, TMessage>
	{
		private readonly AsyncMessageBrokerCore<TKey, TMessage> core;

		private readonly FilterAttachedAsyncMessageHandlerFactory handlerFactory;

		[Preserve]
		public AsyncMessageBroker(AsyncMessageBrokerCore<TKey, TMessage> core, FilterAttachedAsyncMessageHandlerFactory handlerFactory)
		{
			this.core = core;
			this.handlerFactory = handlerFactory;
		}

		public void Publish(TKey key, TMessage message, CancellationToken cancellationToken)
		{
			core.Publish(key, message, cancellationToken);
		}

		public UniTask PublishAsync(TKey key, TMessage message, CancellationToken cancellationToken)
		{
			return core.PublishAsync(key, message, cancellationToken);
		}

		public UniTask PublishAsync(TKey key, TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			return core.PublishAsync(key, message, publishStrategy, cancellationToken);
		}

		public IDisposable Subscribe(TKey key, IAsyncMessageHandler<TMessage> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return core.Subscribe(key, handlerFactory.CreateAsyncMessageHandler(handler, filters));
		}
	}
}
