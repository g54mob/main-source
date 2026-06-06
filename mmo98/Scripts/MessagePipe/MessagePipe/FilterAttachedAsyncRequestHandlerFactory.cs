using System;
using System.Linq;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class FilterAttachedAsyncRequestHandlerFactory
	{
		private readonly MessagePipeOptions options;

		private readonly AttributeFilterProvider<AsyncRequestHandlerFilterAttribute> filterProvider;

		private readonly IServiceProvider provider;

		[Preserve]
		public FilterAttachedAsyncRequestHandlerFactory(MessagePipeOptions options, AttributeFilterProvider<AsyncRequestHandlerFilterAttribute> filterProvider, IServiceProvider provider)
		{
			this.options = options;
			this.filterProvider = filterProvider;
			this.provider = provider;
		}

		public IAsyncRequestHandlerCore<TRequest, TResponse> CreateAsyncRequestHandler<TRequest, TResponse>(IAsyncRequestHandlerCore<TRequest, TResponse> handler)
		{
			var (num, first) = options.GetGlobalAsyncRequestHandlerFilters(provider, typeof(TRequest), typeof(TResponse));
			var (num2, second) = filterProvider.GetAttributeFilters(handler.GetType(), provider);
			if (num != 0 || num2 != 0)
			{
				handler = new FilterAttachedAsyncRequestHandler<TRequest, TResponse>(handler, first.Concat(second).Cast<AsyncRequestHandlerFilter<TRequest, TResponse>>());
			}
			return handler;
		}
	}
}
