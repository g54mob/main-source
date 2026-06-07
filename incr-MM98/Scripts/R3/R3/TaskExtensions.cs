using System.Threading;
using System.Threading.Tasks;

namespace R3
{
	internal static class TaskExtensions
	{
		internal static Task<T> WaitAsync<T>(this Task<T> task, CancellationToken cancellationToken)
		{
			TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
			CancellationTokenRegistration registration = cancellationToken.Register(delegate
			{
				tcs.TrySetCanceled(cancellationToken);
			});
			task.ContinueWith(delegate(Task<T> t)
			{
				registration.Dispose();
				if (t.IsFaulted)
				{
					tcs.TrySetException(t.Exception.InnerExceptions);
				}
				else if (t.IsCanceled)
				{
					tcs.TrySetCanceled(cancellationToken);
				}
				else
				{
					tcs.TrySetResult(t.Result);
				}
			}, TaskScheduler.Default);
			return tcs.Task;
		}
	}
}
