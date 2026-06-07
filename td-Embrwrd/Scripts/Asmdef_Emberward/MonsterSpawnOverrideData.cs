using System.Collections.Generic;

public class MonsterSpawnOverrideData
{
	private List<eMonsterType> list_SmallMonsterOverride;

	private List<eMonsterType> list_MediumMonsterOverride;

	private List<eMonsterType> list_LargeMonsterOverride;

	private int overrideDuration;

	private int sourceID;

	public int OverrideDuration => 0;

	public int SourceID => 0;

	public MonsterSpawnOverrideData(int duration, int sourceID)
	{
	}

	public void AddOverrideMonster(eMonsterType type, eMonsterSize size)
	{
	}

	public void UpdateDuration()
	{
	}

	public eMonsterType GetRandomOverrideMonster(eMonsterSize size, eMonsterType originalType)
	{
		return default(eMonsterType);
	}
}
