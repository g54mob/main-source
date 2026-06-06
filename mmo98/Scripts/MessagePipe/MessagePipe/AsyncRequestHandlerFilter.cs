using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public abstract class AsyncRequestHandlerFilter<TRequest, TResponse> : IAsyncRequestHandlerFilter, IMessagePipeFilter
	{
		public int Order { get; set; }

		public abstract UniTask<TResponse> InvokeAsync(TRequest request, CancellationToken cancellationToken, Func<TRequest, CancellationToken, UniTask<TResponse>> next);
	}
}
