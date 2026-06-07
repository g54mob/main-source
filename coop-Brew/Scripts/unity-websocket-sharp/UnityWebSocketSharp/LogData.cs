using System;
using System.Diagnostics;

namespace UnityWebSocketSharp
{
	internal class LogData
	{
		private StackFrame _caller;

		private DateTime _date;

		private LogLevel _level;

		private string _message;

		public StackFrame Caller => null;

		public DateTime Date => default(DateTime);

		public LogLevel Level => default(LogLevel);

		public string Message => null;

		internal LogData(LogLevel level, StackFrame caller, string message)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
