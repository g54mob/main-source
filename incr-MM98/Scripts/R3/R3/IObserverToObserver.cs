using System;

namespace R3
{
	internal sealed class IObserverToObserver<T> : Observer<T>
	{
		public IObserverToObserver(IObserver<T> observer)
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
			_003Cobserver_003EP.OnError(error);
		}

		protected override void OnCompletedCore(Result result)
		{
			if (result.IsFailure)
			{
				_003Cobserver_003EP.OnError(result.Exception);
			}
			else
			{
				_003Cobserver_003EP.OnCompleted();
			}
		}
	}
}
