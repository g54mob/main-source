using System.Collections.Generic;
using UnityEngine;

public class Profiling
{
	public static bool enabled;

	private static Stack<float> testTimes = new Stack<float>();

	public static void Enable()
	{
		enabled = true;
	}

	public static void Disable()
	{
		enabled = false;
	}

	public static void BeginTest()
	{
		if (enabled)
		{
			testTimes.Push(Time.realtimeSinceStartup);
		}
	}

	public static void EndTest(string message)
	{
		if (enabled && testTimes.Count > 0)
		{
			float num = testTimes.Pop();
			Debug.Log(message + " : " + (Time.realtimeSinceStartup - num));
		}
	}
}
