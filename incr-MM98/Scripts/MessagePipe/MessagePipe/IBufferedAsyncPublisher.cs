using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IBufferedAsyncPublisher<TMessage>
	{
		void Publish(TMessage message, CancellationToken cancellationToken = default(CancellationToken));

		UniTask PublishAsync(TMessage message, CancellationToken cancellationToken = default(CancellationToken));

		UniTask PublishAsync(TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken = default(CancellationToken));
	}
}
