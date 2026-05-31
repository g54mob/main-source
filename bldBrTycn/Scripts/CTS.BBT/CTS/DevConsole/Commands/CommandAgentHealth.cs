using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	internal class CommandAgentHealth : SelectionCommand<Agent>
	{
		public override string Command { get; } = "AgentHealth";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Displays the current amount of health for a selected agent.";
		}

		protected override void RunCommandOnSelection(Agent selection, List<object> objects, string[] rawArgs)
		{
			UnitHealth health = selection.Health;
			DeveloperConsole.Log($"{selection.agentName}: {health.CurrentHealth}/{health.MaxHealth}");
		}
	}
}
