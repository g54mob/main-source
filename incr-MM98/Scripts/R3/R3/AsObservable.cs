using System;

namespace R3
{
	internal sealed class AsObservable<T> : Observable<T>
	{
		public AsObservable(Observable<T> observable)
		{
			_003Cobservable_003EP = observable;
			base._002Ector();
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return _003Cobservable_003EP.Subscribe(observer.Wrap());
		}
	}
}
