using System;

namespace Alekrus.UnivarsalPlatform.Utilities
{
	public class PlatformDebugging
	{
		public delegate void DebugLogEventHandler(string parMessage);

		public static event DebugLogEventHandler OnLog;

		public static event DebugLogEventHandler OnLogWarning;

		public static event DebugLogEventHandler OnLogError;

		protected PlatformDebugging()
		{
		}

		public static void Log(DebugMessageType parMessageType, Type parType, string parMessage)
		{
			switch (parMessageType)
			{
			default:
				PlatformDebugging.OnLog?.Invoke(GetMessage(parType, parMessage));
				break;
			case DebugMessageType.Waring:
				PlatformDebugging.OnLogWarning?.Invoke(GetMessage(parType, parMessage));
				break;
			case DebugMessageType.Error:
				PlatformDebugging.OnLogError?.Invoke(GetMessage(parType, parMessage));
				break;
			}
		}

		public static void Log(Type parType, string parMessage)
		{
			PlatformDebugging.OnLog?.Invoke(GetMessage(parType, parMessage));
		}

		public static void LogWarning(Type parType, string parMessage)
		{
			PlatformDebugging.OnLogWarning?.Invoke(GetMessage(parType, parMessage));
		}

		public static void LogError(Type parType, string parMessage)
		{
			PlatformDebugging.OnLogError?.Invoke(GetMessage(parType, parMessage));
		}

		public static void Log(DebugMessageType parMessageType, Type parType, string parFunction, string parMessage)
		{
			switch (parMessageType)
			{
			default:
				PlatformDebugging.OnLog?.Invoke(GetMessage(parType, parFunction, parMessage));
				break;
			case DebugMessageType.Waring:
				PlatformDebugging.OnLogWarning?.Invoke(GetMessage(parType, parFunction, parMessage));
				break;
			case DebugMessageType.Error:
				PlatformDebugging.OnLogError?.Invoke(GetMessage(parType, parFunction, parMessage));
				break;
			}
		}

		public static void Log(Type parType, string parFunction, string parMessage)
		{
			PlatformDebugging.OnLog?.Invoke(GetMessage(parType, parFunction, parMessage));
		}

		public static void LogWarning(Type parType, string parFunction, string parMessage)
		{
			PlatformDebugging.OnLogWarning?.Invoke(GetMessage(parType, parFunction, parMessage));
		}

		public static void LogError(Type parType, string parFunction, string parMessage)
		{
			PlatformDebugging.OnLogError?.Invoke(GetMessage(parType, parFunction, parMessage));
		}

		public static string GetMessage(Type parType, string parFunction, string parMessage)
		{
			return "[" + parType.Name + "] " + parFunction + " : " + parMessage;
		}

		public static string GetMessage(Type parType, string parMessage)
		{
			return "[" + parType.Name + "] " + parMessage;
		}
	}
}
