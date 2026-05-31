using System.Collections.Generic;
using CTS.BBT;

namespace CTS.DevConsole.Commands
{
	public class CommandStockAdd : CommandStock, ISubCommand<CommandStock>, ISubCommand
	{
		public override string Command { get; } = "Add";

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
			Stocks.ForceAdd(new StockStack(stockItem, num, 5f));
			DeveloperConsole.Log($"Added {num} {stockItem.Name}");
		}

		public override string GetCommandDescription()
		{
			return "Adds a specified amount of an ingredient to the global storage";
		}
	}
}
