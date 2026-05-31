using System.Collections.Generic;

namespace CTS.DevConsole.Commands
{
	public class CommandStockClear : ConsoleCommand, ISubCommand<CommandStock>, ISubCommand
	{
		public override string Command { get; } = "Clear";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; }

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			Stocks.BarStock.ClearInventory();
		}

		public override string GetCommandDescription()
		{
			return "Completely wipes the inventory";
		}
	}
}
