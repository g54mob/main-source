using System;
using System.Threading;

namespace MessagePipe
{
	public sealed class CancellationTokenDisposable : IDisposable
	{
		private CancellationTokenSource cancellationTokenSource;

		public CancellationToken Token => cancellationTokenSource.Token;

		public CancellationTokenDisposable()
		{
			cancellationTokenSource = new CancellationTokenSource();
		}

		public void Dispose()
		{
			cancellationTokenSource.Cancel();
			cancellationTokenSource.Dispose();
		}
	}
}
