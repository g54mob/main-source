using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class AsyncRequestHandlerFilterRunner<TRequest, TResponse>
	{
		private readonly AsyncRequestHandlerFilter<TRequest, TResponse> filter;

		private readonly Func<TRequest, CancellationToken, UniTask<TResponse>> next;

		public AsyncRequestHandlerFilterRunner(AsyncRequestHandlerFilter<TRequest, TResponse> filter, Func<TRequest, CancellationToken, UniTask<TResponse>> next)
		{
			this.filter = filter;
			this.next = next;
		}

		public Func<TRequest, CancellationToken, UniTask<TResponse>> GetDelegate()
		{
			return InvokeAsync;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private UniTask<TResponse> InvokeAsync(TRequest request, CancellationToken cancellationToken)
		{
			return filter.InvokeAsync(request, cancellationToken, next);
		}
	}
}
