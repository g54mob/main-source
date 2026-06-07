using System;

namespace R3
{
	internal sealed class Pairwise<T> : Observable<(T Previous, T Current)>
	{
		private sealed class _Pairwise : Observer<T>
		{
			private T? previous;

			private bool isFirst;

			public _Pairwise(Observer<(T Previous, T Current)> observer)
			{
				_003Cobserver_003EP = observer;
				isFirst = true;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				if (isFirst)
				{
					isFirst = false;
					previous = value;
				}
				else
				{
					(T, T) value2 = (previous, value);
					previous = value;
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

		public Pairwise(Observable<T> source)
		{
			_003Csource_003EP = source;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<(T Previous, T Current)> observer)
		{
			return _003Csource_003EP.Subscribe(new _Pairwise(observer));
		}
	}
}
