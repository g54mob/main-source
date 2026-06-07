public class RequiredTownLevel : Requirement
{
	public readonly int requiredTownLevel;

	public readonly BiomeType requiredBiome;

	private PropertyItem<float> cachedLevelValue;

	public RequiredTownLevel(int level, BiomeType biomeType)
	{
		requiredTownLevel = level;
		requiredBiome = biomeType;
		TryAddToProcessingQueue();
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		if (requiredBiome != BiomeType.None)
		{
			if (GameManager.Instance.biomeLevels.TryGetValue(requiredBiome, out var value))
			{
				cachedLevelValue = value;
			}
		}
		else
		{
			cachedLevelValue = GameManager.Instance.cachedMaxTownLevel;
		}
	}

	public override void StoreItemStateCache(Town town)
	{
		PropertyItem<float> value;
		if (requiredBiome == BiomeType.None)
		{
			cachedLevelValue = town.cachedLevelProgress;
		}
		else if (GameManager.Instance.biomeLevels.TryGetValue(requiredBiome, out value))
		{
			cachedLevelValue = value;
		}
		_ = cachedLevelValue;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= (float)requiredTownLevel;
	}

	public float CurrentCount()
	{
		if (cachedLevelValue != null)
		{
			return cachedLevelValue.value;
		}
		if (requiredBiome == BiomeType.None)
		{
			return GameManager.Instance.activeTown.cachedLevelProgress.value;
		}
		return 0f;
	}
}
