using System;
using System.Linq;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class FilterAttachedRequestHandlerFactory
	{
		private readonly MessagePipeOptions options;

		private readonly AttributeFilterProvider<RequestHandlerFilterAttribute> filterProvider;

		private readonly IServiceProvider provider;

		[Preserve]
		public FilterAttachedRequestHandlerFactory(MessagePipeOptions options, AttributeFilterProvider<RequestHandlerFilterAttribute> filterProvider, IServiceProvider provider)
		{
			this.options = options;
			this.filterProvider = filterProvider;
			this.provider = provider;
		}

		public IRequestHandlerCore<TRequest, TResponse> CreateRequestHandler<TRequest, TResponse>(IRequestHandlerCore<TRequest, TResponse> handler)
		{
			var (num, first) = options.GetGlobalRequestHandlerFilters(provider, typeof(TRequest), typeof(TResponse));
			var (num2, second) = filterProvider.GetAttributeFilters(handler.GetType(), provider);
			if (num != 0 || num2 != 0)
			{
				handler = new FilterAttachedRequestHandler<TRequest, TResponse>(handler, first.Concat(second).Cast<RequestHandlerFilter<TRequest, TResponse>>());
			}
			return handler;
		}
	}
}
