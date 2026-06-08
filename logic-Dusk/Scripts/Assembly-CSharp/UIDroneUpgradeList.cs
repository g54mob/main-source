using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIDroneUpgradeList : MonoBehaviour, IUIList, IUIMultiPageList
{
	public GameObject itemPrefab;

	public GameObject moreUpObject;

	public GameObject moreDownObject;

	public GameObject listContainer;

	public int itemsPerPage = 17;

	protected UIUpgradeItem[] itemList;

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
		if (itemList != null)
		{
			int num = itemList.Length;
			for (int i = 0; i < num; i++)
			{
				itemList[i] = null;
			}
			itemList = null;
		}
	}

	public virtual void Refresh()
	{
		CurrentHighlightedIndex = -1;
		topVisibleIndex = -1;
		bottomVisibleIndex = -1;
		CurrentPageIndex = 0;
		if (itemList != null && itemList.Length > 0)
		{
			int num = itemList.Length;
			for (int i = 0; i < num; i++)
			{
				UIUpgradeItem uIUpgradeItem = itemList[i];
				if (uIUpgradeItem != null)
				{
					GameObjectPool.Instance.PushObject(uIUpgradeItem.gameObject);
				}
			}
		}
		itemList = new UIUpgradeItem[0];
		if (GlobalSettings.GameState.ThePlayer.Drones != null)
		{
			int num2 = itemList.Length;
			int count = GlobalSettings.GameState.ThePlayer.Drones.Count;
			for (int j = 0; j < count; j++)
			{
				IDrone drone = GlobalSettings.GameState.ThePlayer.Drones[j];
				if (drone.Upgrades == null)
				{
					continue;
				}
				int count2 = drone.Upgrades.Count;
				for (int k = 0; k < count2; k++)
				{
					BaseDroneUpgrade baseDroneUpgrade = drone.Upgrades[k];
					if (baseDroneUpgrade == null)
					{
						continue;
					}
					Array.Resize(ref itemList, itemList.Length + 1);
					GameObject gameObject = GameObjectPool.Instance.PopObject("DroneUpgradeItem");
					itemList[itemList.Length - 1] = gameObject.GetComponent<UIUpgradeItem>();
					UIUpgradeItem uIUpgradeItem2 = itemList[itemList.Length - 1];
					List<IModification> modificationsForType = ModificationsHelper.GetModificationsForType(baseDroneUpgrade.GetType());
					uIUpgradeItem2.label.text = DroneManager.GetDroneUpgradeText(baseDroneUpgrade);
					uIUpgradeItem2.overrideActiveColor = DroneManager.GetUpgradeStatus(baseDroneUpgrade, false);
					uIUpgradeItem2.Init();
					uIUpgradeItem2.ClearHighlight();
					uIUpgradeItem2.UnDim();
					uIUpgradeItem2.AffectedItem = null;
					int count3 = modificationsForType.Count;
					for (int l = 0; l < count3; l++)
					{
						IModification mod = modificationsForType[l];
						if (uIUpgradeItem2 != null)
						{
							uIUpgradeItem2.AddModification(mod);
						}
					}
					uIUpgradeItem2.InventoryItem = baseDroneUpgrade;
					uIUpgradeItem2.ParentItem = (IInventoryItem)drone;
					uIUpgradeItem2.HasIcon(true);
					gameObject.transform.SetParent(listContainer.transform);
					gameObject.transform.localScale = Vector3.one;
					num2++;
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
				int count4 = list.Count;
				int num3 = itemList.Length;
				Array.Resize(ref itemList, itemList.Length + count4);
				for (int num4 = 0; num4 < count4; num4++)
				{
					GameObject gameObject2 = GameObjectPool.Instance.PopObject("DroneUpgradeItem");
					UIUpgradeItem component = gameObject2.GetComponent<UIUpgradeItem>();
					IInventoryItem inventoryItem = list[num4];
					itemList[num4 + num3] = component;
					List<IModification> modificationsForType2 = ModificationsHelper.GetModificationsForType(inventoryItem.GetType());
					BaseDroneUpgrade upgrade = (BaseDroneUpgrade)inventoryItem;
					component.label.text = DroneManager.GetDroneUpgradeText(upgrade);
					component.overrideActiveColor = DroneManager.GetUpgradeStatus(upgrade, false);
					component.Init();
					component.ClearHighlight();
					component.UnDim();
					component.AffectedItem = null;
					int count5 = modificationsForType2.Count;
					for (int num5 = 0; num5 < count5; num5++)
					{
						component.AddModification(modificationsForType2[num5]);
					}
					component.InventoryItem = inventoryItem;
					component.HasIcon(false);
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
				int num6 = itemList.Length;
				for (int num7 = itemsPerPage; num7 < num6; num7++)
				{
					if (itemList[num7] != null)
					{
						itemList[num7].gameObject.SetActive(false);
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
		if (num2 > itemList.Length)
		{
			return;
		}
		if (num3 > itemList.Length)
		{
			num3 = itemList.Length;
		}
		if (itemList != null && itemList.Length > 0)
		{
			for (int j = num2; j < num3; j++)
			{
				itemList[j].gameObject.SetActive(true);
			}
		}
		topVisibleIndex = num2;
		bottomVisibleIndex = num3;
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
		UIUpgradeItem[] array = itemList;
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
				if (drone.Upgrades != null && drone.Upgrades.Remove((BaseDroneUpgrade)((UIUpgradeItem)highlightedItem).InventoryItem))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				GlobalSettings.GameState.ThePlayer.Inventory.RemoveInventoryItem(((UIUpgradeItem)highlightedItem).InventoryItem);
				flag = true;
			}
		}
		return flag;
	}

	public virtual void AddBackendItem(IUIItem item)
	{
		IInventoryItem inventoryItem = ((UIUpgradeItem)item).InventoryItem;
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
		UIUpgradeItem[] array = itemList;
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
		UIUpgradeItem[] array = itemList;
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
}
