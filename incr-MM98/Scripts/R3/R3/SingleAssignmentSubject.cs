using System;
using System.Threading;

namespace R3
{
	public sealed class SingleAssignmentSubject<T> : Observable<T>, ISubject<T>, IDisposable
	{
		private class Subscription : IDisposable
		{
			public Subscription(SingleAssignmentSubject<T> parent)
			{
				_003Cparent_003EP = parent;
				base._002Ector();
			}

			public void Dispose()
			{
				Observer<T> observer;
				do
				{
					observer = Volatile.Read(ref _003Cparent_003EP.singleObserver);
				}
				while (observer != CompletedObserver.Instance && observer != DisposedObserver.Instance && observer != null && Interlocked.CompareExchange(ref _003Cparent_003EP.singleObserver, null, observer) != observer);
			}
		}

		private sealed class CompletedObserver : Observer<T>
		{
			public static readonly CompletedObserver Instance = new CompletedObserver();

			protected override void OnCompletedCore(Result result)
			{
			}

			protected override void OnErrorResumeCore(Exception error)
			{
			}

			protected override void OnNextCore(T value)
			{
			}
		}

		private sealed class DisposedObserver : Observer<T>
		{
			public static readonly DisposedObserver Instance = new DisposedObserver();

			protected override void OnCompletedCore(Result result)
			{
			}

			protected override void OnErrorResumeCore(Exception error)
			{
			}

			protected override void OnNextCore(T value)
			{
			}
		}

		private Observer<T>? singleObserver;

		private Result completed;

		public bool IsDisposed => singleObserver == DisposedObserver.Instance;

		public void OnNext(T value)
		{
			Observer<T> observer = singleObserver;
			if (observer != CompletedObserver.Instance && observer != null)
			{
				if (observer == DisposedObserver.Instance)
				{
					ThrowAlreadyDisposed();
				}
				else
				{
					observer.OnNext(value);
				}
			}
		}

		public void OnErrorResume(Exception error)
		{
			Observer<T> observer = singleObserver;
			if (observer != CompletedObserver.Instance && observer != null)
			{
				if (observer == DisposedObserver.Instance)
				{
					ThrowAlreadyDisposed();
				}
				else
				{
					observer.OnErrorResume(error);
				}
			}
		}

		public void OnCompleted(Result complete)
		{
			Observer<T> observer;
			do
			{
				observer = Volatile.Read(ref singleObserver);
				if (observer == CompletedObserver.Instance)
				{
					return;
				}
				if (observer == DisposedObserver.Instance)
				{
					ThrowAlreadyDisposed();
					return;
				}
				completed = complete;
			}
			while (Interlocked.CompareExchange(ref singleObserver, CompletedObserver.Instance, observer) != observer);
			observer?.OnCompleted(complete);
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			Observer<T> observer2 = Interlocked.CompareExchange(ref singleObserver, observer, null);
			if (observer2 == null)
			{
				return new Subscription(this);
			}
			if (observer2 == DisposedObserver.Instance)
			{
				ThrowAlreadyDisposed();
			}
			else if (observer2 == CompletedObserver.Instance)
			{
				observer.OnCompleted(completed);
			}
			else
			{
				ThrowAlreadyAssignment();
			}
			return Disposable.Empty;
		}

		public void Dispose()
		{
			Dispose(callOnCompleted: true);
		}

		public void Dispose(bool callOnCompleted)
		{
			Observer<T> observer = Interlocked.Exchange(ref singleObserver, DisposedObserver.Instance);
			if (observer != DisposedObserver.Instance && observer != null && callOnCompleted)
			{
				observer.OnCompleted();
			}
		}

		private static void ThrowAlreadyAssignment()
		{
			throw new InvalidOperationException("Observer is already assigned.");
		}

		private void ThrowAlreadyDisposed()
		{
			throw new ObjectDisposedException("");
		}
	}
}
