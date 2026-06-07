using System.Collections.Generic;

public class RequiredBuildingSkills : Requirement
{
	public BuildingType buildingType;

	public int totalLevels;

	private List<Skill> skillCache;

	private bool isMissingTownCache;

	private static GameManager gm => GameManager.Instance;

	public RequiredBuildingSkills(BuildingType t, int requiredTotalLevels)
	{
		buildingType = t;
		totalLevels = requiredTotalLevels;
		TryAddToProcessingQueue();
	}

	public override Requirement GetCopy()
	{
		return new RequiredBuildingSkills(buildingType, totalLevels);
	}

	public override bool IsMet()
	{
		if (isMissingTownCache)
		{
			return false;
		}
		return CurrentCount() >= (float)totalLevels;
	}

	public override void StoreItemStateCache(Town town)
	{
		base.StoreItemStateCache(town);
		if (town.skillsPerBuilding.TryGetValue(buildingType, out var value))
		{
			skillCache = value;
		}
		else
		{
			isMissingTownCache = true;
		}
	}

	public float CurrentCount()
	{
		List<Skill> list = skillCache;
		if (list == null)
		{
			list = GameManager.Instance.ActiveTownBuildingSkills(buildingType);
		}
		int num = 0;
		if (list != null)
		{
			foreach (Skill item in list)
			{
				num += item.level;
			}
		}
		return num;
	}
}
