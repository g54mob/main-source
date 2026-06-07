using System;
using System.Threading;

namespace R3
{
	internal sealed class RangeC : Observable<int>
	{
		public RangeC(int start, int count, CancellationToken cancellationToken)
		{
			_003Cstart_003EP = start;
			_003Ccount_003EP = count;
			_003CcancellationToken_003EP = cancellationToken;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<int> observer)
		{
			for (int i = 0; i < _003Ccount_003EP; i++)
			{
				if (_003CcancellationToken_003EP.IsCancellationRequested)
				{
					observer.OnCompleted();
					return Disposable.Empty;
				}
				observer.OnNext(_003Cstart_003EP + i);
			}
			observer.OnCompleted();
			return Disposable.Empty;
		}
	}
}
