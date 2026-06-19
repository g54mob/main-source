using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal
{
	internal class Lock : IDisposable
	{
		private readonly Signal _signal;

		public Lock()
		{
			_signal = new Signal(isReleasedInitially: true);
		}

		public async Task<IDisposable> AcquireAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			await _signal.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return Disposable.Create(_signal.Release);
		}

		public void Dispose()
		{
			_signal.Dispose();
		}
	}
}
