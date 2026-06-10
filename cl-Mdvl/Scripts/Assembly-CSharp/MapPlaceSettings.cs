using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Model;
using NSEipix.Repository;
using NSMedieval.Dictionary;
using NSMedieval.Model.SecondMap;
using NSMedieval.Village.Map;
using Repository.Map;
using UnityEngine;

[Serializable]
public class MapPlaceSettings : SingletonModel<MapPlaceSettings, MapPlaceSettingsData>
{
	[SerializeField]
	private SerializableIntStringDictionary stashLootConfigByWealth;

	[SerializeField]
	private SerializableIntStringDictionary banditCampLootConfigByWealth;

	[SerializeField]
	private IntRange stashDurationRangeMinutes;

	[SerializeField]
	private IntRange stashSpawnDistanceRange;

	[SerializeField]
	private IntRange banditCampDurationRangeMinutes;

	[SerializeField]
	private IntRange banditCampSpawnDistanceRange;

	[SerializeField]
	private List<string> stashMapIds;

	[SerializeField]
	private List<string> banditCampMapIds;

	[SerializeField]
	private int maxLootStashes;

	[SerializeField]
	private int maxBanditCamps;

	public Dictionary<int, string> StashLootConfigByWealth => stashLootConfigByWealth.Dictionary;

	public Dictionary<int, string> BanditCampLootConfigByWealth => banditCampLootConfigByWealth.Dictionary;

	public IntRange StashDurationRangeMinutes => stashDurationRangeMinutes;

	public IntRange StashSpawnDistanceRange => stashSpawnDistanceRange;

	public IntRange BanditCampDurationRangeMinutes => banditCampDurationRangeMinutes;

	public IntRange BanditCampSpawnDistanceRange => banditCampSpawnDistanceRange;

	public int MaxLootStashes => maxLootStashes;

	public int MaxBanditCamps => maxBanditCamps;

	public IReadOnlyList<string> StashMapIds
	{
		get
		{
			if (stashMapIds == null || stashMapIds.Count == 0)
			{
				stashMapIds = (from item in Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetSaves(SecondMapType.LootStash)
					select item.Id).ToList();
			}
			return stashMapIds;
		}
	}

	public IReadOnlyList<string> BanditCampMapIds
	{
		get
		{
			if (banditCampMapIds == null || banditCampMapIds.Count == 0)
			{
				banditCampMapIds = (from item in Repository<SecondMapSaveRepository, SecondMapSaveInfo>.Instance.GetSaves(SecondMapType.Attack)
					select item.Id).ToList();
			}
			return banditCampMapIds;
		}
	}

	public override string GetID()
	{
		return "MapPlaceSettings";
	}
}
