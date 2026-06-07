using System;

namespace R3
{
	internal sealed class IgnoreElements<T> : Observable<T>
	{
		private sealed class _IgnoreElements : Observer<T>
		{
			public _IgnoreElements(Observer<T> observer, Action<T>? doOnNext)
			{
				_003Cobserver_003EP = observer;
				_003CdoOnNext_003EP = doOnNext;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003CdoOnNext_003EP?.Invoke(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public IgnoreElements(Observable<T> source, Action<T>? doOnNext)
		{
			_003Csource_003EP = source;
			_003CdoOnNext_003EP = doOnNext;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _IgnoreElements(observer, _003CdoOnNext_003EP));
		}
	}
}
