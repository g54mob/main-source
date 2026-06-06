using System;
using System.Collections.Generic;
using MessagePipe.Internal;

namespace MessagePipe
{
	public sealed class MessagePipeOptions
	{
		private List<FilterDefinition> messageHandlerFilters = new List<FilterDefinition>();

		private List<FilterDefinition> asyncMessageHandlerFilters = new List<FilterDefinition>();

		private List<FilterDefinition> requestHandlerFilters = new List<FilterDefinition>();

		private List<FilterDefinition> asyncRequestHandlerFilters = new List<FilterDefinition>();

		public AsyncPublishStrategy DefaultAsyncPublishStrategy { get; set; }

		public bool EnableCaptureStackTrace { get; set; }

		public HandlingSubscribeDisposedPolicy HandlingSubscribeDisposedPolicy { get; set; }

		public InstanceLifetime InstanceLifetime { get; set; }

		public InstanceLifetime RequestHandlerLifetime { get; set; }

		public MessagePipeOptions()
		{
			DefaultAsyncPublishStrategy = AsyncPublishStrategy.Parallel;
			InstanceLifetime = InstanceLifetime.Singleton;
			RequestHandlerLifetime = InstanceLifetime.Scoped;
			EnableCaptureStackTrace = false;
			HandlingSubscribeDisposedPolicy = HandlingSubscribeDisposedPolicy.Ignore;
		}

		internal IEnumerable<Type> GetGlobalFilterTypes()
		{
			foreach (FilterDefinition messageHandlerFilter in messageHandlerFilters)
			{
				yield return messageHandlerFilter.FilterType;
			}
			foreach (FilterDefinition asyncMessageHandlerFilter in asyncMessageHandlerFilters)
			{
				yield return asyncMessageHandlerFilter.FilterType;
			}
			foreach (FilterDefinition requestHandlerFilter in requestHandlerFilters)
			{
				yield return requestHandlerFilter.FilterType;
			}
			foreach (FilterDefinition asyncRequestHandlerFilter in asyncRequestHandlerFilters)
			{
				yield return asyncRequestHandlerFilter.FilterType;
			}
		}

		public void AddGlobalMessageHandlerFilter<T>(int order = 0) where T : IMessageHandlerFilter
		{
			messageHandlerFilters.Add(new MessageHandlerFilterDefinition(typeof(T), order, typeof(MessageHandlerFilter<>)));
		}

		internal (int count, IEnumerable<IMessageHandlerFilter>) GetGlobalMessageHandlerFilters(IServiceProvider provider, Type messageType)
		{
			return (count: messageHandlerFilters.Count, CreateFilters<IMessageHandlerFilter>(messageHandlerFilters, provider, messageType));
		}

		public void AddGlobalAsyncMessageHandlerFilter<T>(int order = 0) where T : IAsyncMessageHandlerFilter
		{
			asyncMessageHandlerFilters.Add(new MessageHandlerFilterDefinition(typeof(T), order, typeof(AsyncMessageHandlerFilter<>)));
		}

		internal (int count, IEnumerable<IAsyncMessageHandlerFilter>) GetGlobalAsyncMessageHandlerFilters(IServiceProvider provider, Type messageType)
		{
			return (count: asyncMessageHandlerFilters.Count, CreateFilters<IAsyncMessageHandlerFilter>(asyncMessageHandlerFilters, provider, messageType));
		}

		public void AddGlobalRequestHandlerFilter<T>(int order = 0) where T : IRequestHandlerFilter
		{
			requestHandlerFilters.Add(new RequestHandlerFilterDefinition(typeof(T), order, typeof(RequestHandlerFilter<, >)));
		}

		internal (int, IEnumerable<IRequestHandlerFilter>) GetGlobalRequestHandlerFilters(IServiceProvider provider, Type requestType, Type responseType)
		{
			return (requestHandlerFilters.Count, CreateFilters<IRequestHandlerFilter>(requestHandlerFilters, provider, requestType, responseType));
		}

		public void AddGlobalAsyncRequestHandlerFilter<T>(int order = 0) where T : IAsyncRequestHandlerFilter
		{
			asyncRequestHandlerFilters.Add(new RequestHandlerFilterDefinition(typeof(T), order, typeof(AsyncRequestHandlerFilter<, >)));
		}

		internal (int, IEnumerable<IAsyncRequestHandlerFilter>) GetGlobalAsyncRequestHandlerFilters(IServiceProvider provider, Type requestType, Type responseType)
		{
			return (asyncRequestHandlerFilters.Count, CreateFilters<IAsyncRequestHandlerFilter>(asyncRequestHandlerFilters, provider, requestType, responseType));
		}

		private static IEnumerable<T> CreateFilters<T>(List<FilterDefinition> filterDefinitions, IServiceProvider provider, Type messageType) where T : IMessagePipeFilter
		{
			if (filterDefinitions.Count == 0)
			{
				return Array.Empty<T>();
			}
			return CreateFiltersCore<T>(filterDefinitions, provider, messageType);
		}

		private static IEnumerable<T> CreateFiltersCore<T>(List<FilterDefinition> filterDefinitions, IServiceProvider provider, Type messageType) where T : IMessagePipeFilter
		{
			for (int i = 0; i < filterDefinitions.Count; i++)
			{
				if (filterDefinitions[i] is MessageHandlerFilterDefinition { FilterType: var type } messageHandlerFilterDefinition)
				{
					if (messageHandlerFilterDefinition.IsOpenGenerics)
					{
						type = type.MakeGenericType(messageType);
					}
					else if (messageHandlerFilterDefinition.MessageType != messageType)
					{
						continue;
					}
					T val = (T)provider.GetRequiredService(type);
					val.Order = messageHandlerFilterDefinition.Order;
					yield return val;
				}
			}
		}

		private static IEnumerable<T> CreateFilters<T>(List<FilterDefinition> filterDefinitions, IServiceProvider provider, Type requestType, Type responseType) where T : IMessagePipeFilter
		{
			if (filterDefinitions.Count == 0)
			{
				return Array.Empty<T>();
			}
			return CreateFiltersCore<T>(filterDefinitions, provider, requestType, responseType);
		}

		private static IEnumerable<T> CreateFiltersCore<T>(List<FilterDefinition> filterDefinitions, IServiceProvider provider, Type requestType, Type responseType) where T : IMessagePipeFilter
		{
			for (int i = 0; i < filterDefinitions.Count; i++)
			{
				if (filterDefinitions[i] is RequestHandlerFilterDefinition { FilterType: var type } requestHandlerFilterDefinition)
				{
					if (requestHandlerFilterDefinition.IsOpenGenerics)
					{
						type = type.MakeGenericType(requestType, responseType);
					}
					else if (!(requestHandlerFilterDefinition.RequestType == requestType) || !(requestHandlerFilterDefinition.ResponseType == responseType))
					{
						continue;
					}
					T val = (T)provider.GetRequiredService(type);
					val.Order = requestHandlerFilterDefinition.Order;
					yield return val;
				}
			}
		}

		private void ValidateFilterType(Type type, Type filterType)
		{
			if (!filterType.IsAssignableFrom(type))
			{
				throw new ArgumentException(type.FullName + " is not " + filterType.Name);
			}
		}
	}
}
