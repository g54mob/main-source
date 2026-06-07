using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	internal sealed class FilterAttachedAsyncRequestHandler<TRequest, TResponse> : IAsyncRequestHandler<TRequest, TResponse>, IAsyncRequestHandlerCore<TRequest, TResponse>, IAsyncRequestHandler
	{
		private Func<TRequest, CancellationToken, UniTask<TResponse>> handler;

		public FilterAttachedAsyncRequestHandler(IAsyncRequestHandlerCore<TRequest, TResponse> body, IEnumerable<AsyncRequestHandlerFilter<TRequest, TResponse>> filters)
		{
			Func<TRequest, CancellationToken, UniTask<TResponse>> next = body.InvokeAsync;
			foreach (AsyncRequestHandlerFilter<TRequest, TResponse> item in filters.OrderByDescending((AsyncRequestHandlerFilter<TRequest, TResponse> x) => x.Order))
			{
				next = new AsyncRequestHandlerFilterRunner<TRequest, TResponse>(item, next).GetDelegate();
			}
			handler = next;
		}

		public UniTask<TResponse> InvokeAsync(TRequest request, CancellationToken cancellationToken)
		{
			return handler(request, cancellationToken);
		}
	}
}
