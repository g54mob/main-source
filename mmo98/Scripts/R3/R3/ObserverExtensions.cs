using System;

namespace R3
{
	public static class ObserverExtensions
	{
		public static void OnCompleted<T>(this Observer<T> observer)
		{
			observer.OnCompleted(Result.Success);
		}

		public static void OnCompleted<T>(this Observer<T> observer, Exception exception)
		{
			observer.OnCompleted(Result.Failure(exception));
		}

		public static Observer<T> Wrap<T>(this Observer<T> observer)
		{
			return new WrappedObserver<T>(observer);
		}

		public static Observer<T> ToObserver<T>(this IObserver<T> observer)
		{
			return new IObserverToObserver<T>(observer);
		}
	}
}
