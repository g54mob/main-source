using System;
using System.Linq;

namespace NSMedieval.Utils
{
	public static class ArgumentParser
	{
		public static string GetArg(string name)
		{
			return Environment.GetCommandLineArgs().FirstOrDefault((string arg) => arg == name);
		}

		public static string GetArgValue(string name)
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				if (commandLineArgs[i] == name && commandLineArgs.Length > i + 1)
				{
					return commandLineArgs[i + 1];
				}
			}
			return null;
		}
	}
}
