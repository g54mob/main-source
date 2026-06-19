using System;
using UnityEngine;

namespace TH20
{
	public class RepeatToUnityLogHandler : ILogHandler
	{
		[StackTraceIgnore]
		void ILogHandler.Log(LogEntry logEntry)
		{
			switch (logEntry.Level)
			{
			case LogLevel.Verbose:
			case LogLevel.Debug:
			case LogLevel.Information:
			case LogLevel.AlwaysLog:
				UnityEngine.Debug.Log(logEntry.Message, logEntry.RelatedUnityObject);
				break;
			case LogLevel.Warning:
				UnityEngine.Debug.LogWarning("WARNING: " + logEntry.Message, logEntry.RelatedUnityObject);
				break;
			case LogLevel.Error:
				UnityEngine.Debug.LogError("ERROR: " + logEntry.Message, logEntry.RelatedUnityObject);
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		bool ILogHandler.RequestsCallstackAtLevel(LogLevel logLevel)
		{
			return false;
		}
	}
}
