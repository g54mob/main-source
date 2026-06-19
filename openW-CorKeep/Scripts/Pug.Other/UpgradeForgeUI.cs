using UnityEngine;

public class UpgradeForgeUI : InventoryUI
{
	public UpgradePreviewSlotUI previewSlot;

	public UpgradeForgeButton button;

	public override int MAX_ROWS => 1;

	public override int MAX_COLUMNS => 1;

	public override void ShowContainerUI()
	{
		base.ShowContainerUI();
		UIManager.CraftingUIThemeType craftingUIThemeType = UIManager.CraftingUIThemeType.Stone;
		CraftingBuilding craftingBuilding = GetCraftingBuilding();
		if (craftingBuilding != null && craftingBuilding.entityExist)
		{
			craftingUIThemeType = craftingBuilding.GetCraftingUISettings().craftingUIBackgroundVariation;
		}
		UIManager.CraftingUITheme craftingUITheme = Manager.ui.GetCraftingUITheme(craftingUIThemeType);
		foreach (SlotUIBase itemSlot in itemSlots)
		{
			(itemSlot as InventorySlotUI).useWhiteColoredBorderForCommonItems = true;
			itemSlot.background.sprite = craftingUITheme.inventorySlotBackground;
			if (itemSlot.tiledDecorationBackground != null)
			{
				itemSlot.tiledDecorationBackground.gameObject.SetActive(craftingUITheme.inventorySlotTiledDecorationBackground != null);
				Vector2 size = itemSlot.tiledDecorationBackground.size;
				itemSlot.tiledDecorationBackground.sprite = craftingUITheme.inventorySlotTiledDecorationBackground;
				itemSlot.tiledDecorationBackground.size = size;
			}
			if (itemSlot.darkBackground != null)
			{
				itemSlot.darkBackground.color = craftingUITheme.backgroundColor;
			}
			InventorySlotUI inventorySlotUI = itemSlot as InventorySlotUI;
			if (inventorySlotUI != null)
			{
				inventorySlotUI.darkBackgroundDefaultAlpha = craftingUITheme.backgroundColor.a;
			}
			itemSlot.background.color = Color.white;
			itemSlot.hoverBorder.sprite = craftingUITheme.slotHoverSprite;
			itemSlot.activeBorder.sprite = craftingUITheme.slotSelectSprite;
		}
	}

	protected override void LateUpdate()
	{
		base.LateUpdate();
		if (!isShowing)
		{
			return;
		}
		ContainedObjectsBuffer containedObject = itemSlots[0].GetContainedObject();
		button.UpdateSlotItem(containedObject);
		if (containedObject.objectID == ObjectID.None)
		{
			previewSlot.Show(value: false);
			return;
		}
		ObjectInfo objectInfo = PugDatabase.GetObjectInfo(containedObject.objectID, containedObject.variation);
		int num = ((containedObject.objectData.variation > 0) ? containedObject.objectData.variation : PugDatabase.GetComponent<LevelCD>(containedObject.objectData).level);
		if (objectInfo != null && num < LevelScaling.GetMaxLevel())
		{
			previewSlot.Show(value: true);
			previewSlot.UpdatePreview(itemSlots[0]);
		}
		else
		{
			previewSlot.Show(value: false);
		}
	}

	public void Upgrade()
	{
		PlayerController playerController = Manager.main.player;
		if (!(playerController == null))
		{
			InventoryHandler inventoryHandler = GetInventoryHandler();
			playerController.activeCraftingHandler.Upgrade(playerController, 0, inventoryHandler);
		}
	}

	protected CraftingBuilding GetCraftingBuilding()
	{
		InteractableObject currentInteractableObject = Manager.main.player.GetCurrentInteractableObject();
		if (currentInteractableObject != null && Manager.main.player.activeCraftingHandler != Manager.main.player.playerCraftingHandler)
		{
			return currentInteractableObject.transform.parent.GetComponent<CraftingBuilding>();
		}
		return null;
	}
}
