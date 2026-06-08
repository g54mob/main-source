using System.Diagnostics;
using UnityEngine;

public class PlatformServicesLogger
{
	public const string LOGGING_DEFINE = "PLATFORM_LOGGING";

	[Conditional("PLATFORM_LOGGING")]
	public static void Log(object message)
	{
		UnityEngine.Debug.Log(message);
	}

	[Conditional("PLATFORM_LOGGING")]
	public static void Log(object message, Object context)
	{
		UnityEngine.Debug.Log(message, context);
	}

	[Conditional("PLATFORM_LOGGING")]
	public static void LogWarning(object message)
	{
		UnityEngine.Debug.LogWarning(message);
	}

	[Conditional("PLATFORM_LOGGING")]
	public static void LogWarning(object message, Object context)
	{
		UnityEngine.Debug.LogWarning(message, context);
	}

	[Conditional("PLATFORM_LOGGING")]
	public static void LogError(object message)
	{
		UnityEngine.Debug.LogError(message);
	}

	[Conditional("PLATFORM_LOGGING")]
	public static void LogError(object message, Object context)
	{
		UnityEngine.Debug.Log(message, context);
	}
}
