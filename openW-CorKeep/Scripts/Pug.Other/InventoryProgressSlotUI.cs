using UnityEngine;

public class InventoryProgressSlotUI : InventorySlotUI
{
	public Transform timeOverlayMaskPivot;

	private Vector3 timeOverlayDefaultScale;

	public override void Init(ItemSlotsUIContainer slotsUIContainer)
	{
		base.Init(slotsUIContainer);
		timeOverlayDefaultScale = timeOverlayMaskPivot.localScale;
		SetTimerOverlay(0f);
	}

	public override void UpdateSlot()
	{
		CraftingHandler craftingHandler = Manager.main.player?.activeCraftingHandler;
		if (craftingHandler == null)
		{
			return;
		}
		int slotIndex = base.inventorySlotIndex;
		bool flag = craftingHandler.HasStartedCrafting(slotIndex);
		if (flag)
		{
			float timerOverlay = 1f - craftingHandler.GetNormalizedElapsedCraftingTime(slotIndex);
			SetTimerOverlay(timerOverlay);
		}
		else
		{
			SetTimerOverlay(0f);
		}
		bool flag2 = flag && craftingHandler.IsCrafting(slotIndex);
		if (loopEffect != null)
		{
			CraftingVisualCD value;
			bool active = flag2 && EntityUtility.TryGetComponentData<CraftingVisualCD>(craftingHandler.craftingEntity, base.world, out value) && value.showLoopEffectOnOutputSlot;
			loopEffect.SetActive(active);
		}
		base.UpdateSlot();
		if (!HasObject() && flag)
		{
			if (craftingHandler.craftingType == CraftingType.Cooking)
			{
				ObjectID objectID = craftingHandler.inventoryHandler.GetObjectData(0).objectID;
				ObjectID objectID2 = craftingHandler.inventoryHandler.GetObjectData(1).objectID;
				if (objectID != ObjectID.None && objectID2 != ObjectID.None)
				{
					ObjectDataCD objectData = new ObjectDataCD
					{
						objectID = PugDatabase.GetComponent<CookingIngredientCD>(CookedFoodCD.GetPrimaryIngredient(objectID, objectID2)).turnsIntoFood,
						amount = 1,
						variation = CookedFoodCD.GetFoodVariation(objectID, objectID2)
					};
					ShowHint(objectData, showSilhouette: true);
				}
				else
				{
					HideHint();
				}
			}
			else
			{
				ObjectID objectID3 = Manager.main.player.activeCraftingHandler.GetActiveRecipe(slotIndex)?.objectID ?? ObjectID.None;
				ObjectDataCD objectData2 = new ObjectDataCD
				{
					objectID = objectID3,
					amount = 1,
					variation = 0
				};
				if (objectData2.objectID == ObjectID.None)
				{
					HideHint();
				}
				else
				{
					ShowHint(objectData2, showSilhouette: true);
				}
			}
		}
		else
		{
			HideHint();
		}
	}

	private void SetTimerOverlay(float value)
	{
		timeOverlayMaskPivot.localScale = new Vector3(timeOverlayDefaultScale.x, Mathf.Lerp(0f, timeOverlayDefaultScale.y, value), timeOverlayDefaultScale.z);
	}

	public override void OnSelected()
	{
		hoverBorder.gameObject.SetActive(value: true);
	}

	public override void OnDeselected(bool playEffect = true)
	{
		hoverBorder.gameObject.SetActive(value: false);
	}
}
