using System;

public static class TimeSpanDefault
{
	public static readonly TimeSpan TenthSecond = TimeSpan.FromMilliseconds(100.0);

	public static readonly TimeSpan HalfSecond = TimeSpan.FromMilliseconds(500.0);

	public static readonly TimeSpan Second = TimeSpan.FromSeconds(1.0);

	public static readonly TimeSpan Minute = TimeSpan.FromMinutes(1.0);

	public static readonly TimeSpan Hour = TimeSpan.FromHours(1.0);
}
