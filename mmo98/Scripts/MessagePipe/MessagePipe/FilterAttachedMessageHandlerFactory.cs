using System;
using System.Linq;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public sealed class FilterAttachedMessageHandlerFactory
	{
		private readonly MessagePipeOptions options;

		private readonly AttributeFilterProvider<MessageHandlerFilterAttribute> filterProvider;

		private readonly IServiceProvider provider;

		[Preserve]
		public FilterAttachedMessageHandlerFactory(MessagePipeOptions options, AttributeFilterProvider<MessageHandlerFilterAttribute> filterProvider, IServiceProvider provider)
		{
			this.options = options;
			this.filterProvider = filterProvider;
			this.provider = provider;
		}

		public IMessageHandler<TMessage> CreateMessageHandler<TMessage>(IMessageHandler<TMessage> handler, MessageHandlerFilter<TMessage>[] filters)
		{
			var (num, first) = options.GetGlobalMessageHandlerFilters(provider, typeof(TMessage));
			var (num2, second) = filterProvider.GetAttributeFilters(handler.GetType(), provider);
			if (filters.Length != 0 || num != 0 || num2 != 0)
			{
				handler = new FilterAttachedMessageHandler<TMessage>(handler, first.Concat(second).Concat(filters).Cast<MessageHandlerFilter<TMessage>>());
			}
			return handler;
		}
	}
}
