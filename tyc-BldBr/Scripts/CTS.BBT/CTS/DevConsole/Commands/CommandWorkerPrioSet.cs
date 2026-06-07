using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandWorkerPrioSet : SelectionCommand<Worker>, ISubCommand<CommandWorkerPrio>, ISubCommand
	{
		public override string Command { get; } = "Set";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[2]
		{
			typeof(ChoreCategory),
			EArgType.Bool
		};

		public override string GetCommandDescription()
		{
			return "Sets active or inactive a specified Chore Priority";
		}

		protected override void RunCommandOnSelection(Worker selection, List<object> args, string[] rawArgs)
		{
			if (!(args[0] is ChoreCategory cat))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[ChoreCategory]");
			}
			if (!(args[1] is bool value))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[1], "[True/False]");
			}
			selection.ChoreAssigner.TogglePriority(cat, value);
		}
	}
}
