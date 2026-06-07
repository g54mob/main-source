public abstract class VitalQuirkBase : QuirkBase
{
	public virtual int OnInitializeVital(VitalType vital, int amount)
	{
		return amount;
	}

	public virtual int OnIncreaseVital(VitalType vital, int amount)
	{
		return amount;
	}

	protected override void ApplyToDrifter(Quirks quirks)
	{
		quirks.AddVitalQuirk(this);
	}

	protected override void RemoveFromDrifter(Quirks quirks)
	{
		quirks.RemoveVitalQuirk(this);
	}
}
