using System.Collections.Generic;
using CTS.Core;

namespace CTS.DevConsole
{
	public class CommandHelp : ConsoleCommand
	{
		public override string Command { get; } = "Help";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Lists all available commands.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			string text = "";
			foreach (KeyValuePair<string, ConsoleCommand> command in CTSSingleton<DeveloperConsole>.Instance.Commands)
			{
				text = text + "/" + command.Value.Command + "\n";
			}
			DeveloperConsole.Log("Command List ->", text);
			DeveloperConsole.OpenLastLog();
		}
	}
}
