using System;
using System.Runtime.CompilerServices;
using System.Threading;
using UniRx.InternalUtil;

namespace UniRx
{
	public sealed class AsyncSubject<T> : ISubject<T>, ISubject<T, T>, IObserver<T>, IObservable<T>, IOptimizedObservable<T>, IDisposable, INotifyCompletion
	{
		private class Subscription : IDisposable
		{
			private readonly object gate = new object();

			private AsyncSubject<T> parent;

			private IObserver<T> unsubscribeTarget;

			public Subscription(AsyncSubject<T> parent, IObserver<T> unsubscribeTarget)
			{
				this.parent = parent;
				this.unsubscribeTarget = unsubscribeTarget;
			}

			public void Dispose()
			{
				lock (gate)
				{
					if (parent == null)
					{
						return;
					}
					lock (parent.observerLock)
					{
						if (parent.outObserver is ListObserver<T> listObserver)
						{
							parent.outObserver = listObserver.Remove(unsubscribeTarget);
						}
						else
						{
							parent.outObserver = EmptyObserver<T>.Instance;
						}
						unsubscribeTarget = null;
						parent = null;
					}
				}
			}
		}

		private class AwaitObserver : IObserver<T>
		{
			private readonly SynchronizationContext _context;

			private readonly Action _callback;

			public AwaitObserver(Action callback, bool originalContext)
			{
				if (originalContext)
				{
					_context = SynchronizationContext.Current;
				}
				_callback = callback;
			}

			public void OnCompleted()
			{
				InvokeOnOriginalContext();
			}

			public void OnError(Exception error)
			{
				InvokeOnOriginalContext();
			}

			public void OnNext(T value)
			{
			}

			private void InvokeOnOriginalContext()
			{
				if (_context != null)
				{
					_context.Post(delegate(object c)
					{
						((Action)c)();
					}, _callback);
				}
				else
				{
					_callback();
				}
			}
		}

		private object observerLock = new object();

		private T lastValue;

		private bool hasValue;

		private bool isStopped;

		private bool isDisposed;

		private Exception lastError;

		private IObserver<T> outObserver = EmptyObserver<T>.Instance;

		public T Value
		{
			get
			{
				ThrowIfDisposed();
				if (!isStopped)
				{
					throw new InvalidOperationException("AsyncSubject is not completed yet");
				}
				if (lastError != null)
				{
					lastError.Throw();
				}
				return lastValue;
			}
		}

		public bool HasObservers
		{
			get
			{
				if (!(outObserver is EmptyObserver<T>) && !isStopped)
				{
					return !isDisposed;
				}
				return false;
			}
		}

		public bool IsCompleted => isStopped;

		public void OnCompleted()
		{
			IObserver<T> observer;
			T value;
			bool flag;
			lock (observerLock)
			{
				ThrowIfDisposed();
				if (isStopped)
				{
					return;
				}
				observer = outObserver;
				outObserver = EmptyObserver<T>.Instance;
				isStopped = true;
				value = lastValue;
				flag = hasValue;
			}
			if (flag)
			{
				observer.OnNext(value);
				observer.OnCompleted();
			}
			else
			{
				observer.OnCompleted();
			}
		}

		public void OnError(Exception error)
		{
			if (error == null)
			{
				throw new ArgumentNullException("error");
			}
			IObserver<T> observer;
			lock (observerLock)
			{
				ThrowIfDisposed();
				if (isStopped)
				{
					return;
				}
				observer = outObserver;
				outObserver = EmptyObserver<T>.Instance;
				isStopped = true;
				lastError = error;
			}
			observer.OnError(error);
		}

		public void OnNext(T value)
		{
			lock (observerLock)
			{
				ThrowIfDisposed();
				if (!isStopped)
				{
					hasValue = true;
					lastValue = value;
				}
			}
		}

		public IDisposable Subscribe(IObserver<T> observer)
		{
			if (observer == null)
			{
				throw new ArgumentNullException("observer");
			}
			Exception ex = null;
			T value = default(T);
			bool flag = false;
			lock (observerLock)
			{
				ThrowIfDisposed();
				if (!isStopped)
				{
					if (outObserver is ListObserver<T> listObserver)
					{
						outObserver = listObserver.Add(observer);
					}
					else
					{
						IObserver<T> observer2 = outObserver;
						if (observer2 is EmptyObserver<T>)
						{
							outObserver = observer;
						}
						else
						{
							outObserver = new ListObserver<T>(new ImmutableList<IObserver<T>>(new IObserver<T>[2] { observer2, observer }));
						}
					}
					return new Subscription(this, observer);
				}
				ex = lastError;
				value = lastValue;
				flag = hasValue;
			}
			if (ex != null)
			{
				observer.OnError(ex);
			}
			else if (flag)
			{
				observer.OnNext(value);
				observer.OnCompleted();
			}
			else
			{
				observer.OnCompleted();
			}
			return Disposable.Empty;
		}

		public void Dispose()
		{
			lock (observerLock)
			{
				isDisposed = true;
				outObserver = DisposedObserver<T>.Instance;
				lastError = null;
				lastValue = default(T);
			}
		}

		private void ThrowIfDisposed()
		{
			if (isDisposed)
			{
				throw new ObjectDisposedException("");
			}
		}

		public bool IsRequiredSubscribeOnCurrentThread()
		{
			return false;
		}

		public AsyncSubject<T> GetAwaiter()
		{
			return this;
		}

		public void OnCompleted(Action continuation)
		{
			if (continuation == null)
			{
				throw new ArgumentNullException("continuation");
			}
			OnCompleted(continuation, originalContext: true);
		}

		private void OnCompleted(Action continuation, bool originalContext)
		{
			Subscribe(new AwaitObserver(continuation, originalContext));
		}

		public T GetResult()
		{
			if (!isStopped)
			{
				ManualResetEvent e = new ManualResetEvent(initialState: false);
				OnCompleted(delegate
				{
					e.Set();
				}, originalContext: false);
				e.WaitOne();
			}
			if (lastError != null)
			{
				lastError.Throw();
			}
			if (!hasValue)
			{
				throw new InvalidOperationException("NO_ELEMENTS");
			}
			return lastValue;
		}
	}
}
