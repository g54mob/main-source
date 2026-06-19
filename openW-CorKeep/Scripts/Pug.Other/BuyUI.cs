using UnityEngine;

public class BuyUI : MonoBehaviour
{
	public BuyInventoryUI buyInventory;

	public GameObject root;

	public SpriteRenderer background;

	public SmallTitleUIBackground title;

	public bool isShowing => root.activeInHierarchy;

	private void Awake()
	{
		buyInventory.Init();
		root.SetActive(value: false);
	}

	private void LateUpdate()
	{
		root.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	public void ShowContainerUI()
	{
		buyInventory.ShowContainerUI();
		if (Manager.ui.isSellUIShowing)
		{
			root.transform.localPosition = new Vector3(-2.5f, 3.3125f, 0f);
		}
		else
		{
			root.transform.localPosition = new Vector3(0f, 3.3125f, 0f);
		}
		root.SetActive(value: true);
		UIManager.CraftingUIThemeType craftingUIThemeType = UIManager.CraftingUIThemeType.Wood;
		bool flag = false;
		InteractableObject currentInteractableObject = Manager.main.player.GetCurrentInteractableObject();
		if (currentInteractableObject != null && currentInteractableObject.transform.parent.GetComponent<VendingMachine>() != null)
		{
			flag = true;
		}
		if (flag)
		{
			craftingUIThemeType = UIManager.CraftingUIThemeType.Stone;
		}
		UIManager.CraftingUITheme craftingUITheme = Manager.ui.GetCraftingUITheme(craftingUIThemeType);
		background.sprite = craftingUITheme.background;
		foreach (SlotUIBase itemSlot in buyInventory.itemSlots)
		{
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
			itemSlot.hoverBorder.sprite = craftingUITheme.slotHoverSprite;
			itemSlot.activeBorder.sprite = craftingUITheme.slotSelectSprite;
			((InventorySlotUI)itemSlot).useWhiteColoredBorderForCommonItems = true;
		}
		if (title != null)
		{
			title.UpdateThemeTextAndBackground(craftingUITheme, 0);
		}
	}

	public void HideContainerUI()
	{
		buyInventory.HideContainerUI();
		root.SetActive(value: false);
	}
}
