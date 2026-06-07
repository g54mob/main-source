using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IDistributedSubscriber<TKey, TMessage>
	{
		UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IMessageHandler<TMessage> handler, CancellationToken cancellationToken = default(CancellationToken));

		UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IMessageHandler<TMessage> handler, MessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken));

		UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IAsyncMessageHandler<TMessage> handler, CancellationToken cancellationToken = default(CancellationToken));

		UniTask<IUniTaskAsyncDisposable> SubscribeAsync(TKey key, IAsyncMessageHandler<TMessage> handler, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken));
	}
}
