using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal abstract class AwaitOperationParallelConcurrentLimitObserver<T> : Observer<T>
	{
		private readonly CancellationTokenSource cancellationTokenSource;

		protected readonly object gate;

		private int runningCount;

		private bool completed;

		private Queue<T> queue;

		protected sealed override bool AutoDisposeOnCompleted => false;

		protected AwaitOperationParallelConcurrentLimitObserver(bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
		{
			_003CconfigureAwait_003EP = configureAwait;
			_003CcancelOnCompleted_003EP = cancelOnCompleted;
			_003CmaxConcurrent_003EP = maxConcurrent;
			cancellationTokenSource = new CancellationTokenSource();
			gate = new object();
			queue = new Queue<T>();
			base._002Ector();
		}

		protected sealed override void OnNextCore(T value)
		{
			lock (gate)
			{
				if (runningCount < _003CmaxConcurrent_003EP)
				{
					runningCount++;
					StartAsync(value);
				}
				else
				{
					queue.Enqueue(value);
				}
			}
		}

		protected sealed override void OnCompletedCore(Result result)
		{
			if (_003CcancelOnCompleted_003EP || result.IsFailure)
			{
				cancellationTokenSource.Cancel();
				PublishOnCompleted(result);
				Dispose();
				return;
			}
			lock (gate)
			{
				completed = true;
				if (runningCount == 0 && queue.Count == 0)
				{
					PublishOnCompleted(result);
					Dispose();
				}
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
				await OnNextAsync(value, cancellationTokenSource.Token, _003CconfigureAwait_003EP).ConfigureAwait(_003CconfigureAwait_003EP);
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
				lock (gate)
				{
					runningCount--;
					if (runningCount == 0 && queue.Count == 0 && completed)
					{
						PublishOnCompleted(Result.Success);
						Dispose();
					}
					else if (runningCount < _003CmaxConcurrent_003EP && queue.Count != 0)
					{
						runningCount++;
						StartAsync(queue.Dequeue());
					}
				}
			}
		}
	}
}
