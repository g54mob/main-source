using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using R3.Collections;
using R3.Internal;

namespace R3
{
	public static class ObservableExtensions
	{
		public static LiveList<T> ToLiveList<T>(this Observable<T> source)
		{
			return new LiveList<T>(source);
		}

		public static LiveList<T> ToLiveList<T>(this Observable<T> source, int bufferSize)
		{
			return new LiveList<T>(source, bufferSize);
		}

		public static Observable<T> Concat<T>(this Observable<T> source, Observable<T> second)
		{
			return new Concat<T>(new Observable<T>[2] { source, second });
		}

		public static Observable<T> Merge<T>(this Observable<T> source, Observable<T> second)
		{
			return new Merge<T>(new Observable<T>[2] { source, second });
		}

		public static Observable<T> Race<T>(this Observable<T> source, Observable<T> second)
		{
			return Observable.Race<T>(source, second);
		}

		[Obsolete("Amb is renamed to Race.")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public static Observable<T> Amb<T>(this Observable<T> source, Observable<T> second)
		{
			return source.Race(second);
		}

		public static Task<T> AggregateAsync<T>(this Observable<T> source, Func<T, T, T> func, CancellationToken cancellationToken = default(CancellationToken))
		{
			AggregateAsync<T> aggregateAsync = new AggregateAsync<T>(func, cancellationToken);
			source.Subscribe(aggregateAsync);
			return aggregateAsync.Task;
		}

		public static Task<TResult> AggregateAsync<T, TResult>(this Observable<T> source, TResult seed, Func<TResult, T, TResult> func, CancellationToken cancellationToken = default(CancellationToken))
		{
			AggregateAsync<T, TResult> aggregateAsync = new AggregateAsync<T, TResult>(seed, func, cancellationToken);
			source.Subscribe(aggregateAsync);
			return aggregateAsync.Task;
		}

		public static Task<TResult> AggregateAsync<T, TAccumulate, TResult>(this Observable<T> source, TAccumulate seed, Func<TAccumulate, T, TAccumulate> func, Func<TAccumulate, TResult> resultSelector, CancellationToken cancellationToken = default(CancellationToken))
		{
			AggregateAsync<T, TAccumulate, TResult> aggregateAsync = new AggregateAsync<T, TAccumulate, TResult>(seed, func, resultSelector, cancellationToken);
			source.Subscribe(aggregateAsync);
			return aggregateAsync.Task;
		}

		public static Task<IEnumerable<KeyValuePair<TKey, TAccumulate>>> AggregateByAsync<TSource, TKey, TAccumulate>(this Observable<TSource> source, Func<TSource, TKey> keySelector, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer = null, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			AggregateByAsync<TSource, TKey, TAccumulate> aggregateByAsync = new AggregateByAsync<TSource, TKey, TAccumulate>(keySelector, seed, func, keyComparer, cancellationToken);
			source.Subscribe(aggregateByAsync);
			return aggregateByAsync.Task;
		}

		public static Task<IEnumerable<KeyValuePair<TKey, TAccumulate>>> AggregateByAsync<TSource, TKey, TAccumulate>(this Observable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, TAccumulate> seedSelector, Func<TAccumulate, TSource, TAccumulate> func, IEqualityComparer<TKey>? keyComparer = null, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			AggregateByAsyncSeedSelector<TSource, TKey, TAccumulate> aggregateByAsyncSeedSelector = new AggregateByAsyncSeedSelector<TSource, TKey, TAccumulate>(keySelector, seedSelector, func, keyComparer, cancellationToken);
			source.Subscribe(aggregateByAsyncSeedSelector);
			return aggregateByAsyncSeedSelector.Task;
		}

		public static Task<bool> AllAsync<T>(this Observable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			AllAsync<T> allAsync = new AllAsync<T>(predicate, cancellationToken);
			source.Subscribe(allAsync);
			return allAsync.Task;
		}

		public static Task<bool> AnyAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.AnyAsync((T x) => true, cancellationToken);
		}

		public static Task<bool> AnyAsync<T>(this Observable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			AnyAsync<T> anyAsync = new AnyAsync<T>(predicate, cancellationToken);
			source.Subscribe(anyAsync);
			return anyAsync.Task;
		}

		public static Task<bool> IsEmptyAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			IsEmptyAsync<T> isEmptyAsync = new IsEmptyAsync<T>(cancellationToken);
			source.Subscribe(isEmptyAsync);
			return isEmptyAsync.Task;
		}

		public static Observable<T> Append<T>(this Observable<T> source, T value)
		{
			return new AppendPrepend<T>(source, value, append: true);
		}

		public static Observable<T> Append<T>(this Observable<T> source, IEnumerable<T> values)
		{
			return new AppendPrependEnumerable<T>(source, values, append: true);
		}

		public static Observable<T> Append<T>(this Observable<T> source, Func<T> valueFactory)
		{
			return new AppendPrependFactory<T>(source, valueFactory, append: true);
		}

		public static Observable<T> Append<T, TState>(this Observable<T> source, TState state, Func<TState, T> valueFactory)
		{
			return new AppendPrependFactory<T, TState>(source, state, valueFactory, append: true);
		}

		public static Observable<T> Prepend<T>(this Observable<T> source, T value)
		{
			return new AppendPrepend<T>(source, value, append: false);
		}

		public static Observable<T> Prepend<T>(this Observable<T> source, IEnumerable<T> values)
		{
			return new AppendPrependEnumerable<T>(source, values, append: false);
		}

		public static Observable<T> Prepend<T>(this Observable<T> source, Func<T> valueFactory)
		{
			return new AppendPrependFactory<T>(source, valueFactory, append: false);
		}

		public static Observable<T> Prepend<T, TState>(this Observable<T> source, TState state, Func<TState, T> valueFactory)
		{
			return new AppendPrependFactory<T, TState>(source, state, valueFactory, append: false);
		}

		public static Observable<T> AsObservable<T>(this Observable<T> source)
		{
			if (source is AsObservable<T>)
			{
				return source;
			}
			return new AsObservable<T>(source);
		}

		public static IObservable<T> AsSystemObservable<T>(this Observable<T> source)
		{
			return new AsSystemObservable<T>(source);
		}

		public static Observable<Unit> AsUnitObservable<T>(this Observable<T> source)
		{
			if (source is Observable<Unit> result)
			{
				return result;
			}
			return new AsUnitObservable<T>(source);
		}

		public static Task<double> AverageAsync(this Observable<int> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageInt32Async averageInt32Async = new AverageInt32Async(cancellationToken);
			source.Subscribe(averageInt32Async);
			return averageInt32Async.Task;
		}

		public static Task<double> AverageAsync<T>(this Observable<T> source, Func<T, int> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageInt32Async<T> averageInt32Async = new AverageInt32Async<T>(selector, cancellationToken);
			source.Subscribe(averageInt32Async);
			return averageInt32Async.Task;
		}

		public static Task<double> AverageAsync(this Observable<long> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageInt64Async averageInt64Async = new AverageInt64Async(cancellationToken);
			source.Subscribe(averageInt64Async);
			return averageInt64Async.Task;
		}

		public static Task<double> AverageAsync<T>(this Observable<T> source, Func<T, long> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageInt64Async<T> averageInt64Async = new AverageInt64Async<T>(selector, cancellationToken);
			source.Subscribe(averageInt64Async);
			return averageInt64Async.Task;
		}

		public static Task<double> AverageAsync(this Observable<float> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageFloatAsync averageFloatAsync = new AverageFloatAsync(cancellationToken);
			source.Subscribe(averageFloatAsync);
			return averageFloatAsync.Task;
		}

		public static Task<double> AverageAsync<T>(this Observable<T> source, Func<T, float> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageFloatAsync<T> averageFloatAsync = new AverageFloatAsync<T>(selector, cancellationToken);
			source.Subscribe(averageFloatAsync);
			return averageFloatAsync.Task;
		}

