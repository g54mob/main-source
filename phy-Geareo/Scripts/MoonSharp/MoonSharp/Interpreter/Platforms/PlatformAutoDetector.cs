using MoonSharp.Interpreter.Loaders;

namespace MoonSharp.Interpreter.Platforms
{
	public static class PlatformAutoDetector
	{
		private static bool? m_IsRunningOnAOT;

		private static bool m_AutoDetectionsDone;

		public static bool IsRunningOnMono { get; private set; }

		public static bool IsRunningOnClr4 { get; private set; }

		public static bool IsRunningOnUnity { get; private set; }

		public static bool IsPortableFramework { get; private set; }

		public static bool IsUnityNative { get; private set; }

		public static bool IsUnityIL2CPP { get; private set; }

		public static bool IsRunningOnAOT => false;

		private static void AutoDetectPlatformFlags()
		{
		}

		internal static IPlatformAccessor GetDefaultPlatform()
		{
			return null;
		}

		internal static IScriptLoader GetDefaultScriptLoader()
		{
			return null;
		}
	}
}
