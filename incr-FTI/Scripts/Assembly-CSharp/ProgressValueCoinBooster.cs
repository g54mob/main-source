public class ProgressValueCoinBooster : ProgressValueAdjustableBooster
{
	public readonly ItemType currencyType;

	public bool isPaused;

	public ProgressValueCoinBooster(ItemType progressType, ItemType currencyType, float baselineProductionRate, float baselineDepletionRate)
	{
		this.currencyType = currencyType;
		base.progressType = progressType;
		base.baselineProductionRate = baselineProductionRate;
		base.baselineDepletionRate = baselineDepletionRate;
		maxBoosts = 10;
		_currentValue = 0f;
	}

	public override void Consume(float amount)
	{
		if (!isPaused)
		{
			base.Consume(amount);
		}
	}

	public override bool CanCurrentlyBoost()
	{
		if (isPaused)
		{
			return false;
		}
		return base.CanCurrentlyBoost();
	}
}
