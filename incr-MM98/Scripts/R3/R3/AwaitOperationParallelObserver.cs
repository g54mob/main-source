using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal abstract class AwaitOperationParallelObserver<T> : Observer<T>
	{
		private readonly CancellationTokenSource cancellationTokenSource;

		private readonly bool configureAwait;

		private readonly bool cancelOnCompleted;

		protected readonly object gate = new object();

		private int runningCount;

		private bool completed;

		protected sealed override bool AutoDisposeOnCompleted => false;

		public AwaitOperationParallelObserver(bool configureAwait, bool cancelOnCompleted)
		{
			cancellationTokenSource = new CancellationTokenSource();
			this.configureAwait = configureAwait;
			this.cancelOnCompleted = cancelOnCompleted;
		}

		protected sealed override void OnNextCore(T value)
		{
			Interlocked.Increment(ref runningCount);
			StartAsync(value);
		}

		protected sealed override void OnCompletedCore(Result result)
		{
			if (cancelOnCompleted || result.IsFailure)
			{
				cancellationTokenSource.Cancel();
				PublishOnCompleted(result);
				Dispose();
				return;
			}
			Volatile.Write(ref completed, value: true);
			if (Volatile.Read(ref runningCount) == 0)
			{
				PublishOnCompleted(result);
				Dispose();
			}
		}

		protected override void DisposeCore()
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
				if (Interlocked.Decrement(ref runningCount) == 0 && Volatile.Read(ref completed))
				{
					PublishOnCompleted(Result.Success);
					Dispose();
				}
			}
		}
	}
}
