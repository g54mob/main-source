using System;

namespace R3
{
	public static class SubjectExtensions
	{
		public static Observer<T> AsObserver<T>(this ISubject<T> subject)
		{
			return new SubjectToObserver<T>(subject);
		}

		public static void OnCompleted<T>(this ISubject<T> subject)
		{
			subject.OnCompleted(default(Result));
		}

		public static void OnCompleted<T>(this ISubject<T> subject, Exception exception)
		{
			subject.OnCompleted(Result.Failure(exception));
		}
	}
}
