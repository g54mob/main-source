using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class DistinctBy<T, TKey> : Observable<T>
	{
		private sealed class _DistinctBy : Observer<T>
		{
			private readonly Observer<T> observer;

			private readonly Func<T, TKey> keySelector;

			private readonly HashSet<TKey> set;

			public _DistinctBy(Observer<T> observer, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
			{
				this.observer = observer;
				this.keySelector = keySelector;
				set = new HashSet<TKey>(comparer);
			}

			protected override void OnNextCore(T value)
			{
				TKey item = keySelector(value);
				if (set.Add(item))
				{
					observer.OnNext(value);
				}
			}

			protected override void OnErrorResumeCore(Exception error)
			{
				observer.OnErrorResume(error);
			}

			protected override void OnCompletedCore(Result result)
			{
				observer.OnCompleted(result);
			}
		}

		public DistinctBy(Observable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			_003Csource_003EP = source;
			_003CkeySelector_003EP = keySelector;
			_003Ccomparer_003EP = comparer;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _DistinctBy(observer, _003CkeySelector_003EP, _003Ccomparer_003EP));
		}
	}
}
