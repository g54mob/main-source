using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public interface IRemoteRequestHandler<in TRequest, TResponse>
	{
		UniTask<TResponse> InvokeAsync(TRequest request, CancellationToken cancellationToken = default(CancellationToken));
	}
}
