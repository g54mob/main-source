using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using R3.Internal;

namespace R3
{
	internal abstract class AwaitOperationSequentialParallelObserver<T, TTaskValue> : Observer<T>
	{
		private readonly CancellationTokenSource cancellationTokenSource;

		private readonly bool configureAwait;

		private readonly bool cancelOnCompleted;

		private readonly Channel<(T, ValueTask<TTaskValue>)> channel;

		private bool completed;

		protected sealed override bool AutoDisposeOnCompleted => false;

		public AwaitOperationSequentialParallelObserver(bool configureAwait, bool cancelOnCompleted)
		{
			cancellationTokenSource = new CancellationTokenSource();
			this.configureAwait = configureAwait;
			this.cancelOnCompleted = cancelOnCompleted;
			channel = ChannelUtility.CreateSingleReadeWriterUnbounded<(T, ValueTask<TTaskValue>)>();
			RunQueueWorker();
		}

		protected sealed override void OnNextCore(T value)
		{
			ValueTask<TTaskValue> item = OnNextTaskAsync(value, cancellationTokenSource.Token, configureAwait);
			channel.Writer.TryWrite((value, item));
		}

		protected sealed override void OnCompletedCore(Result result)
		{
			if (cancelOnCompleted || result.IsFailure)
			{
				channel.Writer.TryComplete();
				cancellationTokenSource.Cancel();
				PublishOnCompleted(result);
				Dispose();
			}
			else
			{
				Volatile.Write(ref completed, value: true);
				channel.Writer.TryComplete();
			}
		}

		protected sealed override void DisposeCore()
		{
			channel.Writer.TryComplete();
			cancellationTokenSource.Cancel();
		}

		protected abstract ValueTask<TTaskValue> OnNextTaskAsync(T value, CancellationToken cancellationToken, bool configureAwait);

		protected abstract void PublishOnNext(T value, TTaskValue result);

		protected abstract void PublishOnCompleted(Result result);

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
				}
				if (Volatile.Read(ref completed))
				{
					PublishOnCompleted(Result.Success);
					Dispose();
				}
			}
			catch (Exception ex2) when (!(ex2 is OperationCanceledException))
			{
				ObservableSystem.GetUnhandledExceptionHandler()(ex2);
			}
		}
	}
}
