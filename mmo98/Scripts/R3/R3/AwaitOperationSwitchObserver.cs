using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal abstract class AwaitOperationSwitchObserver<T> : Observer<T>
	{
		private CancellationTokenSource cancellationTokenSource;

		private readonly bool configureAwait;

		private readonly bool cancelOnCompleted;

		protected readonly object gate = new object();

		private bool running;

		private bool completed;

		protected sealed override bool AutoDisposeOnCompleted => false;

		public AwaitOperationSwitchObserver(bool configureAwait, bool cancelOnCompleted)
		{
			cancellationTokenSource = new CancellationTokenSource();
			this.configureAwait = configureAwait;
			this.cancelOnCompleted = cancelOnCompleted;
		}

		protected sealed override void OnNextCore(T value)
		{
			CancellationToken token = cancellationTokenSource.Token;
			lock (gate)
			{
				if (running)
				{
					if (base.IsDisposed)
					{
						return;
					}
					cancellationTokenSource.Cancel();
					cancellationTokenSource = new CancellationTokenSource();
					token = cancellationTokenSource.Token;
				}
				running = true;
			}
			StartAsync(value, token);
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
			lock (gate)
			{
				if (running)
				{
					completed = true;
					return;
				}
				PublishOnCompleted(result);
				Dispose();
			}
		}

		protected override void DisposeCore()
		{
			lock (gate)
			{
				cancellationTokenSource.Cancel();
			}
		}

		protected abstract ValueTask OnNextAsync(T value, CancellationToken cancellationToken, bool configureAwait);

		protected abstract void PublishOnCompleted(Result result);

		private async void StartAsync(T value, CancellationToken token)
		{
			try
			{
				await OnNextAsync(value, token, configureAwait).ConfigureAwait(configureAwait);
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
					if (!token.IsCancellationRequested)
					{
						running = false;
						if (completed)
						{
							PublishOnCompleted(Result.Success);
							Dispose();
						}
					}
				}
			}
		}
	}
}
