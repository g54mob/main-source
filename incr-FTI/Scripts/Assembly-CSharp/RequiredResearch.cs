public class RequiredResearch : Requirement
{
	public readonly ResearchType researchType;

	private ResearchState cachedResearchState;

	private FloatProperty cachedGlobalResearchStat;

	private Flag isObsolete;

	public bool tempDebug;

	public RequiredResearch(ResearchType researchItem)
	{
		isObsolete = Flag.Unknown;
		researchType = researchItem;
		TryAddToProcessingQueue();
		if (researchItem == ResearchType.MagicJewelry)
		{
			tempDebug = true;
		}
	}

	public override Requirement GetCopy()
	{
		return new RequiredResearch(researchType);
	}

	public override bool IsImpossible()
	{
		if (cachedResearchState != null)
		{
			return cachedResearchState.availability == BuildObjectAvailability.Disabled;
		}
		return false;
	}

	public override bool IsMet()
	{
		_ = tempDebug;
		if (cachedResearchState != null)
		{
			_ = tempDebug;
			return cachedResearchState.numCompleted > 0;
		}
		if (isObsolete == Flag.Unknown)
		{
			if (!Crafting.researchCache.ContainsKey(researchType))
			{
				isObsolete = Flag.True;
			}
			else
			{
				isObsolete = Flag.False;
			}
		}
		if (isObsolete == Flag.True)
		{
			return true;
		}
		if (cachedGlobalResearchStat != null)
		{
			_ = tempDebug;
			return cachedGlobalResearchStat.value > 0.0;
		}
		_ = tempDebug;
		return GameManager.Instance.ActiveTownResearchCompleted(researchType) > 0f;
	}

	public override void StoreItemStateCache(Town town)
	{
		_ = tempDebug;
		base.StoreItemStateCache(town);
		if (town.research.TryGetValue(researchType, out var value))
		{
			cachedResearchState = value;
			_ = tempDebug;
		}
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		if (GameManager.Instance.globalResearchStats.TryGetValue(researchType, out var value))
		{
			cachedGlobalResearchStat = value;
		}
	}

	public bool IsUnlockableFrom(ResearchType otherKnowledgeType)
	{
		return researchType == otherKnowledgeType;
	}

	public override string ToString()
	{
		return string.Format("Required Research " + TextDisplay.LabelForResearch(researchType));
	}
}
