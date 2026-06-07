using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IAsyncMessageHandler<TMessage>
	{
		UniTask HandleAsync(TMessage message, CancellationToken cancellationToken);
	}
}
