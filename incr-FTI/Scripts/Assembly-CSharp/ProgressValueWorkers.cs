public class ProgressValueWorkers : ProgressValueAdjustableBooster
{
	public float _perWorkerBonuses;

	public float cachedWorkerBonusOverride;

	public float perWorkerBonuses
	{
		get
		{
			return _perWorkerBonuses;
		}
		set
		{
			_perWorkerBonuses = value;
			CalcMetadata();
		}
	}

	public ProgressValueWorkers()
	{
		progressType = ItemType.Worker;
	}

	protected override void CalcMetadata()
	{
		base.effectiveDepletionRate = 0f;
		base.effectiveProductionRate = ProductionBonusForNumWorkers(base.numBoostsAssigned) + perWorkerBonuses * (float)base.numBoostsAssigned;
	}

	public float ProductionBonusForNumWorkers(int n)
	{
		if (cachedWorkerBonusOverride > 0f)
		{
			return (float)n * cachedWorkerBonusOverride * 0.01f;
		}
		if (n > 5)
		{
			int num = n - 5;
			return 3f + (float)num * 0.4f;
		}
		if (n > 1)
		{
			int num2 = n - 1;
			return 1f + (float)num2 * 0.5f;
		}
		if (n == 1)
		{
			return 1f;
		}
		return 0f;
	}

	public override bool CanCurrentlyBoost()
	{
		return true;
	}
}
