using System;
using System.Collections.Generic;

namespace MessagePipe
{
	public class BuiltinContainerBuilder : IServiceCollection
	{
		internal readonly Dictionary<Type, object> singletonInstances = new Dictionary<Type, object>();

		internal readonly List<(Type serviceType, Type implementationType)> singleton = new List<(Type, Type)>();

		internal readonly List<(Type serviceType, Type implementationType)> transient = new List<(Type, Type)>();

		public BuiltinContainerBuilder AddMessagePipe()
		{
			return AddMessagePipe(delegate
			{
			});
		}

		public BuiltinContainerBuilder AddMessagePipe(Action<MessagePipeOptions> configure)
		{
			ServiceCollectionExtensions.AddMessagePipe(this, configure);
			return this;
		}

		public IServiceProvider BuildServiceProvider()
		{
			return new BuiltinContainerBuilderServiceProvider(this);
		}

		public BuiltinContainerBuilder AddMessageBroker<TMessage>()
		{
			AddSingleton(typeof(MessageBrokerCore<TMessage>));
			AddSingleton(typeof(IPublisher<TMessage>), typeof(MessageBroker<TMessage>));
			AddSingleton(typeof(ISubscriber<TMessage>), typeof(MessageBroker<TMessage>));
			AddSingleton(typeof(AsyncMessageBrokerCore<TMessage>));
			AddSingleton(typeof(IAsyncPublisher<TMessage>), typeof(AsyncMessageBroker<TMessage>));
			AddSingleton(typeof(IAsyncSubscriber<TMessage>), typeof(AsyncMessageBroker<TMessage>));
			AddSingleton(typeof(BufferedMessageBrokerCore<TMessage>));
			AddSingleton(typeof(IBufferedPublisher<TMessage>), typeof(BufferedMessageBroker<TMessage>));
			AddSingleton(typeof(IBufferedSubscriber<TMessage>), typeof(BufferedMessageBroker<TMessage>));
			AddSingleton(typeof(BufferedAsyncMessageBrokerCore<TMessage>));
			AddSingleton(typeof(IBufferedAsyncPublisher<TMessage>), typeof(BufferedAsyncMessageBroker<TMessage>));
			AddSingleton(typeof(IBufferedAsyncSubscriber<TMessage>), typeof(BufferedAsyncMessageBroker<TMessage>));
			return this;
		}

		public BuiltinContainerBuilder AddMessageBroker<TKey, TMessage>()
		{
			AddSingleton(typeof(MessageBrokerCore<TKey, TMessage>));
			AddSingleton(typeof(IPublisher<TKey, TMessage>), typeof(MessageBroker<TKey, TMessage>));
			AddSingleton(typeof(ISubscriber<TKey, TMessage>), typeof(MessageBroker<TKey, TMessage>));
			AddSingleton(typeof(AsyncMessageBrokerCore<TKey, TMessage>));
			AddSingleton(typeof(IAsyncPublisher<TKey, TMessage>), typeof(AsyncMessageBroker<TKey, TMessage>));
			AddSingleton(typeof(IAsyncSubscriber<TKey, TMessage>), typeof(AsyncMessageBroker<TKey, TMessage>));
			return this;
		}

		public BuiltinContainerBuilder AddRequestHandler<TRequest, TResponse, THandler>() where THandler : IRequestHandler
		{
			AddSingleton(typeof(IRequestHandlerCore<TRequest, TResponse>), typeof(THandler));
			AddSingleton(typeof(IRequestHandler<TRequest, TResponse>), typeof(RequestHandler<TRequest, TResponse>));
			return this;
		}

		public BuiltinContainerBuilder AddAsyncRequestHandler<TRequest, TResponse, THandler>() where THandler : IAsyncRequestHandler
		{
			AddSingleton(typeof(IAsyncRequestHandlerCore<TRequest, TResponse>), typeof(THandler));
			AddSingleton(typeof(IAsyncRequestHandler<TRequest, TResponse>), typeof(AsyncRequestHandler<TRequest, TResponse>));
			AsyncRequestHandlerRegistory.Add(typeof(TRequest), typeof(TResponse), typeof(THandler));
			return this;
		}

		public BuiltinContainerBuilder AddMessageHandlerFilter<T>() where T : class, IMessageHandlerFilter
		{
			TryAddTransient(typeof(T));
			return this;
		}

		public BuiltinContainerBuilder AddAsyncMessageHandlerFilter<T>() where T : class, IAsyncMessageHandlerFilter
		{
			TryAddTransient(typeof(T));
			return this;
		}

		public BuiltinContainerBuilder AddRequestHandlerFilter<T>() where T : class, IRequestHandlerFilter
		{
			TryAddTransient(typeof(T));
			return this;
		}

		public BuiltinContainerBuilder AddAsyncRequestHandlerFilter<T>() where T : class, IAsyncRequestHandlerFilter
		{
			TryAddTransient(typeof(T));
			return this;
		}

		public void AddSingleton<T>(T instance)
		{
			singletonInstances[typeof(T)] = instance;
		}

		public void AddSingleton(Type type)
		{
			singleton.Add((type, type));
		}

		public void AddTransient(Type type)
		{
			transient.Add((type, type));
		}

		public void TryAddTransient(Type type)
		{
			foreach (var item in transient)
			{
				if (item.serviceType == type)
				{
					return;
				}
			}
			transient.Add((type, type));
		}

		public void AddSingleton(Type serviceType, Type implementationType)
		{
			singleton.Add((serviceType, implementationType));
		}

		public void Add(Type serviceType, InstanceLifetime lifetime)
		{
			Add(serviceType, serviceType, lifetime);
		}

		public void Add(Type serviceType, Type implementationType, InstanceLifetime lifetime)
		{
			if (lifetime == InstanceLifetime.Scoped || lifetime == InstanceLifetime.Singleton)
			{
				singleton.Add((serviceType, implementationType));
			}
			else
			{
				transient.Add((serviceType, implementationType));
			}
		}
	}
}
