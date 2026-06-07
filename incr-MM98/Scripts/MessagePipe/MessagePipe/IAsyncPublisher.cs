using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IAsyncPublisher<TMessage>
	{
		void Publish(TMessage message, CancellationToken cancellationToken = default(CancellationToken));

		UniTask PublishAsync(TMessage message, CancellationToken cancellationToken = default(CancellationToken));

		UniTask PublishAsync(TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken = default(CancellationToken));
	}
	public interface IAsyncPublisher<TKey, TMessage>
	{
		void Publish(TKey key, TMessage message, CancellationToken cancellationToken = default(CancellationToken));

		UniTask PublishAsync(TKey key, TMessage message, CancellationToken cancellationToken = default(CancellationToken));

		UniTask PublishAsync(TKey key, TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken = default(CancellationToken));
	}
}
