using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;

namespace Amazon.Runtime.Internal
{
	public static class AsyncRunner
	{
		public static Task Run(Action action, CancellationToken cancellationToken)
		{
			return Run(delegate
			{
				action();
				return (object)null;
			}, cancellationToken);
		}

		public static Task<T> Run<T>(Func<T> action, CancellationToken cancellationToken)
		{
			return Task.Run(async delegate
			{
				Exception exception = null;
				T result = default(T);
				SemaphoreSlim semaphore = new SemaphoreSlim(0);
				try
				{
					Thread thread = new Thread((ThreadStart)delegate
					{
						try
						{
							result = action();
						}
						catch (Exception ex)
						{
							exception = ex;
						}
						finally
						{
							semaphore.Release();
						}
					});
					thread.Start();
					await semaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
					thread.Join();
					if (exception != null)
					{
						cancellationToken.ThrowIfCancellationRequested();
						ExceptionDispatchInfo.Capture(exception).Throw();
					}
					return result;
				}
				finally
				{
					if (semaphore != null)
					{
						((IDisposable)semaphore).Dispose();
					}
				}
			}, cancellationToken);
		}
	}
}
