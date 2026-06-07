using System;
using System.Threading;
using R3.Collections;
using R3.Internal;

namespace R3
{
	public sealed class ReplaySubject<T> : Observable<T>, ISubject<T>, IDisposable
	{
		private sealed class Subscription : IDisposable
		{
			public readonly Observer<T> observer;

			private readonly int removeKey;

			private ReplaySubject<T>? parent;

			public Subscription(ReplaySubject<T> parent, Observer<T> observer)
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

		private readonly int bufferSize;

		private readonly TimeSpan window;

		private readonly TimeProvider? timeProvider;

		private readonly RingBuffer<(long timestamp, T value)> replayBuffer;

		private FreeListCore<Subscription> list;

		private CompleteState completeState;

		public bool IsDisposed => completeState.IsDisposed;

		public ReplaySubject()
			: this(int.MaxValue, TimeSpan.MaxValue, (TimeProvider)null)
		{
		}

		public ReplaySubject(int bufferSize)
			: this(bufferSize, TimeSpan.MaxValue, (TimeProvider)null)
		{
		}

		public ReplaySubject(TimeSpan window)
			: this(int.MaxValue, window, ObservableSystem.DefaultTimeProvider)
		{
		}

		public ReplaySubject(TimeSpan window, TimeProvider timeProvider)
			: this(int.MaxValue, window, timeProvider)
		{
		}

		public ReplaySubject(int bufferSize, TimeSpan window)
			: this(bufferSize, window, ObservableSystem.DefaultTimeProvider)
		{
		}

		public ReplaySubject(int bufferSize, TimeSpan window, TimeProvider timeProvider)
		{
			this.bufferSize = bufferSize;
			this.window = window;
			this.timeProvider = timeProvider;
			replayBuffer = new RingBuffer<(long, T)>((bufferSize < 8) ? bufferSize : 8);
			list = new FreeListCore<Subscription>(replayBuffer);
		}

		public void OnNext(T value)
		{
			if (completeState.IsCompleted)
			{
				return;
			}
			lock (replayBuffer)
			{
				Trim();
				replayBuffer.AddLast((timeProvider?.GetTimestamp() ?? 0, value));
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
			lock (replayBuffer)
			{
				Trim();
				RingBufferSpan<(long, T)> span = replayBuffer.GetSpan();
				ReadOnlySpan<(long, T)> first = span.First;
				for (int i = 0; i < first.Length; i++)
				{
					observer.OnNext(first[i].Item2);
				}
				first = span.Second;
				for (int i = 0; i < first.Length; i++)
				{
					observer.OnNext(first[i].Item2);
				}
				Result? result = completeState.TryGetResult();
				if (result.HasValue)
				{
					observer.OnCompleted(result.Value);
					return Disposable.Empty;
				}
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
			lock (replayBuffer)
			{
				replayBuffer.Clear();
			}
		}

		private void Trim()
		{
			while (replayBuffer.Count > bufferSize)
			{
				replayBuffer.RemoveFirst();
			}
			if (timeProvider == null)
			{
				return;
			}
			long timestamp = timeProvider.GetTimestamp();
			while (replayBuffer.Count > 0)
			{
				(long, T) tuple = replayBuffer[0];
				if (timeProvider.GetElapsedTime(tuple.Item1, timestamp) >= window)
				{
					replayBuffer.RemoveFirst();
					continue;
				}
				break;
			}
		}
	}
}
