using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentAnim : SelectionCommand<AgentAnimator>
	{
		public override string Command { get; } = "AgentAnim";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[2]
		{
			EArgType.String,
			EArgType.Bool
		};

		protected override bool CanSearchObjectInSceneIfNothingSelected { get; }

		public override string GetCommandDescription()
		{
			return "Enables or disables a specified animation override for a selected agent.";
		}

		protected override void RunCommandOnSelection(AgentAnimator selection, List<object> args, string[] rawArgs)
		{
			if (!(args[1] is bool flag))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[1], "[True/False]");
			}
			string overrideKey = rawArgs[0];
			if (flag)
			{
				selection.EnableOverride(overrideKey);
			}
			else
			{
				selection.DisableOverride(overrideKey);
			}
		}
	}
}
