using System;

namespace R3
{
	internal sealed class Repeat<T> : Observable<T>
	{
		public Repeat(T value, int count)
		{
			_003Cvalue_003EP = value;
			_003Ccount_003EP = count;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			for (int i = 0; i < _003Ccount_003EP; i++)
			{
				observer.OnNext(_003Cvalue_003EP);
			}
			observer.OnCompleted(default(Result));
			return Disposable.Empty;
		}
	}
}
