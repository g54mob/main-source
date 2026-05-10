using System.Diagnostics;

namespace LiteNetLib
{
	public static class NetDebug
	{
		public static INetLogger Logger;

		private static readonly object DebugLogLock;

		private static void WriteLogic(NetLogLevel logLevel, string str, params object[] args)
		{
		}

		[Conditional("DEBUG_MESSAGES")]
		internal static void Write(string str, params object[] args)
		{
		}

		[Conditional("DEBUG_MESSAGES")]
		internal static void Write(NetLogLevel level, string str, params object[] args)
		{
		}

		[Conditional("DEBUG")]
		[Conditional("DEBUG_MESSAGES")]
		internal static void WriteForce(string str, params object[] args)
		{
		}

		[Conditional("DEBUG")]
		[Conditional("DEBUG_MESSAGES")]
		internal static void WriteForce(NetLogLevel level, string str, params object[] args)
		{
		}

		internal static void WriteError(string str, params object[] args)
		{
		}
	}
}
