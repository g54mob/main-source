using System;
using UnityEngine;

namespace Rhizomatic.LoggyLogger
{
	public class LoggyUnityLogHandler : ILogHandler
	{
		public static LoggyUnityLogHandler instance { get; private set; }

		public void LogException(Exception exception, UnityEngine.Object context)
		{
		}

		public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
		{
		}
	}
}
