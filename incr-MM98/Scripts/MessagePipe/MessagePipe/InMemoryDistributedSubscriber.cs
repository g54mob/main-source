using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class InMemoryDistributedSubscriber<TKey, TMessage> : IDistributedSubscriber<TKey, TMessage>
	{
		private readonly IAsyncSubscriber<TKey, TMessage> subscriber;

		[Preserve]
		public InMemoryDistributedSubscriber(IAsyncSubscriber<TKey, TMessage> subscriber)
		{
			this.subscriber = subscriber;
		}

		public UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IMessageHandler<TMessage> handler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new UniTask<IUniTaskAsyncDisposable>(new AsyncDisposableBridge(subscriber.Subscribe(key, new AsyncMessageHandlerBridge<TMessage>(handler))));
		}

		public UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IMessageHandler<TMessage> handler, MessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			IAsyncSubscriber<TKey, TMessage> asyncSubscriber = subscriber;
			AsyncMessageHandlerBridge<TMessage> asyncHandler = new AsyncMessageHandlerBridge<TMessage>(handler);
			AsyncMessageHandlerFilter<TMessage>[] filters2 = filters.Select((MessageHandlerFilter<TMessage> x) => new AsyncMessageHandlerFilterBridge<TMessage>(x)).ToArray();
			return new UniTask<IUniTaskAsyncDisposable>(new AsyncDisposableBridge(asyncSubscriber.Subscribe(key, asyncHandler, filters2)));
		}

		public UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IAsyncMessageHandler<TMessage> handler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new UniTask<IUniTaskAsyncDisposable>(new AsyncDisposableBridge(subscriber.Subscribe(key, handler)));
		}

		public UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IAsyncMessageHandler<TMessage> handler, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			return new UniTask<IUniTaskAsyncDisposable>(new AsyncDisposableBridge(subscriber.Subscribe(key, handler, filters)));
		}
	}
}
