using System;
using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandAgentStateSet : SelectionCommand<Agent>, ISubCommand<CommandAgentState>, ISubCommand
	{
		private enum EAgentState
		{
			Normal = 0,
			Panic = 1,
			Stuck = 2,
			Dead = 3
		}

		public override string Command { get; } = "Set";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(EAgentState) };

		public override string GetCommandDescription()
		{
			return "Sets the current state of the selected agent to a specified value.";
		}

		protected override void RunCommandOnSelection(Agent selection, List<object> args, string[] rawArgs)
		{
			object obj = args[0];
			if (!(obj is EAgentState))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "Normal", "Panic", "Stuck", "Dead");
			}
			switch ((EAgentState)obj)
			{
			case EAgentState.Normal:
				selection.ContextualFSM.SetStateNormal();
				break;
			case EAgentState.Panic:
				selection.ContextualFSM.SetStatePanicking();
				break;
			case EAgentState.Stuck:
				selection.ContextualFSM.SetStateStuck();
				break;
			case EAgentState.Dead:
				selection.ContextualFSM.SetStateDead();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
