using System;

namespace R3
{
	internal class OnErrorResumeAsFailure<T> : Observable<T>
	{
		private sealed class _OnErrorAsComplete : Observer<T>
		{
			public _OnErrorAsComplete(Observer<T> observer)
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
				_003Cobserver_003EP.OnCompleted(error);
			}

			protected override void OnCompletedCore(Result complete)
			{
				_003Cobserver_003EP.OnCompleted(complete);
			}
		}

		public OnErrorResumeAsFailure(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _OnErrorAsComplete(observer));
		}
	}
}
