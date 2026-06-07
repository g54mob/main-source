using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/一般關卡的無盡模式設定 (BasicEndlessModeSettingData)", order = 1)]
public class BasicEndlessModeSettingData : ScriptableObject
{
	[SerializeField]
	private List<EndlessMapData> list_LevelData;

	[SerializeField]
	[Header("可以開場取得的神器")]
	private List<eItemType> list_StartingRelics;

	[SerializeField]
	private List<TowerPresetData> list_TowerPresets;

	public List<EndlessMapData> GetAvailableEndlessMaps(int weekIndex)
	{
		return null;
	}

	public EndlessMapData GetDailyEndlessMapData(DateTime currentDate)
	{
		return null;
	}

	public EndlessMapData GetWeeklyEndlessMapData(DateTime currentDate)
	{
		return null;
	}

	public EndlessMapData GetEndlessMapDataBySeed(int seed)
	{
		return null;
	}

	public EndlessMapData GetSpecificEndlessMap(eEndlessModeType endlessModeType)
	{
		return null;
	}

	public int GetWeekOfYear(DateTime time)
	{
		return 0;
	}

	public List<eItemType> GetRandomStartingRelics(int count, int seed)
	{
		return null;
	}

	public TowerPresetData GetRandomTowerPreset(int seed)
	{
		return null;
	}
}
