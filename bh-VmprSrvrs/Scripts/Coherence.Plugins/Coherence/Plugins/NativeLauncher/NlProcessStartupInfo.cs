using System.Collections.Generic;

namespace Coherence.Plugins.NativeLauncher
{
	public class NlProcessStartupInfo
	{
		public string ExecutablePath { get; private set; }

		public List<string> Arguments { get; private set; }

		public Dictionary<string, string> EnvironmentVariables { get; private set; }

		public bool RaiseOnExit { get; set; }

		public NlProcessStartupInfo(string executablePath, string arguments)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public string[] EnvironmentVariablesToArray()
		{
			return null;
		}

		private static List<string> ConvertToArgumentList(string arguments)
		{
			return null;
		}

		private static string GetNextArgument(string arguments, ref int i)
		{
			return null;
		}
	}
}
