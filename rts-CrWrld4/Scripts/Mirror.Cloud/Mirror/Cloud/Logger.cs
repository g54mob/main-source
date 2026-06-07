using UnityEngine.Networking;

namespace Mirror.Cloud
{
	public static class Logger
	{
		public static bool VerboseLogging;

		public static void LogRequest(string page, string method, bool hasJson, string json)
		{
		}

		public static void LogResponse(UnityWebRequest statusRequest)
		{
		}

		internal static void Log(string msg)
		{
		}

		internal static void LogWarning(string msg)
		{
		}

		internal static void LogError(string msg)
		{
		}

		internal static void Verbose(string msg)
		{
		}
	}
}
