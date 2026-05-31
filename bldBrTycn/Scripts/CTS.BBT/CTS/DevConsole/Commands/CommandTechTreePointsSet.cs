using System.Collections.Generic;
using CTS.BBT.TechTree;
using CTS.Core;
using CTS.TechTree;

namespace CTS.DevConsole.Commands
{
	public class CommandTechTreePointsSet : ConsoleCommand, ISubCommand<CommandTechTreePoints>, ISubCommand
	{
		public override string Command { get; } = "Set";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Sets the current amount of points to a specified amount.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(args[0] is int points))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			if (!CTSSingleton<TechTreePoints>.InstanceExists())
			{
				DeveloperConsole.LogError("Can't change points when not in a scene");
				return;
			}
			CTSSingleton<TechTreePoints>.Instance.SetPoints(points);
			DeveloperConsole.Log($"Set tech tree points to {TechTreeManager.GetCurrentPoints}");
		}
	}
}