		public static Task<double> AverageAsync(this Observable<double> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageDoubleAsync averageDoubleAsync = new AverageDoubleAsync(cancellationToken);
			source.Subscribe(averageDoubleAsync);
			return averageDoubleAsync.Task;
		}

		public static Task<double> AverageAsync<T>(this Observable<T> source, Func<T, double> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageDoubleAsync<T> averageDoubleAsync = new AverageDoubleAsync<T>(selector, cancellationToken);
			source.Subscribe(averageDoubleAsync);
			return averageDoubleAsync.Task;
		}

		public static Task<double> AverageAsync(this Observable<decimal> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageDecimalAsync averageDecimalAsync = new AverageDecimalAsync(cancellationToken);
			source.Subscribe(averageDecimalAsync);
			return averageDecimalAsync.Task;
		}

		public static Task<double> AverageAsync<T>(this Observable<T> source, Func<T, decimal> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			AverageDecimalAsync<T> averageDecimalAsync = new AverageDecimalAsync<T>(selector, cancellationToken);
			source.Subscribe(averageDecimalAsync);
			return averageDecimalAsync.Task;
		}

		public static Observable<TResult> Cast<T, TResult>(this Observable<T> source)
		{
			return new Cast<T, TResult>(source);
		}

		public static Observable<T> Catch<T>(this Observable<T> source, Observable<T> second)
		{
			return new Catch<T>(source, second);
		}

		public static Observable<T> Catch<T, TException>(this Observable<T> source, Func<TException, Observable<T>> errorHandler)
		{
			return new Catch<T, TException>(source, errorHandler);
		}

