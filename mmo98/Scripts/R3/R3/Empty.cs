using System;

namespace R3
{
	internal sealed class Empty<T> : Observable<T>
	{
		public static readonly Empty<T> Instance = new Empty<T>();

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			observer.OnCompleted();
			return Disposable.Empty;
		}

		private Empty()
		{
		}
	}
}
