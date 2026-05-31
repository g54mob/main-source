using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandWorkerPrio : SelectionCommand<Worker>, ISubCommand<CommandWorker>, ISubCommand
	{
		public override string Command { get; } = "Prio";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(ChoreCategory) };

		public override string GetCommandDescription()
		{
			return "Display the active state of a specified priority.";
		}

		protected override void RunCommandOnSelection(Worker selection, List<object> args, string[] rawArgs)
		{
			if (!(args[0] is ChoreCategory cat))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[ChoreCategory]");
			}
			if (selection.ChoreAssigner.TryGetPriority(cat, out var selfEnabled, out var _))
			{
				DeveloperConsole.Log($"Worker {selection.agentFirstName} '{cat.ToString()}' [{selfEnabled}]");
				return;
			}
			DeveloperConsole.LogWarning("Worker " + selection.agentFirstName + " doesn't have priority '" + cat.ToString() + "'");
		}
	}
}
