using System;

public static class SystemTime
{
	private static double _timeAtLaunch = time;

	public static double time
	{
		get
		{
			return (double)DateTime.UtcNow.Ticks * 1E-07;
		}
	}

	public static double timeSinceLaunch
	{
		get
		{
			return time - _timeAtLaunch;
		}
	}
}
