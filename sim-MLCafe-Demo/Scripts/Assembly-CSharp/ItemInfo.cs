using System;
using MLCN_Localization;
using UnityEngine;

[Serializable]
public class ItemInfo
{
	public enum ItemType
	{
		Tool = 0,
		Ingredient = 1,
		Workstation = 2,
		Dish = 3,
		Furniture = 4,
		Decoration = 5,
		Other = 6
	}

	public ItemType itemType;

	public string name;

	public string description;

	public string localizationKey;

	public string localizationKeyDescription;

	public Sprite icon;

	public GameObject prefab;

	public GameObject previewPrefab;

	public string animationTrigger;

	public int maxStack;

	public int upkeep;

	public int ambientRating;

	public ItemBehaviour.BehaviourType behaviorType;

	public LayerMask dataLayer_1;

	public AnomalyTag dataLayer_2;

	public int dataLayer_3;

	public string GetLocalizedName()
	{
		return LocalizationManager.GetLocalizedString(localizationKey, LocalizationManager.GetTableItemKeys());
	}

	public string GetLocalizedDescription()
	{
		return LocalizationManager.GetLocalizedString(localizationKeyDescription, LocalizationManager.GetTableItemKeys());
	}
}
