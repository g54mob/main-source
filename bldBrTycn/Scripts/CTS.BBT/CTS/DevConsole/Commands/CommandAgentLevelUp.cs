using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentLevelUp : SelectionCommand<WorkerLevel>, ISubCommand<CommandAgentLevel>, ISubCommand
	{
		public override string Command { get; } = "Up";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Instantly levels up a selected Worker.";
		}

		protected override void RunCommandOnSelection(WorkerLevel selection, List<object> args, string[] rawArgs)
		{
			InvokeOnSelection("LevelUp");
			DeveloperConsole.Log($"Worker Level: {selection.CurrentLevel}, XP: {selection.CurrentXP}");
		}
	}
}
