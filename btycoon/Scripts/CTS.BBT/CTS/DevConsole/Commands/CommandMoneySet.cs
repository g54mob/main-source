using System.Collections.Generic;
using CTS.Core;

namespace CTS.DevConsole.Commands
{
	public class CommandMoneySet : ConsoleCommand, ISubCommand<CommandMoney>, ISubCommand
	{
		public override string Command { get; } = "Set";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Sets the current amount of money to a specified amount.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(args[0] is int currentMoney))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(currentMoney);
			DeveloperConsole.Log($"Set Money to {MonoSingleton<MoneyHandler>.Instance.CurrentMoney}");
		}
	}
}
