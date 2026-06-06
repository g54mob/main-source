using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagePipe
{
	internal sealed class FilterAttachedRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>, IRequestHandlerCore<TRequest, TResponse>, IRequestHandler
	{
		private Func<TRequest, TResponse> handler;

		public FilterAttachedRequestHandler(IRequestHandlerCore<TRequest, TResponse> body, IEnumerable<RequestHandlerFilter<TRequest, TResponse>> filters)
		{
			Func<TRequest, TResponse> next = body.Invoke;
			foreach (RequestHandlerFilter<TRequest, TResponse> item in filters.OrderByDescending((RequestHandlerFilter<TRequest, TResponse> x) => x.Order))
			{
				next = new RequestHandlerFilterRunner<TRequest, TResponse>(item, next).GetDelegate();
			}
			handler = next;
		}

		public TResponse Invoke(TRequest request)
		{
			return handler(request);
		}
	}
}
