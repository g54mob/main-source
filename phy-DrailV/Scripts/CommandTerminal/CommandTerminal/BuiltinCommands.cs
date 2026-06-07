using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using UnityEngine;

namespace CommandTerminal
{
	public static class BuiltinCommands
	{
		[RegisterCommand(null, Help = "Clear the command console", MaxArgCount = 0)]
		private static void CommandClear(CommandArg[] args)
		{
			Terminal.Buffer.Clear();
		}

		[RegisterCommand(null, Help = "Display help information about a command", MaxArgCount = 1)]
		private static void CommandHelp(CommandArg[] args)
		{
			if (args.Length == 0)
			{
				foreach (KeyValuePair<string, CommandInfo> command in Terminal.Shell.Commands)
				{
					if (!command.Value.secret)
					{
						Terminal.Log("{0}: {1}", command.Value.name.PadRight(16), command.Value.help);
					}
				}
				return;
			}
			string text = args[0].String.ToUpper();
			if (!Terminal.Shell.Commands.ContainsKey(text))
			{
				Terminal.Shell.IssueErrorMessage("Command {0} could not be found.", text);
				return;
			}
			CommandInfo commandInfo = Terminal.Shell.Commands[text];
			if (commandInfo.help == null)
			{
				Terminal.Log("{0} does not provide any help documentation.", text);
			}
			else if (commandInfo.hint == null)
			{
				Terminal.Log(commandInfo.help);
			}
			else
			{
				Terminal.Log("{0}\nUsage: {1}", commandInfo.help, commandInfo.hint);
			}
		}

		[RegisterCommand(null, Help = "Time the execution of a command", MinArgCount = 1)]
		private static void CommandTime(CommandArg[] args)
		{
			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();
			Terminal.Shell.RunCommand(JoinArguments(args));
			stopwatch.Stop();
			Terminal.Log("Time: {0}ms", (double)stopwatch.ElapsedTicks / 10000.0);
		}

		[RegisterCommand(null, Help = "Output message")]
		private static void CommandPrint(CommandArg[] args)
		{
			Terminal.Log(JoinArguments(args));
		}

		[RegisterCommand(null, Help = "List all variables or set a variable value")]
		private static void CommandSet(CommandArg[] args)
		{
			if (args.Length == 0)
			{
				foreach (KeyValuePair<string, CommandArg> variable in Terminal.Shell.Variables)
				{
					Terminal.Log("{0}: {1}", variable.Key.PadRight(16), variable.Value);
				}
				return;
			}
			string text = args[0].String;
			if (text[0] == '$')
			{
				Terminal.Log(TerminalLogType.Warning, "Warning: Variable name starts with '$', '${0}'.", text);
			}
			Terminal.Shell.SetVariable(text, JoinArguments(args, 1));
		}

		[RegisterCommand(null, Help = "No operation")]
		private static void CommandNoop(CommandArg[] args)
		{
		}

		[RegisterCommand(null, Help = "Quit running application", MaxArgCount = 0)]
		private static void CommandQuit(CommandArg[] args)
		{
			Application.Quit();
		}

		private static string JoinArguments(CommandArg[] args, int start = 0)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num = args.Length;
			for (int i = start; i < num; i++)
			{
				stringBuilder.Append(args[i].String);
				if (i < num - 1)
				{
					stringBuilder.Append(" ");
				}
			}
			return stringBuilder.ToString();
		}
	}
}
