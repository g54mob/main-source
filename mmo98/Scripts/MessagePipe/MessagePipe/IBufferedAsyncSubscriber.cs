using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IBufferedAsyncSubscriber<TMessage>
	{
		UniTask<IDisposable> SubscribeAsync(IAsyncMessageHandler<TMessage> handler, CancellationToken cancellationToken = default(CancellationToken));

		UniTask<IDisposable> SubscribeAsync(IAsyncMessageHandler<TMessage> handler, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken));
	}
}
