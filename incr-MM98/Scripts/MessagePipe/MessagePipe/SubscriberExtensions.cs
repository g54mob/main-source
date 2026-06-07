using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe.Internal;

namespace MessagePipe
{
	public static class SubscriberExtensions
	{
		public static IUniTaskAsyncEnumerable<TMessage> AsAsyncEnumerable<TMessage>(this IAsyncSubscriber<TMessage> subscriber, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return new AsyncEnumerableAsyncSubscriber<TMessage>(subscriber, filters);
		}

		public static IUniTaskAsyncEnumerable<TMessage> AsAsyncEnumerable<TMessage>(this IBufferedAsyncSubscriber<TMessage> subscriber, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return new BufferedAsyncEnumerableAsyncSubscriber<TMessage>(subscriber, filters);
		}

		public static IUniTaskAsyncEnumerable<TMessage> AsAsyncEnumerable<TKey, TMessage>(this IAsyncSubscriber<TKey, TMessage> subscriber, TKey key, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return new AsyncEnumerableAsyncSubscriber<TKey, TMessage>(key, subscriber, filters);
		}

		public static IObservable<TMessage> AsObservable<TMessage>(this ISubscriber<TMessage> subscriber, params MessageHandlerFilter<TMessage>[] filters)
		{
			return new ObservableSubscriber<TMessage>(subscriber, filters);
		}

		public static IObservable<TMessage> AsObservable<TMessage>(this IBufferedSubscriber<TMessage> subscriber, params MessageHandlerFilter<TMessage>[] filters)
		{
			return new ObservableBufferedSubscriber<TMessage>(subscriber, filters);
		}

		public static IObservable<TMessage> AsObservable<TKey, TMessage>(this ISubscriber<TKey, TMessage> subscriber, TKey key, params MessageHandlerFilter<TMessage>[] filters)
		{
			return new ObservableSubscriber<TKey, TMessage>(key, subscriber, filters);
		}

