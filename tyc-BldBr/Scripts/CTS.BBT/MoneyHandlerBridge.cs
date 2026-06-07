using CTS;
using CTS.Core;

public class MoneyHandlerBridge : AbsMoneyHandlerBridge
{
	private void Awake()
	{
		MoneyHandler.MoneyAmountChanged += base.OnMoneyAmountChanged;
	}

	private void OnDestroy()
	{
		MoneyHandler.MoneyAmountChanged -= base.OnMoneyAmountChanged;
	}

	public override int GetCurrentMoney()
	{
		return MonoSingleton<MoneyHandler>.Instance.CurrentMoney;
	}

	public override void SpendMoney(int amount)
	{
		if (MonoSingleton<MoneyHandler>.InstanceExists())
		{
			MonoSingleton<MoneyHandler>.Instance.SetCurrentMoney(MonoSingleton<MoneyHandler>.Instance.CurrentMoney - amount);
		}
	}

	public override string GetToMoneyStringFormat(int money)
	{
		return MoneyHandler.GetToMoneyStringFormat(money);
	}

	protected override void SingletonAwake()
	{
	}

	protected override void OnSingletonDestroy()
	{
	}
}
