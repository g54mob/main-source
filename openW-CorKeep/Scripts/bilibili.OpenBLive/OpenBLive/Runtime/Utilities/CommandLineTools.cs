using System;

namespace OpenBLive.Runtime.Utilities
{
	public static class CommandLineTools
	{
		private const string k_CodeIdArgs = "code=";

		public static string GetCodeViaCmdLineArgs()
		{
			string result = "";
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			foreach (string text in commandLineArgs)
			{
				if (text.Contains("code="))
				{
					result = text.Substring("code=".Length, text.Length - "code=".Length);
				}
			}
			return result;
		}
	}
}
