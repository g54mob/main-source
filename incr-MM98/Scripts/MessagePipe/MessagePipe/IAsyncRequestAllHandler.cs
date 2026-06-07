using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IAsyncRequestAllHandler<in TRequest, TResponse>
	{
		UniTask<TResponse[]> InvokeAllAsync(TRequest request, CancellationToken cancellationToken = default(CancellationToken));

		UniTask<TResponse[]> InvokeAllAsync(TRequest request, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken = default(CancellationToken));

		IUniTaskAsyncEnumerable<TResponse> InvokeAllLazyAsync(TRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}
}
