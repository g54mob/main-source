using System;
using System.Collections.Generic;
using Data.Objectives.Events;
using UnityEngine;

[Serializable]
public class ModuleChallengeSet
{
	public int ID;

	public string TitleLocaKey;

	public Sprite Icon;

	public string RewardNameLocaKey;

	public Sprite RewardThumbnail;

	public List<ObjectiveTargetCategorySO> Categories = new List<ObjectiveTargetCategorySO>();

	public List<AbstractObjectiveEvent> Events;

	private ModuleViewerData _moduleViewerData;

	public const int METAL_TIERS_MAX = 3;

	public const int SILVER_TIERS_MAX = 3;

	public const int GOLD_TIERS_MAX = 3;

	public ModuleViewerData GetModuleViewerData => _moduleViewerData;

	public bool AllFirstTiersCompleted => GetTotalCompletedMetalTiers() >= 3;

	public bool AllTiersCompleted
	{
		get
		{
			if (GetTotalCompletedMetalTiers() >= 3 && GetTotalCompletedSilverTiers() >= 3)
			{
				return GetTotalCompletedGoldTiers() >= 3;
			}
			return false;
		}
	}

	public int GetTotalCompletedMetalTiers()
	{
		int num = 0;
		foreach (ObjectiveTargetCategorySO category in Categories)
		{
			if (category.IsMetalCompleted)
			{
				num++;
			}
		}
		return num;
	}

	public int GetTotalCompletedSilverTiers()
	{
		int num = 0;
		foreach (ObjectiveTargetCategorySO category in Categories)
		{
			if (category.IsSilverCompleted)
			{
				num++;
			}
		}
		return num;
	}

	public int GetTotalCompletedGoldTiers()
	{
		int num = 0;
		foreach (ObjectiveTargetCategorySO category in Categories)
		{
			if (category.IsGoldCompleted)
			{
				num++;
			}
		}
		return num;
	}

	public void InitModuleViewerData(int index)
	{
		ID = index;
		List<ModuleViewerData.ShapeDataAndAmount> list = new List<ModuleViewerData.ShapeDataAndAmount>();
		foreach (ObjectiveTargetCategorySO category in Categories)
		{
			list.Add(new ModuleViewerData.ShapeDataAndAmount(category.Resource.ShapeData, 1));
		}
		_moduleViewerData = new ModuleViewerData(TitleLocaKey, Icon, list, index);
	}
}