		public static Observable<T[]> Chunk<T>(this Observable<T> source, int count)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count <= 0");
			}
			return new Chunk<T>(source, count);
		}

		public static Observable<T[]> Chunk<T>(this Observable<T> source, int count, int skip)
		{
			if (count <= 0)
			{
				throw new ArgumentOutOfRangeException("count <= 0");
			}
			if (skip <= 0)
			{
				return source.Chunk(count);
			}
			return new ChunkCountSkip<T>(source, count, skip);
		}

		public static Observable<T[]> Chunk<T>(this Observable<T> source, TimeSpan timeSpan)
		{
			return source.Chunk(timeSpan, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T[]> Chunk<T>(this Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			return new ChunkTime<T>(source, timeSpan.Normalize(), timeProvider);
		}

		public static Observable<T[]> Chunk<T>(this Observable<T> source, TimeSpan timeSpan, int count)
		{
			return source.Chunk(timeSpan, count, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T[]> Chunk<T>(this Observable<T> source, TimeSpan timeSpan, int count, TimeProvider timeProvider)
		{
			return new ChunkTimeCount<T>(source, timeSpan.Normalize(), count, timeProvider);
		}

		public static Observable<TSource[]> Chunk<TSource, TWindowBoundary>(this Observable<TSource> source, Observable<TWindowBoundary> windowBoundaries)
		{
			return new ChunkWindow<TSource, TWindowBoundary>(source, windowBoundaries);
		}

		public static Observable<T[]> Chunk<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> asyncWindow, bool configureAwait = true)
		{
			return new ChunkAsync<T>(source, asyncWindow, configureAwait);
		}

		public static Observable<T[]> ChunkFrame<T>(this Observable<T> source)
		{
			return source.ChunkFrame(0, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T[]> ChunkFrame<T>(this Observable<T> source, int frameCount)
		{
			return source.ChunkFrame(frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T[]> ChunkFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount < 0");
			}
			return new ChunkFrame<T>(source, frameCount.NormalizeFrame(), frameProvider);
		}

		public static Observable<T[]> ChunkFrame<T>(this Observable<T> source, int frameCount, int count)
		{
			return source.ChunkFrame(frameCount, count, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T[]> ChunkFrame<T>(this Observable<T> source, int frameCount, int count, FrameProvider frameProvider)
		{
			if (frameCount < 0)
			{
				throw new ArgumentOutOfRangeException("frameCount < 0");
			}
			return new ChunkFrameCount<T>(source, frameCount.NormalizeFrame(), count, frameProvider);
		}

		public static Observable<T[]> ChunkUntil<T>(this Observable<T> source, Func<T, bool> predicate)
		{
			return new ChunkUntil<T>(source, predicate);
		}

		public static Observable<T[]> ChunkUntil<T>(this Observable<T> source, Func<T, int, bool> predicate)
		{
			return new ChunkUntilI<T>(source, predicate);
		}

		public static Task<bool> ContainsAsync<T>(this Observable<T> source, T value, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.ContainsAsync(value, EqualityComparer<T>.Default, cancellationToken);
		}

		public static Task<bool> ContainsAsync<T>(this Observable<T> source, T value, IEqualityComparer<T> equalityComparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			ContainsAsync<T> containsAsync = new ContainsAsync<T>(value, equalityComparer, cancellationToken);
			source.Subscribe(containsAsync);
			return containsAsync.Task;
		}

		public static Task<int> CountAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			CountAsync<T> countAsync = new CountAsync<T>(cancellationToken);
			source.Subscribe(countAsync);
			return countAsync.Task;
		}

		public static Task<int> CountAsync<T>(this Observable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			CountFilterAsync<T> countFilterAsync = new CountFilterAsync<T>(predicate, cancellationToken);
			source.Subscribe(countFilterAsync);
			return countFilterAsync.Task;
		}

		public static Task<long> LongCountAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			LongCountAsync<T> longCountAsync = new LongCountAsync<T>(cancellationToken);
			source.Subscribe(longCountAsync);
			return longCountAsync.Task;
		}

		public static Task<long> LongCountAsync<T>(this Observable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			LongCountFilterAsync<T> longCountFilterAsync = new LongCountFilterAsync<T>(predicate, cancellationToken);
			source.Subscribe(longCountFilterAsync);
			return longCountFilterAsync.Task;
		}

		public static Observable<T> Debounce<T>(this Observable<T> source, TimeSpan timeSpan)
		{
			return new Debounce<T>(source, timeSpan, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> Debounce<T>(this Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			return new Debounce<T>(source, timeSpan, timeProvider);
		}

		public static Observable<T> Debounce<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> throttleDurationSelector, bool configureAwait = true)
		{
			return new DebounceSelector<T>(source, throttleDurationSelector, configureAwait);
		}

		public static Observable<T> DebounceFrame<T>(this Observable<T> source, int frameCount)
		{
			return new DebounceFrame<T>(source, frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> DebounceFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new DebounceFrame<T>(source, frameCount, frameProvider);
		}

		public static Observable<T?> DefaultIfEmpty<T>(this Observable<T> source)
		{
			return source.DefaultIfEmpty(default(T));
		}

		public static Observable<T?> DefaultIfEmpty<T>(this Observable<T> source, T? defaultValue)
		{
			return new DefaultIfEmpty<T>(source, defaultValue);
		}

		public static Observable<T> Delay<T>(this Observable<T> source, TimeSpan dueTime)
		{
			return new Delay<T>(source, dueTime, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> Delay<T>(this Observable<T> source, TimeSpan dueTime, TimeProvider timeProvider)
		{
			return new Delay<T>(source, dueTime, timeProvider);
		}

		public static Observable<T> DelayFrame<T>(this Observable<T> source, int frameCount)
		{
			return new DelayFrame<T>(source, frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> DelayFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new DelayFrame<T>(source, frameCount, frameProvider);
		}

		public static Observable<T> DelaySubscription<T>(this Observable<T> source, TimeSpan dueTime)
		{
			return new DelaySubscription<T>(source, dueTime, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> DelaySubscription<T>(this Observable<T> source, TimeSpan dueTime, TimeProvider timeProvider)
		{
			return new DelaySubscription<T>(source, dueTime, timeProvider);
		}

		public static Observable<T> DelaySubscriptionFrame<T>(this Observable<T> source, int frameCount)
		{
			return new DelaySubscriptionFrame<T>(source, frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> DelaySubscriptionFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new DelaySubscriptionFrame<T>(source, frameCount, frameProvider);
		}

		public static Observable<T> Distinct<T>(this Observable<T> source)
		{
			return source.Distinct(EqualityComparer<T>.Default);
		}

		public static Observable<T> Distinct<T>(this Observable<T> source, IEqualityComparer<T> comparer)
		{
			return new Distinct<T>(source, comparer);
		}

		public static Observable<TSource> DistinctBy<TSource, TKey>(this Observable<TSource> source, Func<TSource, TKey> keySelector)
		{
			return source.DistinctBy(keySelector, EqualityComparer<TKey>.Default);
		}

		public static Observable<TSource> DistinctBy<TSource, TKey>(this Observable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return new DistinctBy<TSource, TKey>(source, keySelector, comparer);
		}

		public static Observable<T> DistinctUntilChanged<T>(this Observable<T> source)
		{
			return source.DistinctUntilChanged(EqualityComparer<T>.Default);
		}

		public static Observable<T> DistinctUntilChanged<T>(this Observable<T> source, IEqualityComparer<T> comparer)
		{
			return new DistinctUntilChanged<T>(source, comparer);
		}

		public static Observable<T> DistinctUntilChangedBy<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector)
		{
			return source.DistinctUntilChangedBy(keySelector, EqualityComparer<TKey>.Default);
		}

		public static Observable<T> DistinctUntilChangedBy<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			return new DistinctUntilChangedBy<T, TKey>(source, keySelector, comparer);
		}

		public static Observable<T> Do<T>(this Observable<T> source, Action<T>? onNext = null, Action<Exception>? onErrorResume = null, Action<Result>? onCompleted = null, Action? onDispose = null, Action? onSubscribe = null)
		{
			return new Do<T>(source, onNext, onErrorResume, onCompleted, onDispose, onSubscribe);
		}

		public static Observable<T> Do<T, TState>(this Observable<T> source, TState state, Action<T, TState>? onNext = null, Action<Exception, TState>? onErrorResume = null, Action<Result, TState>? onCompleted = null, Action<TState>? onDispose = null, Action<TState>? onSubscribe = null)
		{
			return new Do<T, TState>(source, state, onNext, onErrorResume, onCompleted, onDispose, onSubscribe);
		}

		public static Observable<T> DoCancelOnCompleted<T>(this Observable<T> source, CancellationTokenSource cancellationTokenSource)
		{
			return source.Do(cancellationTokenSource, null, null, delegate(Result _, CancellationTokenSource state)
			{
				state.Cancel();
			});
		}

		public static Task<T> ElementAtAsync<T>(this Observable<T> source, int index, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ElementAtAsync<T> elementAtAsync = new ElementAtAsync<T>(index, useDefaultValue: false, default(T), cancellationToken);
			source.Subscribe(elementAtAsync);
			return elementAtAsync.Task;
		}

		public static Task<T> ElementAtAsync<T>(this Observable<T> source, Index index, CancellationToken cancellationToken = default(CancellationToken))
		{
			if (index.IsFromEnd)
			{
				if (index.Value <= 0)
				{
					throw new ArgumentOutOfRangeException("index");
				}
				ElementAtFromEndAsync<T> elementAtFromEndAsync = new ElementAtFromEndAsync<T>(index.Value, useDefaultValue: false, default(T), cancellationToken);
				source.Subscribe(elementAtFromEndAsync);
				return elementAtFromEndAsync.Task;
			}
			return source.ElementAtAsync(index.Value, cancellationToken);
		}

		public static Task<T> ElementAtOrDefaultAsync<T>(this Observable<T> source, int index, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			if (index < 0)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ElementAtAsync<T> elementAtAsync = new ElementAtAsync<T>(index, useDefaultValue: true, defaultValue, cancellationToken);
			source.Subscribe(elementAtAsync);
			return elementAtAsync.Task;
		}

		public static Task<T> ElementAtOrDefaultAsync<T>(this Observable<T> source, Index index, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			if (index.IsFromEnd)
			{
				ElementAtFromEndAsync<T> elementAtFromEndAsync = new ElementAtFromEndAsync<T>(index.Value, useDefaultValue: true, defaultValue, cancellationToken);
				source.Subscribe(elementAtFromEndAsync);
				return elementAtFromEndAsync.Task;
			}
			return source.ElementAtOrDefaultAsync(index.Value, defaultValue, cancellationToken);
		}

		public static Task<T> FirstAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstAsync((T _) => true, cancellationToken);
		}

		public static Task<T> FirstOrDefaultAsync<T>(this Observable<T> source, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstOrDefaultAsync((T _) => true, defaultValue, cancellationToken);
		}

		public static Task<T> LastAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.LastAsync((T _) => true, cancellationToken);
		}

		public static Task<T> LastOrDefaultAsync<T>(this Observable<T> source, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.LastOrDefaultAsync((T _) => true, defaultValue, cancellationToken);
		}

		public static Task<T> SingleAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.SingleAsync((T _) => true, cancellationToken);
		}

		public static Task<T> SingleOrDefaultAsync<T>(this Observable<T> source, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.SingleOrDefaultAsync((T _) => true, defaultValue, cancellationToken);
		}

		public static Task<T> FirstAsync<T>(this Observable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstLastSingleAsync(FirstLastSingleOperation.First, useDefaultIfEmpty: false, default(T), predicate, cancellationToken);
		}

		public static Task<T> FirstOrDefaultAsync<T>(this Observable<T> source, Func<T, bool> predicate, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstLastSingleAsync(FirstLastSingleOperation.First, useDefaultIfEmpty: true, defaultValue, predicate, cancellationToken);
		}

		public static Task<T> LastAsync<T>(this Observable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstLastSingleAsync(FirstLastSingleOperation.Last, useDefaultIfEmpty: false, default(T), predicate, cancellationToken);
		}

		public static Task<T> LastOrDefaultAsync<T>(this Observable<T> source, Func<T, bool> predicate, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstLastSingleAsync(FirstLastSingleOperation.Last, useDefaultIfEmpty: true, defaultValue, predicate, cancellationToken);
		}

		public static Task<T> SingleAsync<T>(this Observable<T> source, Func<T, bool> predicate, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstLastSingleAsync(FirstLastSingleOperation.Single, useDefaultIfEmpty: false, default(T), predicate, cancellationToken);
		}

		public static Task<T> SingleOrDefaultAsync<T>(this Observable<T> source, Func<T, bool> predicate, T? defaultValue = default(T?), CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.FirstLastSingleAsync(FirstLastSingleOperation.Single, useDefaultIfEmpty: true, defaultValue, predicate, cancellationToken);
		}

		private static Task<T> FirstLastSingleAsync<T>(this Observable<T> source, FirstLastSingleOperation operation, bool useDefaultIfEmpty, T? defaultValue, Func<T, bool> predicate, CancellationToken cancellationToken)
		{
			FirstLastSingle<T> firstLastSingle = new FirstLastSingle<T>(operation, useDefaultIfEmpty, defaultValue, predicate, cancellationToken);
			source.Subscribe(firstLastSingle);
			return firstLastSingle.Task;
		}

		public static Task ForEachAsync<T>(this Observable<T> source, Action<T> action, CancellationToken cancellationToken = default(CancellationToken))
		{
			ForEachAsync<T> forEachAsync = new ForEachAsync<T>(action, cancellationToken);
			source.Subscribe(forEachAsync);
			return forEachAsync.Task;
		}

		public static Task ForEachAsync<T>(this Observable<T> source, Action<T, int> action, CancellationToken cancellationToken = default(CancellationToken))
		{
			ForEachAsyncWithIndex<T> forEachAsyncWithIndex = new ForEachAsyncWithIndex<T>(action, cancellationToken);
			source.Subscribe(forEachAsyncWithIndex);
			return forEachAsyncWithIndex.Task;
		}

		public static Observable<(long FrameCount, T Value)> FrameCount<T>(this Observable<T> source)
		{
			return new FrameCount<T>(source, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<(long FrameCount, T Value)> FrameCount<T>(this Observable<T> source, FrameProvider frameProvider)
		{
			return new FrameCount<T>(source, frameProvider);
		}

		public static Observable<(long Interval, T Value)> FrameInterval<T>(this Observable<T> source)
		{
			return new FrameInterval<T>(source, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<(long Interval, T Value)> FrameInterval<T>(this Observable<T> source, FrameProvider frameProvider)
		{
			return new FrameInterval<T>(source, frameProvider);
		}

		public static Observable<T> IgnoreElements<T>(this Observable<T> source)
		{
			return new IgnoreElements<T>(source, null);
		}

		public static Observable<T> IgnoreElements<T>(this Observable<T> source, Action<T> doOnNext)
		{
			return new IgnoreElements<T>(source, doOnNext);
		}

		public static Observable<T> IgnoreOnErrorResume<T>(this Observable<T> source)
		{
			return new IgnoreOnErrorResume<T>(source, null);
		}

		public static Observable<T> IgnoreOnErrorResume<T>(this Observable<T> source, Action<Exception>? doOnErrorResume)
		{
			return new IgnoreOnErrorResume<T>(source, doOnErrorResume);
		}

		public static Observable<int> Index(this Observable<Unit> source)
		{
			return new IndexObservable(source);
		}

		public static Observable<(int Index, T Item)> Index<T>(this Observable<T> source)
		{
			return new IndexObservable<T>(source);
		}

		public static Observable<Notification<T>> Materialize<T>(this Observable<T> source)
		{
			return new Materialize<T>(source);
		}

		public static Observable<T> Dematerialize<T>(this Observable<Notification<T>> source)
		{
			return new Dematerialize<T>(source);
		}

		public static Task<T> MaxAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			MaxAsync<T> maxAsync = new MaxAsync<T>(Comparer<T>.Default, cancellationToken);
			source.Subscribe(maxAsync);
			return maxAsync.Task;
		}

		public static Task<T> MaxAsync<T>(this Observable<T> source, IComparer<T> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MaxAsync<T> maxAsync = new MaxAsync<T>(comparer, cancellationToken);
			source.Subscribe(maxAsync);
			return maxAsync.Task;
		}

		public static Task<TResult> MaxAsync<TSource, TResult>(this Observable<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			MaxAsync<TSource, TResult> maxAsync = new MaxAsync<TSource, TResult>(selector, Comparer<TResult>.Default, cancellationToken);
			source.Subscribe(maxAsync);
			return maxAsync.Task;
		}

		public static Task<TResult> MaxAsync<TSource, TResult>(this Observable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MaxAsync<TSource, TResult> maxAsync = new MaxAsync<TSource, TResult>(selector, comparer, cancellationToken);
			source.Subscribe(maxAsync);
			return maxAsync.Task;
		}

		public static Task<T> MaxByAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.MaxByAsync(keySelector, Comparer<TKey>.Default, cancellationToken);
		}

		public static Task<T> MaxByAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MaxByAsync<T, TKey> maxByAsync = new MaxByAsync<T, TKey>(keySelector, comparer, cancellationToken);
			source.Subscribe(maxByAsync);
			return maxByAsync.Task;
		}

		public static Task<T> MinByAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.MinByAsync(keySelector, Comparer<TKey>.Default, cancellationToken);
		}

		public static Task<T> MinByAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, IComparer<TKey> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MinByAsync<T, TKey> minByAsync = new MinByAsync<T, TKey>(keySelector, comparer, cancellationToken);
			source.Subscribe(minByAsync);
			return minByAsync.Task;
		}

		public static Task<T> MinAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			MinAsync<T> minAsync = new MinAsync<T>(Comparer<T>.Default, cancellationToken);
			source.Subscribe(minAsync);
			return minAsync.Task;
		}

		public static Task<T> MinAsync<T>(this Observable<T> source, IComparer<T> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MinAsync<T> minAsync = new MinAsync<T>(comparer, cancellationToken);
			source.Subscribe(minAsync);
			return minAsync.Task;
		}

		public static Task<TResult> MinAsync<TSource, TResult>(this Observable<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			MinAsync<TSource, TResult> minAsync = new MinAsync<TSource, TResult>(selector, Comparer<TResult>.Default, cancellationToken);
			source.Subscribe(minAsync);
			return minAsync.Task;
		}

		public static Task<TResult> MinAsync<TSource, TResult>(this Observable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MinAsync<TSource, TResult> minAsync = new MinAsync<TSource, TResult>(selector, comparer, cancellationToken);
			source.Subscribe(minAsync);
			return minAsync.Task;
		}

		public static Task<(T Min, T Max)> MinMaxAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.MinMaxAsync(Comparer<T>.Default, cancellationToken);
		}

		public static Task<(T Min, T Max)> MinMaxAsync<T>(this Observable<T> source, IComparer<T> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MinMaxAsync<T> minMaxAsync = new MinMaxAsync<T>(comparer, cancellationToken);
			source.Subscribe(minMaxAsync);
			return minMaxAsync.Task;
		}

		public static Task<(TResult Min, TResult Max)> MinMaxAsync<TSource, TResult>(this Observable<TSource> source, Func<TSource, TResult> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.MinMaxAsync(selector, Comparer<TResult>.Default, cancellationToken);
		}

		public static Task<(TResult Min, TResult Max)> MinMaxAsync<TSource, TResult>(this Observable<TSource> source, Func<TSource, TResult> selector, IComparer<TResult> comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			MinMaxAsync<TSource, TResult> minMaxAsync = new MinMaxAsync<TSource, TResult>(selector, comparer, cancellationToken);
			source.Subscribe(minMaxAsync);
			return minMaxAsync.Task;
		}

		public static ConnectableObservable<T> Multicast<T>(this Observable<T> source, ISubject<T> subject)
		{
			return new Multicast<T>(source, subject);
		}

		public static ConnectableObservable<T> Publish<T>(this Observable<T> source)
		{
			return source.Multicast(new Subject<T>());
		}

		public static ConnectableObservable<T> Publish<T>(this Observable<T> source, T initialValue)
		{
			return source.Multicast(new BehaviorSubject<T>(initialValue));
		}

		public static ConnectableObservable<T> Replay<T>(this Observable<T> source)
		{
			return source.Multicast(new ReplaySubject<T>());
		}

		public static ConnectableObservable<T> Replay<T>(this Observable<T> source, int bufferSize)
		{
			return source.Multicast(new ReplaySubject<T>(bufferSize));
		}

		public static ConnectableObservable<T> Replay<T>(this Observable<T> source, TimeSpan window)
		{
			return source.Multicast(new ReplaySubject<T>(window));
		}

		public static ConnectableObservable<T> Replay<T>(this Observable<T> source, TimeSpan window, TimeProvider timeProvider)
		{
			return source.Multicast(new ReplaySubject<T>(window, timeProvider));
		}

		public static ConnectableObservable<T> Replay<T>(this Observable<T> source, int bufferSize, TimeSpan window)
		{
			return source.Multicast(new ReplaySubject<T>(bufferSize, window));
		}

		public static ConnectableObservable<T> Replay<T>(this Observable<T> source, int bufferSize, TimeSpan window, TimeProvider timeProvider)
		{
			return source.Multicast(new ReplaySubject<T>(bufferSize, window, timeProvider));
		}

		public static ConnectableObservable<T> ReplayFrame<T>(this Observable<T> source, int window)
		{
			return source.Multicast(new ReplayFrameSubject<T>(window));
		}

		public static ConnectableObservable<T> ReplayFrame<T>(this Observable<T> source, int window, FrameProvider frameProvider)
		{
			return source.Multicast(new ReplayFrameSubject<T>(window, frameProvider));
		}

		public static ConnectableObservable<T> ReplayFrame<T>(this Observable<T> source, int bufferSize, int window)
		{
			return source.Multicast(new ReplayFrameSubject<T>(bufferSize, window));
		}

		public static ConnectableObservable<T> ReplayFrame<T>(this Observable<T> source, int bufferSize, int window, FrameProvider frameProvider)
		{
			return source.Multicast(new ReplayFrameSubject<T>(bufferSize, window, frameProvider));
		}

		public static Observable<T> Share<T>(this Observable<T> source)
		{
			return source.Publish().RefCount();
		}

		public static Observable<T> ObserveOnCurrentSynchronizationContext<T>(this Observable<T> source)
		{
			return source.ObserveOn(SynchronizationContext.Current);
		}

		public static Observable<T> ObserveOnThreadPool<T>(this Observable<T> source)
		{
			return new ObserveOnThreadPool<T>(source);
		}

		public static Observable<T> ObserveOn<T>(this Observable<T> source, SynchronizationContext? synchronizationContext)
		{
			if (synchronizationContext == null)
			{
				return new ObserveOnThreadPool<T>(source);
			}
			return new ObserveOnSynchronizationContext<T>(source, synchronizationContext);
		}

		public static Observable<T> ObserveOn<T>(this Observable<T> source, TimeProvider timeProvider)
		{
			if (timeProvider == TimeProvider.System)
			{
				return new ObserveOnThreadPool<T>(source);
			}
			return new ObserveOnTimeProvider<T>(source, timeProvider);
		}

		public static Observable<T> ObserveOn<T>(this Observable<T> source, FrameProvider frameProvider)
		{
			return new ObserveOnFrameProvider<T>(source, frameProvider);
		}

		public static Observable<TResult> OfType<T, TResult>(this Observable<T> source)
		{
			return new OfType<T, TResult>(source);
		}

		public static Observable<T> OnErrorResumeAsFailure<T>(this Observable<T> source)
		{
			return new OnErrorResumeAsFailure<T>(source);
		}

		public static Observable<(T Previous, T Current)> Pairwise<T>(this Observable<T> source)
		{
			return new Pairwise<T>(source);
		}

		public static Observable<T> RefCount<T>(this ConnectableObservable<T> source)
		{
			return new RefCount<T>(source);
		}

		public static Observable<TSource> Scan<TSource>(this Observable<TSource> source, Func<TSource, TSource, TSource> accumulator)
		{
			return new Scan<TSource>(source, accumulator);
		}

		public static Observable<TAccumulate> Scan<TSource, TAccumulate>(this Observable<TSource> source, TAccumulate seed, Func<TAccumulate, TSource, TAccumulate> accumulator)
		{
			return new Scan<TSource, TAccumulate>(source, seed, accumulator);
		}

		public static Observable<TResult> Select<T, TResult>(this Observable<T> source, Func<T, TResult> selector)
		{
			if (source is Where<T> obj)
			{
				return new WhereSelect<T, TResult>(obj.source, selector, obj.predicate);
			}
			return new Select<T, TResult>(source, selector);
		}

		public static Observable<TResult> Select<T, TResult>(this Observable<T> source, Func<T, int, TResult> selector)
		{
			return new SelectIndexed<T, TResult>(source, selector);
		}

		public static Observable<TResult> Select<T, TResult, TState>(this Observable<T> source, TState state, Func<T, TState, TResult> selector)
		{
			return new Select<T, TResult, TState>(source, selector, state);
		}

		public static Observable<TResult> Select<T, TResult, TState>(this Observable<T> source, TState state, Func<T, int, TState, TResult> selector)
		{
			return new SelectIndexed<T, TResult, TState>(source, selector, state);
		}

		public static Observable<TResult> SelectAwait<T, TResult>(this Observable<T> source, Func<T, CancellationToken, ValueTask<TResult>> selector, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			return new SelectAwait<T, TResult>(source, selector, awaitOperation, configureAwait, cancelOnCompleted, maxConcurrent);
		}

		public static Observable<TResult> SelectMany<TSource, TResult>(this Observable<TSource> source, Func<TSource, Observable<TResult>> selector)
		{
			return source.SelectMany(selector, (TSource sourceValue, TResult collectionValue) => collectionValue);
		}

		public static Observable<TResult> SelectMany<TSource, TCollection, TResult>(this Observable<TSource> source, Func<TSource, Observable<TCollection>> collectionSelector, Func<TSource, TCollection, TResult> resultSelector)
		{
			return new SelectMany<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
		}

		public static Observable<TResult> SelectMany<TSource, TResult>(this Observable<TSource> source, Func<TSource, int, Observable<TResult>> selector)
		{
			return source.SelectMany(selector, (TSource sourceValue, int sourceIndex, TResult collectionValue, int collectionIndex) => collectionValue);
		}

		public static Observable<TResult> SelectMany<TSource, TCollection, TResult>(this Observable<TSource> source, Func<TSource, int, Observable<TCollection>> collectionSelector, Func<TSource, int, TCollection, int, TResult> resultSelector)
		{
			return new SelectManyIndexed<TSource, TCollection, TResult>(source, collectionSelector, resultSelector);
		}

		public static Task<bool> SequenceEqualAsync<T>(this Observable<T> source, Observable<T> second, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.SequenceEqualAsync(second, EqualityComparer<T>.Default, cancellationToken);
		}

		public static Task<bool> SequenceEqualAsync<T>(this Observable<T> source, Observable<T> second, IEqualityComparer<T> equalityComparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			SequenceEqualAsync<T> sequenceEqualAsync = new SequenceEqualAsync<T>(equalityComparer, cancellationToken);
			try
			{
				source.Subscribe(sequenceEqualAsync.leftObserver);
				second.Subscribe(sequenceEqualAsync.rightObserver);
			}
			catch
			{
				sequenceEqualAsync.Dispose();
				throw;
			}
			return sequenceEqualAsync.Task;
		}

		public static Observable<T> Skip<T>(this Observable<T> source, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return new Skip<T>(source, count);
		}

		public static Observable<T> Skip<T>(this Observable<T> source, TimeSpan duration)
		{
			return source.Skip(duration, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> Skip<T>(this Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			return new SkipTime<T>(source, duration.Normalize(), timeProvider);
		}

		public static Observable<T> SkipFrame<T>(this Observable<T> source, int frameCount)
		{
			return source.SkipFrame(frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> SkipFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new SkipFrame<T>(source, frameCount.NormalizeFrame(), frameProvider);
		}

		public static Observable<T> SkipLast<T>(this Observable<T> source, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return new SkipLast<T>(source, count);
		}

		public static Observable<T> SkipLast<T>(this Observable<T> source, TimeSpan duration)
		{
			return source.SkipLast(duration, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> SkipLast<T>(this Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			return new SkipLastTime<T>(source, duration.Normalize(), timeProvider);
		}

		public static Observable<T> SkipLastFrame<T>(this Observable<T> source, int frameCount)
		{
			return source.SkipLastFrame(frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> SkipLastFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new SkipLastFrame<T>(source, frameCount.NormalizeFrame(), frameProvider);
		}

		public static Observable<T> SkipUntil<T, TOther>(this Observable<T> source, Observable<TOther> other)
		{
			return new SkipUntil<T, TOther>(source, other);
		}

		public static Observable<T> SkipUntil<T>(this Observable<T> source, CancellationToken cancellationToken)
		{
			if (!cancellationToken.CanBeCanceled)
			{
				throw new ArgumentException("cancellationToken must be cancellable", "cancellationToken");
			}
			return new SkipUntilC<T>(source, cancellationToken);
		}

		public static Observable<T> SkipUntil<T>(this Observable<T> source, Task task, bool configureAwait = true)
		{
			return new SkipUntilT<T>(source, task, configureAwait);
		}

		public static Observable<T> SkipUntil<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> asyncFunc, bool configureAwait = true)
		{
			return new SkipUntilAsync<T>(source, asyncFunc, configureAwait);
		}

		public static Observable<T> SkipWhile<T>(this Observable<T> source, Func<T, bool> predicate)
		{
			return new SkipWhile<T>(source, predicate);
		}

		public static Observable<T> SkipWhile<T>(this Observable<T> source, Func<T, int, bool> predicate)
		{
			return new SkipWhileI<T>(source, predicate);
		}

		public static IDisposable SubscribeAwait<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> onNextAsync, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			return source.SubscribeAwait(onNextAsync, ObservableSystem.GetUnhandledExceptionHandler(), Stubs.HandleResult, awaitOperation, configureAwait, cancelOnCompleted, maxConcurrent);
		}

		public static IDisposable SubscribeAwait<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> onNextAsync, Action<Result> onCompleted, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			return source.SubscribeAwait(onNextAsync, ObservableSystem.GetUnhandledExceptionHandler(), onCompleted, awaitOperation, configureAwait, cancelOnCompleted, maxConcurrent);
		}

		public static IDisposable SubscribeAwait<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> onNextAsync, Action<Exception> onErrorResume, Action<Result> onCompleted, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			switch (awaitOperation)
			{
			case AwaitOperation.Sequential:
				return source.Subscribe(new SubscribeAwaitSequential<T>(onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			case AwaitOperation.Drop:
				return source.Subscribe(new SubscribeAwaitDrop<T>(onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			case AwaitOperation.Parallel:
				if (maxConcurrent == -1)
				{
					return source.Subscribe(new SubscribeAwaitParallel<T>(onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
				}
				if (maxConcurrent == 0 || maxConcurrent < -1)
				{
					throw new ArgumentException("maxConcurrent must be a -1 or greater than 1.");
				}
				return source.Subscribe(new SubscribeAwaitParallelConcurrentLimit<T>(onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted, maxConcurrent));
			case AwaitOperation.Switch:
				return source.Subscribe(new SubscribeAwaitSwitch<T>(onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			case AwaitOperation.SequentialParallel:
				throw new ArgumentException("SubscribeAwait does not support SequentialParallel. Use Sequential for sequential operation, use parallel for parallel operation instead.");
			case AwaitOperation.ThrottleFirstLast:
				return source.Subscribe(new SubscribeAwaitThrottleFirstLast<T>(onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			default:
				throw new ArgumentException();
			}
		}

		public static IDisposable SubscribeAwait<T, TState>(this Observable<T> source, TState state, Func<T, TState, CancellationToken, ValueTask> onNextAsync, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			return source.SubscribeAwait(state, onNextAsync, Stubs<TState>.HandleException, Stubs<TState>.HandleResult, awaitOperation, configureAwait, cancelOnCompleted, maxConcurrent);
		}

		public static IDisposable SubscribeAwait<T, TState>(this Observable<T> source, TState state, Func<T, TState, CancellationToken, ValueTask> onNextAsync, Action<Result, TState> onCompleted, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			return source.SubscribeAwait(state, onNextAsync, Stubs<TState>.HandleException, onCompleted, awaitOperation, configureAwait, cancelOnCompleted, maxConcurrent);
		}

		public static IDisposable SubscribeAwait<T, TState>(this Observable<T> source, TState state, Func<T, TState, CancellationToken, ValueTask> onNextAsync, Action<Exception, TState> onErrorResume, Action<Result, TState> onCompleted, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			switch (awaitOperation)
			{
			case AwaitOperation.Sequential:
				return source.Subscribe(new SubscribeAwaitSequential<T, TState>(state, onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			case AwaitOperation.Drop:
				return source.Subscribe(new SubscribeAwaitDrop<T, TState>(state, onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			case AwaitOperation.Parallel:
				if (maxConcurrent == -1)
				{
					return source.Subscribe(new SubscribeAwaitParallel<T, TState>(state, onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
				}
				if (maxConcurrent == 0 || maxConcurrent < -1)
				{
					throw new ArgumentException("maxConcurrent must be a -1 or greater than 1.");
				}
				return source.Subscribe(new SubscribeAwaitParallelConcurrentLimit<T, TState>(state, onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted, maxConcurrent));
			case AwaitOperation.Switch:
				return source.Subscribe(new SubscribeAwaitSwitch<T, TState>(state, onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			case AwaitOperation.SequentialParallel:
				throw new ArgumentException("SubscribeAwait does not support SequentialParallel. Use Sequential for sequential operation, use parallel for parallel operation instead.");
			case AwaitOperation.ThrottleFirstLast:
				return source.Subscribe(new SubscribeAwaitThrottleFirstLast<T, TState>(state, onNextAsync, onErrorResume, onCompleted, configureAwait, cancelOnCompleted));
			default:
				throw new ArgumentException();
			}
		}

		public static Observable<T> SubscribeOnCurrentSynchronizationContext<T>(this Observable<T> source)
		{
			return source.SubscribeOn(SynchronizationContext.Current);
		}

		public static Observable<T> SubscribeOnThreadPool<T>(this Observable<T> source)
		{
			return new SubscribeOnThreadPool<T>(source);
		}

		public static Observable<T> SubscribeOnSynchronize<T>(this Observable<T> source, object gate, bool rawObserver = false)
		{
			return new SubscribeOnSynchronize<T>(source, gate, rawObserver);
		}

		public static Observable<T> SubscribeOn<T>(this Observable<T> source, SynchronizationContext? synchronizationContext)
		{
			if (synchronizationContext == null)
			{
				return new SubscribeOnThreadPool<T>(source);
			}
			return new SubscribeOnSynchronizationContext<T>(source, synchronizationContext);
		}

		public static Observable<T> SubscribeOn<T>(this Observable<T> source, TimeProvider timeProvider)
		{
			if (timeProvider == TimeProvider.System)
			{
				return new SubscribeOnThreadPool<T>(source);
			}
			return new SubscribeOnTimeProvider<T>(source, timeProvider);
		}

		public static Observable<T> SubscribeOn<T>(this Observable<T> source, FrameProvider frameProvider)
		{
			return new SubscribeOnFrameProvider<T>(source, frameProvider);
		}

		public static Task<int> SumAsync(this Observable<int> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumInt32Async sumInt32Async = new SumInt32Async(cancellationToken);
			source.Subscribe(sumInt32Async);
			return sumInt32Async.Task;
		}

		public static Task<int> SumAsync<TSource>(this Observable<TSource> source, Func<TSource, int> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumInt32Async<TSource> sumInt32Async = new SumInt32Async<TSource>(selector, cancellationToken);
			source.Subscribe(sumInt32Async);
			return sumInt32Async.Task;
		}

		public static Task<long> SumAsync(this Observable<long> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumInt64Async sumInt64Async = new SumInt64Async(cancellationToken);
			source.Subscribe(sumInt64Async);
			return sumInt64Async.Task;
		}

		public static Task<long> SumAsync<TSource>(this Observable<TSource> source, Func<TSource, long> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumInt64Async<TSource> sumInt64Async = new SumInt64Async<TSource>(selector, cancellationToken);
			source.Subscribe(sumInt64Async);
			return sumInt64Async.Task;
		}

		public static Task<float> SumAsync(this Observable<float> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumFloatAsync sumFloatAsync = new SumFloatAsync(cancellationToken);
			source.Subscribe(sumFloatAsync);
			return sumFloatAsync.Task;
		}

		public static Task<float> SumAsync<TSource>(this Observable<TSource> source, Func<TSource, float> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumFloatAsync<TSource> sumFloatAsync = new SumFloatAsync<TSource>(selector, cancellationToken);
			source.Subscribe(sumFloatAsync);
			return sumFloatAsync.Task;
		}

		public static Task<double> SumAsync(this Observable<double> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumDoubleAsync sumDoubleAsync = new SumDoubleAsync(cancellationToken);
			source.Subscribe(sumDoubleAsync);
			return sumDoubleAsync.Task;
		}

		public static Task<double> SumAsync<TSource>(this Observable<TSource> source, Func<TSource, double> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumDoubleAsync<TSource> sumDoubleAsync = new SumDoubleAsync<TSource>(selector, cancellationToken);
			source.Subscribe(sumDoubleAsync);
			return sumDoubleAsync.Task;
		}

		public static Task<decimal> SumAsync(this Observable<decimal> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumDecimalAsync sumDecimalAsync = new SumDecimalAsync(cancellationToken);
			source.Subscribe(sumDecimalAsync);
			return sumDecimalAsync.Task;
		}

		public static Task<decimal> SumAsync<TSource>(this Observable<TSource> source, Func<TSource, decimal> selector, CancellationToken cancellationToken = default(CancellationToken))
		{
			SumDecimalAsync<TSource> sumDecimalAsync = new SumDecimalAsync<TSource>(selector, cancellationToken);
			source.Subscribe(sumDecimalAsync);
			return sumDecimalAsync.Task;
		}

		public static Observable<T> Switch<T>(this Observable<Observable<T>> sources)
		{
			return new Switch<T>(sources);
		}

		public static Observable<T> Synchronize<T>(this Observable<T> source)
		{
			return new Synchronize<T>(source, new object());
		}

		public static Observable<T> Synchronize<T>(this Observable<T> source, object gate)
		{
			return new Synchronize<T>(source, gate);
		}

		public static Observable<T> Take<T>(this Observable<T> source, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			if (count == 0)
			{
				return Observable.Empty<T>();
			}
			return new Take<T>(source, count);
		}

		public static Observable<T> Take<T>(this Observable<T> source, TimeSpan duration)
		{
			return source.Take(duration, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> Take<T>(this Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			return new TakeTime<T>(source, duration.Normalize(), timeProvider);
		}

		public static Observable<T> TakeFrame<T>(this Observable<T> source, int frameCount)
		{
			return source.TakeFrame(frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> TakeFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new TakeFrame<T>(source, frameCount.NormalizeFrame(), frameProvider);
		}

		public static Observable<T> TakeLast<T>(this Observable<T> source, int count)
		{
			if (count < 0)
			{
				throw new ArgumentOutOfRangeException("count");
			}
			return new TakeLast<T>(source, count);
		}

		public static Observable<T> TakeLast<T>(this Observable<T> source, TimeSpan duration)
		{
			return source.TakeLast(duration, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> TakeLast<T>(this Observable<T> source, TimeSpan duration, TimeProvider timeProvider)
		{
			return new TakeLastTime<T>(source, duration.Normalize(), timeProvider);
		}

		public static Observable<T> TakeLastFrame<T>(this Observable<T> source, int frameCount)
		{
			return source.TakeLastFrame(frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> TakeLastFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new TakeLastFrame<T>(source, frameCount.NormalizeFrame(), frameProvider);
		}

		public static Observable<T> TakeUntil<T, TOther>(this Observable<T> source, Observable<TOther> other)
		{
			return new TakeUntil<T, TOther>(source, other);
		}

		public static Observable<T> TakeUntil<T>(this Observable<T> source, CancellationToken cancellationToken)
		{
			if (!cancellationToken.CanBeCanceled)
			{
				return source;
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Observable.Empty<T>();
			}
			return new TakeUntilC<T>(source, cancellationToken);
		}

		public static Observable<T> TakeUntil<T>(this Observable<T> source, Task task, bool configureAwait = true)
		{
			return new TakeUntilT<T>(source, task, configureAwait);
		}

		public static Observable<T> TakeUntil<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> asyncFunc, bool configureAwait = true)
		{
			return new TakeUntilAsync<T>(source, asyncFunc, configureAwait);
		}

		public static Observable<T> TakeUntil<T>(this Observable<T> source, Func<T, bool> predicate)
		{
			return new TakeUntil<T>(source, predicate);
		}

		public static Observable<T> TakeUntil<T>(this Observable<T> source, Func<T, int, bool> predicate)
		{
			return new TakeUntilI<T>(source, predicate);
		}

		public static Observable<T> TakeWhile<T>(this Observable<T> source, Func<T, bool> predicate)
		{
			return new TakeWhile<T>(source, predicate);
		}

		public static Observable<T> TakeWhile<T>(this Observable<T> source, Func<T, int, bool> predicate)
		{
			return new TakeWhileI<T>(source, predicate);
		}

		public static Observable<T> ThrottleFirst<T>(this Observable<T> source, TimeSpan timeSpan)
		{
			return new ThrottleFirst<T>(source, timeSpan, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> ThrottleFirst<T>(this Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			return new ThrottleFirst<T>(source, timeSpan, timeProvider);
		}

		public static Observable<T> ThrottleFirst<T, TSample>(this Observable<T> source, Observable<TSample> sampler)
		{
			return new ThrottleFirstObservableSampler<T, TSample>(source, sampler);
		}

		public static Observable<T> ThrottleFirst<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> sampler, bool configureAwait = true)
		{
			return new ThrottleFirstAsyncSampler<T>(source, sampler, configureAwait);
		}

		public static Observable<T> ThrottleFirstFrame<T>(this Observable<T> source, int frameCount)
		{
			return new ThrottleFirstFrame<T>(source, frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> ThrottleFirstFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new ThrottleFirstFrame<T>(source, frameCount, frameProvider);
		}

		public static Observable<T> ThrottleFirstLast<T>(this Observable<T> source, TimeSpan timeSpan)
		{
			return new ThrottleFirstLast<T>(source, timeSpan, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> ThrottleFirstLast<T>(this Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			return new ThrottleFirstLast<T>(source, timeSpan, timeProvider);
		}

		public static Observable<T> ThrottleFirstLast<T, TSample>(this Observable<T> source, Observable<TSample> sampler)
		{
			return new ThrottleFirstLastObservableSampler<T, TSample>(source, sampler);
		}

		public static Observable<T> ThrottleFirstLast<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> sampler, bool configureAwait = true)
		{
			return new ThrottleFirstLastAsyncSampler<T>(source, sampler, configureAwait);
		}

		public static Observable<T> ThrottleFirstLastFrame<T>(this Observable<T> source, int frameCount)
		{
			return new ThrottleFirstLastFrame<T>(source, frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> ThrottleFirstLastFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new ThrottleFirstLastFrame<T>(source, frameCount, frameProvider);
		}

		public static Observable<T> ThrottleLast<T>(this Observable<T> source, TimeSpan timeSpan)
		{
			return new ThrottleLast<T>(source, timeSpan, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> ThrottleLast<T>(this Observable<T> source, TimeSpan timeSpan, TimeProvider timeProvider)
		{
			return new ThrottleLast<T>(source, timeSpan, timeProvider);
		}

		public static Observable<T> ThrottleLast<T, TSample>(this Observable<T> source, Observable<TSample> sampler)
		{
			return new ThrottleLastObservableSampler<T, TSample>(source, sampler);
		}

		public static Observable<T> ThrottleLast<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask> sampler, bool configureAwait = true)
		{
			return new ThrottleLastAsyncSampler<T>(source, sampler, configureAwait);
		}

		public static Observable<T> ThrottleLastFrame<T>(this Observable<T> source, int frameCount)
		{
			return new ThrottleLastFrame<T>(source, frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> ThrottleLastFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new ThrottleLastFrame<T>(source, frameCount, frameProvider);
		}

		public static Observable<(TimeSpan Interval, T Value)> TimeInterval<T>(this Observable<T> source)
		{
			return new TimeInterval<T>(source, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<(TimeSpan Interval, T Value)> TimeInterval<T>(this Observable<T> source, TimeProvider timeProvider)
		{
			return new TimeInterval<T>(source, timeProvider);
		}

		public static Observable<T> Timeout<T>(this Observable<T> source, TimeSpan dueTime)
		{
			return new Timeout<T>(source, dueTime, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<T> Timeout<T>(this Observable<T> source, TimeSpan dueTime, TimeProvider timeProvider)
		{
			return new Timeout<T>(source, dueTime, timeProvider);
		}

		public static Observable<T> TimeoutFrame<T>(this Observable<T> source, int frameCount)
		{
			return new TimeoutFrame<T>(source, frameCount, ObservableSystem.DefaultFrameProvider);
		}

		public static Observable<T> TimeoutFrame<T>(this Observable<T> source, int frameCount, FrameProvider frameProvider)
		{
			return new TimeoutFrame<T>(source, frameCount, frameProvider);
		}

		public static Observable<(long Timestamp, T Value)> Timestamp<T>(this Observable<T> source)
		{
			return new Timestamp<T>(source, ObservableSystem.DefaultTimeProvider);
		}

		public static Observable<(long Timestamp, T Value)> Timestamp<T>(this Observable<T> source, TimeProvider timeProvider)
		{
			return new Timestamp<T>(source, timeProvider);
		}

		public static Task<T[]> ToArrayAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			ToArrayAsync<T> toArrayAsync = new ToArrayAsync<T>(cancellationToken);
			source.Subscribe(toArrayAsync);
			return toArrayAsync.Task;
		}

		public static IAsyncEnumerable<T> ToAsyncEnumerable<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			Channel<T> channel = ChannelUtility.CreateSingleReadeWriterUnbounded<T>();
			ToAsyncEnumerable<T> toAsyncEnumerable = new ToAsyncEnumerable<T>(channel.Writer);
			IDisposable state = source.Subscribe(toAsyncEnumerable);
			if (cancellationToken.CanBeCanceled)
			{
				toAsyncEnumerable.registration = cancellationToken.UnsafeRegister(delegate(object? obj)
				{
					((IDisposable)obj).Dispose();
				}, state);
			}
			return channel.Reader.ReadAllAsync(cancellationToken);
		}

		public static Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			return source.ToDictionaryAsync(keySelector, null, cancellationToken);
		}

		public static Task<Dictionary<TKey, T>> ToDictionaryAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			ToDictionaryAsync<T, TKey> toDictionaryAsync = new ToDictionaryAsync<T, TKey>(keySelector, keyComparer, cancellationToken);
			source.Subscribe(toDictionaryAsync);
			return toDictionaryAsync.Task;
		}

		public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(this Observable<T> source, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			return source.ToDictionaryAsync(keySelector, elementSelector, null, cancellationToken);
		}

		public static Task<Dictionary<TKey, TElement>> ToDictionaryAsync<T, TKey, TElement>(this Observable<T> source, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			ToDictionaryAsync<T, TKey, TElement> toDictionaryAsync = new ToDictionaryAsync<T, TKey, TElement>(keySelector, elementSelector, keyComparer, cancellationToken);
			source.Subscribe(toDictionaryAsync);
			return toDictionaryAsync.Task;
		}

		public static Task<HashSet<T>> ToHashSetAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			return source.ToHashSetAsync(null, cancellationToken);
		}

		public static Task<HashSet<T>> ToHashSetAsync<T>(this Observable<T> source, IEqualityComparer<T>? comparer, CancellationToken cancellationToken = default(CancellationToken))
		{
			ToHashSetAsync<T> toHashSetAsync = new ToHashSetAsync<T>(comparer, cancellationToken);
			source.Subscribe(toHashSetAsync);
			return toHashSetAsync.Task;
		}

		public static Task<List<T>> ToListAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			ToListAsync<T> toListAsync = new ToListAsync<T>(cancellationToken);
			source.Subscribe(toListAsync);
			return toListAsync.Task;
		}

		public static Task<ILookup<TKey, T>> ToLookupAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			return source.ToLookupAsync(keySelector, null, cancellationToken);
		}

		public static Task<ILookup<TKey, T>> ToLookupAsync<T, TKey>(this Observable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			ToLookupAsync<T, TKey> toLookupAsync = new ToLookupAsync<T, TKey>(keySelector, keyComparer, cancellationToken);
			source.Subscribe(toLookupAsync);
			return toLookupAsync.Task;
		}

		public static Task<ILookup<TKey, TElement>> ToLookupAsync<T, TKey, TElement>(this Observable<T> source, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			return source.ToLookupAsync(keySelector, elementSelector, null, cancellationToken);
		}

		public static Task<ILookup<TKey, TElement>> ToLookupAsync<T, TKey, TElement>(this Observable<T> source, Func<T, TKey> keySelector, Func<T, TElement> elementSelector, IEqualityComparer<TKey>? keyComparer, CancellationToken cancellationToken = default(CancellationToken)) where TKey : notnull
		{
			ToLookupAsync<T, TKey, TElement> toLookupAsync = new ToLookupAsync<T, TKey, TElement>(keySelector, elementSelector, keyComparer, cancellationToken);
			source.Subscribe(toLookupAsync);
			return toLookupAsync.Task;
		}

		public static Observable<T> Trampoline<T>(this Observable<T> source)
		{
			return new Trampoline<T>(source);
		}

		public static Task WaitAsync<T>(this Observable<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			WaitAsync<T> waitAsync = new WaitAsync<T>(cancellationToken);
			source.Subscribe(waitAsync);
			return waitAsync.Task;
		}

		public static Observable<T> Where<T>(this Observable<T> source, Func<T, bool> predicate)
		{
			if (source is Where<T> obj)
			{
				Func<T, bool> p = obj.predicate;
				return new Where<T>(obj.source, (T x) => p(x) && predicate(x));
			}
			return new Where<T>(source, predicate);
		}

		public static Observable<T> Where<T>(this Observable<T> source, Func<T, int, bool> predicate)
		{
			return new WhereIndexed<T>(source, predicate);
		}

		public static Observable<T> Where<T, TState>(this Observable<T> source, TState state, Func<T, TState, bool> predicate)
		{
			return new Where<T, TState>(source, predicate, state);
		}

		public static Observable<T> Where<T, TState>(this Observable<T> source, TState state, Func<T, int, TState, bool> predicate)
		{
			return new WhereIndexed<T, TState>(source, predicate, state);
		}

		public static Observable<T> WhereAwait<T>(this Observable<T> source, Func<T, CancellationToken, ValueTask<bool>> predicate, AwaitOperation awaitOperation = AwaitOperation.Sequential, bool configureAwait = true, bool cancelOnCompleted = false, int maxConcurrent = -1)
		{
			return new WhereAwait<T>(source, predicate, awaitOperation, configureAwait, cancelOnCompleted, maxConcurrent);
		}

		public static Observable<TResult> WhereNotNull<TResult>(this Observable<TResult?> source) where TResult : class
		{
			return new WhereSelect<TResult, TResult>(source, (TResult? item) => item, (TResult? item) => item != null);
		}

		public static Observable<TResult> WithLatestFrom<TFirst, TSecond, TResult>(this Observable<TFirst> first, Observable<TSecond> second, Func<TFirst, TSecond, TResult> resultSelector)
		{
			return new WithLatestFrom<TFirst, TSecond, TResult>(first, second, resultSelector);
		}
	}
}
