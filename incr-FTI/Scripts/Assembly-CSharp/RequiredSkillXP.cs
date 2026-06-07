public class RequiredSkillXP : Requirement
{
	public readonly SkillType skillType;

	public readonly double targetCount;

	private FloatProperty cachedStat;

	public RequiredSkillXP(SkillType type, double requiredCount)
	{
		skillType = type;
		targetCount = requiredCount;
		TryAddToProcessingQueue();
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		cachedStat = town.townSkillStats[skillType];
	}

	public override bool IsMet()
	{
		return CurrentCount() >= targetCount;
	}

	public double CurrentCount()
	{
		return cachedStat.value;
	}
}
