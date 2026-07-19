using System;
using System.Threading.Tasks;

namespace DepthFirstScheduler
{
	public static class SchedulableExtensions
	{
		public static void Subscribe<T>(this Schedulable<T> schedulable, IScheduler scheduler, Action<T> onCompleted, Action<Exception> onError)
		{
			schedulable.ContinueWith(scheduler, onCompleted);
			TaskChain.Schedule(schedulable.GetRoot(), onError);
		}

		public static Task<T> ToTask<T>(this Schedulable<T> schedulable)
		{
			return schedulable.ToTask(Scheduler.MainThread);
		}

		public static Task<T> ToTask<T>(this Schedulable<T> schedulable, IScheduler scheduler)
		{
			TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
			schedulable.Subscribe(scheduler, delegate(T r)
			{
				tcs.TrySetResult(r);
			}, delegate(Exception ex)
			{
				tcs.TrySetException(ex);
			});
			return tcs.Task;
		}
	}
}
