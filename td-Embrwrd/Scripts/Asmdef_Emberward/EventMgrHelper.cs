using System;
using System.Diagnostics;

public static class EventMgrHelper
{
	public static T SafeCast<T>(Enum key, IEventBase obj) where T : IEventBase
	{
		return default(T);
	}

	[Conditional("EventMgrDebug")]
	public static void Log(string message)
	{
	}

	public static void LogError(string message)
	{
	}

	public static void LogError(Exception e)
	{
	}
}
