using System;
using System.Collections.Generic;
using CTS.BBT;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace CTS.DevConsole.Commands
{
	public class CommandStock : ConsoleCommand
	{
		private static List<string> _tempList;

		public override string Command { get; } = "Stock";

		public override bool CanHaveNoArguments { get; }

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { EArgType.StringList };

		public static IList<StockItemSO> Items { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Init()
		{
			Items = Addressables.LoadAssetsAsync<StockItemSO>("Stockables").WaitForCompletion();
		}

		protected override List<string> GetStringListArgument(int argIndex, out bool caseSensitive)
		{
			caseSensitive = false;
			if (_tempList == null)
			{
				_tempList = new List<string>();
				foreach (StockItemSO item in Items)
				{
					_tempList.Add(item.name);
				}
			}
			return _tempList;
		}

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			if (Items == null)
			{
				return;
			}
			string text = rawArgs[0];
			StockItemSO stockItemSO = null;
			foreach (StockItemSO item in Items)
			{
				if (string.Equals(item.name, text, StringComparison.InvariantCultureIgnoreCase))
				{
					stockItemSO = item;
					break;
				}
			}
			if (!stockItemSO)
			{
				throw ConsoleCommand.ErrorBadArgument(text, "[StockItemSO]");
			}
			RunForStockItem(stockItemSO, args, rawArgs);
		}

		protected virtual void RunForStockItem(StockItemSO stockItem, List<object> args, string[] rawArgs)
		{
			int stockedCount = Stocks.GetStockedCount(stockItem);
			DeveloperConsole.Log($"There are {stockedCount} {stockItem.Name} in Stock!");
		}

		public override string GetCommandDescription()
		{
			return "Displays or changes the available amount of a specified ingredient";
		}
	}
}
