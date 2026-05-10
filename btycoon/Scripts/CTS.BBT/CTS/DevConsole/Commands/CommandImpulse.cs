using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;

namespace CTS.DevConsole.Commands
{
	public class CommandImpulse : ConsoleCommand
	{
		private enum EType
		{
			All = 0,
			Stock = 1,
			Money = 2
		}

		public override string Command { get; } = "Impulse";

		public override bool CanHaveNoArguments { get; } = true;

		public override bool EnableHelpCommand { get; } = true;

		public override object[] ArgumentTypes { get; } = new object[1] { typeof(EType) };

		protected override void RunCommand(List<object> args, string[] rawArgs)
		{
			switch ((args.Count != 0) ? ((EType)args[0]) : EType.All)
			{
			case EType.All:
				ImpulseStock();
				ImpulseMoney();
				break;
			case EType.Stock:
				ImpulseStock();
				break;
			case EType.Money:
				ImpulseMoney();
				break;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private void ImpulseStock()
		{
			foreach (StockItemSO item in CommandStock.Items)
			{
				Stocks.ForceAdd(new StockStack(item, 500, 10f));
			}
		}

		private void ImpulseMoney()
		{
			MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(1000000);
		}

		private void ImpulseWorkers()
		{
		}

		public override string GetCommandDescription()
		{
			return "Adds a head start to the stock, money and recruited workers.";
		}
	}
}
