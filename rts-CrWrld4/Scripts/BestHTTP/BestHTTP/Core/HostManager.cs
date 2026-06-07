using System.Collections.Generic;

namespace BestHTTP.Core
{
	internal static class HostManager
	{
		private const int Version = 1;

		private static string LibraryPath;

		private static bool IsSaveAndLoadSupported;

		private static bool IsLoaded;

		private static Dictionary<string, HostDefinition> hosts;

		public static HostDefinition GetHost(string hostStr)
		{
			return null;
		}

		public static void TryToSendQueuedRequests()
		{
		}

		public static void Shutdown()
		{
		}

		public static void Clear()
		{
		}

		private static void SetupFolder()
		{
		}

		public static void Save()
		{
		}

		public static void Load()
		{
		}
	}
}
