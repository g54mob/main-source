using System.Collections.Generic;
using CTS.AI;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	internal class CommandCustomerLeaveAll : ConsoleCommand, ISubCommand<CommandCustomerLeave>, ISubCommand
	{
		public override string Command { get; } = "All";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Makes all customers leave";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			foreach (Agent item in Agents.List)
			{
				if (item is Customer && item.Tags.HasTag(EAgentTag.IsInside))
				{
					item.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
				}
			}
		}
	}
}
