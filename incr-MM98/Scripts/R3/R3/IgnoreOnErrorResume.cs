using System;

namespace R3
{
	internal sealed class IgnoreOnErrorResume<T> : Observable<T>
	{
		private sealed class _IgnoreOnErrorResume : Observer<T>
		{
			public _IgnoreOnErrorResume(Observer<T> observer, Action<Exception>? doOnErrorResume)
			{
				_003Cobserver_003EP = observer;
				_003CdoOnErrorResume_003EP = doOnErrorResume;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003CdoOnErrorResume_003EP?.Invoke(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public IgnoreOnErrorResume(Observable<T> source, Action<Exception>? doOnErrorResume)
		{
			_003Csource_003EP = source;
			_003CdoOnErrorResume_003EP = doOnErrorResume;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _IgnoreOnErrorResume(observer, _003CdoOnErrorResume_003EP));
		}
	}
}
