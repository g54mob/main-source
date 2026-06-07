using System;

namespace R3
{
	internal sealed class Synchronize<T> : Observable<T>
	{
		private sealed class _Synchronize : Observer<T>
		{
			public _Synchronize(Observer<T> observer, object gate)
			{
				_003Cobserver_003EP = observer;
				_003Cgate_003EP = gate;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				lock (_003Cgate_003EP)
				{
					_003Cobserver_003EP.OnNext(value);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				lock (_003Cgate_003EP)
				{
					_003Cobserver_003EP.OnErrorResume(error);
				}
			}

			protected override void OnCompletedCore(Result result)
			{
				lock (_003Cgate_003EP)
				{
					_003Cobserver_003EP.OnCompleted(result);
				}
			}
		}

		public Synchronize(Observable<T> source, object gate)
		{
			_003Csource_003EP = source;
			_003Cgate_003EP = gate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Synchronize(observer, _003Cgate_003EP));
		}
	}
}
