using System;
using System.Diagnostics;
using UnityEngine;

namespace Rhizomatic.LoggyLogger
{
	public class Log
	{
		public LogLevel level;

		public string message;

		public bool includeStackTrace;

		public DateTime timestamp;

		public object data;

		public StackTrace stackTrace;

		public UnityEngine.Object context;

		public Exception exception;

		public Logger logger;

		public Log(Logger logger, LogLevel level, string message, bool includeStackTrace, object data)
		{
		}

		public string GetStackMessage(bool doubleNewLine = false)
		{
			return null;
		}
	}
}
