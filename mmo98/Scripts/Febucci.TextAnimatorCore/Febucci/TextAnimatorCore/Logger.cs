using System.Diagnostics;
using Febucci.GameEnginesBridge;

namespace Febucci.TextAnimatorCore
{
	internal static class Logger
	{
		public const string CONDITIONAL_DEBUG_STRING = "DEBUG_TEXT_ANIMATOR";

		private const string PREFIX = "[TextAnimatorCore]";

		public static void LogError(string what)
		{
			EngineWrapper.LogError("[TextAnimatorCore] " + what);
		}

		public static void LogWarning(string what)
		{
			EngineWrapper.LogWarning("[TextAnimatorCore] " + what);
		}

		public static void Log(string what)
		{
			EngineWrapper.Log("[TextAnimatorCore] " + what);
		}

		[Conditional("DEBUG_TEXT_ANIMATOR")]
		public static void Debug(string what)
		{
			EngineWrapper.Log("[TextAnimatorCore] " + what);
		}
	}
}
