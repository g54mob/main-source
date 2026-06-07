using System;

namespace R3
{
	internal sealed class ReturnBoolean : Observable<bool>
	{
		internal static readonly Observable<bool> True = new ReturnBoolean(value: true);

		internal static readonly Observable<bool> False = new ReturnBoolean(value: false);

		private bool value;

		private ReturnBoolean(bool value)
		{
			this.value = value;
		}

		protected override IDisposable SubscribeCore(Observer<bool> observer)
		{
			observer.OnNext(value);
			observer.OnCompleted();
			return Disposable.Empty;
		}
	}
}
