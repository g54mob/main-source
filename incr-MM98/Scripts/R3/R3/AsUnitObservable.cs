using System;

namespace R3
{
	internal sealed class AsUnitObservable<T> : Observable<Unit>
	{
		private sealed class _AsUnitObservable : Observer<T>
		{
			public _AsUnitObservable(Observer<Unit> observer)
			{
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				_003Cobserver_003EP.OnNext(default(Unit));
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

		public AsUnitObservable(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			return _003Csource_003EP.Subscribe(new _AsUnitObservable(observer));
		}
	}
}
