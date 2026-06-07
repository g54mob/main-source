public class ProgressValueAdjustableBooster : ProgressValue
{
	private int _numBoostsAssigned;

	public int maxBoosts;

	public float productionProgress;

	public float baselineProductionRate { get; protected set; }

	public float baselineDepletionRate { get; protected set; }

	public float effectiveProductionRate { get; protected set; }

	public float effectiveDepletionRate { get; protected set; }

	public int numBoostsAssigned
	{
		get
		{
			return _numBoostsAssigned;
		}
		set
		{
			_numBoostsAssigned = value;
			CalcMetadata();
		}
	}

	public float CurrentBoostValue()
	{
		return effectiveProductionRate;
	}

	public void SetNumBoosts(int numBoosts)
	{
		numBoostsAssigned = numBoosts;
	}

	public void ModifyBoosts(int difference)
	{
		_numBoostsAssigned += difference;
		if (_numBoostsAssigned < 0)
		{
			_numBoostsAssigned = 0;
		}
		if (_numBoostsAssigned > maxBoosts)
		{
			_numBoostsAssigned = maxBoosts;
		}
		CalcMetadata();
	}

	protected virtual void CalcMetadata()
	{
		effectiveProductionRate = baselineProductionRate * (float)_numBoostsAssigned;
		effectiveDepletionRate = baselineDepletionRate * (float)_numBoostsAssigned;
	}

	public void ModifyNumBoosts(int difference)
	{
		_numBoostsAssigned += difference;
		CalcMetadata();
	}

	public virtual void Consume(float amount)
	{
		float num = amount * effectiveProductionRate;
		float num2 = amount * effectiveDepletionRate;
		if (num2 > base.currentValue)
		{
			num2 = base.currentValue;
			num = num2 * effectiveProductionRate;
		}
		productionProgress += num;
		productionProgress %= 1f;
		ModifyValue(0f - num2);
	}

	public virtual bool CanCurrentlyBoost()
	{
		return base.currentValue > 0f;
	}
}
