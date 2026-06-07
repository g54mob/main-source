using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class DistinctUntilChangedBy<T, TKey> : Observable<T>
	{
		private sealed class _DistinctUntilChangedBy : Observer<T>
		{
			private readonly Observer<T> observer;

			private readonly Func<T, TKey> keySelector;

			private readonly IEqualityComparer<TKey> comparer;

			private TKey? lastKey;

			private bool hasValue;

			public _DistinctUntilChangedBy(Observer<T> observer, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
			{
				this.observer = observer;
				this.keySelector = keySelector;
				this.comparer = comparer;
			}

			protected override void OnNextCore(T value)
			{
				TKey y = keySelector(value);
				if (!hasValue || !comparer.Equals(lastKey, y))
				{
					hasValue = true;
					lastKey = y;
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

		public DistinctUntilChangedBy(Observable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			_003Csource_003EP = source;
			_003CkeySelector_003EP = keySelector;
			_003Ccomparer_003EP = comparer;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _DistinctUntilChangedBy(observer, _003CkeySelector_003EP, _003Ccomparer_003EP));
		}
	}
}
