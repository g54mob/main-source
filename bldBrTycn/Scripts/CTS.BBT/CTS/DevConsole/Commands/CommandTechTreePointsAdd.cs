using System.Collections.Generic;
using CTS.Core;
using CTS.TechTree;

namespace CTS.DevConsole.Commands
{
	public class CommandTechTreePointsAdd : ConsoleCommand, ISubCommand<CommandTechTreePoints>, ISubCommand
	{
		public override string Command { get; } = "Add";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Adds a specified points amount to the total tech tree points.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(args[0] is int num))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			if (!CTSSingleton<TechTreePoints>.InstanceExists())
			{
				DeveloperConsole.LogError("Can't change points when not in a scene");
				return;
			}
			CTSSingleton<TechTreePoints>.Instance.TryToAddPoints(num);
			DeveloperConsole.Log($"Adding {num} points in the tech tree");
		}
	}
}
