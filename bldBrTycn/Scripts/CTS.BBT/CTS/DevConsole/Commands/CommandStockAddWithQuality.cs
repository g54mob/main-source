using System;
using System.Collections.Generic;
using CTS.BBT;

namespace CTS.DevConsole.Commands
{
	public class CommandStockAddWithQuality : CommandStock, ISubCommand<CommandStock>, ISubCommand
	{
		public override string Command { get; } = "AddWithQuality";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[3]
		{
			EArgType.StringList,
			EArgType.Int,
			EArgType.Float
		};

		protected override void RunForStockItem(StockItemSO stockItem, List<object> args, string[] rawArgs)
		{
			if (!(args[1] is int num))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[1], "[Int]");
			}
			if (!(args[2] is float value))
			{
				throw ConsoleCommand.ErrorBadArgument(rawArgs[2], "[Float]");
			}
			float num2 = Math.Clamp(value, 1f, 10f);
			Stocks.ForceAdd(new StockStack(stockItem, num, num2));
			DeveloperConsole.Log($"Added {num} {stockItem.Name} with quality index {num2}");
		}

		public override string GetCommandDescription()
		{
			return "Adds a specified amount of an ingredient to the global storage with a specified quality index";
		}
	}
}
