using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class ChunkCountSkip<T> : Observable<T[]>
	{
		private sealed class _Chunk : Observer<T>
		{
			private Queue<(int, T[])> q;

			private int queueIndex;

			public _Chunk(Observer<T[]> observer, int count, int skip)
			{
				_003Cobserver_003EP = observer;
				_003Ccount_003EP = count;
				_003Cskip_003EP = skip;
				q = new Queue<(int, T[])>();
				queueIndex = -1;
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				queueIndex++;
				if (queueIndex % _003Cskip_003EP == 0)
				{
					q.Enqueue((0, new T[_003Ccount_003EP]));
				}
				int num = q.Count;
				for (int i = 0; i < num; i++)
				{
					T[] array;
					int num2;
					(num2, array) = q.Dequeue();
					array[num2] = value;
					num2++;
					if (num2 == _003Ccount_003EP)
					{
						_003Cobserver_003EP.OnNext(array);
					}
					else
					{
						q.Enqueue((num2, array));
					}
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				foreach (var (length, array) in q)
				{
					_003Cobserver_003EP.OnNext(array.AsSpan(0, length).ToArray());
				}
				q.Clear();
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public ChunkCountSkip(Observable<T> source, int count, int skip)
		{
			_003Csource_003EP = source;
			_003Ccount_003EP = count;
			_003Cskip_003EP = skip;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _Chunk(observer, _003Ccount_003EP, _003Cskip_003EP));
		}
	}
}
