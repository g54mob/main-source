public class ProgressValueFuel : ProgressValue
{
	private readonly float consumptionRate;

	public ProgressValueFuel(ItemType type, float consumptionRate)
	{
		progressType = type;
		this.consumptionRate = consumptionRate;
		_currentValue = 0f;
	}

	public void Consume(float consumptionFactor)
	{
		ModifyValue((0f - consumptionFactor) * consumptionRate);
	}
}
