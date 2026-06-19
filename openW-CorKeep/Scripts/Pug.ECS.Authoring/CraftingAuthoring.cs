using System;
using System.Collections.Generic;
using NaughtyAttributes;
using Pug.UnityExtensions;
using UnityEngine;

public class CraftingAuthoring : MonoBehaviour
{
	[Serializable]
	public struct CraftableObject
	{
		public ObjectID objectID;

		[ShowIf("objectID", ObjectID.None)]
		[AllowNesting]
		public string moddedObjectID;

		public int amount;

		public bool craftingConsumesEntityAmount;

		[ShowIf("craftingConsumesEntityAmount")]
		[AllowNesting]
		public int entityAmountToConsume;

		public bool allowCraftingNone;

		public float craftingTime;

		public bool hasPrerequisites;

		[ShowIf("hasPrerequisites")]
		[AllowNesting]
		public Prerequisites prerequisites;
	}

	[Serializable]
	public struct Prerequisites
	{
		[InfoBox("The recipe is available if at least one of the conditions is met.", EInfoBoxType.Normal)]
		public OptionalValue<DataBlockRef<ContentBundleDataBlock>> contentBundlePresent;

		public OptionalValue<DataBlockRef<ContentBundleDataBlock>> contentBundleAbsent;

		public bool birdBossKilled;

		public bool octopusBossKilled;

		public bool scarabBossKilled;

		public bool hydraBossNatureKilled;

		public bool hydraBossSeaKilled;

		public bool hydraBossDesertKilled;
	}

	public CraftingType craftingType;

	public bool showLoopEffectOnOutputSlot;

	public bool allInventoryIsForSingleCraft;

	[AllowNesting]
	[HideIf("craftingType", CraftingType.Extract)]
	[ArrayElementTitle("objectID, amount")]
	public List<CraftableObject> canCraftObjects = new List<CraftableObject>();

	[AllowNesting]
	[HideIf("craftingType", CraftingType.Extract)]
	public List<CraftingAuthoring> includeCraftedObjectsFromBuildings;

	[AllowNesting]
	[ShowIf("craftingType", CraftingType.Extract)]
	public ObjectCategoryTag extractableType;

	[AllowNesting]
	[ShowIf("craftingType", CraftingType.Extract)]
	public Vector2 minMaxRandomDefaultExtractedOutputAmount;

	public Vector2 minMaxRandomDefaultCraftingTime;

	private void OnValidate()
	{
		for (int i = 0; i < canCraftObjects.Count; i++)
		{
			if (canCraftObjects[i].amount <= 0)
			{
				canCraftObjects[i] = new CraftableObject
				{
					objectID = canCraftObjects[i].objectID,
					amount = 1,
					craftingConsumesEntityAmount = (craftingType == CraftingType.Cattle)
				};
			}
		}
	}
}
