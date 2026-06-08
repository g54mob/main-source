using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIDroneUpgradeSellableList : MonoBehaviour, IUIList, IUIMultiPageList
{
	public GameObject itemPrefab;

	public GameObject moreUpObject;

	public GameObject moreDownObject;

	public GameObject listContainer;

	public int itemsPerPage = 17;

	protected UIModItemBreakableUpgrade[] itemList;

	protected int topVisibleIndex = -1;

	protected int bottomVisibleIndex = -1;

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public int ItemCount
	{
		get
		{
			if (itemList != null)
			{
				return itemList.Length;
			}
			return 0;
		}
	}

	public int CurrentPageIndex { get; protected set; }

	public int CurrentHighlightedIndex { get; protected set; }

	private void OnDestroy()
	{
		itemPrefab = null;
		moreUpObject = null;
		moreDownObject = null;
		listContainer = null;
	}

	public virtual void Refresh()
	{
		CurrentHighlightedIndex = -1;
		topVisibleIndex = -1;
		bottomVisibleIndex = -1;
		CurrentPageIndex = 0;
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
		if (GlobalSettings.GameState.ThePlayer.Drones != null)
		{
			int num = itemList.Length;
			foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
			{
				if (drone.Upgrades == null)
				{
					continue;
				}
				foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
				{
					if (upgrade != null)
					{
						Array.Resize(ref itemList, itemList.Length + 1);
						GameObject gameObject = GameObjectPool.Instance.PopObject("DroneUpgradeSellableItem");
						itemList[itemList.Length - 1] = gameObject.GetComponent<UIModItemBreakableUpgrade>();
						UIModItemBreakableUpgrade uIModItemBreakableUpgrade = itemList[itemList.Length - 1];
						uIModItemBreakableUpgrade.Init();
						uIModItemBreakableUpgrade.ClearHighlight();
						uIModItemBreakableUpgrade.descriptionLabel.text = DroneManager.GetDroneUpgradeText(upgrade);
						uIModItemBreakableUpgrade.overrideActiveColor = DroneManager.GetUpgradeStatus(upgrade, false);
						uIModItemBreakableUpgrade.SetCost((int)upgrade.SellValue);
						uIModItemBreakableUpgrade.breakProbabilityField.text = upgrade.BreakProbability.ToString("0.00") + "%";
						uIModItemBreakableUpgrade.breakProbabilityField.color = uIModItemBreakableUpgrade.overrideActiveColor;
						uIModItemBreakableUpgrade.InventoryItem = upgrade;
						uIModItemBreakableUpgrade.ParentItem = (IInventoryItem)drone;
						uIModItemBreakableUpgrade.SetActive();
						if (((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory.Scrap >= uIModItemBreakableUpgrade.Cost)
						{
							uIModItemBreakableUpgrade.UnDim(true);
						}
						else
						{
							uIModItemBreakableUpgrade.Dim(true);
						}
						gameObject.transform.SetParent(listContainer.transform);
						gameObject.transform.localScale = Vector3.one;
						num++;
					}
				}
			}
		}
		if (GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy != null)
		{
			List<IInventoryItem> list = null;
			IEnumerable<IInventoryItem> enumerable = GlobalSettings.GameState.ThePlayer.Inventory.ItemsCopy.Where((IInventoryItem x) => x != null && x.GetType().BaseType == typeof(BaseDroneUpgrade));
			if (enumerable != null)
			{
				list = enumerable.ToList();
				int count = list.Count;
				int num2 = itemList.Length;
				Array.Resize(ref itemList, itemList.Length + count);
				for (int num3 = 0; num3 < count; num3++)
				{
					GameObject gameObject2 = GameObjectPool.Instance.PopObject("DroneUpgradeSellableItem");
					UIModItemBreakableUpgrade component = gameObject2.GetComponent<UIModItemBreakableUpgrade>();
					component.Init();
					component.ClearHighlight();
					IInventoryItem inventoryItem = list[num3];
					itemList[num3 + num2] = component;
					component.descriptionLabel.text = DroneManager.GetDroneUpgradeText((BaseDroneUpgrade)inventoryItem);
					component.overrideActiveColor = DroneManager.GetUpgradeStatus((BaseDroneUpgrade)inventoryItem, false);
					component.SetCost((int)inventoryItem.SellValue);
					component.breakProbabilityField.text = ((BaseDroneUpgrade)inventoryItem).BreakProbability.ToString("0.00") + "%";
					component.breakProbabilityField.color = component.overrideActiveColor;
					component.InventoryItem = inventoryItem;
					component.SetActive();
					if (((TradingPostInfo)GalaxyMapManager.Instance.SelectedDungeon).Inventory.Scrap >= component.Cost)
					{
						component.UnDim(true);
					}
					else
					{
						component.Dim(true);
					}
					gameObject2.transform.SetParent(listContainer.transform);
					gameObject2.transform.localScale = Vector3.one;
				}
			}
		}
		if (itemList.Length > 0)
		{
			CurrentHighlightedIndex = 0;
			topVisibleIndex = 0;
			bottomVisibleIndex = itemList.Length;
			if (itemList.Length > itemsPerPage)
			{
				int num4 = itemList.Length;
				for (int num5 = itemsPerPage; num5 < num4; num5++)
				{
					if (itemList[num5] != null)
					{
						itemList[num5].gameObject.SetActive(false);
					}
				}
				bottomVisibleIndex = itemsPerPage;
			}
		}
		RefreshMoreButtons();
	}

	public void MoveToFirstPage()
	{
		Show(0);
		RefreshMoreButtons();
	}

	public void MoveToLastPage()
	{
		Show(NumberOfPages() - 1);
		RefreshMoreButtons();
	}

	public bool PageForward()
	{
		int num = 0;
		num = ((CurrentPageIndex + 1 != 1) ? (CurrentPageIndex * itemsPerPage + itemsPerPage) : itemsPerPage);
		if (num < itemList.Length)
		{
			Show(CurrentPageIndex + 1);
			RefreshMoreButtons();
			return true;
		}
		return false;
	}

	public bool PageBack()
	{
		if (CurrentPageIndex > 0)
		{
			Show(CurrentPageIndex - 1);
			RefreshMoreButtons();
			return true;
		}
		return false;
	}

	public void Show(int pageIdx)
	{
		int num = itemList.Length;
		if (num <= 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			itemList[i].gameObject.SetActive(false);
		}
		CurrentPageIndex = pageIdx;
		int num2 = 0;
		int num3 = itemsPerPage;
		if (CurrentPageIndex == 0)
		{
			num3 = itemsPerPage;
		}
		else if (CurrentPageIndex == 1)
		{
			num2 = itemsPerPage;
			num3 = num2 + itemsPerPage;
		}
		else
		{
			num2 = (pageIdx - 1) * itemsPerPage + itemsPerPage;
			num3 = num2 + itemsPerPage;
		}
		if (num2 <= itemList.Length)
		{
			if (num3 > itemList.Length)
			{
				num3 = itemList.Length;
			}
			for (int j = num2; j < num3; j++)
			{
				itemList[j].gameObject.SetActive(true);
			}
			topVisibleIndex = num2;
			bottomVisibleIndex = num3;
		}
	}

	public void GotFocus()
	{
		if (CurrentHighlightedIndex == -1 && itemList.Length > 0)
		{
			CurrentHighlightedIndex = 0;
		}
		if (CurrentHighlightedIndex != -1)
		{
			itemList[CurrentHighlightedIndex].Highlight();
		}
		RefreshMoreButtons();
	}

	public void LoseFocus()
	{
		if (itemList != null && itemList.Length > 0 && CurrentHighlightedIndex != -1)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
		}
	}

	public bool MoveDown()
	{
		if (itemList != null && itemList.Length > 0)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex += 1;
			if (CurrentHighlightedIndex >= bottomVisibleIndex)
			{
				return true;
			}
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveUp()
	{
		if (itemList != null && itemList.Length > 0)
		{
			itemList[CurrentHighlightedIndex].ClearHighlight();
			CurrentHighlightedIndex -= 1;
			if (CurrentHighlightedIndex < topVisibleIndex)
			{
				return true;
			}
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToBottom()
	{
		if (itemList != null && itemList.Length > 0)
		{
			CurrentHighlightedIndex = bottomVisibleIndex - 1;
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public bool MoveToTop()
	{
		if (itemList != null && itemList.Length > 0)
		{
			CurrentHighlightedIndex = topVisibleIndex;
			itemList[CurrentHighlightedIndex].Highlight();
			return false;
		}
		return true;
	}

	public void MoveToTopOrSelected()
	{
		IUIItem selectedItem = GetSelectedItem();
		if (selectedItem == null)
		{
			MoveToTop();
			return;
		}
		CurrentHighlightedIndex = 0;
		UIModItemBreakableUpgrade[] array = itemList;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsSelected)
			{
				break;
			}
			CurrentHighlightedIndex += 1;
		}
		selectedItem.Highlight();
	}

	public bool DeleteHighlightedItem()
	{
		throw new NotImplementedException();
	}

	public void DeleteAllItems()
	{
		if (itemList != null)
		{
			int num = itemList.Length;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				GameObjectPool.Instance.PushObject(itemList[num2].UnderlyingGameObject);
			}
			itemList = null;
		}
	}

	public virtual bool RemoveBackendSelectedItem()
	{
		bool flag = false;
		IUIItem highlightedItem = GetHighlightedItem();
		if (highlightedItem != null)
		{
			foreach (IDrone drone in GlobalSettings.GameState.ThePlayer.Drones)
			{
				if (drone.Upgrades == null)
				{
					continue;
				}
				int num = -1;
				foreach (BaseDroneUpgrade upgrade in drone.Upgrades)
				{
					num++;
					if (upgrade == (BaseDroneUpgrade)((UIModItem)highlightedItem).InventoryItem)
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					drone.Upgrades[num] = null;
					break;
				}
			}
			if (!flag)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.RemoveInventoryItem(((UIModItem)highlightedItem).InventoryItem);
				flag = true;
			}
			int currentHighlightedIndex = CurrentHighlightedIndex;
			Refresh();
			if (itemList.Length > 0)
			{
				UIModItem uIModItem = null;
				int num2 = -1;
				num2 = ((currentHighlightedIndex >= itemList.Length) ? (itemList.Length - 1) : currentHighlightedIndex);
				uIModItem = itemList[num2];
				itemList[CurrentHighlightedIndex].ClearHighlight();
				CurrentHighlightedIndex = num2;
				uIModItem.Highlight();
				ShowPageWithIndex(num2);
			}
		}
		return flag;
	}

	public virtual void AddBackendItem(IUIItem item)
	{
		IInventoryItem inventoryItem = ((UIModItem)item).InventoryItem;
		Inventory inventory = GlobalSettings.GameState.ThePlayer.Inventory;
		if (inventoryItem is ExpandedInventoryItem)
		{
			inventory.AddInventoryItem(((ExpandedInventoryItem)inventoryItem).RealItem);
		}
		else
		{
			inventory.AddInventoryItem(inventoryItem);
		}
	}

	public IUIItem SelectHighlightedItem()
	{
		if (CurrentHighlightedIndex >= topVisibleIndex && CurrentHighlightedIndex <= bottomVisibleIndex)
		{
			itemList[CurrentHighlightedIndex].Select();
			return itemList[CurrentHighlightedIndex];
		}
		return null;
	}

	public IUIItem GetHighlightedItem()
	{
		UIModItemBreakableUpgrade[] array = itemList;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsHighlighted)
			{
				return iUIItem;
			}
		}
		return null;
	}

	public IUIItem GetSelectedItem()
	{
		UIModItemBreakableUpgrade[] array = itemList;
		foreach (IUIItem iUIItem in array)
		{
			if (iUIItem.IsSelected)
			{
				return iUIItem;
			}
		}
		return null;
	}

	protected void RefreshMoreButtons()
	{
		int num = NumberOfPages();
		if (num > 1)
		{
			if (CurrentPageIndex > 0)
			{
				moreUpObject.SetActive(true);
			}
			else
			{
				moreUpObject.SetActive(false);
			}
			if (CurrentPageIndex < num - 1)
			{
				moreDownObject.SetActive(true);
			}
			else
			{
				moreDownObject.SetActive(false);
			}
		}
		else
		{
			moreUpObject.SetActive(false);
			moreDownObject.SetActive(false);
		}
	}

	public int NumberOfPages()
	{
		int num = itemList.Length;
		if (num == 0)
		{
			return 0;
		}
		if (num <= itemsPerPage)
		{
			return 1;
		}
		int num2 = num - itemsPerPage;
		float f = (float)num2 / (float)itemsPerPage;
		return Mathf.CeilToInt(f) + 1;
	}

	private void ShowPageWithIndex(int index)
	{
		int pageIdx = index / itemsPerPage;
		Show(pageIdx);
		RefreshMoreButtons();
	}
}
