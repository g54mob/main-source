using System.Collections.Generic;
using CTS.Core;

namespace CTS.DevConsole.Commands
{
	public class CommandMoney : ConsoleCommand
	{
		public override string Command => "Money";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		public override string GetCommandDescription()
		{
			return "Displays the current amount of money.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			DeveloperConsole.Log($"Current money account: {MonoSingleton<MoneyHandler>.Instance.CurrentMoney}");
		}
	}
}
