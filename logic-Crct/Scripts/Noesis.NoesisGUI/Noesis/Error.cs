using System;

namespace Noesis
{
	public class Error
	{
		private static UnhandledExceptionCallback _unhandledCallback;

		public static void SetUnhandledCallback(UnhandledExceptionCallback callback)
		{
		}

		public static void UnhandledException(Exception exception)
		{
		}
	}
}
