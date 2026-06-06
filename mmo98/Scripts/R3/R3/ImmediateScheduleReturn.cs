using System;

namespace R3
{
	internal sealed class ImmediateScheduleReturn<T> : Observable<T>
	{
		public ImmediateScheduleReturn(T value)
		{
			_003Cvalue_003EP = value;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			observer.OnNext(_003Cvalue_003EP);
			observer.OnCompleted();
			return Disposable.Empty;
		}
	}
}
