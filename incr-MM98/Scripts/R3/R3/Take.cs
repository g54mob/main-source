using System;

namespace R3
{
	internal sealed class Take<T> : Observable<T>
	{
		private sealed class _Take : Observer<T>, IDisposable
		{
			private int remaining;

			public _Take(Observer<T> observer, int count)
			{
				_003Cobserver_003EP = observer;
				remaining = count;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (remaining > 0)
				{
					remaining--;
					_003Cobserver_003EP.OnNext(value);
					if (remaining == 0)
					{
						_003Cobserver_003EP.OnCompleted();
					}
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

		public Take(Observable<T> source, int count)
		{
			_003Csource_003EP = source;
			_003Ccount_003EP = count;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Take(observer, _003Ccount_003EP));
		}
	}
}
