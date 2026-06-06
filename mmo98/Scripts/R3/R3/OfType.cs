using System;

namespace R3
{
	internal sealed class OfType<T, TResult> : Observable<TResult>
	{
		private sealed class _OfType : Observer<T>
		{
			public _OfType(Observer<TResult> observer)
			{
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (value is TResult)
				{
					TResult value2 = (TResult)((((object)value) is TResult) ? ((object)value) : null);
					_003Cobserver_003EP.OnNext(value2);
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

		public OfType(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return _003Csource_003EP.Subscribe(new _OfType(observer));
		}
	}
}
