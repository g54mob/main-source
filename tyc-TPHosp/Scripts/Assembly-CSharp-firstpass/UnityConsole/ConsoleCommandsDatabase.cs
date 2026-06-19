using System;
using System.Collections.Generic;
using System.Linq;

namespace UnityConsole
{
	public static class ConsoleCommandsDatabase
	{
		private static readonly Dictionary<string, ConsoleCommand> Database = new Dictionary<string, ConsoleCommand>(StringComparer.OrdinalIgnoreCase);

		public static IEnumerable<ConsoleCommand> Commands => from kv in Database
			orderby kv.Key
			select kv.Value;

		public static void RegisterCommand(string command, string description, string usage, ConsoleCommandCallback callback)
		{
		}

		public static void RegisterSimpleCommand(string command, string description, SimpleConsoleCommandCallback callback)
		{
		}

		public static void RegisterAlias(string command, string description, string actualCommand, params string[] actualCommandArgs)
		{
		}

		public static void UnRegisterCommand(string command)
		{
			Database.Remove(command);
		}

		public static ConsoleCommandResult ExecuteCommand(string command, params string[] args)
		{
			try
			{
				if (TryGetCommand(command, out var result))
				{
					return result.Callback(args);
				}
				return new ConsoleCommandResult
				{
					succeeded = true,
					Output = "Command " + command + " not found."
				};
			}
			catch (NoSuchCommandException ex)
			{
				return new ConsoleCommandResult
				{
					succeeded = true,
					Output = ex.ToString()
				};
			}
			catch (Exception ex2)
			{
				return new ConsoleCommandResult
				{
					succeeded = false,
					Output = ex2.ToString()
				};
			}
		}

		public static bool TryGetCommand(string command, out ConsoleCommand result)
		{
			try
			{
				result = GetCommand(command);
				return true;
			}
			catch (NoSuchCommandException)
			{
				result = default(ConsoleCommand);
				return false;
			}
		}

		public static ConsoleCommand GetCommand(string command)
		{
			if (HasCommand(command))
			{
				return Database[command];
			}
			throw new NoSuchCommandException("Command " + command + " not found.", command);
		}

		public static bool HasCommand(string command)
		{
			return Database.ContainsKey(command);
		}

		public static List<string> CommandsContainingStrings(string[] strings, bool ignorePrefix = false)
		{
			List<string> list = new List<string>();
			int num = (ignorePrefix ? 1 : 0);
			foreach (KeyValuePair<string, ConsoleCommand> item in Database)
			{
				bool flag = true;
				for (int i = 0; i < strings.Length; i++)
				{
					if (item.Key.IndexOf(strings[i], StringComparison.OrdinalIgnoreCase) < num)
					{
						flag = false;
					}
				}
				if (flag)
				{
					list.Add(item.Key);
				}
			}
			return list;
		}

		public static List<string> CommandsMatchingPrefix(string prefix)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, ConsoleCommand> item in Database)
			{
				if (item.Key.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
				{
					list.Add(item.Key);
				}
			}
			return list;
		}
	}
}
