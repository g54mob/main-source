public class ResourceState : ConsumableState
{
	public NaturalResource type;

	public readonly NaturalResourceDef def;

	public readonly RequirementGroup unlockRequirements = new RequirementGroup();

	public float biomeCapacityMultiplier;

	private Flag biomeAvailabilityFlag;

	public ResourceState(NaturalResourceDef naturalResourceDef)
	{
		type = naturalResourceDef.type;
		def = naturalResourceDef;
	}

	public void StoreItemStateCache()
	{
		CountableState.gm.StoreRequirementCacheInTarget(def.requirements, parentTown, unlockRequirements.requirements);
	}

	public override string ToString()
	{
		return "Resource " + type;
	}

	public override double DefaultCapacity()
	{
		if (isOutputCapacityInfinite)
		{
			return double.MaxValue;
		}
		_ = type;
		return 100.0;
	}

	public override EntityId AsEntity()
	{
		return EntityId.FromNaturalResource(type);
	}

	public void CalcAvailability()
	{
		if (isLocked && ShouldBeUnlocked())
		{
			isLocked = false;
			OnBecameAvailable();
		}
	}

	private void OnBecameAvailable()
	{
		parentTown.SetMetadataFlag(65536);
		CountableState.gm.isQuestAvailabilityStale = true;
		if (CountableState.gm.gameState == GameState.InGame)
		{
			CalcCapacity();
			if (CountableState.gm.isTownStorageInfinite)
			{
				currentCount = 5000.0;
			}
			else
			{
				currentCount = maxCount;
			}
			if (parentTown == CountableState.gm.activeTown && null != MenuManager.Instance.minigamePanelMining)
			{
				MenuManager.Instance.minigamePanelMining.isItemAvailabilityStale = true;
			}
		}
		CountableState.gm.globalResourceUnlockStates[type].ChangeValue(nextValue: true);
	}

	public void CalcBiomeUnlock()
	{
		if (parentTown != null)
		{
			if (def.exclusiveBiome == BiomeType.None)
			{
				biomeAvailabilityFlag = Flag.Unknown;
			}
			else
			{
				biomeAvailabilityFlag = ((def.exclusiveBiome == parentTown.biomeType) ? Flag.True : Flag.False);
			}
		}
	}

	public override bool ShouldBeUnlocked()
	{
		BiomeResourceDef biomeDef = Biome.GetBiomeDef(type, parentTown.biomeType);
		if (biomeDef == null)
		{
			return false;
		}
		if (biomeAvailabilityFlag == Flag.False)
		{
			return false;
		}
		foreach (Requirement requirement in unlockRequirements.requirements)
		{
			if (!requirement.IsMet())
			{
				return false;
			}
		}
		return true;
	}
}
