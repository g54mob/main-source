using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandPanic : ConsoleCommand
	{
		public override string Command => "Panic";

		public override bool CanHaveNoArguments => true;

		public override bool EnableHelpCommand => true;

		public override object[] ArgumentTypes => null;

		public override string GetCommandDescription()
		{
			return "Set all human on panic state";
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
