using UnityEngine;

public class SalvageAndRepairUI : InventoryUI
{
	public SmallTitleUIBackground title;

	public ParticleSystem particles;

	public override int MAX_ROWS => 2;

	public override int MAX_COLUMNS => 3;

	public override void ShowContainerUI()
	{
		base.ShowContainerUI();
		UIManager.CraftingUITheme craftingUITheme = Manager.ui.GetCraftingUITheme(UIManager.CraftingUIThemeType.Stone);
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
				InventorySlotUI inventorySlotUI = itemSlot as InventorySlotUI;
				if (inventorySlotUI != null)
				{
					inventorySlotUI.darkBackgroundDefaultAlpha = craftingUITheme.backgroundColor.a;
				}
			}
			itemSlot.background.color = Color.white;
			itemSlot.hoverBorder.sprite = craftingUITheme.slotHoverSprite;
			itemSlot.activeBorder.sprite = craftingUITheme.slotSelectSprite;
		}
		if (title != null)
		{
			title.UpdateThemeTextAndBackground(craftingUITheme, 0);
		}
	}

	public void Salvage()
	{
		PlayerController playerController = Manager.main.player;
		if (!(playerController == null) && playerController.activeInventoryHandler != playerController.playerInventoryHandler && playerController.activeCraftingHandler.inventoryHandler.CanSalvageAnyItem())
		{
			AudioManager.SfxUI(SfxID.toolbreak, 1.2f, reuse: true, 0.75f, 0.1f);
			AudioManager.SfxUI(SfxID.woodenDestructable, 0.9f, reuse: true, 0.5f, 0.1f);
			AudioManager.SfxUI(SfxID.slingshotImpact, 1.1f, reuse: true, 0.4f, 0.05f);
			particles.Play(withChildren: true);
			playerController.activeCraftingHandler.inventoryHandler.SalvageAll(playerController, playerController.playerInventoryHandler, Manager.main.player.RenderPosition);
		}
	}

	public void ToggleRepair()
	{
		Manager.ui.mouse.SetMouseMode((Manager.ui.mouse.mouseMode != UIMouse.MouseMode.Repair) ? UIMouse.MouseMode.Repair : UIMouse.MouseMode.Normal);
		if (Manager.ui.mouse.mouseMode == UIMouse.MouseMode.Repair)
		{
			AudioManager.Sfx(SfxTableID.inventorySFXRepairOn, Manager.main.player.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.inventorySFXRepairOff, Manager.main.player.transform.position);
		}
	}

	public void ToggleReinforce()
	{
		Manager.ui.mouse.SetMouseMode((Manager.ui.mouse.mouseMode != UIMouse.MouseMode.Reinforce) ? UIMouse.MouseMode.Reinforce : UIMouse.MouseMode.Normal);
		if (Manager.ui.mouse.mouseMode == UIMouse.MouseMode.Reinforce)
		{
			AudioManager.Sfx(SfxTableID.inventorySFXReinforceOn, Manager.main.player.transform.position);
		}
		else
		{
			AudioManager.Sfx(SfxTableID.inventorySFXReinforceOff, Manager.main.player.transform.position);
		}
	}
}
