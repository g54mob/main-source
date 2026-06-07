using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UniRx.InternalUtil;
using UniRx.Operators;
using UniRx.Triggers;
using UnityEngine;

namespace UniRx
{
	public static class Observable
	{
		private class ConnectableObservable<T> : IConnectableObservable<T>, IObservable<T>
		{
			private class Connection : IDisposable
			{
				private readonly ConnectableObservable<T> parent;

				private IDisposable subscription;

				public Connection(ConnectableObservable<T> parent, IDisposable subscription)
				{
					this.parent = parent;
					this.subscription = subscription;
				}

				public void Dispose()
				{
					lock (parent.gate)
					{
						if (subscription != null)
						{
							subscription.Dispose();
							subscription = null;
							parent.connection = null;
						}
					}
				}
			}

			private readonly IObservable<T> source;

			private readonly ISubject<T> subject;

			private readonly object gate = new object();

			private Connection connection;

			public ConnectableObservable(IObservable<T> source, ISubject<T> subject)
			{
				this.source = source.AsObservable();
				this.subject = subject;
			}

			public IDisposable Connect()
			{
				lock (gate)
				{
					if (connection == null)
					{
						IDisposable subscription = source.Subscribe(subject);
						connection = new Connection(this, subscription);
					}
					return connection;
				}
			}

			public IDisposable Subscribe(IObserver<T> observer)
			{
				return subject.Subscribe(observer);
			}
		}

		private class EveryAfterUpdateInvoker : IEnumerator
		{
			private long count = -1L;

			private readonly IObserver<long> observer;

			private readonly CancellationToken cancellationToken;

			public object Current => null;

			public EveryAfterUpdateInvoker(IObserver<long> observer, CancellationToken cancellationToken)
			{
				this.observer = observer;
				this.cancellationToken = cancellationToken;
			}

			public bool MoveNext()
			{
				if (!cancellationToken.IsCancellationRequested)
				{
					if (count != -1)
					{
						observer.OnNext(count++);
					}
					else
					{
						count++;
					}
					return true;
				}
				return false;
			}

			public void Reset()
			{
				throw new NotSupportedException();
			}
		}

		private static readonly TimeSpan InfiniteTimeSpan = new TimeSpan(0, 0, 0, 0, -1);

		private static readonly HashSet<Type> YieldInstructionTypes = new HashSet<Type>
		{
			typeof(WWW),
			typeof(WaitForEndOfFrame),
			typeof(WaitForFixedUpdate),
			typeof(WaitForSeconds),
			typeof(AsyncOperation),
			typeof(Coroutine)
		};

		private static IObservable<T> AddRef<T>(IObservable<T> xs, RefCountDisposable r)
		{
			return Create((IObserver<T> observer) => new CompositeDisposable(r.GetDisposable(), xs.Subscribe(observer)));
		}

		public static IObservable<TSource> Scan<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator)
		{
			return new ScanObservable<TSource>(source, accumulator);
		}

		public static IObservable<TAccumulate> Scan<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
		{
			return new ScanObservable<TSource, TAccumulate>(source, seed, accumulator);
		}

		public static IObservable<TSource> Aggregate<TSource>(this IObservable<TSource> source, Func<TSource, TSource, TSource> accumulator)
		{
			return new AggregateObservable<TSource>(source, accumulator);
		}

		public static IObservable<TAccumulate> Aggregate<TSource, TAccumulate>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
		{
			return new AggregateObservable<TSource, TAccumulate>(source, seed, accumulator);
		}

		public static IObservable<TResult> Aggregate<TSource, TAccumulate, TResult>(this IObservable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator, Func<TAccumulate, TResult> resultSelector)
		{
			return new AggregateObservable<TSource, TAccumulate, TResult>(source, seed, accumulator, resultSelector);
		}

		public static AsyncSubject<TSource> GetAwaiter<TSource>(this IObservable<TSource> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return RunAsync(source, CancellationToken.None);
		}

		public static AsyncSubject<TSource> GetAwaiter<TSource>(this IConnectableObservable<TSource> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return RunAsync(source, CancellationToken.None);
		}

