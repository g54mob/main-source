using System;

namespace R3
{
	internal class ImmediateScheduleReturnOnCompleted<T> : Observable<T>
	{
		public ImmediateScheduleReturnOnCompleted(Result result)
		{
			_003Cresult_003EP = result;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			observer.OnCompleted(_003Cresult_003EP);
			return Disposable.Empty;
		}
	}
}
