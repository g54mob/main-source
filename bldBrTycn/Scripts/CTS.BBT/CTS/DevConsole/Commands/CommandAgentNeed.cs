using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentNeed : SelectionCommand<AgentStatistics>
	{
		public override string Command { get; } = "AgentNeed";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(EAgentStatistics) };

		public override string GetCommandDescription()
		{
			return "Displays or changes a specified need for a selected Agent.";
		}

		protected override void RunCommandOnSelection(AgentStatistics selection, List<object> args, string[] rawArgs)
		{
			if (!(args[0] is EAgentStatistics eAgentStatistics))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[ENeedType]");
			}
			if (!selection.HasStatistic(eAgentStatistics))
			{
				DeveloperConsole.LogError($"Selected agent doesn't feel {eAgentStatistics}");
			}
			else
			{
				RunCommandOnNeed(selection, args, rawArgs, eAgentStatistics);
			}
		}

		protected virtual void RunCommandOnNeed(AgentStatistics selection, List<object> args, string[] rawArgs, EAgentStatistics needType)
		{
			if (selection.TryGetStatisticValue(needType, out var statisticValue))
			{
				DeveloperConsole.Log($"Agent {needType}: {statisticValue}");
			}
		}
	}
}
