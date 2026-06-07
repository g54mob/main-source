using System;
using System.Linq;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class FilterAttachedAsyncMessageHandlerFactory
	{
		private readonly MessagePipeOptions options;

		private readonly AttributeFilterProvider<AsyncMessageHandlerFilterAttribute> filterProvider;

		private readonly IServiceProvider provider;

		[Preserve]
		public FilterAttachedAsyncMessageHandlerFactory(MessagePipeOptions options, AttributeFilterProvider<AsyncMessageHandlerFilterAttribute> filterProvider, IServiceProvider provider)
		{
			this.options = options;
			this.filterProvider = filterProvider;
			this.provider = provider;
		}

		public IAsyncMessageHandler<TMessage> CreateAsyncMessageHandler<TMessage>(IAsyncMessageHandler<TMessage> handler, AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			var (num, first) = options.GetGlobalAsyncMessageHandlerFilters(provider, typeof(TMessage));
			var (num2, second) = filterProvider.GetAttributeFilters(handler.GetType(), provider);
			if (filters.Length != 0 || num != 0 || num2 != 0)
			{
				handler = new FilterAttachedAsyncMessageHandler<TMessage>(handler, first.Concat(second).Concat(filters).Cast<AsyncMessageHandlerFilter<TMessage>>());
			}
			return handler;
		}
	}
}
