using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.Utility
{
	public class UnityLogger : ILogHandler
	{
		private List<ILogHandler> handlers;

		private static UnityLogger _instance;

		public UnityConsole console { get; private set; }

		public static UnityLogger instance => null;

		public static void Init()
		{
		}

		public static void RegisterHandler(ILogHandler handler)
		{
		}

		public void LogException(Exception exception, UnityEngine.Object context)
		{
		}

		public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
		{
		}
	}
}
