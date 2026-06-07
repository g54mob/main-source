using System;
using System.Threading;

namespace R3
{
	public struct SingleAssignmentDisposableCore
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
				IDisposable disposable = Interlocked.CompareExchange(ref current, value, null);
				if (disposable != null)
				{
					if (disposable == DisposedSentinel.Instance)
					{
						value?.Dispose();
					}
					else
					{
						ThrowAlreadyAssignment();
					}
				}
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

		private static void ThrowAlreadyAssignment()
		{
			throw new InvalidOperationException("Disposable is already assigned.");
		}
	}
}
