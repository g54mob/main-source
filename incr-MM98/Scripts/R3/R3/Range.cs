using System;

namespace R3
{
	internal sealed class Range : Observable<int>
	{
		public Range(int start, int count)
		{
			_003Cstart_003EP = start;
			_003Ccount_003EP = count;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<int> observer)
		{
			for (int i = 0; i < _003Ccount_003EP; i++)
			{
				observer.OnNext(_003Cstart_003EP + i);
			}
			observer.OnCompleted(default(Result));
			return Disposable.Empty;
		}
	}
}