		public static AsyncSubject<TSource> GetAwaiter<TSource>(this IObservable<TSource> source, CancellationToken cancellationToken)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return RunAsync(source, cancellationToken);
		}

		public static AsyncSubject<TSource> GetAwaiter<TSource>(this IConnectableObservable<TSource> source, CancellationToken cancellationToken)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return RunAsync(source, cancellationToken);
		}

		private static AsyncSubject<TSource> RunAsync<TSource>(IObservable<TSource> source, CancellationToken cancellationToken)
		{
			AsyncSubject<TSource> asyncSubject = new AsyncSubject<TSource>();
			if (cancellationToken.IsCancellationRequested)
			{
				return Cancel(asyncSubject, cancellationToken);
			}
			IDisposable subscription = source.Subscribe(asyncSubject);
			if (cancellationToken.CanBeCanceled)
			{
				RegisterCancelation(asyncSubject, subscription, cancellationToken);
			}
			return asyncSubject;
		}

		private static AsyncSubject<TSource> RunAsync<TSource>(IConnectableObservable<TSource> source, CancellationToken cancellationToken)
		{
			AsyncSubject<TSource> asyncSubject = new AsyncSubject<TSource>();
			if (cancellationToken.IsCancellationRequested)
			{
				return Cancel(asyncSubject, cancellationToken);
			}
			IDisposable disposable = source.Subscribe(asyncSubject);
			IDisposable disposable2 = source.Connect();
			if (cancellationToken.CanBeCanceled)
			{
				RegisterCancelation(asyncSubject, StableCompositeDisposable.Create(disposable, disposable2), cancellationToken);
			}
			return asyncSubject;
		}

		private static AsyncSubject<T> Cancel<T>(AsyncSubject<T> subject, CancellationToken cancellationToken)
		{
			subject.OnError(new OperationCanceledException(cancellationToken));
			return subject;
		}

		private static void RegisterCancelation<T>(AsyncSubject<T> subject, IDisposable subscription, CancellationToken token)
		{
			CancellationTokenRegistration ctr = token.Register(delegate
			{
				subscription.Dispose();
				Cancel(subject, token);
			});
			subject.Subscribe(Stubs<T>.Ignore, delegate
			{
				ctr.Dispose();
			}, ((CancellationTokenRegistration)ctr).Dispose);
		}

		public static IConnectableObservable<T> Multicast<T>(this IObservable<T> source, ISubject<T> subject)
		{
			return new ConnectableObservable<T>(source, subject);
		}

		public static IConnectableObservable<T> Publish<T>(this IObservable<T> source)
		{
			return source.Multicast(new Subject<T>());
		}

		public static IConnectableObservable<T> Publish<T>(this IObservable<T> source, T initialValue)
		{
			return source.Multicast(new BehaviorSubject<T>(initialValue));
		}

		public static IConnectableObservable<T> PublishLast<T>(this IObservable<T> source)
		{
			return source.Multicast(new AsyncSubject<T>());
		}

		public static IConnectableObservable<T> Replay<T>(this IObservable<T> source)
		{
			return source.Multicast(new ReplaySubject<T>());
		}

		public static IConnectableObservable<T> Replay<T>(this IObservable<T> source, IScheduler scheduler)
		{
			return source.Multicast(new ReplaySubject<T>(scheduler));
		}

		public static IConnectableObservable<T> Replay<T>(this IObservable<T> source, int bufferSize)
		{
			return source.Multicast(new ReplaySubject<T>(bufferSize));
		}

		public static IConnectableObservable<T> Replay<T>(this IObservable<T> source, int bufferSize, IScheduler scheduler)
		{
			return source.Multicast(new ReplaySubject<T>(bufferSize, scheduler));
		}

		public static IConnectableObservable<T> Replay<T>(this IObservable<T> source, TimeSpan window)
		{
			return source.Multicast(new ReplaySubject<T>(window));
		}

		public static IConnectableObservable<T> Replay<T>(this IObservable<T> source, TimeSpan window, IScheduler scheduler)
		{
			return source.Multicast(new ReplaySubject<T>(window, scheduler));
		}

		public static IConnectableObservable<T> Replay<T>(this IObservable<T> source, int bufferSize, TimeSpan window, IScheduler scheduler)
		{
			return source.Multicast(new ReplaySubject<T>(bufferSize, window, scheduler));
		}

		public static IObservable<T> RefCount<T>(this IConnectableObservable<T> source)
		{
			return new RefCountObservable<T>(source);
		}

		public static IObservable<T> Share<T>(this IObservable<T> source)
		{
			return source.Publish().RefCount();
		}

		public static T Wait<T>(this IObservable<T> source)
		{
			return new Wait<T>(source, InfiniteTimeSpan).Run();
		}

		public static T Wait<T>(this IObservable<T> source, TimeSpan timeout)
		{
			return new Wait<T>(source, timeout).Run();
		}

		private static IEnumerable<IObservable<T>> CombineSources<T>(IObservable<T> first, IObservable<T>[] seconds)
		{
			yield return first;
			for (int i = 0; i < seconds.Length; i++)
			{
				yield return seconds[i];
			}
		}

		public static IObservable<TSource> Concat<TSource>(params IObservable<TSource>[] sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			return new ConcatObservable<TSource>(sources);
		}

		public static IObservable<TSource> Concat<TSource>(this IEnumerable<IObservable<TSource>> sources)
		{
			if (sources == null)
			{
				throw new ArgumentNullException("sources");
			}
			return new ConcatObservable<TSource>(sources);
		}

		public static IObservable<TSource> Concat<TSource>(this IObservable<IObservable<TSource>> sources)
		{
			return sources.Merge(1);
		}

		public static IObservable<TSource> Concat<TSource>(this IObservable<TSource> first, params IObservable<TSource>[] seconds)
		{
			if (first == null)
			{
				throw new ArgumentNullException("first");
			}
			if (seconds == null)
			{
				throw new ArgumentNullException("seconds");
			}
			if (first is ConcatObservable<TSource> concatObservable)
			{
				return concatObservable.Combine(seconds);
			}
			return CombineSources(first, seconds).Concat();
		}

		public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources)
		{
			return sources.Merge(Scheduler.DefaultSchedulers.ConstantTimeOperations);
		}

		public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, IScheduler scheduler)
		{
			return new MergeObservable<TSource>(sources.ToObservable(scheduler), scheduler == Scheduler.CurrentThread);
		}

		public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, int maxConcurrent)
		{
			return sources.Merge(maxConcurrent, Scheduler.DefaultSchedulers.ConstantTimeOperations);
		}

		public static IObservable<TSource> Merge<TSource>(this IEnumerable<IObservable<TSource>> sources, int maxConcurrent, IScheduler scheduler)
		{
			return new MergeObservable<TSource>(sources.ToObservable(scheduler), maxConcurrent, scheduler == Scheduler.CurrentThread);
		}

		public static IObservable<TSource> Merge<TSource>(params IObservable<TSource>[] sources)
		{
			return Merge(Scheduler.DefaultSchedulers.ConstantTimeOperations, sources);
		}

		public static IObservable<TSource> Merge<TSource>(IScheduler scheduler, params IObservable<TSource>[] sources)
		{
			return new MergeObservable<TSource>(sources.ToObservable(scheduler), scheduler == Scheduler.CurrentThread);
		}

		public static IObservable<T> Merge<T>(this IObservable<T> first, params IObservable<T>[] seconds)
		{
			return CombineSources(first, seconds).Merge();
		}

		public static IObservable<T> Merge<T>(this IObservable<T> first, IObservable<T> second, IScheduler scheduler)
		{
			return Merge<T>(scheduler, first, second);
		}

		public static IObservable<T> Merge<T>(this IObservable<IObservable<T>> sources)
		{
			return new MergeObservable<T>(sources, isRequiredSubscribeOnCurrentThread: false);
		}

		public static IObservable<T> Merge<T>(this IObservable<IObservable<T>> sources, int maxConcurrent)
		{
			return new MergeObservable<T>(sources, maxConcurrent, isRequiredSubscribeOnCurrentThread: false);
		}

		public static IObservable<TResult> Zip<TLeft, TRight, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, TRight, TResult> selector)
		{
			return new ZipObservable<TLeft, TRight, TResult>(left, right, selector);
		}

		public static IObservable<IList<T>> Zip<T>(this IEnumerable<IObservable<T>> sources)
		{
			return Zip(sources.ToArray());
		}

		public static IObservable<IList<T>> Zip<T>(params IObservable<T>[] sources)
		{
			return new ZipObservable<T>(sources);
		}

		public static IObservable<TR> Zip<T1, T2, T3, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, ZipFunc<T1, T2, T3, TR> resultSelector)
		{
			return new ZipObservable<T1, T2, T3, TR>(source1, source2, source3, resultSelector);
		}

		public static IObservable<TR> Zip<T1, T2, T3, T4, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, ZipFunc<T1, T2, T3, T4, TR> resultSelector)
		{
			return new ZipObservable<T1, T2, T3, T4, TR>(source1, source2, source3, source4, resultSelector);
		}

		public static IObservable<TR> Zip<T1, T2, T3, T4, T5, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, ZipFunc<T1, T2, T3, T4, T5, TR> resultSelector)
		{
			return new ZipObservable<T1, T2, T3, T4, T5, TR>(source1, source2, source3, source4, source5, resultSelector);
		}

		public static IObservable<TR> Zip<T1, T2, T3, T4, T5, T6, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, ZipFunc<T1, T2, T3, T4, T5, T6, TR> resultSelector)
		{
			return new ZipObservable<T1, T2, T3, T4, T5, T6, TR>(source1, source2, source3, source4, source5, source6, resultSelector);
		}

		public static IObservable<TR> Zip<T1, T2, T3, T4, T5, T6, T7, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, IObservable<T7> source7, ZipFunc<T1, T2, T3, T4, T5, T6, T7, TR> resultSelector)
		{
			return new ZipObservable<T1, T2, T3, T4, T5, T6, T7, TR>(source1, source2, source3, source4, source5, source6, source7, resultSelector);
		}

		public static IObservable<TResult> CombineLatest<TLeft, TRight, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, TRight, TResult> selector)
		{
			return new CombineLatestObservable<TLeft, TRight, TResult>(left, right, selector);
		}

		public static IObservable<IList<T>> CombineLatest<T>(this IEnumerable<IObservable<T>> sources)
		{
			return CombineLatest(sources.ToArray());
		}

		public static IObservable<IList<TSource>> CombineLatest<TSource>(params IObservable<TSource>[] sources)
		{
			return new CombineLatestObservable<TSource>(sources);
		}

		public static IObservable<TR> CombineLatest<T1, T2, T3, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, CombineLatestFunc<T1, T2, T3, TR> resultSelector)
		{
			return new CombineLatestObservable<T1, T2, T3, TR>(source1, source2, source3, resultSelector);
		}

		public static IObservable<TR> CombineLatest<T1, T2, T3, T4, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, CombineLatestFunc<T1, T2, T3, T4, TR> resultSelector)
		{
			return new CombineLatestObservable<T1, T2, T3, T4, TR>(source1, source2, source3, source4, resultSelector);
		}

		public static IObservable<TR> CombineLatest<T1, T2, T3, T4, T5, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, CombineLatestFunc<T1, T2, T3, T4, T5, TR> resultSelector)
		{
			return new CombineLatestObservable<T1, T2, T3, T4, T5, TR>(source1, source2, source3, source4, source5, resultSelector);
		}

		public static IObservable<TR> CombineLatest<T1, T2, T3, T4, T5, T6, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, CombineLatestFunc<T1, T2, T3, T4, T5, T6, TR> resultSelector)
		{
			return new CombineLatestObservable<T1, T2, T3, T4, T5, T6, TR>(source1, source2, source3, source4, source5, source6, resultSelector);
		}

		public static IObservable<TR> CombineLatest<T1, T2, T3, T4, T5, T6, T7, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, IObservable<T7> source7, CombineLatestFunc<T1, T2, T3, T4, T5, T6, T7, TR> resultSelector)
		{
			return new CombineLatestObservable<T1, T2, T3, T4, T5, T6, T7, TR>(source1, source2, source3, source4, source5, source6, source7, resultSelector);
		}

		public static IObservable<TResult> ZipLatest<TLeft, TRight, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, TRight, TResult> selector)
		{
			return new ZipLatestObservable<TLeft, TRight, TResult>(left, right, selector);
		}

		public static IObservable<IList<T>> ZipLatest<T>(this IEnumerable<IObservable<T>> sources)
		{
			return ZipLatest(sources.ToArray());
		}

		public static IObservable<IList<TSource>> ZipLatest<TSource>(params IObservable<TSource>[] sources)
		{
			return new ZipLatestObservable<TSource>(sources);
		}

		public static IObservable<TR> ZipLatest<T1, T2, T3, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, ZipLatestFunc<T1, T2, T3, TR> resultSelector)
		{
			return new ZipLatestObservable<T1, T2, T3, TR>(source1, source2, source3, resultSelector);
		}

		public static IObservable<TR> ZipLatest<T1, T2, T3, T4, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, ZipLatestFunc<T1, T2, T3, T4, TR> resultSelector)
		{
			return new ZipLatestObservable<T1, T2, T3, T4, TR>(source1, source2, source3, source4, resultSelector);
		}

		public static IObservable<TR> ZipLatest<T1, T2, T3, T4, T5, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, ZipLatestFunc<T1, T2, T3, T4, T5, TR> resultSelector)
		{
			return new ZipLatestObservable<T1, T2, T3, T4, T5, TR>(source1, source2, source3, source4, source5, resultSelector);
		}

		public static IObservable<TR> ZipLatest<T1, T2, T3, T4, T5, T6, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, ZipLatestFunc<T1, T2, T3, T4, T5, T6, TR> resultSelector)
		{
			return new ZipLatestObservable<T1, T2, T3, T4, T5, T6, TR>(source1, source2, source3, source4, source5, source6, resultSelector);
		}

		public static IObservable<TR> ZipLatest<T1, T2, T3, T4, T5, T6, T7, TR>(this IObservable<T1> source1, IObservable<T2> source2, IObservable<T3> source3, IObservable<T4> source4, IObservable<T5> source5, IObservable<T6> source6, IObservable<T7> source7, ZipLatestFunc<T1, T2, T3, T4, T5, T6, T7, TR> resultSelector)
		{
			return new ZipLatestObservable<T1, T2, T3, T4, T5, T6, T7, TR>(source1, source2, source3, source4, source5, source6, source7, resultSelector);
		}

		public static IObservable<T> Switch<T>(this IObservable<IObservable<T>> sources)
		{
			return new SwitchObservable<T>(sources);
		}

		public static IObservable<TResult> WithLatestFrom<TLeft, TRight, TResult>(this IObservable<TLeft> left, IObservable<TRight> right, Func<TLeft, TRight, TResult> selector)
		{
			return new WithLatestFromObservable<TLeft, TRight, TResult>(left, right, selector);
		}

		public static IObservable<T[]> WhenAll<T>(params IObservable<T>[] sources)
		{
			if (sources.Length == 0)
			{
				return Return(new T[0]);
			}
			return new WhenAllObservable<T>(sources);
		}

		public static IObservable<Unit> WhenAll(params IObservable<Unit>[] sources)
		{
			if (sources.Length == 0)
			{
				return ReturnUnit();
			}
			return new WhenAllObservable(sources);
		}

		public static IObservable<T[]> WhenAll<T>(this IEnumerable<IObservable<T>> sources)
		{
			if (sources is IObservable<T>[] sources2)
			{
				return WhenAll(sources2);
			}
			return new WhenAllObservable<T>(sources);
		}

		public static IObservable<Unit> WhenAll(this IEnumerable<IObservable<Unit>> sources)
		{
			if (sources is IObservable<Unit>[] sources2)
			{
				return WhenAll(sources2);
			}
			return new WhenAllObservable(sources);
		}

		public static IObservable<T> StartWith<T>(this IObservable<T> source, T value)
		{
			return new StartWithObservable<T>(source, value);
		}

		public static IObservable<T> StartWith<T>(this IObservable<T> source, Func<T> valueFactory)
		{
			return new StartWithObservable<T>(source, valueFactory);
		}

		public static IObservable<T> StartWith<T>(this IObservable<T> source, params T[] values)
		{
			return source.StartWith(Scheduler.DefaultSchedulers.ConstantTimeOperations, values);
		}

		public static IObservable<T> StartWith<T>(this IObservable<T> source, IEnumerable<T> values)
		{
			return source.StartWith(Scheduler.DefaultSchedulers.ConstantTimeOperations, values);
		}

		public static IObservable<T> StartWith<T>(this IObservable<T> source, IScheduler scheduler, T value)
		{
			return Return(value, scheduler).Concat(source);
		}

		public static IObservable<T> StartWith<T>(this IObservable<T> source, IScheduler scheduler, IEnumerable<T> values)
		{
			T[] array = values as T[];
			if (array == null)
			{
				array = values.ToArray();
			}
			return source.StartWith(scheduler, array);
		}

		public static IObservable<T> StartWith<T>(this IObservable<T> source, IScheduler scheduler, params T[] values)
		{
			return values.ToObservable(scheduler).Concat(source);
		}

		public static IObservable<T> Synchronize<T>(this IObservable<T> source)
		{
			return new SynchronizeObservable<T>(source, new object());
		}

		public static IObservable<T> Synchronize<T>(this IObservable<T> source, object gate)
		{
			return new SynchronizeObservable<T>(source, gate);
		}

		public static IObservable<T> ObserveOn<T>(this IObservable<T> source, IScheduler scheduler)
		{
			return new ObserveOnObservable<T>(source, scheduler);
		}

		public static IObservable<T> SubscribeOn<T>(this IObservable<T> source, IScheduler scheduler)
		{
			return new SubscribeOnObservable<T>(source, scheduler);
		}

		public static IObservable<T> DelaySubscription<T>(this IObservable<T> source, TimeSpan dueTime)
		{
			return new DelaySubscriptionObservable<T>(source, dueTime, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> DelaySubscription<T>(this IObservable<T> source, TimeSpan dueTime, IScheduler scheduler)
		{
			return new DelaySubscriptionObservable<T>(source, dueTime, scheduler);
		}

		public static IObservable<T> DelaySubscription<T>(this IObservable<T> source, DateTimeOffset dueTime)
		{
			return new DelaySubscriptionObservable<T>(source, dueTime, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> DelaySubscription<T>(this IObservable<T> source, DateTimeOffset dueTime, IScheduler scheduler)
		{
			return new DelaySubscriptionObservable<T>(source, dueTime, scheduler);
		}

		public static IObservable<T> Amb<T>(params IObservable<T>[] sources)
		{
			return Amb((IEnumerable<IObservable<T>>)sources);
		}

		public static IObservable<T> Amb<T>(IEnumerable<IObservable<T>> sources)
		{
			IObservable<T> observable = Never<T>();
			foreach (IObservable<T> source in sources)
			{
				observable = observable.Amb(source);
			}
			return observable;
		}

		public static IObservable<T> Amb<T>(this IObservable<T> source, IObservable<T> second)
		{
			return new AmbObservable<T>(source, second);
		}

		public static IObservable<T> AsObservable<T>(this IObservable<T> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source is AsObservableObservable<T>)
			{
				return source;
			}
			return new AsObservableObservable<T>(source);
		}

		public static IObservable<T> ToObservable<T>(this IEnumerable<T> source)
		{
			return source.ToObservable(Scheduler.DefaultSchedulers.Iteration);
		}

		public static IObservable<T> ToObservable<T>(this IEnumerable<T> source, IScheduler scheduler)
		{
			return new ToObservableObservable<T>(source, scheduler);
		}

		public static IObservable<TResult> Cast<TSource, TResult>(this IObservable<TSource> source)
		{
			return new CastObservable<TSource, TResult>(source);
		}

		public static IObservable<TResult> Cast<TSource, TResult>(this IObservable<TSource> source, TResult witness)
		{
			return new CastObservable<TSource, TResult>(source);
		}

		public static IObservable<TResult> OfType<TSource, TResult>(this IObservable<TSource> source)
		{
			return new OfTypeObservable<TSource, TResult>(source);
		}

		public static IObservable<TResult> OfType<TSource, TResult>(this IObservable<TSource> source, TResult witness)
		{
			return new OfTypeObservable<TSource, TResult>(source);
		}

		public static IObservable<Unit> AsUnitObservable<T>(this IObservable<T> source)
		{
			return new AsUnitObservableObservable<T>(source);
		}

		public static IObservable<Unit> AsSingleUnitObservable<T>(this IObservable<T> source)
		{
			return new AsSingleUnitObservableObservable<T>(source);
		}

		public static IObservable<T> Create<T>(Func<IObserver<T>, IDisposable> subscribe)
		{
			if (subscribe == null)
			{
				throw new ArgumentNullException("subscribe");
			}
			return new CreateObservable<T>(subscribe);
		}

		public static IObservable<T> Create<T>(Func<IObserver<T>, IDisposable> subscribe, bool isRequiredSubscribeOnCurrentThread)
		{
			if (subscribe == null)
			{
				throw new ArgumentNullException("subscribe");
			}
			return new CreateObservable<T>(subscribe, isRequiredSubscribeOnCurrentThread);
		}

		public static IObservable<T> CreateWithState<T, TState>(TState state, Func<TState, IObserver<T>, IDisposable> subscribe)
		{
			if (subscribe == null)
			{
				throw new ArgumentNullException("subscribe");
			}
			return new CreateObservable<T, TState>(state, subscribe);
		}

		public static IObservable<T> CreateWithState<T, TState>(TState state, Func<TState, IObserver<T>, IDisposable> subscribe, bool isRequiredSubscribeOnCurrentThread)
		{
			if (subscribe == null)
			{
				throw new ArgumentNullException("subscribe");
			}
			return new CreateObservable<T, TState>(state, subscribe, isRequiredSubscribeOnCurrentThread);
		}

		public static IObservable<T> CreateSafe<T>(Func<IObserver<T>, IDisposable> subscribe)
		{
			if (subscribe == null)
			{
				throw new ArgumentNullException("subscribe");
			}
			return new CreateSafeObservable<T>(subscribe);
		}

		public static IObservable<T> CreateSafe<T>(Func<IObserver<T>, IDisposable> subscribe, bool isRequiredSubscribeOnCurrentThread)
		{
			if (subscribe == null)
			{
				throw new ArgumentNullException("subscribe");
			}
			return new CreateSafeObservable<T>(subscribe, isRequiredSubscribeOnCurrentThread);
		}

		public static IObservable<T> Empty<T>()
		{
			return Empty<T>(Scheduler.DefaultSchedulers.ConstantTimeOperations);
		}

		public static IObservable<T> Empty<T>(IScheduler scheduler)
		{
			if (scheduler == Scheduler.Immediate)
			{
				return ImmutableEmptyObservable<T>.Instance;
			}
			return new EmptyObservable<T>(scheduler);
		}

		public static IObservable<T> Empty<T>(T witness)
		{
			return Empty<T>(Scheduler.DefaultSchedulers.ConstantTimeOperations);
		}

		public static IObservable<T> Empty<T>(IScheduler scheduler, T witness)
		{
			return Empty<T>(scheduler);
		}

		public static IObservable<T> Never<T>()
		{
			return ImmutableNeverObservable<T>.Instance;
		}

		public static IObservable<T> Never<T>(T witness)
		{
			return ImmutableNeverObservable<T>.Instance;
		}

		public static IObservable<T> Return<T>(T value)
		{
			return Return(value, Scheduler.DefaultSchedulers.ConstantTimeOperations);
		}

		public static IObservable<T> Return<T>(T value, IScheduler scheduler)
		{
			if (scheduler == Scheduler.Immediate)
			{
				return new ImmediateReturnObservable<T>(value);
			}
			return new ReturnObservable<T>(value, scheduler);
		}

		public static IObservable<Unit> Return(Unit value)
		{
			return ImmutableReturnUnitObservable.Instance;
		}

		public static IObservable<bool> Return(bool value)
		{
			if (!value)
			{
				return ImmutableReturnFalseObservable.Instance;
			}
			return ImmutableReturnTrueObservable.Instance;
		}

		public static IObservable<int> Return(int value)
		{
			return ImmutableReturnInt32Observable.GetInt32Observable(value);
		}

		public static IObservable<Unit> ReturnUnit()
		{
			return ImmutableReturnUnitObservable.Instance;
		}

		public static IObservable<T> Throw<T>(Exception error)
		{
			return Throw<T>(error, Scheduler.DefaultSchedulers.ConstantTimeOperations);
		}

		public static IObservable<T> Throw<T>(Exception error, T witness)
		{
			return Throw<T>(error, Scheduler.DefaultSchedulers.ConstantTimeOperations);
		}

		public static IObservable<T> Throw<T>(Exception error, IScheduler scheduler)
		{
			return new ThrowObservable<T>(error, scheduler);
		}

		public static IObservable<T> Throw<T>(Exception error, IScheduler scheduler, T witness)
		{
			return Throw<T>(error, scheduler);
		}

		public static IObservable<int> Range(int start, int count)
		{
			return Range(start, count, Scheduler.DefaultSchedulers.Iteration);
		}

		public static IObservable<int> Range(int start, int count, IScheduler scheduler)
		{
			return new RangeObservable(start, count, scheduler);
		}

		public static IObservable<T> Repeat<T>(T value)
		{
			return Repeat(value, Scheduler.DefaultSchedulers.Iteration);
		}

		public static IObservable<T> Repeat<T>(T value, IScheduler scheduler)
		{
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			return new RepeatObservable<T>(value, null, scheduler);
		}

		public static IObservable<T> Repeat<T>(T value, int repeatCount)
		{
			return Repeat(value, repeatCount, Scheduler.DefaultSchedulers.Iteration);
		}

		public static IObservable<T> Repeat<T>(T value, int repeatCount, IScheduler scheduler)
		{
			if (repeatCount < 0)
			{
				throw new ArgumentOutOfRangeException("repeatCount");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			return new RepeatObservable<T>(value, repeatCount, scheduler);
		}

		public static IObservable<T> Repeat<T>(this IObservable<T> source)
		{
			return RepeatInfinite(source).Concat();
		}

		private static IEnumerable<IObservable<T>> RepeatInfinite<T>(IObservable<T> source)
		{
			while (true)
			{
				yield return source;
			}
		}

		public static IObservable<T> RepeatSafe<T>(this IObservable<T> source)
		{
			return new RepeatSafeObservable<T>(RepeatInfinite(source), source.IsRequiredSubscribeOnCurrentThread());
		}

		public static IObservable<T> Defer<T>(Func<IObservable<T>> observableFactory)
		{
			return new DeferObservable<T>(observableFactory);
		}

		public static IObservable<T> Start<T>(Func<T> function)
		{
			return new StartObservable<T>(function, null, Scheduler.DefaultSchedulers.AsyncConversions);
		}

		public static IObservable<T> Start<T>(Func<T> function, TimeSpan timeSpan)
		{
			return new StartObservable<T>(function, timeSpan, Scheduler.DefaultSchedulers.AsyncConversions);
		}

		public static IObservable<T> Start<T>(Func<T> function, IScheduler scheduler)
		{
			return new StartObservable<T>(function, null, scheduler);
		}

		public static IObservable<T> Start<T>(Func<T> function, TimeSpan timeSpan, IScheduler scheduler)
		{
			return new StartObservable<T>(function, timeSpan, scheduler);
		}

		public static IObservable<Unit> Start(Action action)
		{
			return new StartObservable<Unit>(action, null, Scheduler.DefaultSchedulers.AsyncConversions);
		}

		public static IObservable<Unit> Start(Action action, TimeSpan timeSpan)
		{
			return new StartObservable<Unit>(action, timeSpan, Scheduler.DefaultSchedulers.AsyncConversions);
		}

		public static IObservable<Unit> Start(Action action, IScheduler scheduler)
		{
			return new StartObservable<Unit>(action, null, scheduler);
		}

		public static IObservable<Unit> Start(Action action, TimeSpan timeSpan, IScheduler scheduler)
		{
			return new StartObservable<Unit>(action, timeSpan, scheduler);
		}

		public static Func<IObservable<T>> ToAsync<T>(Func<T> function)
		{
			return ToAsync(function, Scheduler.DefaultSchedulers.AsyncConversions);
		}

		public static Func<IObservable<T>> ToAsync<T>(Func<T> function, IScheduler scheduler)
		{
			return delegate
			{
				AsyncSubject<T> subject = new AsyncSubject<T>();
				scheduler.Schedule(delegate
				{
					T val = default(T);
					try
					{
						val = function();
					}
					catch (Exception error)
					{
						subject.OnError(error);
						return;
					}
					subject.OnNext(val);
					subject.OnCompleted();
				});
				return subject.AsObservable();
			};
		}

		public static Func<IObservable<Unit>> ToAsync(Action action)
		{
			return ToAsync(action, Scheduler.DefaultSchedulers.AsyncConversions);
		}

		public static Func<IObservable<Unit>> ToAsync(Action action, IScheduler scheduler)
		{
			return delegate
			{
				AsyncSubject<Unit> subject = new AsyncSubject<Unit>();
				scheduler.Schedule(delegate
				{
					try
					{
						action();
					}
					catch (Exception error)
					{
						subject.OnError(error);
						return;
					}
					subject.OnNext(Unit.Default);
					subject.OnCompleted();
				});
				return subject.AsObservable();
			};
		}

		public static IObservable<T> Finally<T>(this IObservable<T> source, Action finallyAction)
		{
			return new FinallyObservable<T>(source, finallyAction);
		}

		public static IObservable<T> Catch<T, TException>(this IObservable<T> source, Func<TException, IObservable<T>> errorHandler) where TException : Exception
		{
			return new CatchObservable<T, TException>(source, errorHandler);
		}

		public static IObservable<TSource> Catch<TSource>(this IEnumerable<IObservable<TSource>> sources)
		{
			return new CatchObservable<TSource>(sources);
		}

		public static IObservable<TSource> CatchIgnore<TSource>(this IObservable<TSource> source)
		{
			return source.Catch<TSource, Exception>(Stubs.CatchIgnore<TSource>);
		}

		public static IObservable<TSource> CatchIgnore<TSource, TException>(this IObservable<TSource> source, Action<TException> errorAction) where TException : Exception
		{
			return source.Catch(delegate(TException ex)
			{
				errorAction(ex);
				return Empty<TSource>();
			});
		}

		public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source)
		{
			return RepeatInfinite(source).Catch();
		}

		public static IObservable<TSource> Retry<TSource>(this IObservable<TSource> source, int retryCount)
		{
			return Enumerable.Repeat(source, retryCount).Catch();
		}

		public static IObservable<TSource> OnErrorRetry<TSource>(this IObservable<TSource> source)
		{
			return source.Retry();
		}

		public static IObservable<TSource> OnErrorRetry<TSource, TException>(this IObservable<TSource> source, Action<TException> onError) where TException : Exception
		{
			return source.OnErrorRetry(onError, TimeSpan.Zero);
		}

		public static IObservable<TSource> OnErrorRetry<TSource, TException>(this IObservable<TSource> source, Action<TException> onError, TimeSpan delay) where TException : Exception
		{
			return source.OnErrorRetry(onError, int.MaxValue, delay);
		}

		public static IObservable<TSource> OnErrorRetry<TSource, TException>(this IObservable<TSource> source, Action<TException> onError, int retryCount) where TException : Exception
		{
			return source.OnErrorRetry(onError, retryCount, TimeSpan.Zero);
		}

		public static IObservable<TSource> OnErrorRetry<TSource, TException>(this IObservable<TSource> source, Action<TException> onError, int retryCount, TimeSpan delay) where TException : Exception
		{
			return source.OnErrorRetry(onError, retryCount, delay, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<TSource> OnErrorRetry<TSource, TException>(this IObservable<TSource> source, Action<TException> onError, int retryCount, TimeSpan delay, IScheduler delayScheduler) where TException : Exception
		{
			return Defer(delegate
			{
				TimeSpan dueTime = ((delay.Ticks < 0) ? TimeSpan.Zero : delay);
				int count = 0;
				IObservable<TSource> self = null;
				self = source.Catch(delegate(TException ex)
				{
					onError(ex);
					if (++count >= retryCount)
					{
						return Throw<TSource>(ex);
					}
					return (!(dueTime == TimeSpan.Zero)) ? self.DelaySubscription(dueTime, delayScheduler).SubscribeOn(Scheduler.CurrentThread) : self.SubscribeOn(Scheduler.CurrentThread);
				});
				return self;
			});
		}

		public static IObservable<EventPattern<TEventArgs>> FromEventPattern<TDelegate, TEventArgs>(Func<EventHandler<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler) where TEventArgs : EventArgs
		{
			return new FromEventPatternObservable<TDelegate, TEventArgs>(conversion, addHandler, removeHandler);
		}

		public static IObservable<Unit> FromEvent<TDelegate>(Func<Action, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
		{
			return new FromEventObservable<TDelegate>(conversion, addHandler, removeHandler);
		}

		public static IObservable<TEventArgs> FromEvent<TDelegate, TEventArgs>(Func<Action<TEventArgs>, TDelegate> conversion, Action<TDelegate> addHandler, Action<TDelegate> removeHandler)
		{
			return new FromEventObservable<TDelegate, TEventArgs>(conversion, addHandler, removeHandler);
		}

		public static IObservable<Unit> FromEvent(Action<Action> addHandler, Action<Action> removeHandler)
		{
			return new FromEventObservable(addHandler, removeHandler);
		}

		public static IObservable<T> FromEvent<T>(Action<Action<T>> addHandler, Action<Action<T>> removeHandler)
		{
			return new FromEventObservable_<T>(addHandler, removeHandler);
		}

		public static Func<IObservable<TResult>> FromAsyncPattern<TResult>(Func<AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
		{
			return delegate
			{
				AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
				try
				{
					begin(delegate(IAsyncResult iar)
					{
						TResult value;
						try
						{
							value = end(iar);
						}
						catch (Exception error2)
						{
							subject.OnError(error2);
							return;
						}
						subject.OnNext(value);
						subject.OnCompleted();
					}, null);
				}
				catch (Exception error)
				{
					return Throw<TResult>(error, Scheduler.DefaultSchedulers.AsyncConversions);
				}
				return subject.AsObservable();
			};
		}

		public static Func<T1, IObservable<TResult>> FromAsyncPattern<T1, TResult>(Func<T1, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
		{
			return delegate(T1 x)
			{
				AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
				try
				{
					begin(x, delegate(IAsyncResult iar)
					{
						TResult value;
						try
						{
							value = end(iar);
						}
						catch (Exception error2)
						{
							subject.OnError(error2);
							return;
						}
						subject.OnNext(value);
						subject.OnCompleted();
					}, null);
				}
				catch (Exception error)
				{
					return Throw<TResult>(error, Scheduler.DefaultSchedulers.AsyncConversions);
				}
				return subject.AsObservable();
			};
		}

		public static Func<T1, T2, IObservable<TResult>> FromAsyncPattern<T1, T2, TResult>(Func<T1, T2, AsyncCallback, object, IAsyncResult> begin, Func<IAsyncResult, TResult> end)
		{
			return delegate(T1 x, T2 y)
			{
				AsyncSubject<TResult> subject = new AsyncSubject<TResult>();
				try
				{
					begin(x, y, delegate(IAsyncResult iar)
					{
						TResult value;
						try
						{
							value = end(iar);
						}
						catch (Exception error2)
						{
							subject.OnError(error2);
							return;
						}
						subject.OnNext(value);
						subject.OnCompleted();
					}, null);
				}
				catch (Exception error)
				{
					return Throw<TResult>(error, Scheduler.DefaultSchedulers.AsyncConversions);
				}
				return subject.AsObservable();
			};
		}

		public static Func<IObservable<Unit>> FromAsyncPattern(Func<AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
		{
			return FromAsyncPattern(begin, delegate(IAsyncResult iar)
			{
				end(iar);
				return Unit.Default;
			});
		}

		public static Func<T1, IObservable<Unit>> FromAsyncPattern<T1>(Func<T1, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
		{
			return FromAsyncPattern(begin, delegate(IAsyncResult iar)
			{
				end(iar);
				return Unit.Default;
			});
		}

		public static Func<T1, T2, IObservable<Unit>> FromAsyncPattern<T1, T2>(Func<T1, T2, AsyncCallback, object, IAsyncResult> begin, Action<IAsyncResult> end)
		{
			return FromAsyncPattern(begin, delegate(IAsyncResult iar)
			{
				end(iar);
				return Unit.Default;
			});
		}

		public static IObservable<T> Take<T>(this IObservable<T> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count == 0)
			{
				return Empty<T>();
			}
			if (source is TakeObservable<T> takeObservable && takeObservable.scheduler == null)
			{
				return takeObservable.Combine(count);
			}
			return new TakeObservable<T>(source, count);
		}

		public static IObservable<T> Take<T>(this IObservable<T> source, TimeSpan duration)
		{
			return source.Take(duration, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> Take<T>(this IObservable<T> source, TimeSpan duration, IScheduler scheduler)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			if (source is TakeObservable<T> takeObservable && takeObservable.scheduler == scheduler)
			{
				return takeObservable.Combine(duration);
			}
			return new TakeObservable<T>(source, duration, scheduler);
		}

		public static IObservable<T> TakeWhile<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new TakeWhileObservable<T>(source, predicate);
		}

		public static IObservable<T> TakeWhile<T>(this IObservable<T> source, Func<T, int, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return new TakeWhileObservable<T>(source, predicate);
		}

		public static IObservable<T> TakeUntil<T, TOther>(this IObservable<T> source, IObservable<TOther> other)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			return new TakeUntilObservable<T, TOther>(source, other);
		}

		public static IObservable<T> TakeLast<T>(this IObservable<T> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return new TakeLastObservable<T>(source, count);
		}

		public static IObservable<T> TakeLast<T>(this IObservable<T> source, TimeSpan duration)
		{
			return source.TakeLast(duration, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> TakeLast<T>(this IObservable<T> source, TimeSpan duration, IScheduler scheduler)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new TakeLastObservable<T>(source, duration, scheduler);
		}

		public static IObservable<T> Skip<T>(this IObservable<T> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (source is SkipObservable<T> skipObservable && skipObservable.scheduler == null)
			{
				return skipObservable.Combine(count);
			}
			return new SkipObservable<T>(source, count);
		}

		public static IObservable<T> Skip<T>(this IObservable<T> source, TimeSpan duration)
		{
			return source.Skip(duration, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> Skip<T>(this IObservable<T> source, TimeSpan duration, IScheduler scheduler)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (scheduler == null)
			{
				throw new ArgumentNullException("scheduler");
			}
			if (source is SkipObservable<T> skipObservable && skipObservable.scheduler == scheduler)
			{
				return skipObservable.Combine(duration);
			}
			return new SkipObservable<T>(source, duration, scheduler);
		}

		public static IObservable<T> SkipWhile<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new SkipWhileObservable<T>(source, predicate);
		}

		public static IObservable<T> SkipWhile<T>(this IObservable<T> source, Func<T, int, bool> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			return new SkipWhileObservable<T>(source, predicate);
		}

		public static IObservable<T> SkipUntil<T, TOther>(this IObservable<T> source, IObservable<TOther> other)
		{
			return new SkipUntilObservable<T, TOther>(source, other);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, int count)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count <= 0");
			}
			return new BufferObservable<T>(source, count, 0);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, int count, int skip)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count <= 0");
			}
			if (skip <= 0)
			{
				throw new ArgumentOutOfRangeException("skip <= 0");
			}
			return new BufferObservable<T>(source, count, skip);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, TimeSpan timeSpan)
		{
			return source.Buffer(timeSpan, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, TimeSpan timeSpan, IScheduler scheduler)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new BufferObservable<T>(source, timeSpan, timeSpan, scheduler);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, TimeSpan timeSpan, int count)
		{
			return source.Buffer(timeSpan, count, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, TimeSpan timeSpan, int count, IScheduler scheduler)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count <= 0");
			}
			return new BufferObservable<T>(source, timeSpan, count, scheduler);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, TimeSpan timeSpan, TimeSpan timeShift)
		{
			return new BufferObservable<T>(source, timeSpan, timeShift, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<IList<T>> Buffer<T>(this IObservable<T> source, TimeSpan timeSpan, TimeSpan timeShift, IScheduler scheduler)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new BufferObservable<T>(source, timeSpan, timeShift, scheduler);
		}

		public static IObservable<IList<TSource>> Buffer<TSource, TWindowBoundary>(this IObservable<TSource> source, IObservable<TWindowBoundary> windowBoundaries)
		{
			return new BufferObservable<TSource, TWindowBoundary>(source, windowBoundaries);
		}

		public static IObservable<Pair<T>> Pairwise<T>(this IObservable<T> source)
		{
			return new PairwiseObservable<T>(source);
		}

		public static IObservable<TR> Pairwise<T, TR>(this IObservable<T> source, Func<T, T, TR> selector)
		{
			return new PairwiseObservable<T, TR>(source, selector);
		}

		public static IObservable<T> Last<T>(this IObservable<T> source)
		{
			return new LastObservable<T>(source, useDefault: false);
		}

		public static IObservable<T> Last<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new LastObservable<T>(source, predicate, useDefault: false);
		}

		public static IObservable<T> LastOrDefault<T>(this IObservable<T> source)
		{
			return new LastObservable<T>(source, useDefault: true);
		}

		public static IObservable<T> LastOrDefault<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new LastObservable<T>(source, predicate, useDefault: true);
		}

		public static IObservable<T> First<T>(this IObservable<T> source)
		{
			return new FirstObservable<T>(source, useDefault: false);
		}

		public static IObservable<T> First<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new FirstObservable<T>(source, predicate, useDefault: false);
		}

		public static IObservable<T> FirstOrDefault<T>(this IObservable<T> source)
		{
			return new FirstObservable<T>(source, useDefault: true);
		}

		public static IObservable<T> FirstOrDefault<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new FirstObservable<T>(source, predicate, useDefault: true);
		}

		public static IObservable<T> Single<T>(this IObservable<T> source)
		{
			return new SingleObservable<T>(source, useDefault: false);
		}

		public static IObservable<T> Single<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new SingleObservable<T>(source, predicate, useDefault: false);
		}

		public static IObservable<T> SingleOrDefault<T>(this IObservable<T> source)
		{
			return new SingleObservable<T>(source, useDefault: true);
		}

		public static IObservable<T> SingleOrDefault<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			return new SingleObservable<T>(source, predicate, useDefault: true);
		}

		public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.GroupBy(keySelector, Stubs<TSource>.Identity);
		}

		public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return source.GroupBy(keySelector, Stubs<TSource>.Identity, comparer);
		}

		public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)
		{
			IEqualityComparer<TKey> comparer = UnityEqualityComparer.GetDefault<TKey>();
			return source.GroupBy(keySelector, elementSelector, comparer);
		}

		public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			return new GroupByObservable<TSource, TKey, TElement>(source, keySelector, elementSelector, null, comparer);
		}

		public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, int capacity)
		{
			return source.GroupBy(keySelector, Stubs<TSource>.Identity, capacity);
		}

		public static IObservable<IGroupedObservable<TKey, TSource>> GroupBy<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, int capacity, IEqualityComparer<TKey> comparer)
		{
			return source.GroupBy(keySelector, Stubs<TSource>.Identity, capacity, comparer);
		}

		public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, int capacity)
		{
			IEqualityComparer<TKey> comparer = UnityEqualityComparer.GetDefault<TKey>();
			return source.GroupBy(keySelector, elementSelector, capacity, comparer);
		}

		public static IObservable<IGroupedObservable<TKey, TElement>> GroupBy<TSource, TKey, TElement>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, int capacity, IEqualityComparer<TKey> comparer)
		{
			return new GroupByObservable<TSource, TKey, TElement>(source, keySelector, elementSelector, capacity, comparer);
		}

		public static IObservable<long> Interval(TimeSpan period)
		{
			return new TimerObservable(period, period, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<long> Interval(TimeSpan period, IScheduler scheduler)
		{
			return new TimerObservable(period, period, scheduler);
		}

		public static IObservable<long> Timer(TimeSpan dueTime)
		{
			return new TimerObservable(dueTime, null, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<long> Timer(DateTimeOffset dueTime)
		{
			return new TimerObservable(dueTime, null, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period)
		{
			return new TimerObservable(dueTime, period, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<long> Timer(DateTimeOffset dueTime, TimeSpan period)
		{
			return new TimerObservable(dueTime, period, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<long> Timer(TimeSpan dueTime, IScheduler scheduler)
		{
			return new TimerObservable(dueTime, null, scheduler);
		}

		public static IObservable<long> Timer(DateTimeOffset dueTime, IScheduler scheduler)
		{
			return new TimerObservable(dueTime, null, scheduler);
		}

		public static IObservable<long> Timer(TimeSpan dueTime, TimeSpan period, IScheduler scheduler)
		{
			return new TimerObservable(dueTime, period, scheduler);
		}

		public static IObservable<long> Timer(DateTimeOffset dueTime, TimeSpan period, IScheduler scheduler)
		{
			return new TimerObservable(dueTime, period, scheduler);
		}

		public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source)
		{
			return source.Timestamp(Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<Timestamped<TSource>> Timestamp<TSource>(this IObservable<TSource> source, IScheduler scheduler)
		{
			return new TimestampObservable<TSource>(source, scheduler);
		}

		public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source)
		{
			return source.TimeInterval(Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<TimeInterval<TSource>> TimeInterval<TSource>(this IObservable<TSource> source, IScheduler scheduler)
		{
			return new TimeIntervalObservable<TSource>(source, scheduler);
		}

		public static IObservable<T> Delay<T>(this IObservable<T> source, TimeSpan dueTime)
		{
			return source.Delay(dueTime, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<TSource> Delay<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
		{
			return new DelayObservable<TSource>(source, dueTime, scheduler);
		}

		public static IObservable<T> Sample<T>(this IObservable<T> source, TimeSpan interval)
		{
			return source.Sample(interval, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> Sample<T>(this IObservable<T> source, TimeSpan interval, IScheduler scheduler)
		{
			return new SampleObservable<T>(source, interval, scheduler);
		}

		public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
		{
			return source.Throttle(dueTime, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<TSource> Throttle<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
		{
			return new ThrottleObservable<TSource>(source, dueTime, scheduler);
		}

		public static IObservable<TSource> ThrottleFirst<TSource>(this IObservable<TSource> source, TimeSpan dueTime)
		{
			return source.ThrottleFirst(dueTime, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<TSource> ThrottleFirst<TSource>(this IObservable<TSource> source, TimeSpan dueTime, IScheduler scheduler)
		{
			return new ThrottleFirstObservable<TSource>(source, dueTime, scheduler);
		}

		public static IObservable<T> Timeout<T>(this IObservable<T> source, TimeSpan dueTime)
		{
			return source.Timeout(dueTime, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> Timeout<T>(this IObservable<T> source, TimeSpan dueTime, IScheduler scheduler)
		{
			return new TimeoutObservable<T>(source, dueTime, scheduler);
		}

		public static IObservable<T> Timeout<T>(this IObservable<T> source, DateTimeOffset dueTime)
		{
			return source.Timeout(dueTime, Scheduler.DefaultSchedulers.TimeBasedOperations);
		}

		public static IObservable<T> Timeout<T>(this IObservable<T> source, DateTimeOffset dueTime, IScheduler scheduler)
		{
			return new TimeoutObservable<T>(source, dueTime, scheduler);
		}

		public static IObservable<TR> Select<T, TR>(this IObservable<T> source, Func<T, TR> selector)
		{
			if (source is WhereObservable<T> whereObservable)
			{
				return whereObservable.CombineSelector(selector);
			}
			return new SelectObservable<T, TR>(source, selector);
		}

		public static IObservable<TR> Select<T, TR>(this IObservable<T> source, Func<T, int, TR> selector)
		{
			return new SelectObservable<T, TR>(source, selector);
		}

		public static IObservable<T> Where<T>(this IObservable<T> source, Func<T, bool> predicate)
		{
			if (source is WhereObservable<T> whereObservable)
			{
				return whereObservable.CombinePredicate(predicate);
			}
			if (source is ISelect<T> obj)
			{
				return obj.CombinePredicate(predicate);
			}
			return new WhereObservable<T>(source, predicate);
		}

		public static IObservable<T> Where<T>(this IObservable<T> source, Func<T, int, bool> predicate)
		{
			return new WhereObservable<T>(source, predicate);
		}

		public static IObservable<TR> ContinueWith<T, TR>(this IObservable<T> source, IObservable<TR> other)
		{
			return source.ContinueWith((T _) => other);
		}

		public static IObservable<TR> ContinueWith<T, TR>(this IObservable<T> source, Func<T, IObservable<TR>> selector)
		{
			return new ContinueWithObservable<T, TR>(source, selector);
		}

		public static IObservable<TR> SelectMany<T, TR>(this IObservable<T> source, IObservable<TR> other)
		{
			return source.SelectMany((T _) => other);
		}

		public static IObservable<TR> SelectMany<T, TR>(this IObservable<T> source, Func<T, IObservable<TR>> selector)
		{
			return new SelectManyObservable<T, TR>(source, selector);
		}

		public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, IObservable<TResult>> selector)
		{
			return new SelectManyObservable<TSource, TResult>(source, selector);
		}

		public static IObservable<TR> SelectMany<T, TC, TR>(this IObservable<T> source, Func<T, IObservable<TC>> collectionSelector, Func<T, TC, TR> resultSelector)
		{
			return new SelectManyObservable<T, TC, TR>(source, collectionSelector, resultSelector);
		}

		public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, int, IObservable<TCollection>> collectionSelector, Func<TSource, int, TCollection, int, TResult> resultSelector)
		{
			return new SelectManyObservable<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
		}

		public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TResult>> selector)
		{
			return new SelectManyObservable<TSource, TResult>(source, selector);
		}

		public static IObservable<TResult> SelectMany<TSource, TResult>(this IObservable<TSource> source, Func<TSource, int, IEnumerable<TResult>> selector)
		{
			return new SelectManyObservable<TSource, TResult>(source, selector);
		}

		public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, IEnumerable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			return new SelectManyObservable<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
		}

		public static IObservable<TResult> SelectMany<TSource, TCollection, TResult>(this IObservable<TSource> source, Func<TSource, int, IEnumerable<TCollection>> collectionSelector, Func<TSource, int, TCollection, int, TResult> resultSelector)
		{
			return new SelectManyObservable<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
		}

		public static IObservable<T[]> ToArray<T>(this IObservable<T> source)
		{
			return new ToArrayObservable<T>(source);
		}

		public static IObservable<IList<T>> ToList<T>(this IObservable<T> source)
		{
			return new ToListObservable<T>(source);
		}

		public static IObservable<T> Do<T>(this IObservable<T> source, IObserver<T> observer)
		{
			return new DoObserverObservable<T>(source, observer);
		}

		public static IObservable<T> Do<T>(this IObservable<T> source, Action<T> onNext)
		{
			return new DoObservable<T>(source, onNext, Stubs.Throw, Stubs.Nop);
		}

		public static IObservable<T> Do<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError)
		{
			return new DoObservable<T>(source, onNext, onError, Stubs.Nop);
		}

		public static IObservable<T> Do<T>(this IObservable<T> source, Action<T> onNext, Action onCompleted)
		{
			return new DoObservable<T>(source, onNext, Stubs.Throw, onCompleted);
		}

		public static IObservable<T> Do<T>(this IObservable<T> source, Action<T> onNext, Action<Exception> onError, Action onCompleted)
		{
			return new DoObservable<T>(source, onNext, onError, onCompleted);
		}

		public static IObservable<T> DoOnError<T>(this IObservable<T> source, Action<Exception> onError)
		{
			return new DoOnErrorObservable<T>(source, onError);
		}

		public static IObservable<T> DoOnCompleted<T>(this IObservable<T> source, Action onCompleted)
		{
			return new DoOnCompletedObservable<T>(source, onCompleted);
		}

		public static IObservable<T> DoOnTerminate<T>(this IObservable<T> source, Action onTerminate)
		{
			return new DoOnTerminateObservable<T>(source, onTerminate);
		}

		public static IObservable<T> DoOnSubscribe<T>(this IObservable<T> source, Action onSubscribe)
		{
			return new DoOnSubscribeObservable<T>(source, onSubscribe);
		}

		public static IObservable<T> DoOnCancel<T>(this IObservable<T> source, Action onCancel)
		{
			return new DoOnCancelObservable<T>(source, onCancel);
		}

		public static IObservable<Notification<T>> Materialize<T>(this IObservable<T> source)
		{
			return new MaterializeObservable<T>(source);
		}

		public static IObservable<T> Dematerialize<T>(this IObservable<Notification<T>> source)
		{
			return new DematerializeObservable<T>(source);
		}

		public static IObservable<T> DefaultIfEmpty<T>(this IObservable<T> source)
		{
			return new DefaultIfEmptyObservable<T>(source, default(T));
		}

		public static IObservable<T> DefaultIfEmpty<T>(this IObservable<T> source, T defaultValue)
		{
			return new DefaultIfEmptyObservable<T>(source, defaultValue);
		}

		public static IObservable<TSource> Distinct<TSource>(this IObservable<TSource> source)
		{
			IEqualityComparer<TSource> comparer = UnityEqualityComparer.GetDefault<TSource>();
			return new DistinctObservable<TSource>(source, comparer);
		}

		public static IObservable<TSource> Distinct<TSource>(this IObservable<TSource> source, IEqualityComparer<TSource> comparer)
		{
			return new DistinctObservable<TSource>(source, comparer);
		}

		public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector)
		{
			IEqualityComparer<TKey> comparer = UnityEqualityComparer.GetDefault<TKey>();
			return new DistinctObservable<TSource, TKey>(source, keySelector, comparer);
		}

		public static IObservable<TSource> Distinct<TSource, TKey>(this IObservable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return new DistinctObservable<TSource, TKey>(source, keySelector, comparer);
		}

		public static IObservable<T> DistinctUntilChanged<T>(this IObservable<T> source)
		{
			IEqualityComparer<T> comparer = UnityEqualityComparer.GetDefault<T>();
			return new DistinctUntilChangedObservable<T>(source, comparer);
		}

		public static IObservable<T> DistinctUntilChanged<T>(this IObservable<T> source, IEqualityComparer<T> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new DistinctUntilChangedObservable<T>(source, comparer);
		}

		public static IObservable<T> DistinctUntilChanged<T, TKey>(this IObservable<T> source, Func<T, TKey> keySelector)
		{
			IEqualityComparer<TKey> comparer = UnityEqualityComparer.GetDefault<TKey>();
			return new DistinctUntilChangedObservable<T, TKey>(source, keySelector, comparer);
		}

		public static IObservable<T> DistinctUntilChanged<T, TKey>(this IObservable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new DistinctUntilChangedObservable<T, TKey>(source, keySelector, comparer);
		}

		public static IObservable<T> IgnoreElements<T>(this IObservable<T> source)
		{
			return new IgnoreElementsObservable<T>(source);
		}

		public static IObservable<Unit> ForEachAsync<T>(this IObservable<T> source, Action<T> onNext)
		{
			return new ForEachAsyncObservable<T>(source, onNext);
		}

		public static IObservable<Unit> ForEachAsync<T>(this IObservable<T> source, Action<T, int> onNext)
		{
			return new ForEachAsyncObservable<T>(source, onNext);
		}

		public static IObservable<Unit> FromCoroutine(Func<IEnumerator> coroutine, bool publishEveryYield = false)
		{
			return FromCoroutine((IObserver<Unit> observer, CancellationToken cancellationToken) => WrapEnumerator(coroutine(), observer, cancellationToken, publishEveryYield));
		}

		public static IObservable<Unit> FromCoroutine(Func<CancellationToken, IEnumerator> coroutine, bool publishEveryYield = false)
		{
			return FromCoroutine((IObserver<Unit> observer, CancellationToken cancellationToken) => WrapEnumerator(coroutine(cancellationToken), observer, cancellationToken, publishEveryYield));
		}

		public static IObservable<Unit> FromMicroCoroutine(Func<IEnumerator> coroutine, bool publishEveryYield = false, FrameCountType frameCountType = FrameCountType.Update)
		{
			return FromMicroCoroutine((IObserver<Unit> observer, CancellationToken cancellationToken) => WrapEnumerator(coroutine(), observer, cancellationToken, publishEveryYield), frameCountType);
		}

		public static IObservable<Unit> FromMicroCoroutine(Func<CancellationToken, IEnumerator> coroutine, bool publishEveryYield = false, FrameCountType frameCountType = FrameCountType.Update)
		{
			return FromMicroCoroutine((IObserver<Unit> observer, CancellationToken cancellationToken) => WrapEnumerator(coroutine(cancellationToken), observer, cancellationToken, publishEveryYield), frameCountType);
		}

		private static IEnumerator WrapEnumerator(IEnumerator enumerator, IObserver<Unit> observer, CancellationToken cancellationToken, bool publishEveryYield)
		{
			bool raisedError = false;
			bool hasNext;
			do
			{
				try
				{
					hasNext = enumerator.MoveNext();
				}
				catch (Exception error)
				{
					try
					{
						observer.OnError(error);
						yield break;
					}
					finally
					{
						if (enumerator is IDisposable disposable)
						{
							disposable.Dispose();
						}
					}
				}
				if (hasNext && publishEveryYield)
				{
					try
					{
						observer.OnNext(Unit.Default);
					}
					catch
					{
						if (enumerator is IDisposable disposable2)
						{
							disposable2.Dispose();
						}
						throw;
					}
				}
				if (!hasNext)
				{
					continue;
				}
				object current = enumerator.Current;
				if (current is ICustomYieldInstructionErrorHandler customHandler && customHandler.IsReThrowOnError)
				{
					customHandler.ForceDisableRethrowOnError();
					yield return current;
					customHandler.ForceEnableRethrowOnError();
					if (!customHandler.HasError)
					{
						continue;
					}
					try
					{
						observer.OnError(customHandler.Error);
						yield break;
					}
					finally
					{
						if (enumerator is IDisposable disposable3)
						{
							disposable3.Dispose();
						}
					}
				}
				yield return enumerator.Current;
			}
			while (hasNext && !cancellationToken.IsCancellationRequested);
			try
			{
				if (!raisedError && !cancellationToken.IsCancellationRequested)
				{
					observer.OnNext(Unit.Default);
					observer.OnCompleted();
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable4)
				{
					disposable4.Dispose();
				}
			}
		}

		public static IObservable<T> FromCoroutineValue<T>(Func<IEnumerator> coroutine, bool nullAsNextUpdate = true)
		{
			return FromCoroutine((IObserver<T> observer, CancellationToken cancellationToken) => WrapEnumeratorYieldValue(coroutine(), observer, cancellationToken, nullAsNextUpdate));
		}

		public static IObservable<T> FromCoroutineValue<T>(Func<CancellationToken, IEnumerator> coroutine, bool nullAsNextUpdate = true)
		{
			return FromCoroutine((IObserver<T> observer, CancellationToken cancellationToken) => WrapEnumeratorYieldValue(coroutine(cancellationToken), observer, cancellationToken, nullAsNextUpdate));
		}

		private static IEnumerator WrapEnumeratorYieldValue<T>(IEnumerator enumerator, IObserver<T> observer, CancellationToken cancellationToken, bool nullAsNextUpdate)
		{
			object current = null;
			bool raisedError = false;
			bool hasNext;
			do
			{
				try
				{
					hasNext = enumerator.MoveNext();
					if (hasNext)
					{
						current = enumerator.Current;
					}
				}
				catch (Exception error)
				{
					try
					{
						observer.OnError(error);
						yield break;
					}
					finally
					{
						if (enumerator is IDisposable disposable)
						{
							disposable.Dispose();
						}
					}
				}
				if (!hasNext)
				{
					continue;
				}
				if (current != null && YieldInstructionTypes.Contains(current.GetType()))
				{
					yield return current;
					continue;
				}
				if (current is IEnumerator)
				{
					if (current is ICustomYieldInstructionErrorHandler customHandler && customHandler.IsReThrowOnError)
					{
						customHandler.ForceDisableRethrowOnError();
						yield return current;
						customHandler.ForceEnableRethrowOnError();
						if (!customHandler.HasError)
						{
							continue;
						}
						try
						{
							observer.OnError(customHandler.Error);
							yield break;
						}
						finally
						{
							if (enumerator is IDisposable disposable2)
							{
								disposable2.Dispose();
							}
						}
					}
					yield return current;
					continue;
				}
				if (current == null && nullAsNextUpdate)
				{
					yield return null;
					continue;
				}
				try
				{
					observer.OnNext((T)current);
				}
				catch
				{
					if (enumerator is IDisposable disposable3)
					{
						disposable3.Dispose();
					}
					throw;
				}
			}
			while (hasNext && !cancellationToken.IsCancellationRequested);
			try
			{
				if (!raisedError && !cancellationToken.IsCancellationRequested)
				{
					observer.OnCompleted();
				}
			}
			finally
			{
				if (enumerator is IDisposable disposable4)
				{
					disposable4.Dispose();
				}
			}
		}

		public static IObservable<T> FromCoroutine<T>(Func<IObserver<T>, IEnumerator> coroutine)
		{
			return FromCoroutine((IObserver<T> observer, CancellationToken cancellationToken) => WrapToCancellableEnumerator(coroutine(observer), observer, cancellationToken));
		}

		public static IObservable<T> FromMicroCoroutine<T>(Func<IObserver<T>, IEnumerator> coroutine, FrameCountType frameCountType = FrameCountType.Update)
		{
			return FromMicroCoroutine((IObserver<T> observer, CancellationToken cancellationToken) => WrapToCancellableEnumerator(coroutine(observer), observer, cancellationToken), frameCountType);
		}

		private static IEnumerator WrapToCancellableEnumerator<T>(IEnumerator enumerator, IObserver<T> observer, CancellationToken cancellationToken)
		{
			bool hasNext;
			do
			{
				try
				{
					hasNext = enumerator.MoveNext();
				}
				catch (Exception error)
				{
					try
					{
						observer.OnError(error);
						yield break;
					}
					finally
					{
						if (enumerator is IDisposable disposable)
						{
							disposable.Dispose();
						}
					}
				}
				yield return enumerator.Current;
			}
			while (hasNext && !cancellationToken.IsCancellationRequested);
			if (enumerator is IDisposable disposable2)
			{
				disposable2.Dispose();
			}
		}

		public static IObservable<T> FromCoroutine<T>(Func<IObserver<T>, CancellationToken, IEnumerator> coroutine)
		{
			return new FromCoroutineObservable<T>(coroutine);
		}

		public static IObservable<T> FromMicroCoroutine<T>(Func<IObserver<T>, CancellationToken, IEnumerator> coroutine, FrameCountType frameCountType = FrameCountType.Update)
		{
			return new FromMicroCoroutineObservable<T>(coroutine, frameCountType);
		}

		public static IObservable<Unit> SelectMany<T>(this IObservable<T> source, IEnumerator coroutine, bool publishEveryYield = false)
		{
			return source.SelectMany(FromCoroutine(() => coroutine, publishEveryYield));
		}

		public static IObservable<Unit> SelectMany<T>(this IObservable<T> source, Func<IEnumerator> selector, bool publishEveryYield = false)
		{
			return source.SelectMany(FromCoroutine(() => selector(), publishEveryYield));
		}

		public static IObservable<Unit> SelectMany<T>(this IObservable<T> source, Func<T, IEnumerator> selector)
		{
			return source.SelectMany((T x) => FromCoroutine(() => selector(x)));
		}

		public static IObservable<Unit> ToObservable(this IEnumerator coroutine, bool publishEveryYield = false)
		{
			return FromCoroutine((IObserver<Unit> observer, CancellationToken cancellationToken) => WrapEnumerator(coroutine, observer, cancellationToken, publishEveryYield));
		}

		public static ObservableYieldInstruction<Unit> ToYieldInstruction(this IEnumerator coroutine)
		{
			return coroutine.ToObservable().ToYieldInstruction();
		}

		public static ObservableYieldInstruction<Unit> ToYieldInstruction(this IEnumerator coroutine, bool throwOnError)
		{
			return coroutine.ToObservable().ToYieldInstruction(throwOnError);
		}

		public static ObservableYieldInstruction<Unit> ToYieldInstruction(this IEnumerator coroutine, CancellationToken cancellationToken)
		{
			return coroutine.ToObservable().ToYieldInstruction(cancellationToken);
		}

		public static ObservableYieldInstruction<Unit> ToYieldInstruction(this IEnumerator coroutine, bool throwOnError, CancellationToken cancellationToken)
		{
			return coroutine.ToObservable().ToYieldInstruction(throwOnError, cancellationToken);
		}

		public static IObservable<long> EveryUpdate()
		{
			return FromMicroCoroutine((IObserver<long> observer, CancellationToken cancellationToken) => EveryCycleCore(observer, cancellationToken));
		}

		public static IObservable<long> EveryFixedUpdate()
		{
			return FromMicroCoroutine((IObserver<long> observer, CancellationToken cancellationToken) => EveryCycleCore(observer, cancellationToken), FrameCountType.FixedUpdate);
		}

		public static IObservable<long> EveryEndOfFrame()
		{
			return FromMicroCoroutine((IObserver<long> observer, CancellationToken cancellationToken) => EveryCycleCore(observer, cancellationToken), FrameCountType.EndOfFrame);
		}

		private static IEnumerator EveryCycleCore(IObserver<long> observer, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				yield break;
			}
			long count = 0L;
			while (true)
			{
				yield return null;
				if (cancellationToken.IsCancellationRequested)
				{
					break;
				}
				observer.OnNext(count++);
			}
		}

		public static IObservable<long> EveryGameObjectUpdate()
		{
			return MainThreadDispatcher.UpdateAsObservable().Scan(-1L, (long x, Unit y) => x + 1);
		}

		public static IObservable<long> EveryLateUpdate()
		{
			return MainThreadDispatcher.LateUpdateAsObservable().Scan(-1L, (long x, Unit y) => x + 1);
		}

		[Obsolete]
		public static IObservable<long> EveryAfterUpdate()
		{
			return FromCoroutine((IObserver<long> observer, CancellationToken cancellationToken) => new EveryAfterUpdateInvoker(observer, cancellationToken));
		}

		public static IObservable<Unit> NextFrame(FrameCountType frameCountType = FrameCountType.Update)
		{
			return FromMicroCoroutine((IObserver<Unit> observer, CancellationToken cancellation) => NextFrameCore(observer, cancellation), frameCountType);
		}

		private static IEnumerator NextFrameCore(IObserver<Unit> observer, CancellationToken cancellation)
		{
			yield return null;
			if (!cancellation.IsCancellationRequested)
			{
				observer.OnNext(Unit.Default);
				observer.OnCompleted();
			}
		}

		public static IObservable<long> IntervalFrame(int intervalFrameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			return TimerFrame(intervalFrameCount, intervalFrameCount, frameCountType);
		}

		public static IObservable<long> TimerFrame(int dueTimeFrameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			return FromMicroCoroutine((IObserver<long> observer, CancellationToken cancellation) => TimerFrameCore(observer, dueTimeFrameCount, cancellation), frameCountType);
		}

		public static IObservable<long> TimerFrame(int dueTimeFrameCount, int periodFrameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			return FromMicroCoroutine((IObserver<long> observer, CancellationToken cancellation) => TimerFrameCore(observer, dueTimeFrameCount, periodFrameCount, cancellation), frameCountType);
		}

		private static IEnumerator TimerFrameCore(IObserver<long> observer, int dueTimeFrameCount, CancellationToken cancel)
		{
			if (dueTimeFrameCount <= 0)
			{
				dueTimeFrameCount = 0;
			}
			int currentFrame = 0;
			while (!cancel.IsCancellationRequested)
			{
				if (currentFrame++ == dueTimeFrameCount)
				{
					observer.OnNext(0L);
					observer.OnCompleted();
					break;
				}
				yield return null;
			}
		}

		private static IEnumerator TimerFrameCore(IObserver<long> observer, int dueTimeFrameCount, int periodFrameCount, CancellationToken cancel)
		{
			if (dueTimeFrameCount <= 0)
			{
				dueTimeFrameCount = 0;
			}
			if (periodFrameCount <= 0)
			{
				periodFrameCount = 1;
			}
			long sendCount = 0L;
			int currentFrame = 0;
			while (!cancel.IsCancellationRequested)
			{
				if (currentFrame++ == dueTimeFrameCount)
				{
					observer.OnNext(sendCount++);
					currentFrame = -1;
					break;
				}
				yield return null;
			}
			while (!cancel.IsCancellationRequested)
			{
				int num = currentFrame + 1;
				currentFrame = num;
				if (num == periodFrameCount)
				{
					observer.OnNext(sendCount++);
					currentFrame = 0;
				}
				yield return null;
			}
		}

		public static IObservable<T> DelayFrame<T>(this IObservable<T> source, int frameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount");
			}
			return new DelayFrameObservable<T>(source, frameCount, frameCountType);
		}

		public static IObservable<T> Sample<T, T2>(this IObservable<T> source, IObservable<T2> sampler)
		{
			return new SampleObservable<T, T2>(source, sampler);
		}

		public static IObservable<T> SampleFrame<T>(this IObservable<T> source, int frameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount");
			}
			return new SampleFrameObservable<T>(source, frameCount, frameCountType);
		}

		public static IObservable<TSource> ThrottleFrame<TSource>(this IObservable<TSource> source, int frameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount");
			}
			return new ThrottleFrameObservable<TSource>(source, frameCount, frameCountType);
		}

		public static IObservable<TSource> ThrottleFirstFrame<TSource>(this IObservable<TSource> source, int frameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount");
			}
			return new ThrottleFirstFrameObservable<TSource>(source, frameCount, frameCountType);
		}

		public static IObservable<T> TimeoutFrame<T>(this IObservable<T> source, int frameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount");
			}
			return new TimeoutFrameObservable<T>(source, frameCount, frameCountType);
		}

		public static IObservable<T> DelayFrameSubscription<T>(this IObservable<T> source, int frameCount, FrameCountType frameCountType = FrameCountType.Update)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount");
			}
			return new DelayFrameSubscriptionObservable<T>(source, frameCount, frameCountType);
		}

		public static ObservableYieldInstruction<T> ToYieldInstruction<T>(this IObservable<T> source)
		{
			return new ObservableYieldInstruction<T>(source, reThrowOnError: true, CancellationToken.None);
		}

		public static ObservableYieldInstruction<T> ToYieldInstruction<T>(this IObservable<T> source, CancellationToken cancel)
		{
			return new ObservableYieldInstruction<T>(source, reThrowOnError: true, cancel);
		}

		public static ObservableYieldInstruction<T> ToYieldInstruction<T>(this IObservable<T> source, bool throwOnError)
		{
			return new ObservableYieldInstruction<T>(source, throwOnError, CancellationToken.None);
		}

		public static ObservableYieldInstruction<T> ToYieldInstruction<T>(this IObservable<T> source, bool throwOnError, CancellationToken cancel)
		{
			return new ObservableYieldInstruction<T>(source, throwOnError, cancel);
		}

		public static IEnumerator ToAwaitableEnumerator<T>(this IObservable<T> source, CancellationToken cancel = default(CancellationToken))
		{
			return source.ToAwaitableEnumerator(Stubs<T>.Ignore, Stubs.Throw, cancel);
		}

		public static IEnumerator ToAwaitableEnumerator<T>(this IObservable<T> source, Action<T> onResult, CancellationToken cancel = default(CancellationToken))
		{
			return source.ToAwaitableEnumerator(onResult, Stubs.Throw, cancel);
		}

		public static IEnumerator ToAwaitableEnumerator<T>(this IObservable<T> source, Action<Exception> onError, CancellationToken cancel = default(CancellationToken))
		{
			return source.ToAwaitableEnumerator(Stubs<T>.Ignore, onError, cancel);
		}

		public static IEnumerator ToAwaitableEnumerator<T>(this IObservable<T> source, Action<T> onResult, Action<Exception> onError, CancellationToken cancel = default(CancellationToken))
		{
			ObservableYieldInstruction<T> enumerator = new ObservableYieldInstruction<T>(source, reThrowOnError: false, cancel);
			IEnumerator<T> e = enumerator;
			while (e.MoveNext() && !cancel.IsCancellationRequested)
			{
				yield return null;
			}
			if (cancel.IsCancellationRequested)
			{
				enumerator.Dispose();
			}
			else if (enumerator.HasResult)
			{
				onResult(enumerator.Result);
			}
			else if (enumerator.HasError)
			{
				onError(enumerator.Error);
			}
		}

		public static Coroutine StartAsCoroutine<T>(this IObservable<T> source, CancellationToken cancel = default(CancellationToken))
		{
			return source.StartAsCoroutine(Stubs<T>.Ignore, Stubs.Throw, cancel);
		}

		public static Coroutine StartAsCoroutine<T>(this IObservable<T> source, Action<T> onResult, CancellationToken cancel = default(CancellationToken))
		{
			return source.StartAsCoroutine(onResult, Stubs.Throw, cancel);
		}

		public static Coroutine StartAsCoroutine<T>(this IObservable<T> source, Action<Exception> onError, CancellationToken cancel = default(CancellationToken))
		{
			return source.StartAsCoroutine(Stubs<T>.Ignore, onError, cancel);
		}

		public static Coroutine StartAsCoroutine<T>(this IObservable<T> source, Action<T> onResult, Action<Exception> onError, CancellationToken cancel = default(CancellationToken))
		{
			return MainThreadDispatcher.StartCoroutine(source.ToAwaitableEnumerator(onResult, onError, cancel));
		}

		public static IObservable<T> ObserveOnMainThread<T>(this IObservable<T> source)
		{
			return source.ObserveOn(Scheduler.MainThread);
		}

		public static IObservable<T> ObserveOnMainThread<T>(this IObservable<T> source, MainThreadDispatchType dispatchType)
		{
			switch (dispatchType)
			{
			case MainThreadDispatchType.Update:
				return source.ObserveOnMainThread();
			case MainThreadDispatchType.FixedUpdate:
				return source.SelectMany((T _) => EveryFixedUpdate().Take(1), (T x, long _) => x);
			case MainThreadDispatchType.EndOfFrame:
				return source.SelectMany((T _) => EveryEndOfFrame().Take(1), (T x, long _) => x);
			case MainThreadDispatchType.GameObjectUpdate:
				return source.SelectMany((T _) => MainThreadDispatcher.UpdateAsObservable().Take(1), (T x, Unit _) => x);
			case MainThreadDispatchType.LateUpdate:
				return source.SelectMany((T _) => MainThreadDispatcher.LateUpdateAsObservable().Take(1), (T x, Unit _) => x);
			default:
				throw new ArgumentException("type is invalid");
			}
		}

		public static IObservable<T> SubscribeOnMainThread<T>(this IObservable<T> source)
		{
			return source.SubscribeOn(Scheduler.MainThread);
		}

		public static IObservable<bool> EveryApplicationPause()
		{
			return MainThreadDispatcher.OnApplicationPauseAsObservable().AsObservable();
		}

		public static IObservable<bool> EveryApplicationFocus()
		{
			return MainThreadDispatcher.OnApplicationFocusAsObservable().AsObservable();
		}

		public static IObservable<Unit> OnceApplicationQuit()
		{
			return MainThreadDispatcher.OnApplicationQuitAsObservable().Take(1);
		}

		public static IObservable<T> TakeUntilDestroy<T>(this IObservable<T> source, Component target)
		{
			return source.TakeUntil(target.OnDestroyAsObservable());
		}

		public static IObservable<T> TakeUntilDestroy<T>(this IObservable<T> source, GameObject target)
		{
			return source.TakeUntil(target.OnDestroyAsObservable());
		}

		public static IObservable<T> TakeUntilDisable<T>(this IObservable<T> source, Component target)
		{
			return source.TakeUntil(target.OnDisableAsObservable());
		}

		public static IObservable<T> TakeUntilDisable<T>(this IObservable<T> source, GameObject target)
		{
			return source.TakeUntil(target.OnDisableAsObservable());
		}

		public static IObservable<T> RepeatUntilDestroy<T>(this IObservable<T> source, GameObject target)
		{
			return RepeatInfinite(source).RepeatUntilCore(target.OnDestroyAsObservable(), target);
		}

		public static IObservable<T> RepeatUntilDestroy<T>(this IObservable<T> source, Component target)
		{
			return RepeatInfinite(source).RepeatUntilCore(target.OnDestroyAsObservable(), (target != null) ? target.gameObject : null);
		}

		public static IObservable<T> RepeatUntilDisable<T>(this IObservable<T> source, GameObject target)
		{
			return RepeatInfinite(source).RepeatUntilCore(target.OnDisableAsObservable(), target);
		}

		public static IObservable<T> RepeatUntilDisable<T>(this IObservable<T> source, Component target)
		{
			return RepeatInfinite(source).RepeatUntilCore(target.OnDisableAsObservable(), (target != null) ? target.gameObject : null);
		}

		private static IObservable<T> RepeatUntilCore<T>(this IEnumerable<IObservable<T>> sources, IObservable<Unit> trigger, GameObject lifeTimeChecker)
		{
			return new RepeatUntilObservable<T>(sources, trigger, lifeTimeChecker);
		}

		public static IObservable<FrameInterval<T>> FrameInterval<T>(this IObservable<T> source)
		{
			return new FrameIntervalObservable<T>(source);
		}

		public static IObservable<TimeInterval<T>> FrameTimeInterval<T>(this IObservable<T> source, bool ignoreTimeScale = false)
		{
			return new FrameTimeIntervalObservable<T>(source, ignoreTimeScale);
		}

		public static IObservable<IList<T>> BatchFrame<T>(this IObservable<T> source)
		{
			return source.BatchFrame(0, FrameCountType.EndOfFrame);
		}

		public static IObservable<IList<T>> BatchFrame<T>(this IObservable<T> source, int frameCount, FrameCountType frameCountType)
		{
			if (frameCount < 0)
			{
				throw new ArgumentException("frameCount must be >= 0, frameCount:" + frameCount);
			}
			return new BatchFrameObservable<T>(source, frameCount, frameCountType);
		}

		public static IObservable<Unit> BatchFrame(this IObservable<Unit> source)
		{
			return source.BatchFrame(0, FrameCountType.EndOfFrame);
		}

		public static IObservable<Unit> BatchFrame(this IObservable<Unit> source, int frameCount, FrameCountType frameCountType)
		{
			if (frameCount < 0)
			{
				throw new ArgumentException("frameCount must be >= 0, frameCount:" + frameCount);
			}
			return new BatchFrameObservable(source, frameCount, frameCountType);
		}
	}
}
