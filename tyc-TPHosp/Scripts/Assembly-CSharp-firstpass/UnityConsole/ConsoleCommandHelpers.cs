using System;

namespace UnityConsole
{
	public static class ConsoleCommandHelpers
	{
		public static ConsoleCommandResult ExtractBool(Action<bool> action, params string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Expecting 1 argument");
			}
			if (!bool.TryParse(args[0], out var result))
			{
				if (!int.TryParse(args[0], out var result2))
				{
					return ConsoleCommandResult.Failed("Expecting 'true' or 'false', '0' or '1'");
				}
				result = result2 != 0;
			}
			action(result);
			return ConsoleCommandResult.Succeeded();
		}

		public static ConsoleCommandResult ExtractInt(Action<int> action, params string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Requires 1 argument");
			}
			if (!int.TryParse(args[0], out var result))
			{
				return ConsoleCommandResult.Failed("Argument (" + args[0] + ") is not a number");
			}
			action(result);
			return ConsoleCommandResult.Succeeded();
		}

		public static ConsoleCommandResult ExtractFloat(Action<float> action, params string[] args)
		{
			if (args.Length != 1)
			{
				return ConsoleCommandResult.Failed("Requires 1 argument");
			}
			if (!float.TryParse(args[0], out var result))
			{
				return ConsoleCommandResult.Failed("Argument (" + args[0] + ") is not a number");
			}
			action(result);
			return ConsoleCommandResult.Succeeded();
		}
	}
}
