using System.Diagnostics;

namespace MagicaCloth2
{
	public static class Develop
	{
		public static void Log(in object mes)
		{
		}

		public static void LogWarning(in object mes)
		{
		}

		public static void LogError(in object mes)
		{
		}

		[Conditional("MC2_LOG")]
		public static void DebugLog(in object mes)
		{
		}

		[Conditional("MC2_DEBUG")]
		public static void DebugLogWarning(in object mes)
		{
		}

		[Conditional("MC2_DEBUG")]
		public static void DebugLogError(in object mes)
		{
		}

		[Conditional("MC2_DEBUG")]
		public static void Assert(bool condition)
		{
		}
	}
}
