using System;

namespace UniRx
{
	public static class OptimizedObservableExtensions
	{
		public static bool IsRequiredSubscribeOnCurrentThread<T>(this IObservable<T> source)
		{
			if (!(source is IOptimizedObservable<T> optimizedObservable))
			{
				return true;
			}
			return optimizedObservable.IsRequiredSubscribeOnCurrentThread();
		}

		public static bool IsRequiredSubscribeOnCurrentThread<T>(this IObservable<T> source, IScheduler scheduler)
		{
			if (scheduler == Scheduler.CurrentThread)
			{
				return true;
			}
			return source.IsRequiredSubscribeOnCurrentThread();
		}
	}
}
