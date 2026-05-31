using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandMoneyAdd : ConsoleCommand, ISubCommand<CommandMoney>, ISubCommand
	{
		public override string Command { get; } = "Add";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.Int };

		public override string GetCommandDescription()
		{
			return "Adds a specified amount to the total money.";
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (!(args[0] is int arg))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[0], "[Int]");
			}
			int num = EventsManager.ChangeMoney(Currencies.Dollars, arg);
			DeveloperConsole.Log($"Set Money to {num}");
		}
	}
}
