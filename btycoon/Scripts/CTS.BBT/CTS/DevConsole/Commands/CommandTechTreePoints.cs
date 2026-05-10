using System.Collections.Generic;
using CTS.BBT.TechTree;

namespace CTS.DevConsole.Commands
{
	public class CommandTechTreePoints : ConsoleCommand
	{
		public override string Command => "TechPoints";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Displays the current amount of points.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			DeveloperConsole.Log($"Current tech tree points amount: {TechTreeManager.GetCurrentPoints}");
		}
	}
}
