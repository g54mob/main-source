using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sentry.Internal
{
	internal class Signal : IDisposable
	{
		private readonly object _lock = new object();

		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0, 1);

		public Signal(bool isReleasedInitially = false)
		{
			if (isReleasedInitially)
			{
				Release();
			}
		}

		public void Release()
		{
			lock (_lock)
			{
				if (_semaphore.CurrentCount < 1)
				{
					_semaphore.Release();
				}
			}
		}

		public Task WaitAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return _semaphore.WaitAsync(cancellationToken);
		}

		public void Dispose()
		{
			_semaphore.Dispose();
		}
	}
}
