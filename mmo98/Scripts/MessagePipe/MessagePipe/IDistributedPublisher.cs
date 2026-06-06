using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IDistributedPublisher<TKey, TMessage>
	{
		UniTask PublishAsync(TKey key, TMessage message, CancellationToken cancellationToken = default(CancellationToken));
	}
}
