using System;
using System.Reflection;

namespace Coherence.Plugins.NativeUtils
{
	[Serializable]
	public class ThreadResumerSettings
	{
		internal static bool SteamDetected;

		public bool Enabled;

		public uint SearchIntervalMs;

		public uint LongSearchWarnThresholdMs;

		public bool WarnOnSuspension;

		private static void DetectSteam()
		{
		}

		private static bool HasSteamWorksDotNet()
		{
			return false;
		}

		private static bool HasFacePunchSteamworks()
		{
			return false;
		}

		private static Assembly TryLoadAssembly(string name)
		{
			return null;
		}

		private static bool AssemblyHasSteamManagerType(Assembly assembly)
		{
			return false;
		}
	}
}
