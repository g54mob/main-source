using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using MessagePipe;

public static class EventHub
{
	public static class Scene
	{
		public static MessagePipeDiagnosticsInfo DiagnosticsInfo => GlobalMessagePipe.DiagnosticsInfo;

		public static void Publish<TMessage>(TMessage message)
		{
			GlobalMessagePipe.GetPublisher<TMessage>().Publish(message);
		}

		public static void Publish<TMessage>()
		{
			Publish(default(TMessage));
		}

		[MustDisposeResource]
		public static EventHubBuilder For(int initialCapacity = 4)
		{
			return new EventHubBuilder(persistent: false, DisposableBag.CreateBuilder(initialCapacity));
		}

		[MustDisposeResource]
		public static EventHubBuilder For(DisposableBagBuilder bag)
		{
			return new EventHubBuilder(persistent: false, bag);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TMessage>(Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TMessage>(Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TMessage>(Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TMessage>(Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeBuffered<TMessage>(Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeBuffered<TMessage>(Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TKey, TMessage>(TKey key, Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetSubscriber<TKey, TMessage>().Subscribe(key, handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TKey, TMessage>(TKey key, Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetSubscriber<TKey, TMessage>().Subscribe(key, handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TKey, TMessage>(TKey key, Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetAsyncSubscriber<TKey, TMessage>().Subscribe(key, handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TKey, TMessage>(TKey key, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return GlobalMessagePipe.GetAsyncSubscriber<TKey, TMessage>().Subscribe(key, handler, predicate, filters);
		}
	}

	public static class Persistent
	{
		public static MessagePipeDiagnosticsInfo DiagnosticsInfo => PersistentMessagePipe.DiagnosticsInfo;

		public static void Publish<TMessage>(TMessage message)
		{
			PersistentMessagePipe.GetPublisher<TMessage>().Publish(message);
		}

		[MustDisposeResource]
		public static EventHubBuilder For(int initialCapacity = 4)
		{
			return new EventHubBuilder(persistent: true, DisposableBag.CreateBuilder(initialCapacity));
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TMessage>(Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TMessage>(Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetSubscriber<TMessage>().Subscribe(handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TMessage>(Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TMessage>(Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetAsyncSubscriber<TMessage>().Subscribe(handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeBuffered<TMessage>(Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeBuffered<TMessage>(Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetBufferedSubscriber<TMessage>().Subscribe(handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TKey, TMessage>(TKey key, Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetSubscriber<TKey, TMessage>().Subscribe(key, handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable Subscribe<TKey, TMessage>(TKey key, Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetSubscriber<TKey, TMessage>().Subscribe(key, handler, predicate, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TKey, TMessage>(TKey key, Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetAsyncSubscriber<TKey, TMessage>().Subscribe(key, handler, filters);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[MustDisposeResource]
		public static IDisposable SubscribeAsync<TKey, TMessage>(TKey key, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return PersistentMessagePipe.GetAsyncSubscriber<TKey, TMessage>().Subscribe(key, handler, predicate, filters);
		}
	}
}
