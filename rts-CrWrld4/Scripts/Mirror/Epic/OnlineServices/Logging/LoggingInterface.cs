using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Logging
{
	public static class LoggingInterface
	{
		public static Result SetCallback(LogMessageFunc callback)
		{
			return default(Result);
		}

		public static Result SetLogLevel(LogCategory logCategory, LogLevel logLevel)
		{
			return default(Result);
		}

		internal static void LogMessageFuncInternalImplementation(IntPtr message)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_Logging_SetCallback(LogMessageFuncInternal callback);

		[PreserveSig]
		internal static extern Result EOS_Logging_SetLogLevel(LogCategory logCategory, LogLevel logLevel);
	}
}
