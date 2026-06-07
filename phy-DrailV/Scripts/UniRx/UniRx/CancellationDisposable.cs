using System;
using System.Threading;

namespace UniRx
{
	public sealed class CancellationDisposable : ICancelable, IDisposable
	{
		private readonly CancellationTokenSource _cts;

		public CancellationToken Token => _cts.Token;

		public bool IsDisposed => _cts.IsCancellationRequested;

		public CancellationDisposable(CancellationTokenSource cts)
		{
			if (cts == null)
			{
				throw new ArgumentNullException("cts");
			}
			_cts = cts;
		}

		public CancellationDisposable()
			: this(new CancellationTokenSource())
		{
		}

		public void Dispose()
		{
			_cts.Cancel();
		}
	}
}
