using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentLevel : SelectionCommand<WorkerLevel>
	{
		public override string Command { get; } = "AgentLevel";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Displays the amount of experience for a selected Worker.";
		}

		protected override void RunCommandOnSelection(WorkerLevel selection, List<object> objects, string[] rawArgs)
		{
			DeveloperConsole.Log($"Worker Level: {selection.CurrentLevel}, XP: {selection.CurrentXP}");
		}
	}
}
