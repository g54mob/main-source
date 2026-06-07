using System;

namespace R3
{
	internal class ImmediateScheduleReturnOnCompletedSuccess<T> : Observable<T>
	{
		public static readonly Observable<T> Instance = new ImmediateScheduleReturnOnCompletedSuccess<T>();

		private ImmediateScheduleReturnOnCompletedSuccess()
		{
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			observer.OnCompleted(Result.Success);
			return Disposable.Empty;
		}
	}
}
