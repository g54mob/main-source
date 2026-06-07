using System.Collections.Generic;
using UnityEngine;

public class DiscoverRewardHandler : Singleton<DiscoverRewardHandler>
{
	public enum eDiscoverRewardType
	{
		NORMAL_CHEST = 0,
		JOKER_CHEST = 1,
		SCRAP_MASTER_CHEST = 2
	}

	private enum eRewardItemType
	{
		NONE = 0,
		HP = 1,
		COIN = 2,
		PANEL = 3,
		TOWER = 4,
		BUFF = 5,
		GEAR = 6,
		REROLL = 7
	}

	[SerializeField]
	private DiscoverRewardAssetData settingData;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestDiscoverReward(eDiscoverRewardType discoverRewardType)
	{
	}

	private void OnDiscoverRewardSelected(DiscoverRewardPack discoverRewardPack, List<Vector3> positions)
	{
	}

	private void Update()
	{
	}

	public DiscoverRewardPack GenerateRewardPack_NormalChest(ref bool isCreatedHPRecovery, ref bool isCreatedReroll, ref bool isCreatedTowerCard)
	{
		return null;
	}

	public DiscoverRewardPack GenerateRewardPack_JokerChest(eTowerSizeType limitType, ref List<eItemType> list_ChosenTowerType)
	{
		return null;
	}
}
