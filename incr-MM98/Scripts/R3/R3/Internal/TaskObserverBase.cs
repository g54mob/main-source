using System;
using System.Threading;
using System.Threading.Tasks;

namespace R3.Internal
{
	internal abstract class TaskObserverBase<T, TTask> : Observer<T>
	{
		private TaskCompletionSource<TTask> tcs;

		private CancellationToken cancellationToken;

		private CancellationTokenRegistration tokenRegistration;

		public Task<TTask> Task => tcs.Task;

		public TaskObserverBase(CancellationToken cancellationToken)
		{
			tcs = new TaskCompletionSource<TTask>();
			this.cancellationToken = cancellationToken;
			if (cancellationToken.CanBeCanceled)
			{
				tokenRegistration = cancellationToken.UnsafeRegister(delegate(object? state)
				{
					TaskObserverBase<T, TTask> taskObserverBase = (TaskObserverBase<T, TTask>)state;
					taskObserverBase.Dispose();
					taskObserverBase.tcs.TrySetCanceled(taskObserverBase.cancellationToken);
				}, this);
			}
		}

		protected override void DisposeCore()
		{
			tokenRegistration.Dispose();
		}

		protected void TrySetResult(TTask result)
		{
			try
			{
				tcs.TrySetResult(result);
			}
			finally
			{
				Dispose();
			}
		}

		protected void TrySetException(Exception exception)
		{
			try
			{
				tcs.TrySetException(exception);
			}
			finally
			{
				Dispose();
			}
		}
	}
}
