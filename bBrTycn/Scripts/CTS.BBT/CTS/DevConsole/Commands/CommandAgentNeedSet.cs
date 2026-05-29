using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentNeedSet : CommandAgentNeed, ISubCommand<CommandAgentNeed>, ISubCommand
	{
		public override string Command { get; } = "Set";

		public override object[] ArgumentTypes { get; } = new object[2]
		{
			typeof(EAgentStatistics),
			EArgType.Float
		};

		public override string GetCommandDescription()
		{
			return "Sets a specified need to a specific amount for selected Agent.";
		}

		protected override void RunCommandOnNeed(AgentStatistics selection, List<object> args, string[] rawArgs, EAgentStatistics needType)
		{
			if (!(args[1] is float unitInterval))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[1], "[Float]");
			}
			selection.SetStatisticFromUnitInterval(needType, unitInterval);
		}
	}
}
