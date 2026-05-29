using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandWorker : SelectionCommand<Worker>
	{
		public override string Command { get; } = "Worker";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Base command for worker related settings, displays the name of the selected worker.";
		}

		protected override void RunCommandOnSelection(Worker selection, List<object> args, string[] rawArgs)
		{
			DeveloperConsole.Log("Worker: " + selection.agentFirstName + " " + selection.agentName);
		}
	}
}
