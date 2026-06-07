using System;
using System.Threading;

namespace R3
{
	internal sealed class RepeatC<T> : Observable<T>
	{
		public RepeatC(T value, int count, CancellationToken cancellationToken)
		{
			_003Cvalue_003EP = value;
			_003Ccount_003EP = count;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			for (int i = 0; i < _003Ccount_003EP; i++)
			{
				if (_003CcancellationToken_003EP.IsCancellationRequested)
				{
					observer.OnCompleted();
					return Disposable.Empty;
				}
				observer.OnNext(_003Cvalue_003EP);
			}
			observer.OnCompleted(default(Result));
			return Disposable.Empty;
		}
	}
}
