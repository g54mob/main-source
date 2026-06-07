using System;

namespace R3
{
	internal sealed class ReturnUnit : Observable<Unit>
	{
		internal static readonly Observable<Unit> Instance = new ReturnUnit();

		private ReturnUnit()
		{
		}

		protected override IDisposable SubscribeCore(Observer<Unit> observer)
		{
			observer.OnNext(default(Unit));
			observer.OnCompleted();
			return Disposable.Empty;
		}
	}
}
