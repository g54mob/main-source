using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentLevelAdd : SelectionCommand<WorkerLevel>, ISubCommand<CommandAgentLevel>, ISubCommand
	{
		public override string Command { get; } = "Add";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Adds a specified amount of experience to a selected Worker.";
		}

		protected override void RunCommandOnSelection(WorkerLevel selection, List<object> objects, string[] rawArgs)
		{
			if (!(objects[0] is int num))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[1], "[Int]");
			}
			selection.AddExperience(num);
			DeveloperConsole.Log($"Worker Level: {selection.CurrentLevel}, XP: {selection.CurrentXP}");
		}
	}
}
