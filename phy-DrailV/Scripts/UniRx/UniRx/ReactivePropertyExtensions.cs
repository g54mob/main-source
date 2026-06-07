using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UniRx.InternalUtil;

namespace UniRx
{
	public static class ReactivePropertyExtensions
	{
		private static readonly Action<object> Callback = CancelCallback;

		public static IReadOnlyReactiveProperty<T> ToReactiveProperty<T>(this IObservable<T> source)
		{
			return new ReadOnlyReactiveProperty<T>(source);
		}

		public static IReadOnlyReactiveProperty<T> ToReactiveProperty<T>(this IObservable<T> source, T initialValue)
		{
			return new ReadOnlyReactiveProperty<T>(source, initialValue);
		}

		public static ReadOnlyReactiveProperty<T> ToReadOnlyReactiveProperty<T>(this IObservable<T> source)
		{
			return new ReadOnlyReactiveProperty<T>(source);
		}

		private static void CancelCallback(object state)
		{
			Tuple<ICancellableTaskCompletionSource, IDisposable> obj = (Tuple<ICancellableTaskCompletionSource, IDisposable>)state;
			obj.Item2.Dispose();
			obj.Item1.TrySetCanceled();
		}

		public static Task<T> WaitUntilValueChangedAsync<T>(this IReadOnlyReactiveProperty<T> source, CancellationToken cancellationToken = default(CancellationToken))
		{
			CancellableTaskCompletionSource<T> tcs = new CancellableTaskCompletionSource<T>();
			SingleAssignmentDisposable disposable = new SingleAssignmentDisposable();
			if (source.HasValue)
			{
				bool isFirstValue = true;
				disposable.Disposable = source.Subscribe(delegate(T x)
				{
					if (isFirstValue)
					{
						isFirstValue = false;
					}
					else
					{
						disposable.Dispose();
						tcs.TrySetResult(x);
					}
				}, delegate(Exception ex)
				{
					tcs.TrySetException(ex);
				}, delegate
				{
					tcs.TrySetCanceled();
				});
			}
			else
			{
				disposable.Disposable = source.Subscribe(delegate(T x)
				{
					disposable.Dispose();
					tcs.TrySetResult(x);
				}, delegate(Exception ex)
				{
					tcs.TrySetException(ex);
				}, delegate
				{
					tcs.TrySetCanceled();
				});
			}
			cancellationToken.Register(Callback, Tuple.Create(tcs, disposable.Disposable), useSynchronizationContext: false);
			return tcs.Task;
		}

		public static TaskAwaiter<T> GetAwaiter<T>(this IReadOnlyReactiveProperty<T> source)
		{
			return source.WaitUntilValueChangedAsync(CancellationToken.None).GetAwaiter();
		}

		public static ReadOnlyReactiveProperty<T> ToSequentialReadOnlyReactiveProperty<T>(this IObservable<T> source)
		{
			return new ReadOnlyReactiveProperty<T>(source, distinctUntilChanged: false);
		}

		public static ReadOnlyReactiveProperty<T> ToReadOnlyReactiveProperty<T>(this IObservable<T> source, T initialValue)
		{
			return new ReadOnlyReactiveProperty<T>(source, initialValue);
		}

		public static ReadOnlyReactiveProperty<T> ToSequentialReadOnlyReactiveProperty<T>(this IObservable<T> source, T initialValue)
		{
			return new ReadOnlyReactiveProperty<T>(source, initialValue, distinctUntilChanged: false);
		}

		public static IObservable<T> SkipLatestValueOnSubscribe<T>(this IReadOnlyReactiveProperty<T> source)
		{
			if (!source.HasValue)
			{
				return source;
			}
			return source.Skip(1);
		}

		public static IObservable<bool> CombineLatestValuesAreAllTrue(this IEnumerable<IObservable<bool>> sources)
		{
			return sources.CombineLatest().Select(delegate(IList<bool> xs)
			{
				foreach (bool x in xs)
				{
					if (!x)
					{
						return false;
					}
				}
				return true;
			});
		}

		public static IObservable<bool> CombineLatestValuesAreAllFalse(this IEnumerable<IObservable<bool>> sources)
		{
			return sources.CombineLatest().Select(delegate(IList<bool> xs)
			{
				foreach (bool x in xs)
				{
					if (x)
					{
						return false;
					}
				}
				return true;
			});
		}
	}
}
