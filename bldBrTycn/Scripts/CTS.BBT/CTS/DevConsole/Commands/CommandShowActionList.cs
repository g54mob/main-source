using System.Collections.Generic;
using CTS.BBT.UI;

namespace CTS.DevConsole.Commands
{
	public class CommandShowActionList : SelectionCommand<UIActionListPanel>
	{
		public override string Command { get; } = "ShowActionList";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Bool };

		protected override void RunCommandOnSelection(UIActionListPanel selection, List<object> args, string[] rawArgs)
		{
			if (!(args[0] is bool active))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[True/False]");
			}
			selection.SetActive(active);
		}

		public override string GetCommandDescription()
		{
			return "Enables or disables the Agents' action list.";
		}
	}
}
