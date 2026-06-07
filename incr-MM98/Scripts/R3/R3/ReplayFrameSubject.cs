using System;
using System.Threading;
using R3.Collections;
using R3.Internal;

namespace R3
{
	public sealed class ReplayFrameSubject<T> : Observable<T>, ISubject<T>, IDisposable
	{
		private sealed class Subscription : IDisposable
		{
			public readonly Observer<T> observer;

			private readonly int removeKey;

			private ReplayFrameSubject<T>? parent;

			public Subscription(ReplayFrameSubject<T> parent, Observer<T> observer)
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

		private readonly int window;

		private readonly FrameProvider frameProvider;

		private readonly RingBuffer<(long timestamp, T value)> replayBuffer;

		private FreeListCore<Subscription> list;

		private CompleteState completeState;

		public bool IsDisposed => completeState.IsDisposed;

		public ReplayFrameSubject(int window)
			: this(int.MaxValue, int.MaxValue, ObservableSystem.DefaultFrameProvider)
		{
		}

		public ReplayFrameSubject(int window, FrameProvider frameProvider)
			: this(int.MaxValue, window, frameProvider)
		{
		}

		public ReplayFrameSubject(int bufferSize, int window)
			: this(bufferSize, window, ObservableSystem.DefaultFrameProvider)
		{
		}

		public ReplayFrameSubject(int bufferSize, int window, FrameProvider frameProvider)
		{
			this.bufferSize = bufferSize;
			this.window = window;
			this.frameProvider = frameProvider;
			replayBuffer = new RingBuffer<(long, T)>((bufferSize < 8) ? bufferSize : 8);
			list = new FreeListCore<Subscription>(replayBuffer);
		}

		public void OnNext(T value)
		{
			if (!completeState.IsCompleted)
			{
				lock (replayBuffer)
				{
					Trim();
					replayBuffer.AddLast((frameProvider?.GetFrameCount() ?? 0, value));
				}
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
			long frameCount = frameProvider.GetFrameCount();
			while (replayBuffer.Count > 0 && frameCount - replayBuffer[0].timestamp >= window)
			{
				replayBuffer.RemoveFirst();
			}
		}
	}
}
