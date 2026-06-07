using System;
using System.Threading;
using Cysharp.Threading.Tasks;

namespace MessagePipe
{
	public static class DistributedSubscriberExtensions
	{
		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Action<TMessage> handler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(key, handler, Array.Empty<MessageHandlerFilter<TMessage>>(), cancellationToken);
		}

		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Action<TMessage> handler, MessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(key, new AnonymousMessageHandler<TMessage>(handler), filters, cancellationToken);
		}

		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Action<TMessage> handler, Func<TMessage, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(key, handler, predicate, Array.Empty<MessageHandlerFilter<TMessage>>(), cancellationToken);
		}

		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Action<TMessage> handler, Func<TMessage, bool> predicate, MessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			PredicateFilter<TMessage> predicateFilter = new PredicateFilter<TMessage>(predicate);
			MessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = Append(filters, predicateFilter);
			}
			else
			{
				MessageHandlerFilter<TMessage>[] array2 = new PredicateFilter<TMessage>[1] { predicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.SubscribeAsync(key, new AnonymousMessageHandler<TMessage>(handler), filters, cancellationToken);
		}

		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Func<TMessage, CancellationToken, UniTask> handler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(key, handler, Array.Empty<AsyncMessageHandlerFilter<TMessage>>(), cancellationToken);
		}

		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Func<TMessage, CancellationToken, UniTask> handler, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(key, new AnonymousAsyncMessageHandler<TMessage>(handler), filters, cancellationToken);
		}

		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(key, handler, predicate, Array.Empty<AsyncMessageHandlerFilter<TMessage>>(), cancellationToken);
		}

		public static UniTask<IUniTaskAsyncDisposable> SubscribeAsync<TKey, TMessage>(this IDistributedSubscriber<TKey, TMessage> subscriber, TKey key, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			AsyncPredicateFilter<TMessage> asyncPredicateFilter = new AsyncPredicateFilter<TMessage>(predicate);
			AsyncMessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = Append(filters, asyncPredicateFilter);
			}
			else
			{
				AsyncMessageHandlerFilter<TMessage>[] array2 = new AsyncPredicateFilter<TMessage>[1] { asyncPredicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.SubscribeAsync(key, new AnonymousAsyncMessageHandler<TMessage>(handler), filters, cancellationToken);
		}

		private static T[] Append<T>(T[] source, T item)
		{
			T[] array = new T[source.Length + 1];
			Array.Copy(source, 0, array, 0, source.Length);
			array[^1] = item;
			return array;
		}
	}
}
