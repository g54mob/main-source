using System.Collections.Generic;
using UnityEngine;

public class PerkManager : Singleton<PerkManager>
{
	[SerializeField]
	private List<eItemType> list_LoadedPerkTypes;

	[SerializeField]
	private Dictionary<eItemType, APerkBase> dict_LoadedPerks;

	[Header("現在啟動中的異變")]
	[SerializeField]
	private List<APerkBase> list_ActivePerks;

	[SerializeField]
	[Header("所有啟動過的異變紀錄")]
	private List<eItemType> list_ActivatedPerkRecord;

	protected override void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void OnRoundEnd()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestActivatePerk(PerkSettingData settingData)
	{
	}

	public bool IsPerkCurrentlyActive(eItemType perkType)
	{
		return false;
	}

	public int GetPerkActivatedCount(eItemType perkType)
	{
		return 0;
	}

	public APerkBase GetLoadedPerkByType(eItemType type)
	{
		return null;
	}

	public void AddPerk(PerkSettingData settingData)
	{
	}

	private APerkBase AddComponentByPerkType(eItemType itemType)
	{
		return null;
	}
}
