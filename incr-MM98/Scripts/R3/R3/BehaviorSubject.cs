using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using R3.Collections;

namespace R3
{
	public sealed class BehaviorSubject<T> : Observable<T>, ISubject<T>, IDisposable
	{
		private sealed class Subscription : IDisposable
		{
			public readonly Observer<T> observer;

			private readonly int removeKey;

			private BehaviorSubject<T>? parent;

			public Subscription(BehaviorSubject<T> parent, Observer<T> observer)
			{
				this.parent = parent;
				this.observer = observer;
				parent.list.Add(this, out removeKey);
			}

			public void Dispose()
			{
				Interlocked.Exchange(ref parent, null)?.list.Remove(removeKey);
			}
		}

		private FreeListCore<Subscription> list;

		private CompleteState completeState;

		private T latestValue;

		public bool IsDisposed => completeState.IsDisposed;

		public T Value
		{
			get
			{
				Result? result = completeState.TryGetResult();
				if (result.HasValue && result.Value.IsFailure)
				{
					ExceptionDispatchInfo.Capture(result.Value.Exception).Throw();
				}
				return latestValue;
			}
		}

		public BehaviorSubject(T initialValue)
		{
			list = new FreeListCore<Subscription>(this);
			latestValue = initialValue;
		}

		public void OnNext(T value)
		{
			if (completeState.IsCompleted)
			{
				return;
			}
			lock (this)
			{
				latestValue = value;
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnNext(value);
				}
			}
		}

		public void OnErrorResume(Exception error)
		{
			if (!completeState.IsCompleted)
			{
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnErrorResume(error);
				}
			}
		}

		public void OnCompleted(Result result)
		{
			if (completeState.TrySetResult(result) == CompleteState.ResultStatus.Done)
			{
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnCompleted(result);
				}
			}
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			lock (this)
			{
				Result? result = completeState.TryGetResult();
				if (result.HasValue)
				{
					observer.OnCompleted(result.Value);
					return Disposable.Empty;
				}
				observer.OnNext(latestValue);
				Subscription subscription = new Subscription(this, observer);
				result = completeState.TryGetResult();
				if (result.HasValue)
				{
					subscription.observer.OnCompleted(result.Value);
					subscription.Dispose();
					return Disposable.Empty;
				}
				return subscription;
			}
		}

		public void Dispose()
		{
			Dispose(callOnCompleted: true);
		}

		public void Dispose(bool callOnCompleted)
		{
			if (!completeState.TrySetDisposed(out var alreadyCompleted))
			{
				return;
			}
			if (callOnCompleted && !alreadyCompleted)
			{
				ReadOnlySpan<Subscription> readOnlySpan = list.AsSpan();
				for (int i = 0; i < readOnlySpan.Length; i++)
				{
					readOnlySpan[i]?.observer.OnCompleted();
				}
			}
			list.Dispose();
			lock (this)
			{
				latestValue = default(T);
			}
		}
	}
}
