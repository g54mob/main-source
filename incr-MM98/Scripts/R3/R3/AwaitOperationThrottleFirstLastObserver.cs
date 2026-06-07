using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using R3.Internal;

namespace R3
{
	internal abstract class AwaitOperationThrottleFirstLastObserver<T> : Observer<T>
	{
		private readonly CancellationTokenSource cancellationTokenSource;

		private readonly bool configureAwait;

		private readonly bool cancelOnCompleted;

		private readonly Channel<T> channel;

		private bool completed;

		protected override bool AutoDisposeOnCompleted => false;

		public AwaitOperationThrottleFirstLastObserver(bool configureAwait, bool cancelOnCompleted)
		{
			cancellationTokenSource = new CancellationTokenSource();
			this.configureAwait = configureAwait;
			this.cancelOnCompleted = cancelOnCompleted;
			channel = ChannelUtility.CreateSingleReadeWriterSingularBounded<T>();
			RunQueueWorker();
		}

		protected sealed override void OnNextCore(T value)
		{
			channel.Writer.TryWrite(value);
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

		protected abstract ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait);

		protected abstract void PublishOnCompleted(Result result);

		private async void RunQueueWorker()
		{
			ChannelReader<T> reader = channel.Reader;
			CancellationToken token = cancellationTokenSource.Token;
			try
			{
				while (await reader.WaitToReadAsync().ConfigureAwait(configureAwait))
				{
					T item;
					while (reader.TryRead(out item))
					{
						try
						{
							if (token.IsCancellationRequested)
							{
								return;
							}
							await OnNextAsync(item, token, configureAwait).ConfigureAwait(configureAwait);
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
