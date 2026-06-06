using System;

namespace R3
{
	internal sealed class DefaultIfEmpty<T> : Observable<T?>
	{
		private sealed class _DefaultIfEmpty : Observer<T>
		{
			private bool hasValue;

			public _DefaultIfEmpty(Observer<T?> observer, T? defaultValue)
			{
				_003Cobserver_003EP = observer;
				_003CdefaultValue_003EP = defaultValue;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				hasValue = true;
				_003Cobserver_003EP.OnNext(value);
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (!hasValue)
				{
					_003Cobserver_003EP.OnNext(_003CdefaultValue_003EP);
				}
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public DefaultIfEmpty(Observable<T> source, T? defaultValue)
		{
			_003Csource_003EP = source;
			_003CdefaultValue_003EP = defaultValue;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T?> observer)
		{
			return _003Csource_003EP.Subscribe(new _DefaultIfEmpty(observer, _003CdefaultValue_003EP));
		}
	}
}
