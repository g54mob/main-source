using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class InMemoryDistributedPublisher<TKey, TMessage> : IDistributedPublisher<TKey, TMessage>
	{
		private readonly IAsyncPublisher<TKey, TMessage> publisher;

		[Preserve]
		public InMemoryDistributedPublisher(IAsyncPublisher<TKey, TMessage> publisher)
		{
			this.publisher = publisher;
		}

		public UniTask PublishAsync(TKey key, TMessage message, CancellationToken cancellationToken = default(CancellationToken))
		{
			return publisher.PublishAsync(key, message, cancellationToken);
		}
	}
}
