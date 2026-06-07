using System;
using System.Threading;

namespace R3
{
	public struct SerialDisposableCore
	{
		private sealed class DisposedSentinel : IDisposable
		{
			public static readonly DisposedSentinel Instance = new DisposedSentinel();

			private DisposedSentinel()
			{
			}

			public void Dispose()
			{
			}
		}

		private IDisposable? current;

		public bool IsDisposed => Volatile.Read(ref current) == DisposedSentinel.Instance;

		public IDisposable? Disposable
		{
			get
			{
				IDisposable disposable = Volatile.Read(ref current);
				if (disposable == DisposedSentinel.Instance)
				{
					return R3.Disposable.Empty;
				}
				return disposable;
			}
			set
			{
				IDisposable disposable = Volatile.Read(ref current);
				IDisposable disposable2;
				while (true)
				{
					if (disposable == DisposedSentinel.Instance)
					{
						value?.Dispose();
						return;
					}
					disposable2 = Interlocked.CompareExchange(ref current, value, disposable);
					if (disposable2 == disposable)
					{
						break;
					}
					disposable = disposable2;
				}
				disposable2?.Dispose();
			}
		}

		public void Dispose()
		{
			IDisposable disposable = Interlocked.Exchange(ref current, DisposedSentinel.Instance);
			if (disposable != DisposedSentinel.Instance)
			{
				disposable?.Dispose();
			}
		}
	}
}
