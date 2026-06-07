using System.Diagnostics;

namespace Coherence
{
	internal static class ProcessUtil
	{
		public static Process RunOutsideTerminal(string executable, string arguments)
		{
			return null;
		}

		public static string CommandFromExecutableAndArguments(string executable, string arguments)
		{
			return null;
		}

		public static Process RunInTerminal(string command)
		{
			return null;
		}

		public static Process RunInTerminal(string command, string projectPath)
		{
			return null;
		}

		public static int RunProcess(string application, string arguments, out string output, out string errors, int waitTimeMs = 5000)
		{
			output = null;
			errors = null;
			return 0;
		}

		[Conditional("UNITY_EDITOR_OSX")]
		[Conditional("UNITY_EDITOR_LINUX")]
		public static void FixUnixPermissions(string path)
		{
		}
	}
}
