using UnityEngine;

namespace Assets.Scripts.Utility;

public static class MyLogger
{
	public static void Log(string s, GameObject context = null)
	{
	}

	public static void LogInBuild(string s, GameObject context = null)
	{
		if (!(context == null))
		{
			Debug.Log(s, context);
		}
		else
		{
			Debug.Log(s);
		}
	}

	public static void LogError(string s, GameObject context = null)
	{
	}

	public static void LogErrorInBuild(string s, GameObject context = null)
	{
		if (!(context == null))
		{
			Debug.LogError(s, context);
		}
		else
		{
			Debug.LogError(s);
		}
	}
}
