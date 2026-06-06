using System;

namespace R3
{
	internal sealed class Cast<T, TResult> : Observable<TResult>
	{
		private sealed class _Cast : Observer<T>
		{
			public _Cast(Observer<TResult> observer)
			{
				_003Cobserver_003EP = observer;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				TResult value2 = (TResult)(object)value;
				_003Cobserver_003EP.OnNext(value2);
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

		public Cast(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<TResult> observer)
		{
			return _003Csource_003EP.Subscribe(new _Cast(observer));
		}
	}
}
