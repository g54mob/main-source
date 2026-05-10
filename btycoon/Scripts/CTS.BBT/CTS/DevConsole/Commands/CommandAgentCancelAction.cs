using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	internal class CommandAgentCancelAction : SelectionCommand<Agent>
	{
		public override string Command { get; } = "AgentCancelAction";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Cancel the current action for a selected agent.";
		}

		protected override void RunCommandOnSelection(Agent selection, List<object> objects, string[] rawArgs)
		{
			if (selection.ActionPlayer.CurrentAction != null)
			{
				selection.ActionPlayer.CurrentAction.ForceCancelAction();
				DeveloperConsole.Log(selection.agentName + ": Action Canceled");
			}
		}
	}
}
