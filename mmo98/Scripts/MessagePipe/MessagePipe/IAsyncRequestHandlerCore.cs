using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IAsyncRequestHandlerCore<in TRequest, TResponse> : IAsyncRequestHandler
	{
		UniTask<TResponse> InvokeAsync(TRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}
}
