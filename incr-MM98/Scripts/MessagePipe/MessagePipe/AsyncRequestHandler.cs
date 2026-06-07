using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class AsyncRequestHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>, IAsyncRequestHandlerCore<TRequest, TResponse>, IAsyncRequestHandler
	{
		private readonly IAsyncRequestHandlerCore<TRequest, TResponse> handler;

		[Preserve]
		public AsyncRequestHandler(IAsyncRequestHandlerCore<TRequest, TResponse> handler, FilterAttachedAsyncRequestHandlerFactory handlerFactory)
		{
			this.handler = handlerFactory.CreateAsyncRequestHandler(handler);
		}

		public UniTask<TResponse> InvokeAsync(TRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			return handler.InvokeAsync(request, cancellationToken);
		}
	}
}
