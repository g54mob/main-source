public class ProgressValueBooster : ProgressValueAdjustableBooster
{
	public readonly ItemType consumedItem;

	public readonly ItemType outputItem;

	public ProgressValueBooster(ItemType progressType, ItemType consumedItem, ItemType outputItem, float baselineProductionRate, float baselineDepletionRate)
	{
		base.progressType = progressType;
		this.consumedItem = consumedItem;
		base.baselineProductionRate = baselineProductionRate;
		base.baselineDepletionRate = baselineDepletionRate;
		this.outputItem = outputItem;
		_currentValue = 0f;
	}

	protected override void CalcMetadata()
	{
		base.effectiveDepletionRate = base.baselineDepletionRate * (float)base.numBoostsAssigned;
		if (base.numBoostsAssigned <= 1)
		{
			base.effectiveProductionRate = base.baselineProductionRate * (float)base.numBoostsAssigned;
			return;
		}
		float num = (float)(base.numBoostsAssigned - 1) * base.baselineProductionRate * 0.5f;
		base.effectiveProductionRate = base.baselineProductionRate + num;
	}
}
