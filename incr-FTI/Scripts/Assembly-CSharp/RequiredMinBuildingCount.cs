public class RequiredMinBuildingCount : Requirement
{
	public readonly BuildingType buildingType;

	private Town cachedTown;

	private BuildingState cachedBuildingState;

	public readonly int numBuildingsRequired;

	private FloatProperty cachedGlobalCount;

	public RequiredMinBuildingCount(BuildingType type, int count)
	{
		buildingType = type;
		numBuildingsRequired = count;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredMinBuildingCount(buildingType, numBuildingsRequired);
	}

	public override void StoreItemStateCacheGlobal()
	{
		base.StoreItemStateCacheGlobal();
		cachedGlobalCount = GameManager.Instance.GetOrCreateCachedBuildingCount(buildingType);
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		cachedTown = town;
		if (buildingType != BuildingType.None && buildingType != BuildingType.Base && town.buildings.TryGetValue(buildingType, out var value))
		{
			cachedBuildingState = value;
		}
	}

	public double CurrentCount()
	{
		if (buildingType == BuildingType.None)
		{
			if (cachedTown == null)
			{
				return GameManager.Instance.activeTown.totalBuildings;
			}
			return cachedTown.totalBuildings;
		}
		if (buildingType == BuildingType.Base)
		{
			return GameManager.Instance.numTowns;
		}
		if (isTargetingGlobalStat && cachedGlobalCount != null)
		{
			return cachedGlobalCount.value;
		}
		if (cachedBuildingState == null)
		{
			return GameManager.Instance.NumBuildingsOfType(buildingType);
		}
		return cachedBuildingState.currentCount;
	}

	public override bool IsMet()
	{
		return CurrentCount() >= (double)numBuildingsRequired;
	}

	public override string ToString()
	{
		return $"Required Building Count {TextDisplay.LabelForBuilding(buildingType)}={numBuildingsRequired}";
	}
}
