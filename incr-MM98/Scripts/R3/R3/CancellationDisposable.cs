using System;
using System.Threading;

namespace R3
{
	public sealed class CancellationDisposable : IDisposable
	{
		public CancellationToken Token => _003CcancellationTokenSource_003EP.Token;

		public bool IsDisposed => _003CcancellationTokenSource_003EP.IsCancellationRequested;

		public CancellationDisposable(CancellationTokenSource cancellationTokenSource)
		{
			_003CcancellationTokenSource_003EP = cancellationTokenSource;
			base._002Ector();
		}

		public CancellationDisposable()
			: this(new CancellationTokenSource())
		{
		}

		public void Dispose()
		{
			_003CcancellationTokenSource_003EP.Cancel();
		}
	}
}
