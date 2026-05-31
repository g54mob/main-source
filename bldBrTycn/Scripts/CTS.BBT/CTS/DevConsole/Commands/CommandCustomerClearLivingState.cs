using System;
using System.Collections.Generic;
using CTS.BBT.AI;

namespace CTS.DevConsole.Commands
{
	public class CommandCustomerClearLivingState : SelectionCommand<Customer>
	{
		public override string Command { get; } = "CustomerClearLivingState";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; }

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			throw new NotImplementedException();
		}

		protected override void RunCommandOnSelection(Customer selection, List<object> args, string[] rawArgs)
		{
			selection.ClearLivingState();
		}
	}
}
