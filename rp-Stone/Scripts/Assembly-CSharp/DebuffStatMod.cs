public class DebuffStatMod : StatModifier
{
	public enum HowToApplyParent
	{
		CopyStats = 0,
		ComputeAsDuration = 1
	}

	public HowToApplyParent howToApplyParent;

	public ItemData.Stat replacementStat;
}
