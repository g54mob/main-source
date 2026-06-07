using System;
using System.Threading;

namespace R3.Internal
{
	internal abstract class CancellableFrameRunnerWorkItemBase<T> : IFrameRunnerWorkItem, IDisposable
	{
		private readonly Observer<T> observer;

		private CancellationTokenRegistration cancellationTokenRegistration;

		private bool isDisposed;

		public CancellableFrameRunnerWorkItemBase(Observer<T> observer, CancellationToken cancellationToken)
		{
			this.observer = observer;
			if (cancellationToken.CanBeCanceled)
			{
				cancellationTokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
				{
					CancellableFrameRunnerWorkItemBase<T> obj = (CancellableFrameRunnerWorkItemBase<T>)state;
					obj.observer.OnCompleted();
					obj.Dispose();
				}, this);
			}
		}

		public bool MoveNext(long frameCount)
		{
			if (isDisposed)
			{
				return false;
			}
			if (observer.IsDisposed)
			{
				Dispose();
				return false;
			}
			return MoveNextCore(frameCount);
		}

		protected abstract bool MoveNextCore(long frameCount);

		public void Dispose()
		{
			if (!isDisposed)
			{
				isDisposed = true;
				cancellationTokenRegistration.Dispose();
				DisposeCore();
			}
		}

		protected virtual void DisposeCore()
		{
		}

		protected void PublishOnNext(T value)
		{
			observer.OnNext(value);
		}

		protected void PublishOnErrorResume(Exception error)
		{
			observer.OnErrorResume(error);
		}

		protected void PublishOnCompleted(Exception error)
		{
			observer.OnCompleted(error);
			Dispose();
		}

		protected void PublishOnCompleted()
		{
			observer.OnCompleted();
			Dispose();
		}
	}
}
