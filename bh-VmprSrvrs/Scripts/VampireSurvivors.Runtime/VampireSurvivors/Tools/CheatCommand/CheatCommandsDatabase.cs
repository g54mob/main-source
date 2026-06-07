using System.Collections.Generic;
using System.Reflection;

namespace VampireSurvivors.Tools.CheatCommand
{
	internal static class CheatCommandsDatabase
	{
		private static Dictionary<string, MethodInfo> _methodInfoCache;

		public static void ExecuteCommand(string methodName, params string[] args)
		{
		}

		internal static void RegisterCommands(Dictionary<string, MethodInfo> commands = null)
		{
		}
	}
}
