using System.Collections.Generic;
using CTS.BBT;

namespace CTS.DevConsole.Commands
{
	public class CommandStockDelete : CommandStock, ISubCommand<CommandStock>, ISubCommand
	{
		private static readonly List<StockStack> _stackReceiver = new List<StockStack>();

		public override string Command { get; } = "Delete";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[2]
		{
			EArgType.StringList,
			EArgType.Int
		};

		protected override void RunForStockItem(StockItemSO stockItem, List<object> args, string[] rawArgs)
		{
			if (!(args[1] is int num))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[1], "[Int]");
			}
			Stocks.BarStock.RetrieveStock(stockItem, num, _stackReceiver);
			DeveloperConsole.Log($"Removed {num} {stockItem.Name}!");
		}

		public override string GetCommandDescription()
		{
			return "Removes a specified amount of an ingredient from the global storage";
		}
	}
}
