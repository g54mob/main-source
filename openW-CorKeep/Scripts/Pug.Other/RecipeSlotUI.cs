using System.Collections.Generic;
using Pug.UnityExtensions;
using UnityEngine;

public class RecipeSlotUI : SlotUIBase
{
	private TimerSimple holdDownCraftTimer;

	private const float TIME_BETWEEN_CRAFTS_SPEED1 = 0.35f;

	private const float TIME_BETWEEN_CRAFTS_SPEED2 = 0.1f;

	private float timeBetweenCraftsWhenHolding;

	private int craftsDoneWhileHolding;

	protected CraftingHandler activeCraftingHandler => Manager.main.player?.activeCraftingHandler;

	private bool canActivateCrafting
	{
		get
		{
			if (IsCraftingAllowed)
			{
				if (!Manager.ui.simpleCraftingUIContainer.isShowing && !Manager.ui.processResourcesCraftingUI.isShowing && !Manager.ui.bossStatueUI.isShowing && !Manager.ui.biomeBossStatueUI.isShowing)
				{
					return Manager.ui.biomeBossHydraStatueUI.isShowing;
				}
				return true;
			}
			return false;
		}
	}

	protected virtual bool IsCraftingAllowed => true;

	private CraftingHandler.RecipeInfo GetRecipeInfo()
	{
		if (activeCraftingHandler == null)
		{
			return default(CraftingHandler.RecipeInfo);
		}
		return activeCraftingHandler.GetRecipeInfo(base.inventorySlotIndex);
	}

	public override void UpdateSlot()
	{
		background.gameObject.SetActive(Manager.ui.simpleCraftingUIContainer.isShowing || Manager.ui.bossStatueUI.isShowing || Manager.ui.biomeBossStatueUI.isShowing || Manager.ui.biomeBossHydraStatueUI.isShowing);
		CraftingHandler.RecipeInfo recipeInfo = GetRecipeInfo();
		if (recipeInfo.isValid)
		{
			Sprite sprite = null;
			Vector3 zero = Vector3.zero;
			Sprite iconOverride = Manager.ui.itemOverridesTable.GetIconOverride(new ObjectData
			{
				objectID = recipeInfo.objectID
			}, getSmallIcon: false);
			if (iconOverride != null)
			{
				sprite = iconOverride;
				zero = Vector3.zero;
			}
			else
			{
				sprite = recipeInfo.icon;
				zero = recipeInfo.iconOffset;
			}
			if (sprite == null)
			{
				sprite = missingIconSprite;
				zero = Vector3.zero;
			}
			icon.sprite = sprite;
			icon.transform.localPosition = zero;
			if (activeCraftingHandler != null && activeCraftingHandler.HasMaterialsInCraftingInventoryToCraftRecipe(base.inventorySlotIndex, checkPlayerInventoryToo: true, activeCraftingHandler.GetNearbyChests()))
			{
				icon.color = Color.white;
			}
			else
			{
				icon.color = new Color(0.8f, 0.8f, 0.8f, 0.5f);
			}
			int amount = recipeInfo.amount;
			RenderAmountNumber(amount);
		}
		else
		{
			SetEmptyIcon();
			RenderAmountNumber(0);
		}
		if (base.leftClickIsHeldDown && canActivateCrafting)
		{
			if (!holdDownCraftTimer.isRunning || holdDownCraftTimer.isTimerElapsed)
			{
				if (craftsDoneWhileHolding > 0)
				{
					timeBetweenCraftsWhenHolding = 0.1f;
				}
				holdDownCraftTimer.Start(timeBetweenCraftsWhenHolding);
				if (craftsDoneWhileHolding > 0)
				{
					Manager.ui.activeCraftingUI.ActivateRecipeSlot(base.inventorySlotIndex, base.mod1IsHeldDown, base.mod2IsHeldDown);
				}
				craftsDoneWhileHolding++;
			}
		}
		else
		{
			holdDownCraftTimer.Stop();
			timeBetweenCraftsWhenHolding = 0.35f;
			craftsDoneWhileHolding = 0;
		}
	}

	public override void OnSelected()
	{
		OnSelectSlot();
	}

	public override void OnDeselected(bool playEffect = true)
	{
		OnDeselectSlot();
	}

	public override void OnLeftClicked(bool mod1, bool mod2)
	{
		if (canActivateCrafting)
		{
			Manager.ui.activeCraftingUI.ActivateRecipeSlot(base.inventorySlotIndex, mod1, mod2);
		}
	}

	public override void OnRightClicked(bool mod1, bool mod2)
	{
	}

	public override List<PugDatabase.MaterialInfo> GetRequiredMaterials(bool isRepairing, bool isReinforcing)
	{
		return activeCraftingHandler?.GetCraftingMaterialInfosForRecipe(base.inventorySlotIndex, activeCraftingHandler.GetNearbyChests(), isRepairing, isReinforcing);
	}

	public override CraftingSettings GetCraftingSettings()
	{
		ContainedObjectsBuffer slotObject = GetSlotObject();
		if (slotObject.objectID != ObjectID.None)
		{
			return PugDatabase.GetObjectInfo(slotObject.objectID).craftingSettings;
		}
		return base.GetCraftingSettings();
	}
}
