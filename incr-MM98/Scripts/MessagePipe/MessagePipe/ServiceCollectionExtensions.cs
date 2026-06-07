using System;

namespace MessagePipe
{
	public static class ServiceCollectionExtensions
	{
		public static IMessagePipeBuilder AddMessagePipe(this IServiceCollection services)
		{
			return services.AddMessagePipe(delegate
			{
			});
		}

		public static IMessagePipeBuilder AddMessagePipe(this IServiceCollection services, Action<MessagePipeOptions> configure)
		{
			MessagePipeOptions messagePipeOptions = new MessagePipeOptions();
			configure(messagePipeOptions);
			services.AddSingleton(messagePipeOptions);
			services.AddSingleton(typeof(MessagePipeDiagnosticsInfo));
			services.AddSingleton(typeof(EventFactory));
			services.AddSingleton(typeof(AttributeFilterProvider<MessageHandlerFilterAttribute>));
			services.AddSingleton(typeof(AttributeFilterProvider<AsyncMessageHandlerFilterAttribute>));
			services.AddSingleton(typeof(AttributeFilterProvider<RequestHandlerFilterAttribute>));
			services.AddSingleton(typeof(AttributeFilterProvider<AsyncRequestHandlerFilterAttribute>));
			services.AddSingleton(typeof(FilterAttachedMessageHandlerFactory));
			services.AddSingleton(typeof(FilterAttachedAsyncMessageHandlerFactory));
			services.AddSingleton(typeof(FilterAttachedRequestHandlerFactory));
			services.AddSingleton(typeof(FilterAttachedAsyncRequestHandlerFactory));
			foreach (Type globalFilterType in messagePipeOptions.GetGlobalFilterTypes())
			{
				services.TryAddTransient(globalFilterType);
			}
			return new MessagePipeBuilder(services);
		}
	}
}
