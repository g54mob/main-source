using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal abstract class AwaitOperationDropObserver<T> : Observer<T>
	{
		private readonly CancellationTokenSource cancellationTokenSource;

		private readonly bool configureAwait;

		private readonly bool cancelOnCompleted;

		private int runningState;

		protected sealed override bool AutoDisposeOnCompleted => false;

		public AwaitOperationDropObserver(bool configureAwait, bool cancelOnCompleted)
		{
			cancellationTokenSource = new CancellationTokenSource();
			this.configureAwait = configureAwait;
			this.cancelOnCompleted = cancelOnCompleted;
		}

		protected sealed override void OnNextCore(T value)
		{
			if (Interlocked.CompareExchange(ref runningState, 1, 0) == 0)
			{
				StartAsync(value);
			}
		}

		protected sealed override void OnCompletedCore(Result result)
		{
			if (cancelOnCompleted || result.IsFailure)
			{
				cancellationTokenSource.Cancel();
				PublishOnCompleted(result);
				Dispose();
			}
			else if (Interlocked.Exchange(ref runningState, 2) == 0)
			{
				PublishOnCompleted(result);
				Dispose();
			}
		}

		protected sealed override void DisposeCore()
		{
			cancellationTokenSource.Cancel();
		}

		protected abstract ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait);

		protected abstract void PublishOnCompleted(Result result);

		private async void StartAsync(T value)
		{
			try
			{
				await OnNextAsync(value, cancellationTokenSource.Token, configureAwait).ConfigureAwait(configureAwait);
			}
			catch (Exception ex)
			{
				if (!(ex is OperationCanceledException))
				{
					OnErrorResume(ex);
				}
			}
			finally
			{
				if (Interlocked.CompareExchange(ref runningState, 0, 1) == 2)
				{
					PublishOnCompleted(Result.Success);
					Dispose();
				}
			}
		}
	}
}
