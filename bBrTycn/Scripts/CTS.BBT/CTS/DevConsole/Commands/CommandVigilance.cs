using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandVigilance : ConsoleCommand
	{
		public override string Command => "Vigilance";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Use to modify current Vigilance\nUse Vigilance Add to add value to the current vigilanceUse Vigilance Set to set the current vigilanceUse Vigilance Clear to clear the current vigilanceUse Vigilance Lock/Unlock to desactivate/activate the gameover";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			ActivePanic();
			DeveloperConsole.Log("Panic actived");
		}

		public static void ActivePanic()
		{
			foreach (Agent item in Agents.List)
			{
				if (item is Customer && item.IsHuman && item.Tags.HasTag(EAgentTag.IsInside))
				{
					item.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
					item.Animator.EnableOverride("Panic");
				}
			}
		}
	}
}
