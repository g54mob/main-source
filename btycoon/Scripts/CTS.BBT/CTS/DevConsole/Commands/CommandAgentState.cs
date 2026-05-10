using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentState : SelectionCommand<Agent>
	{
		public override string Command { get; } = "AgentState";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Displays the current state of the selected Agent.";
		}

		protected override void RunCommandOnSelection(Agent selection, List<object> args, string[] rawArgs)
		{
			if (selection.ContextualFSM.CurrentState == null)
			{
				DeveloperConsole.LogError("The state is null!!");
			}
			else
			{
				DeveloperConsole.Log("Current State: " + selection.ContextualFSM.CurrentState.GetType().Name);
			}
		}
	}
}
