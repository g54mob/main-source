using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class DistinctUntilChanged<T> : Observable<T>
	{
		private sealed class _DistinctUntilChanged : Observer<T>
		{
			private readonly Observer<T> observer;

			private readonly IEqualityComparer<T> comparer;

			private T? lastValue;

			private bool hasValue;

			public _DistinctUntilChanged(Observer<T> observer, IEqualityComparer<T> comparer)
			{
				this.observer = observer;
				this.comparer = comparer;
			}

			protected override void OnNextCore(T value)
			{
				if (!hasValue || !comparer.Equals(lastValue, value))
				{
					hasValue = true;
					lastValue = value;
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

		public DistinctUntilChanged(Observable<T> source, IEqualityComparer<T> comparer)
		{
			_003Csource_003EP = source;
			_003Ccomparer_003EP = comparer;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _DistinctUntilChanged(observer, _003Ccomparer_003EP));
		}
	}
}
