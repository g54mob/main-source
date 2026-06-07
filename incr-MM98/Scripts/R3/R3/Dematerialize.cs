using System;

namespace R3
{
	internal sealed class Dematerialize<T> : Observable<T>
	{
		private sealed class _Dematerialize : Observer<Notification<T>>
		{
			public _Dematerialize(Observer<T> observer)
			{
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			protected override void OnNextCore(Notification<T> value)
			{
				switch (value.Kind)
				{
				case NotificationKind.OnNext:
					_003Cobserver_003EP.OnNext(value.Value);
					break;
				case NotificationKind.OnErrorResume:
					OnErrorResume(value.Error);
					break;
				case NotificationKind.OnCompleted:
					OnCompleted(value.Result);
					break;
				}
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

		public Dematerialize(Observable<Notification<T>> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Dematerialize(observer));
		}
	}
}