		public static IDisposable Subscribe<TMessage>(this ISubscriber<TMessage> subscriber, Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return subscriber.Subscribe(new AnonymousMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TMessage>(this ISubscriber<TMessage> subscriber, Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			PredicateFilter<TMessage> predicateFilter = new PredicateFilter<TMessage>(predicate);
			MessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, predicateFilter);
			}
			else
			{
				MessageHandlerFilter<TMessage>[] array2 = new PredicateFilter<TMessage>[1] { predicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.Subscribe(new AnonymousMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TMessage>(this IBufferedSubscriber<TMessage> subscriber, Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return subscriber.Subscribe(new AnonymousMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TMessage>(this IBufferedSubscriber<TMessage> subscriber, Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			PredicateFilter<TMessage> predicateFilter = new PredicateFilter<TMessage>(predicate);
			MessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, predicateFilter);
			}
			else
			{
				MessageHandlerFilter<TMessage>[] array2 = new PredicateFilter<TMessage>[1] { predicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.Subscribe(new AnonymousMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TMessage>(this IAsyncSubscriber<TMessage> subscriber, Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return subscriber.Subscribe(new AnonymousAsyncMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TMessage>(this IAsyncSubscriber<TMessage> subscriber, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			AsyncPredicateFilter<TMessage> asyncPredicateFilter = new AsyncPredicateFilter<TMessage>(predicate);
			AsyncMessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, asyncPredicateFilter);
			}
			else
			{
				AsyncMessageHandlerFilter<TMessage>[] array2 = new AsyncPredicateFilter<TMessage>[1] { asyncPredicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.Subscribe(new AnonymousAsyncMessageHandler<TMessage>(handler), filters);
		}

		public static UniTask<IDisposable> SubscribeAsync<TMessage>(this IBufferedAsyncSubscriber<TMessage> subscriber, Func<TMessage, CancellationToken, UniTask> handler, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(handler, Array.Empty<AsyncMessageHandlerFilter<TMessage>>(), cancellationToken);
		}

		public static UniTask<IDisposable> SubscribeAsync<TMessage>(this IBufferedAsyncSubscriber<TMessage> subscriber, Func<TMessage, CancellationToken, UniTask> handler, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(new AnonymousAsyncMessageHandler<TMessage>(handler), filters, cancellationToken);
		}

		public static UniTask<IDisposable> SubscribeAsync<TMessage>(this IBufferedAsyncSubscriber<TMessage> subscriber, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			return subscriber.SubscribeAsync(handler, predicate, Array.Empty<AsyncMessageHandlerFilter<TMessage>>(), cancellationToken);
		}

		public static UniTask<IDisposable> SubscribeAsync<TMessage>(this IBufferedAsyncSubscriber<TMessage> subscriber, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, AsyncMessageHandlerFilter<TMessage>[] filters, CancellationToken cancellationToken = default(CancellationToken))
		{
			AsyncPredicateFilter<TMessage> asyncPredicateFilter = new AsyncPredicateFilter<TMessage>(predicate);
			AsyncMessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, asyncPredicateFilter);
			}
			else
			{
				AsyncMessageHandlerFilter<TMessage>[] array2 = new AsyncPredicateFilter<TMessage>[1] { asyncPredicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.SubscribeAsync(new AnonymousAsyncMessageHandler<TMessage>(handler), filters, cancellationToken);
		}

		public static IDisposable Subscribe<TKey, TMessage>(this ISubscriber<TKey, TMessage> subscriber, TKey key, Action<TMessage> handler, params MessageHandlerFilter<TMessage>[] filters)
		{
			return subscriber.Subscribe(key, new AnonymousMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TKey, TMessage>(this ISubscriber<TKey, TMessage> subscriber, TKey key, Action<TMessage> handler, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			PredicateFilter<TMessage> predicateFilter = new PredicateFilter<TMessage>(predicate);
			MessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, predicateFilter);
			}
			else
			{
				MessageHandlerFilter<TMessage>[] array2 = new PredicateFilter<TMessage>[1] { predicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.Subscribe(key, new AnonymousMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TKey, TMessage>(this IAsyncSubscriber<TKey, TMessage> subscriber, TKey key, Func<TMessage, CancellationToken, UniTask> handler, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return subscriber.Subscribe(key, new AnonymousAsyncMessageHandler<TMessage>(handler), filters);
		}

		public static IDisposable Subscribe<TKey, TMessage>(this IAsyncSubscriber<TKey, TMessage> subscriber, TKey key, Func<TMessage, CancellationToken, UniTask> handler, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			AsyncPredicateFilter<TMessage> asyncPredicateFilter = new AsyncPredicateFilter<TMessage>(predicate);
			AsyncMessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, asyncPredicateFilter);
			}
			else
			{
				AsyncMessageHandlerFilter<TMessage>[] array2 = new AsyncPredicateFilter<TMessage>[1] { asyncPredicateFilter };
				array = array2;
			}
			filters = array;
			return subscriber.Subscribe(key, new AnonymousAsyncMessageHandler<TMessage>(handler), filters);
		}

		public static UniTask<TMessage> FirstAsync<TMessage>(this ISubscriber<TMessage> subscriber, CancellationToken cancellationToken, params MessageHandlerFilter<TMessage>[] filters)
		{
			return new UniTask<TMessage>(new FirstAsyncMessageHandler<TMessage>(subscriber, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TMessage>(this ISubscriber<TMessage> subscriber, CancellationToken cancellationToken, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			PredicateFilter<TMessage> predicateFilter = new PredicateFilter<TMessage>(predicate);
			MessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, predicateFilter);
			}
			else
			{
				MessageHandlerFilter<TMessage>[] array2 = new PredicateFilter<TMessage>[1] { predicateFilter };
				array = array2;
			}
			filters = array;
			return new UniTask<TMessage>(new FirstAsyncMessageHandler<TMessage>(subscriber, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TMessage>(this IBufferedSubscriber<TMessage> subscriber, CancellationToken cancellationToken, params MessageHandlerFilter<TMessage>[] filters)
		{
			return new UniTask<TMessage>(new FirstAsyncBufferedMessageHandler<TMessage>(subscriber, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TMessage>(this IBufferedSubscriber<TMessage> subscriber, CancellationToken cancellationToken, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			PredicateFilter<TMessage> predicateFilter = new PredicateFilter<TMessage>(predicate);
			MessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, predicateFilter);
			}
			else
			{
				MessageHandlerFilter<TMessage>[] array2 = new PredicateFilter<TMessage>[1] { predicateFilter };
				array = array2;
			}
			filters = array;
			return new UniTask<TMessage>(new FirstAsyncBufferedMessageHandler<TMessage>(subscriber, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TMessage>(this IAsyncSubscriber<TMessage> subscriber, CancellationToken cancellationToken, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return new UniTask<TMessage>(new FirstAsyncAsyncMessageHandler<TMessage>(subscriber, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TMessage>(this IAsyncSubscriber<TMessage> subscriber, CancellationToken cancellationToken, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			AsyncPredicateFilter<TMessage> asyncPredicateFilter = new AsyncPredicateFilter<TMessage>(predicate);
			AsyncMessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, asyncPredicateFilter);
			}
			else
			{
				AsyncMessageHandlerFilter<TMessage>[] array2 = new AsyncPredicateFilter<TMessage>[1] { asyncPredicateFilter };
				array = array2;
			}
			filters = array;
			return new UniTask<TMessage>(new FirstAsyncAsyncMessageHandler<TMessage>(subscriber, cancellationToken, filters), 0);
		}

		public static async UniTask<TMessage> FirstAsync<TMessage>(this IBufferedAsyncSubscriber<TMessage> subscriber, CancellationToken cancellationToken, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return await new UniTask<TMessage>(await FirstAsyncAsyncBufferedMessageHandler<TMessage>.CreateAsync(subscriber, cancellationToken, filters), 0);
		}

		public static async UniTask<TMessage> FirstAsync<TMessage>(this IBufferedAsyncSubscriber<TMessage> subscriber, CancellationToken cancellationToken, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			AsyncPredicateFilter<TMessage> asyncPredicateFilter = new AsyncPredicateFilter<TMessage>(predicate);
			AsyncMessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, asyncPredicateFilter);
			}
			else
			{
				AsyncMessageHandlerFilter<TMessage>[] array2 = new AsyncPredicateFilter<TMessage>[1] { asyncPredicateFilter };
				array = array2;
			}
			filters = array;
			return await new UniTask<TMessage>(await FirstAsyncAsyncBufferedMessageHandler<TMessage>.CreateAsync(subscriber, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TKey, TMessage>(this ISubscriber<TKey, TMessage> subscriber, TKey key, CancellationToken cancellationToken, params MessageHandlerFilter<TMessage>[] filters)
		{
			return new UniTask<TMessage>(new FirstAsyncMessageHandler<TKey, TMessage>(subscriber, key, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TKey, TMessage>(this ISubscriber<TKey, TMessage> subscriber, TKey key, CancellationToken cancellationToken, Func<TMessage, bool> predicate, params MessageHandlerFilter<TMessage>[] filters)
		{
			PredicateFilter<TMessage> predicateFilter = new PredicateFilter<TMessage>(predicate);
			MessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, predicateFilter);
			}
			else
			{
				MessageHandlerFilter<TMessage>[] array2 = new PredicateFilter<TMessage>[1] { predicateFilter };
				array = array2;
			}
			filters = array;
			return new UniTask<TMessage>(new FirstAsyncMessageHandler<TKey, TMessage>(subscriber, key, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TKey, TMessage>(this IAsyncSubscriber<TKey, TMessage> subscriber, TKey key, CancellationToken cancellationToken, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			return new UniTask<TMessage>(new FirstAsyncAsyncMessageHandler<TKey, TMessage>(subscriber, key, cancellationToken, filters), 0);
		}

		public static UniTask<TMessage> FirstAsync<TKey, TMessage>(this IAsyncSubscriber<TKey, TMessage> subscriber, TKey key, CancellationToken cancellationToken, Func<TMessage, bool> predicate, params AsyncMessageHandlerFilter<TMessage>[] filters)
		{
			AsyncPredicateFilter<TMessage> asyncPredicateFilter = new AsyncPredicateFilter<TMessage>(predicate);
			AsyncMessageHandlerFilter<TMessage>[] array;
			if (filters.Length != 0)
			{
				array = ArrayUtil.ImmutableAdd(filters, asyncPredicateFilter);
			}
			else
			{
				AsyncMessageHandlerFilter<TMessage>[] array2 = new AsyncPredicateFilter<TMessage>[1] { asyncPredicateFilter };
				array = array2;
			}
			filters = array;
			return new UniTask<TMessage>(new FirstAsyncAsyncMessageHandler<TKey, TMessage>(subscriber, key, cancellationToken, filters), 0);
		}
	}
}
