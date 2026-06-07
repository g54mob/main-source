using System;
using System.Text;
using BestHTTP.PlatformSupport.IL2CPP;

namespace BestHTTP.Logger
{
	[Il2CppEagerStaticClassConstruction]
	internal struct LogJob
	{
		private static string[] LevelStrings;

		public Loglevels level;

		public string division;

		public string msg;

		public Exception ex;

		public DateTime time;

		public int threadId;

		public string stackTrace;

		public LoggingContext context1;

		public LoggingContext context2;

		public LoggingContext context3;

		private string WrapInColor(string str, string color)
		{
			return null;
		}

		public string ToJson(StringBuilder sb)
		{
			return null;
		}

		private void ProcessStackTrace(StringBuilder sb)
		{
		}
	}
}
