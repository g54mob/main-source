using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public static class WaitFor
{
	public static readonly WaitForEndOfFrame EndOfFrame = new WaitForEndOfFrame();

	public static readonly WaitForFixedUpdate FixedUpdate = new WaitForFixedUpdate();

	private static readonly Dictionary<float, WaitForSeconds> secondsCache = new Dictionary<float, WaitForSeconds>();

	public static WaitForSeconds Seconds(float seconds)
	{
		if (!secondsCache.TryGetValue(seconds, out var value))
		{
			return secondsCache[seconds] = new WaitForSeconds(seconds);
		}
		return value;
	}

	public static ReusableWaitForSecondsRealtime SecondsRealtime(float seconds)
	{
		return ReusableWaitForSecondsRealtime.New(seconds);
	}
}
