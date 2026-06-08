using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UITradeDroneUpgradeList : UIDroneUpgradeSellableList
{
	private IInventory sourceInventory;

	public override void Refresh()
	{
		base.CurrentHighlightedIndex = -1;
		topVisibleIndex = -1;
		bottomVisibleIndex = -1;
		base.CurrentPageIndex = 0;
		if (itemList != null && itemList.Length > 0)
		{
			UIModItemBreakableUpgrade[] array = itemList;
			foreach (UIModItem uIModItem in array)
			{
				if (uIModItem != null)
				{
					GameObjectPool.Instance.PushObject(uIModItem.gameObject);
				}
			}
		}
		itemList = new UIModItemBreakableUpgrade[0];
		sourceInventory = ((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory;
		if (sourceInventory.ItemsCopy != null)
		{
			List<IInventoryItem> list = null;
			IEnumerable<IInventoryItem> enumerable = sourceInventory.ItemsCopy.Where((IInventoryItem x) => x != null && x.GetType().BaseType == typeof(BaseDroneUpgrade));
			if (enumerable != null)
			{
				list = enumerable.ToList();
				int count = list.Count;
				int num = itemList.Length;
				Array.Resize(ref itemList, itemList.Length + count);
				for (int num2 = 0; num2 < count; num2++)
				{
					GameObject gameObject = GameObjectPool.Instance.PopObject("DroneUpgradeSellableItem");
					UIModItemBreakableUpgrade component = gameObject.GetComponent<UIModItemBreakableUpgrade>();
					component.Init();
					component.ClearHighlight();
					IInventoryItem inventoryItem = list[num2];
					itemList[num2 + num] = component;
					component.descriptionLabel.text = DroneManager.GetDroneUpgradeText((BaseDroneUpgrade)inventoryItem);
					component.overrideActiveColor = DroneManager.GetUpgradeStatus((BaseDroneUpgrade)inventoryItem, false);
					component.SetCost((int)inventoryItem.SellValue);
					component.breakProbabilityField.text = ((BaseDroneUpgrade)inventoryItem).BreakProbability.ToString("0.00") + "%";
					component.breakProbabilityField.color = component.overrideActiveColor;
					component.SetActive();
					component.InventoryItem = inventoryItem;
					if (GlobalSettings.GameState.ThePlayer.Inventory.Scrap >= component.Cost)
					{
						component.UnDim(true);
					}
					else
					{
						component.Dim(true);
					}
					gameObject.transform.SetParent(listContainer.transform);
					gameObject.transform.localScale = Vector3.one;
				}
			}
		}
		if (itemList.Length > 0)
		{
			base.CurrentHighlightedIndex = 0;
			topVisibleIndex = 0;
			bottomVisibleIndex = itemList.Length;
			if (itemList.Length > itemsPerPage)
			{
				int num3 = itemList.Length;
				for (int num4 = itemsPerPage; num4 < num3; num4++)
				{
					if (itemList[num4] != null)
					{
						itemList[num4].gameObject.SetActive(false);
					}
				}
				bottomVisibleIndex = itemsPerPage;
			}
		}
		RefreshMoreButtons();
	}

	public override bool RemoveBackendSelectedItem()
	{
		bool result = false;
		IUIItem highlightedItem = GetHighlightedItem();
		if (highlightedItem != null)
		{
			IInventoryItem inventoryItem = ((UIModItem)highlightedItem).InventoryItem;
			if (inventoryItem is ExpandedInventoryItem)
			{
				sourceInventory.RemoveInventoryItem(((ExpandedInventoryItem)inventoryItem).RealItem);
			}
			else
			{
				sourceInventory.RemoveInventoryItem(inventoryItem);
			}
			result = true;
			int currentHighlightedIndex = CurrentHighlightedIndex;
			Refresh();
			if (itemList.Length > 0)
			{
				UIModItem uIModItem = null;
				int num = -1;
				num = ((currentHighlightedIndex >= itemList.Length) ? (itemList.Length - 1) : currentHighlightedIndex);
				uIModItem = itemList[num];
				itemList[CurrentHighlightedIndex].ClearHighlight();
				base.CurrentHighlightedIndex = num;
				uIModItem.Highlight();
				ShowPageWithIndex(num);
			}
		}
		return result;
	}

	public override void AddBackendItem(IUIItem item)
	{
		IInventoryItem inventoryItem = ((UIModItem)item).InventoryItem;
		Inventory inventory = ((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory;
		if (inventoryItem is ExpandedInventoryItem)
		{
			inventory.AddInventoryItem(((ExpandedInventoryItem)inventoryItem).RealItem);
		}
		else
		{
			inventory.AddInventoryItem(inventoryItem);
		}
	}

	private void ShowPageWithIndex(int index)
	{
		int pageIdx = index / itemsPerPage;
		Show(pageIdx);
		RefreshMoreButtons();
	}
}
