using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using R3.Internal;

namespace R3
{
	internal abstract class AwaitOperationSequentialParallelConcurrentLimitObserver<T, TTaskValue> : Observer<T>
	{
		private readonly CancellationTokenSource cancellationTokenSource;

		private readonly bool configureAwait;

		private readonly bool cancelOnCompleted;

		private readonly int maxConcurrent;

		private readonly object gate = new object();

		private readonly Channel<(T, ValueTask<TTaskValue>)> channel;

		private bool completed;

		private int runningCount;

		private Queue<T> queue = new Queue<T>();

		protected sealed override bool AutoDisposeOnCompleted => false;

		public AwaitOperationSequentialParallelConcurrentLimitObserver(bool configureAwait, bool cancelOnCompleted, int maxConcurrent)
		{
			cancellationTokenSource = new CancellationTokenSource();
			this.configureAwait = configureAwait;
			this.cancelOnCompleted = cancelOnCompleted;
			this.maxConcurrent = maxConcurrent;
			channel = ChannelUtility.CreateSingleReadeWriterUnbounded<(T, ValueTask<TTaskValue>)>();
			RunQueueWorker();
		}

		protected sealed override void OnNextCore(T value)
		{
			lock (gate)
			{
				if (runningCount < maxConcurrent)
				{
					runningCount++;
					ValueTask<TTaskValue> item = OnNextTaskAsync(value);
					channel.Writer.TryWrite((value, item));
				}
				else
				{
					queue.Enqueue(value);
				}
			}
		}

		protected sealed override void OnCompletedCore(Result result)
		{
			if (cancelOnCompleted || result.IsFailure)
			{
				channel.Writer.TryComplete();
				cancellationTokenSource.Cancel();
				PublishOnCompleted(result);
				Dispose();
				return;
			}
			lock (gate)
			{
				completed = true;
				if (queue.Count == 0)
				{
					channel.Writer.TryComplete();
				}
			}
		}

		protected sealed override void DisposeCore()
		{
			channel.Writer.TryComplete();
			cancellationTokenSource.Cancel();
		}

		protected abstract ValueTask<TTaskValue> OnNextTaskAsyncCore(T value, CancellationToken cancellationToken, bool configureAwait);

		protected abstract void PublishOnNext(T value, TTaskValue result);

		protected abstract void PublishOnCompleted(Result result);

		private async ValueTask<TTaskValue> OnNextTaskAsync(T value)
		{
			TTaskValue result = await OnNextTaskAsyncCore(value, cancellationTokenSource.Token, configureAwait).ConfigureAwait(configureAwait);
			lock (gate)
			{
				runningCount--;
				if (runningCount < maxConcurrent && queue.Count != 0)
				{
					runningCount++;
					T val = queue.Dequeue();
					ValueTask<TTaskValue> item = OnNextTaskAsync(val);
					channel.Writer.TryWrite((val, item));
				}
			}
			return result;
		}

		private async void RunQueueWorker()
		{
			ChannelReader<(T, ValueTask<TTaskValue>)> reader = channel.Reader;
			CancellationToken token = cancellationTokenSource.Token;
			try
			{
				while (await reader.WaitToReadAsync().ConfigureAwait(configureAwait))
				{
					(T, ValueTask<TTaskValue>) item;
					while (reader.TryRead(out item))
					{
						try
						{
							if (token.IsCancellationRequested)
							{
								return;
							}
							TTaskValue result = await item.Item2.ConfigureAwait(configureAwait);
							PublishOnNext(item.Item1, result);
						}
						catch (Exception ex)
						{
							if (ex is OperationCanceledException)
							{
								return;
							}
							OnErrorResume(ex);
						}
					}
					lock (gate)
					{
						if (queue.Count == 0 && completed)
						{
							channel.Writer.TryComplete();
						}
					}
				}
				lock (gate)
				{
					if (completed)
					{
						PublishOnCompleted(Result.Success);
						Dispose();
					}
				}
			}
			catch (Exception ex2) when (!(ex2 is OperationCanceledException))
			{
				ObservableSystem.GetUnhandledExceptionHandler()(ex2);
			}
		}
	}
}
