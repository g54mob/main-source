using UnityEngine;

public class OutputSlotUI : InventorySlotUI
{
	public Transform timeOverlayMaskPivot;

	private Vector3 timeOverlayDefaultScale;

	private int outputForCraftingSlotIndex;

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
		bool flag = craftingHandler.HasStartedCrafting(outputForCraftingSlotIndex);
		if (flag)
		{
			float timerOverlay = 1f - craftingHandler.GetNormalizedElapsedCraftingTime(outputForCraftingSlotIndex);
			SetTimerOverlay(timerOverlay);
		}
		else
		{
			SetTimerOverlay(0f);
		}
		bool flag2 = flag && craftingHandler.IsCrafting(outputForCraftingSlotIndex);
		if (loopEffect != null)
		{
			bool active = flag2 && EntityUtility.HasComponentData<CraftingVisualCD>(craftingHandler.craftingEntity, base.world) && EntityUtility.GetComponentData<CraftingVisualCD>(craftingHandler.craftingEntity, base.world).showLoopEffectOnOutputSlot;
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
				ObjectID objectID3 = Manager.main.player.activeCraftingHandler.GetActiveRecipe(outputForCraftingSlotIndex)?.objectID ?? ObjectID.None;
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

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		IncreaseCookingSkillAndSpawnExtraFoodIfWeShould(GetObjectData().amount, tryingToMoveToMouse: true);
		Manager.ui.mouse.OnInventorySlotLeftClicked(this, tryToSendToOtherInventory: false, allowPlacingStuff: false);
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
		int num = (mod2 ? 100 : ((!mod1) ? 1 : 10));
		IncreaseCookingSkillAndSpawnExtraFoodIfWeShould(Mathf.Min(GetObjectData().amount, num), tryingToMoveToMouse: true);
		Manager.ui.mouse.OnInventorySlotRightClicked(this, allowPlacingStuff: false, num);
	}
}
