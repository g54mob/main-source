using System;
using System.Collections.Generic;

namespace R3
{
	internal sealed class Distinct<T> : Observable<T>
	{
		private sealed class _Distinct : Observer<T>
		{
			private readonly Observer<T> observer;

			private readonly HashSet<T> set;

			public _Distinct(Observer<T> observer, IEqualityComparer<T> comparer)
			{
				this.observer = observer;
				set = new HashSet<T>(comparer);
			}

			protected override void OnNextCore(T value)
			{
				if (set.Add(value))
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

		public Distinct(Observable<T> source, IEqualityComparer<T> comparer)
		{
			_003Csource_003EP = source;
			_003Ccomparer_003EP = comparer;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Csource_003EP.Subscribe(new _Distinct(observer, _003Ccomparer_003EP));
		}
	}
}
