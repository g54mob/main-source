using System.Collections.Generic;
using CTS.Core;

namespace CTS.DevConsole
{
	public class CommandHelpFull : ConsoleCommand, ISubCommand<CommandHelp>, ISubCommand
	{
		public override string Command { get; } = "Full";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			string text = "";
			foreach (KeyValuePair<string, ConsoleCommand> command in CTSSingleton<DeveloperConsole>.Instance.Commands)
			{
				text = text + "/" + command.Value.Command + "\n";
				if (!string.IsNullOrEmpty(command.Value.GetCommandDescription()))
				{
					text = text + "\t" + command.Value.GetCommandDescription() + "\n";
				}
			}
			DeveloperConsole.Log("Command List ->", text);
			DeveloperConsole.OpenLastLog();
		}

		public override string GetCommandDescription()
		{
			return "";
		}
	}
}
