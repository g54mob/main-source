using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	internal class CommandCustomerLeave : SelectionCommand<Customer>
	{
		public override string Command { get; } = "CustomerLeave";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Makes a customer leave";
		}

		protected override void RunCommandOnSelection(Customer selection, List<object> args, string[] rawArgs)
		{
			selection.ActionPlayer.ForceAction(new AgentActionLeave(), EActionPriority.Forced);
		}
	}
}
