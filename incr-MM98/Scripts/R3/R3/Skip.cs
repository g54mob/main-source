using System;

namespace R3
{
	internal sealed class Skip<T> : Observable<T>
	{
		private sealed class _Skip : Observer<T>, IDisposable
		{
			private int remaining;

			public _Skip(Observer<T> observer, int count)
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
				}
				else
				{
					_003Cobserver_003EP.OnNext(value);
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

		public Skip(Observable<T> source, int count)
		{
			_003Csource_003EP = source;
			_003Ccount_003EP = count;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Skip(observer, _003Ccount_003EP));
		}
	}
}
