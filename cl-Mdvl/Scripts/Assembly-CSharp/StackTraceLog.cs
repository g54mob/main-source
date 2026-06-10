using System.Diagnostics;
using System.Text;
using UnityEngine;

public class StackTraceLog
{
	private static string logFilePath;

	private static readonly StringBuilder StringBuilder = new StringBuilder(4096);

	private static readonly StackTraceLog logger = new StackTraceLog();

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void OnDomainReload()
	{
		StringBuilder.Clear();
		logFilePath = null;
	}

	public static string GetStackTrace()
	{
		StackTrace stackTrace = new StackTrace();
		return "Stack Trace: " + stackTrace.ToString();
	}

	public static void Log()
	{
	}

	public static void Log(string note)
	{
	}

	public static void LogMessageOnly(string note)
	{
	}
}
