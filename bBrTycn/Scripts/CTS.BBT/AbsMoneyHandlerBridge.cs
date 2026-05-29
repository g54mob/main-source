using System;
using CTS.Core;

public abstract class AbsMoneyHandlerBridge : MonoSingleton<AbsMoneyHandlerBridge>
{
	public static event Action<int> MoneyAmountChanged;

	protected void OnMoneyAmountChanged(int amount)
	{
		AbsMoneyHandlerBridge.MoneyAmountChanged?.Invoke(amount);
	}

	public abstract int GetCurrentMoney();

	public abstract void SpendMoney(int amount);

	public abstract string GetToMoneyStringFormat(int money);
}
