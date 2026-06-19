using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class ShopItem
{
	public BuildingAsset BuildingAsset;

	[field: SerializeField]
	public List<Checkpoint> UnlockPrerequisites { get; private set; }

	public bool PrerequisitesMet => false;

	public bool AlreadyUnlocked => false;

	public bool DemoLocked => false;

	public bool Valid => false;

	public Sprite Icon => null;

	public LocalizedString Title => null;

	public List<CostStack> Cost => null;

	public ShopItem(BuildingAsset buildingAsset)
	{
	}
}
