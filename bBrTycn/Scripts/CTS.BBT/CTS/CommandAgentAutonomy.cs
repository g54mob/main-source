using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.DevConsole;

namespace CTS
{
	public class CommandAgentAutonomy : SelectionCommand<Agent>
	{
		public override string Command { get; } = "AgentAutonomy";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Bool };

		protected override bool CanSearchObjectInSceneIfNothingSelected { get; }

		protected override void RunCommandOnSelection(Agent selection, List<object> args, string[] rawArgs)
		{
			if (args.Count == 0)
			{
				DeveloperConsole.Log($"'{selection.FullName()}' Autonomy: {!selection.AutonomousActions.Paused}");
				if (selection is Worker worker)
				{
					DeveloperConsole.Log($"'{worker.FullName()}' Worker Autonomy: {!worker.ChoreAssigner.IsLocked}");
				}
			}
			else if (args[0] is bool flag)
			{
				selection.AutonomousActions.Paused = !flag;
				DeveloperConsole.Log($"'{selection.FullName()}' Autonomy: {!selection.AutonomousActions.Paused}");
				if (selection is Worker worker2)
				{
					worker2.ChoreAssigner.SetActive(flag);
					DeveloperConsole.Log($"'{worker2.FullName()}' Worker Autonomy: {!worker2.ChoreAssigner.IsLocked}");
				}
			}
		}

		public override string GetCommandDescription()
		{
			return "Displays or set the autonomy for the selected Agent.";
		}
	}
}
