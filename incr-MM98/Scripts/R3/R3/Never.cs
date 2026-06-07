using System;

namespace R3
{
	internal sealed class Never<T> : Observable<T>
	{
		public static readonly Never<T> Instance = new Never<T>();

		private Never()
		{
		}

		protected override IDisposable SubscribeCore(Observer<T> observer)
		{
			return Disposable.Empty;
		}
	}
}
