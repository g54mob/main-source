using System;
using UnityEngine;

public static class Epoch
{
	public static int Current()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return (int)(DateTime.UtcNow - dateTime).TotalSeconds;
	}

	public static int SecondsElapsed(int t1)
	{
		return Mathf.Abs(Current() - t1);
	}

	public static int SecondsElapsed(int t1, int t2)
	{
		return Mathf.Abs(t1 - t2);
	}
}
