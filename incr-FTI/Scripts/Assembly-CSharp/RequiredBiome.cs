public class RequiredBiome : Requirement
{
	public readonly BiomeType biomeType;

	private Town cachedTown;

	public bool excludeFlag;

	public RequiredBiome(BiomeType t, bool exclude = false)
	{
		biomeType = t;
		TryAddToProcessingQueue();
		excludeFlag = exclude;
	}

	public override void StoreItemStateCache(Town town)
	{
		cachedTown = town;
	}

	public override bool IsImpossible()
	{
		if (cachedTown == null || cachedTown.biomeType == BiomeType.None || biomeType == BiomeType.None)
		{
			return false;
		}
		bool flag = cachedTown.biomeType == biomeType;
		if (!excludeFlag)
		{
			return !flag;
		}
		return flag;
	}

	public string PrintDebug()
	{
		return "ReqBiome " + biomeType.ToString() + " in cached town " + cachedTown;
	}

	public override bool IsMet()
	{
		return !IsImpossible();
	}

	public override string ToString()
	{
		return "Required Biome: " + biomeType;
	}
}
