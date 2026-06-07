using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class ChunkUntil<T> : Observable<T[]>
	{
		private sealed class _ChunkUntil : Observer<T>, IDisposable
		{
			private readonly List<T> list;

			public _ChunkUntil(Observer<T[]> observer, Func<T, bool> predicate)
			{
				_003Cobserver_003EP = observer;
				_003Cpredicate_003EP = predicate;
				list = new List<T>();
				base._002Ector();
			}

			protected override void OnNextCore(T value)
			{
				list.Add(value);
				if (_003Cpredicate_003EP(value))
				{
					T[] value2 = list.ToArray();
					list.Clear();
					_003Cobserver_003EP.OnNext(value2);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				_003Cobserver_003EP.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				if (list.Count > 0)
				{
					_003Cobserver_003EP.OnNext(list.ToArray());
				}
				_003Cobserver_003EP.OnCompleted(result);
			}
		}

		public ChunkUntil(Observable<T> source, Func<T, bool> predicate)
		{
			_003Csource_003EP = source;
			_003Cpredicate_003EP = predicate;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T[]> observer)
		{
			return _003Csource_003EP.Subscribe(new _ChunkUntil(observer, _003Cpredicate_003EP));
		}
	}
}
