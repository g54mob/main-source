using System;

namespace R3
{
	internal sealed class Chunk<T> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>
		{
			private T[] buffer;

			private int index;

			public _Chunk(Observer<T[]> observer, int count)
			{
				_003Cobserver_003EP = observer;
				_003Ccount_003EP = count;
				buffer = new T[_003Ccount_003EP];
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				buffer[index++] = value;
				if (index == _003Ccount_003EP)
				{
					index = 0;
					_003Cobserver_003EP.OnNext(buffer);
					buffer = new T[_003Ccount_003EP];
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (index > 0)
				{
					_003Cobserver_003EP.OnNext(buffer.AsSpan(0, index).ToArray());
				}
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public Chunk(Observable<T> source, int count)
		{
			_003Csource_003EP = source;
			_003Ccount_003EP = count;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _Chunk(observer, _003Ccount_003EP));
		}
	}
}
