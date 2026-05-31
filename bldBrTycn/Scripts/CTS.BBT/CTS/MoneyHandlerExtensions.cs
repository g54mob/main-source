using System;
using CTS.BBT.Handlers.Transactions;
using CTS.Core;

namespace CTS
{
	public static class MoneyHandlerExtensions
	{
		public static void AddMoneyWithDifficulty(this MoneyHandler self, int amount, TransactionTag? transactionTag = null)
		{
			if (amount == 0)
			{
				return;
			}
			EventsManager.ChangeMoney?.Invoke(Currencies.Dollars, amount);
			if (transactionTag.HasValue)
			{
				if (amount < 0)
				{
					MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Expense, Math.Abs(amount), transactionTag.Value);
				}
				else
				{
					MonoSingleton<TransactionsHandlers>.Instance.AddNewData(TransactionType.Income, Math.Abs(amount), transactionTag.Value);
				}
			}
		}
	}
}
