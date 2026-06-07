using System;

namespace R3
{
	internal sealed class ReturnInt32 : Observable<int>
	{
		internal static readonly Observable<int> _m1 = new ReturnInt32(-1);

		internal static readonly Observable<int> _0 = new ReturnInt32(0);

		internal static readonly Observable<int> _1 = new ReturnInt32(1);

		internal static readonly Observable<int> _2 = new ReturnInt32(2);

		internal static readonly Observable<int> _3 = new ReturnInt32(3);

		internal static readonly Observable<int> _4 = new ReturnInt32(4);

		internal static readonly Observable<int> _5 = new ReturnInt32(5);

		internal static readonly Observable<int> _6 = new ReturnInt32(6);

		internal static readonly Observable<int> _7 = new ReturnInt32(7);

		internal static readonly Observable<int> _8 = new ReturnInt32(8);

		internal static readonly Observable<int> _9 = new ReturnInt32(9);

		private int value;

		public static Observable<int> GetObservable(int value)
		{
			return value switch
			{
				-1 => _m1, 
				0 => _0, 
				1 => _1, 
				2 => _2, 
				3 => _3, 
				4 => _4, 
				5 => _5, 
				6 => _6, 
				7 => _7, 
				8 => _8, 
				9 => _9, 
				_ => new ReturnInt32(value), 
			};
		}

		private ReturnInt32(int value)
		{
			this.value = value;
		}

		protected override IDisposable SubscribeCore(Observer<int> observer)
		{
			observer.OnNext(value);
			observer.OnCompleted();
			return Disposable.Empty;
		}
	}
}
