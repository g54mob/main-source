using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class AsyncMessageBrokerCore<TMessage> : IDisposable, IHandlerHolderMarker
	{
		private sealed class Subscription : IDisposable
		{
			private bool isDisposed;

			private readonly AsyncMessageBrokerCore<TMessage> core;

			private readonly int subscriptionKey;

			public Subscription(AsyncMessageBrokerCore<TMessage> core, int subscriptionKey)
			{
				this.core = core;
				this.subscriptionKey = subscriptionKey;
			}

			public void Dispose()
			{
				if (!isDisposed)
				{
					isDisposed = true;
					lock (core.gate)
					{
						core.handlers.Remove(subscriptionKey, shrinkWhenEmpty: true);
						core.diagnotics.DecrementSubscribe(core, this);
					}
				}
			}
		}

		private FreeList<IAsyncMessageHandler<TMessage>> handlers;

		private readonly MessagePipeDiagnosticsInfo diagnotics;

		private readonly AsyncPublishStrategy defaultAsyncPublishStrategy;

		private readonly HandlingSubscribeDisposedPolicy handlingSubscribeDisposedPolicy;

		private readonly object gate = new object();

		private bool isDisposed;

		[Preserve]
		public AsyncMessageBrokerCore(MessagePipeDiagnosticsInfo diagnotics, MessagePipeOptions options)
		{
			handlers = new FreeList<IAsyncMessageHandler<TMessage>>();
			defaultAsyncPublishStrategy = options.DefaultAsyncPublishStrategy;
			handlingSubscribeDisposedPolicy = options.HandlingSubscribeDisposedPolicy;
			this.diagnotics = diagnotics;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Publish(TMessage message, CancellationToken cancellationToken)
		{
			IAsyncMessageHandler<TMessage>[] values = handlers.GetValues();
			for (int i = 0; i < values.Length; i++)
			{
				values[i]?.HandleAsync(message, cancellationToken).Forget();
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public UniTask PublishAsync(TMessage message, CancellationToken cancellationToken)
		{
			return PublishAsync(message, defaultAsyncPublishStrategy, cancellationToken);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public async UniTask PublishAsync(TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			IAsyncMessageHandler<TMessage>[] values = handlers.GetValues();
			if (publishStrategy == AsyncPublishStrategy.Sequential)
			{
				IAsyncMessageHandler<TMessage>[] array = values;
				foreach (IAsyncMessageHandler<TMessage> asyncMessageHandler in array)
				{
					if (asyncMessageHandler != null)
					{
						await asyncMessageHandler.HandleAsync(message, cancellationToken);
					}
				}
			}
			else
			{
				await new AsyncHandlerWhenAll<TMessage>(values, message, cancellationToken);
			}
		}

		public IDisposable Subscribe(IAsyncMessageHandler<TMessage> handler)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					return handlingSubscribeDisposedPolicy.Handle("AsyncMessageBrokerCore");
				}
				int subscriptionKey = handlers.Add(handler);
				Subscription subscription = new Subscription(this, subscriptionKey);
				diagnotics.IncrementSubscribe(this, subscription);
				return subscription;
			}
		}

		public void Dispose()
		{
			lock (gate)
			{
				if (!isDisposed && handlers.TryDispose(out var clearedCount))
				{
					isDisposed = true;
					diagnotics.RemoveTargetDiagnostics(this, clearedCount);
				}
			}
		}
	}
	[Preserve]
	public class AsyncMessageBrokerCore<TKey, TMessage> : IDisposable
	{
		private sealed class HandlerHolder : IDisposable, IHandlerHolderMarker
		{
			private sealed class Subscription : IDisposable
			{
				private bool isDisposed;

				private readonly TKey key;

				private readonly int subscriptionKey;

				private readonly HandlerHolder holder;

				public Subscription(TKey key, int subscriptionKey, HandlerHolder holder)
				{
					this.key = key;
					this.subscriptionKey = subscriptionKey;
					this.holder = holder;
				}

				public void Dispose()
				{
					if (isDisposed)
					{
						return;
					}
					isDisposed = true;
					lock (holder.core.gate)
					{
						if (!holder.core.isDisposed)
						{
							holder.handlers.Remove(subscriptionKey, shrinkWhenEmpty: false);
							holder.core.diagnotics.DecrementSubscribe(holder, this);
							if (holder.handlers.GetCount() == 0)
							{
								holder.core.handlerGroup.Remove(key);
							}
						}
					}
				}
			}

			private readonly FreeList<IAsyncMessageHandler<TMessage>> handlers;

			private readonly AsyncMessageBrokerCore<TKey, TMessage> core;

			public HandlerHolder(AsyncMessageBrokerCore<TKey, TMessage> core)
			{
				handlers = new FreeList<IAsyncMessageHandler<TMessage>>();
				this.core = core;
			}

			public IAsyncMessageHandler<TMessage>[] GetHandlers()
			{
				return handlers.GetValues();
			}

			public IDisposable Subscribe(TKey key, IAsyncMessageHandler<TMessage> handler)
			{
				int subscriptionKey = handlers.Add(handler);
				Subscription subscription = new Subscription(key, subscriptionKey, this);
				core.diagnotics.IncrementSubscribe(this, subscription);
				return subscription;
			}

			public void Dispose()
			{
				lock (core.gate)
				{
					if (handlers.TryDispose(out var clearedCount))
					{
						core.diagnotics.RemoveTargetDiagnostics(this, clearedCount);
					}
				}
			}
		}

		private readonly Dictionary<TKey, HandlerHolder> handlerGroup;

		private readonly MessagePipeDiagnosticsInfo diagnotics;

		private readonly AsyncPublishStrategy defaultAsyncPublishStrategy;

		private readonly HandlingSubscribeDisposedPolicy handlingSubscribeDisposedPolicy;

		private readonly object gate;

		private bool isDisposed;

		[Preserve]
		public AsyncMessageBrokerCore(MessagePipeDiagnosticsInfo diagnotics, MessagePipeOptions options)
		{
			handlerGroup = new Dictionary<TKey, HandlerHolder>();
			this.diagnotics = diagnotics;
			defaultAsyncPublishStrategy = options.DefaultAsyncPublishStrategy;
			handlingSubscribeDisposedPolicy = options.HandlingSubscribeDisposedPolicy;
			gate = new object();
		}

		public void Publish(TKey key, TMessage message, CancellationToken cancellationToken)
		{
			IAsyncMessageHandler<TMessage>[] handlers;
			lock (gate)
			{
				if (!handlerGroup.TryGetValue(key, out var value))
				{
					return;
				}
				handlers = value.GetHandlers();
			}
			for (int i = 0; i < handlers.Length; i++)
			{
				handlers[i]?.HandleAsync(message, cancellationToken).Forget();
			}
		}

		public UniTask PublishAsync(TKey key, TMessage message, CancellationToken cancellationToken)
		{
			return PublishAsync(key, message, defaultAsyncPublishStrategy, cancellationToken);
		}

		public async UniTask PublishAsync(TKey key, TMessage message, AsyncPublishStrategy publishStrategy, CancellationToken cancellationToken)
		{
			IAsyncMessageHandler<TMessage>[] handlers;
			lock (gate)
			{
				if (!handlerGroup.TryGetValue(key, out var value))
				{
					return;
				}
				handlers = value.GetHandlers();
			}
			if (publishStrategy == AsyncPublishStrategy.Sequential)
			{
				IAsyncMessageHandler<TMessage>[] array = handlers;
				foreach (IAsyncMessageHandler<TMessage> asyncMessageHandler in array)
				{
					if (asyncMessageHandler != null)
					{
						await asyncMessageHandler.HandleAsync(message, cancellationToken);
					}
				}
			}
			else
			{
				await new AsyncHandlerWhenAll<TMessage>(handlers, message, cancellationToken);
			}
		}

		public IDisposable Subscribe(TKey key, IAsyncMessageHandler<TMessage> handler)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					return handlingSubscribeDisposedPolicy.Handle("AsyncMessageBrokerCore");
				}
				if (!handlerGroup.TryGetValue(key, out var value))
				{
					value = (handlerGroup[key] = new HandlerHolder(this));
				}
				return value.Subscribe(key, handler);
			}
		}

		public void Dispose()
		{
			lock (gate)
			{
				if (isDisposed)
				{
					return;
				}
				isDisposed = true;
				foreach (HandlerHolder value in handlerGroup.Values)
				{
					value.Dispose();
				}
			}
		}
	}
}
