using System;
using System.Collections.Generic;
using System.Threading;

namespace R3
{
	internal sealed class EnumerableToObservable<T> : Observable<T>
	{
		public EnumerableToObservable(IEnumerable<T> source, CancellationToken cancellationToken)
		{
			_003Csource_003EP = source;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			foreach (T item in _003Csource_003EP)
			{
				if (_003CcancellationToken_003EP.IsCancellationRequested)
				{
					observer.OnCompleted();
					return Disposable.Empty;
				}
				observer.OnNext(item);
			}
			observer.OnCompleted();
			return Disposable.Empty;
		}
	}
}
