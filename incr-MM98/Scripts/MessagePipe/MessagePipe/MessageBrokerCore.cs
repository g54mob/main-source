using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MessagePipe.Internal;

namespace MessagePipe
{
	[Preserve]
	public class MessageBrokerCore<TMessage> : IDisposable, IHandlerHolderMarker
	{
		private sealed class Subscription : IDisposable
		{
			private bool isDisposed;

			private readonly MessageBrokerCore<TMessage> core;

			private readonly int subscriptionKey;

			public Subscription(MessageBrokerCore<TMessage> core, int subscriptionKey)
			{
				this.core = core;
				this.subscriptionKey = subscriptionKey;
			}

			public void Dispose()
			{
				if (isDisposed)
				{
					return;
				}
				isDisposed = true;
				lock (core.gate)
				{
					if (!core.isDisposed)
					{
						core.handlers.Remove(subscriptionKey, shrinkWhenEmpty: true);
						core.diagnostics.DecrementSubscribe(core, this);
					}
				}
			}
		}

		private readonly FreeList<IMessageHandler<TMessage>> handlers;

		private readonly MessagePipeDiagnosticsInfo diagnostics;

		private readonly HandlingSubscribeDisposedPolicy handlingSubscribeDisposedPolicy;

		private readonly object gate = new object();

		private bool isDisposed;

		[Preserve]
		public MessageBrokerCore(MessagePipeDiagnosticsInfo diagnostics, MessagePipeOptions options)
		{
			handlers = new FreeList<IMessageHandler<TMessage>>();
			handlingSubscribeDisposedPolicy = options.HandlingSubscribeDisposedPolicy;
			this.diagnostics = diagnostics;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void Publish(TMessage message)
		{
			IMessageHandler<TMessage>[] values = handlers.GetValues();
			for (int i = 0; i < values.Length; i++)
			{
				values[i]?.Handle(message);
			}
		}

		public IDisposable Subscribe(IMessageHandler<TMessage> handler)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					return handlingSubscribeDisposedPolicy.Handle("MessageBrokerCore");
				}
				int subscriptionKey = handlers.Add(handler);
				Subscription subscription = new Subscription(this, subscriptionKey);
				diagnostics.IncrementSubscribe(this, subscription);
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
					diagnostics.RemoveTargetDiagnostics(this, clearedCount);
				}
			}
		}
	}
	[Preserve]
	public class MessageBrokerCore<TKey, TMessage> : IDisposable
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

			private readonly FreeList<IMessageHandler<TMessage>> handlers;

			private readonly MessageBrokerCore<TKey, TMessage> core;

			public HandlerHolder(MessageBrokerCore<TKey, TMessage> core)
			{
				handlers = new FreeList<IMessageHandler<TMessage>>();
				this.core = core;
			}

			public IMessageHandler<TMessage>[] GetHandlers()
			{
				return handlers.GetValues();
			}

			public IDisposable Subscribe(TKey key, IMessageHandler<TMessage> handler)
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

		private readonly HandlingSubscribeDisposedPolicy handlingSubscribeDisposedPolicy;

		private readonly object gate;

		private bool isDisposed;

		[Preserve]
		public MessageBrokerCore(MessagePipeDiagnosticsInfo diagnotics, MessagePipeOptions options)
		{
			handlerGroup = new Dictionary<TKey, HandlerHolder>();
			this.diagnotics = diagnotics;
			handlingSubscribeDisposedPolicy = options.HandlingSubscribeDisposedPolicy;
			gate = new object();
		}

		public void Publish(TKey key, TMessage message)
		{
			IMessageHandler<TMessage>[] handlers;
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
				handlers[i]?.Handle(message);
			}
		}

		public IDisposable Subscribe(TKey key, IMessageHandler<TMessage> handler)
		{
			lock (gate)
			{
				if (isDisposed)
				{
					return handlingSubscribeDisposedPolicy.Handle("MessageBrokerCore");
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
