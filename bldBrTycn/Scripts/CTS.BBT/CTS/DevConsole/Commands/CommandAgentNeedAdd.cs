using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentNeedAdd : CommandAgentNeed, ISubCommand<CommandAgentNeed>, ISubCommand
	{
		public override string Command { get; } = "Add";

		public override object[] ArgumentTypes { get; } = new object[2]
		{
			typeof(EAgentStatistics),
			EArgType.Float
		};

		public override string GetCommandDescription()
		{
			return "Adds a specified amount to a specific need for a selected Agent.";
		}

		protected override void RunCommandOnNeed(AgentStatistics selection, List<object> args, string[] rawArgs, EAgentStatistics needType)
		{
			if (!(args[1] is float unitInterval))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[1], "[Float]");
			}
			selection.AddToStatisticUnitInterval(needType, unitInterval);
		}
	}
}
