using R3;

public static class ObservableThrottleExtensions
{
	public static Observable<T> ThrottleFirstTenthSecond<T>(this Observable<T> source)
	{
		return source.ThrottleFirst(TimeSpanDefault.TenthSecond);
	}

	public static Observable<T> ThrottleFirstHalfSecond<T>(this Observable<T> source)
	{
		return source.ThrottleFirst(TimeSpanDefault.HalfSecond);
	}

	public static Observable<T> ThrottleFirstSecond<T>(this Observable<T> source)
	{
		return source.ThrottleFirst(TimeSpanDefault.Second);
	}

	public static Observable<T> ThrottleLastTenthSecond<T>(this Observable<T> source)
	{
		return source.ThrottleLast(TimeSpanDefault.TenthSecond);
	}

	public static Observable<T> ThrottleLastHalfSecond<T>(this Observable<T> source)
	{
		return source.ThrottleLast(TimeSpanDefault.HalfSecond);
	}

	public static Observable<T> ThrottleLastSecond<T>(this Observable<T> source)
	{
		return source.ThrottleLast(TimeSpanDefault.Second);
	}

	public static Observable<T> ThrottleFirstLastTenthSecond<T>(this Observable<T> source)
	{
		return source.ThrottleFirstLast(TimeSpanDefault.TenthSecond);
	}

	public static Observable<T> ThrottleFirstLastHalfSecond<T>(this Observable<T> source)
	{
		return source.ThrottleFirstLast(TimeSpanDefault.HalfSecond);
	}

	public static Observable<T> ThrottleFirstLastSecond<T>(this Observable<T> source)
	{
		return source.ThrottleFirstLast(TimeSpanDefault.Second);
	}
}
