using System.Collections.Generic;
using CTS.BBT;

namespace CTS.DevConsole.Commands
{
	public class CommandDirty : SelectionCommand<CleanableObject>
	{
		public override string Command => "Dirty";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Dirties a selected object by 1 or a specified amount of levels.";
		}

		protected override void RunCommandOnSelection(CleanableObject selection, List<object> args, string[] rawArgs)
		{
			if (!(args[0] is int dirtToAdd))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			selection.AddFilth(dirtToAdd);
		}
	}
}
