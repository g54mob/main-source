using System;

namespace R3
{
	internal sealed class WrappedObserver<T> : Observer<T>
	{
		public WrappedObserver(Observer<T> observer)
		{
			_003Cobserver_003EP = observer;
			base._002Ector();
		}

		protected override void OnNextCore(T value)
		{
			_003Cobserver_003EP.OnNext(value);
		}

		protected override void OnErrorResumeCore(Exception error)
		{
			_003Cobserver_003EP.OnErrorResume(error);
		}

		protected override void OnCompletedCore(Result result)
		{
			_003Cobserver_003EP.OnCompleted(result);
		}

		protected override void DisposeCore()
		{
			_003Cobserver_003EP.Dispose();
		}
	}
}
