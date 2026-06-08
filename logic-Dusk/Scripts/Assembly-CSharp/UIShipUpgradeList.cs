using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIShipUpgradeList : MonoBehaviour, IUIList, IUIMultiPageList
{
	private enum InventoryTypeEnum
	{
		Loose = 0,
		Installed = 1
	}

	public GameObject itemPrefab;

	public GameObject moreUpObject;

	public GameObject moreDownObject;

	public GameObject listContainer;

	public int itemsPerPage = 17;

	private Dictionary<InventoryTypeEnum, Inventory> sourceInventoryDict;

	private UIUpgradeItem[] itemList;

	private int topVisibleIndex = -1;

	private int bottomVisibleIndex = -1;

	public int ItemCount
	{
		get
		{
			int num = 0;
			if (itemList != null)
			{
				num += itemList.Length;
			}
			return num;
		}
	}

	public GameObject UnderlyingGameObject
	{
		get
		{
			return base.gameObject;
		}
	}

	public int CurrentPageIndex { get; private set; }

	public int CurrentHighlightedIndex { get; private set; }

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
		if (sourceInventoryDict == null)
		{
			sourceInventoryDict = new Dictionary<InventoryTypeEnum, Inventory>();
			sourceInventoryDict.Add(InventoryTypeEnum.Loose, GlobalSettings.GameState.ThePlayer.Inventory);
			sourceInventoryDict.Add(InventoryTypeEnum.Installed, GlobalSettings.GameState.ThePlayer.MyShip.InstalledInventory);
		}
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
				GameObjectPool.Instance.PushObject(uIUpgradeItem.gameObject);
			}
		}
		itemList = new UIUpgradeItem[0];
		List<UIUpgradeItem> list = new List<UIUpgradeItem>();
		for (int j = 0; j <= 1; j++)
		{
			List<IInventoryItem> list2 = null;
			list2 = ((j != 0) ? sourceInventoryDict[InventoryTypeEnum.Installed].ItemsCopy : sourceInventoryDict[InventoryTypeEnum.Loose].ItemsCopy);
			if (list2 == null)
			{
				continue;
			}
			List<IInventoryItem> list3 = null;
			IEnumerable<IInventoryItem> enumerable = list2.Where((IInventoryItem x) => x != null && x.GetType().BaseType == typeof(BaseShipUpgrade));
			if (enumerable == null)
			{
				continue;
			}
			list3 = enumerable.ToList();
			int count = list3.Count;
			for (int num2 = 0; num2 < count; num2++)
			{
				GameObject gameObject = GameObjectPool.Instance.PopObject("ShipUpgradeItem");
				list.Add(gameObject.GetComponent<UIUpgradeItem>());
				IInventoryItem inventoryItem = list3[num2];
				UIUpgradeItem uIUpgradeItem2 = list.Last();
				uIUpgradeItem2.Init();
				List<IModification> modificationsForType = ModificationsHelper.GetModificationsForType(inventoryItem.GetType());
				int count2 = modificationsForType.Count;
				for (int num3 = 0; num3 < count2; num3++)
				{
					uIUpgradeItem2.AddModification(modificationsForType[num3]);
				}
				uIUpgradeItem2.label.text = DroneManager.GetShipUpgradeText((BaseShipUpgrade)inventoryItem);
				uIUpgradeItem2.overrideActiveColor = DroneManager.GetUpgradeStatus((BaseShipUpgrade)inventoryItem, false);
				uIUpgradeItem2.SetActive();
				uIUpgradeItem2.InventoryItem = inventoryItem;
				gameObject.transform.SetParent(listContainer.transform);
				gameObject.transform.localScale = Vector3.one;
				Vector3 position = gameObject.transform.position;
				position.z = 0f;
				gameObject.transform.position = position;
			}
		}
		itemList = list.ToArray();
		if (itemList != null && itemList.Length > 0)
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
		for (int i = 0; i < num; i++)
		{
			itemList[i].gameObject.SetActive(false);
		}
		CurrentPageIndex = pageIdx;
		if (pageIdx <= -1)
		{
			return;
		}
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
		if (CurrentHighlightedIndex != -1 && itemList != null && itemList.Length > 0)
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

	public bool RemoveBackendSelectedItem()
	{
		bool result = false;
		IUIItem highlightedItem = GetHighlightedItem();
		if (highlightedItem != null)
		{
			bool flag = false;
			string groupKey = ((UIUpgradeItem)highlightedItem).InventoryItem.GroupKey;
			foreach (IInventoryItem item in sourceInventoryDict[InventoryTypeEnum.Loose].ItemsCopy)
			{
				if (item.GroupKey == groupKey)
				{
					sourceInventoryDict[InventoryTypeEnum.Loose].RemoveInventoryItem(item);
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				foreach (IInventoryItem item2 in sourceInventoryDict[InventoryTypeEnum.Installed].ItemsCopy)
				{
					if (item2.GroupKey == groupKey)
					{
						sourceInventoryDict[InventoryTypeEnum.Installed].RemoveInventoryItem(item2);
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				int num = 0;
				num++;
			}
			result = true;
		}
		return result;
	}

	public void AddBackendItem(IUIItem item)
	{
		IInventoryItem inventoryItem = ((UIUpgradeItem)item).InventoryItem;
		if (inventoryItem is ExpandedInventoryItem)
		{
			inventoryItem = ((ExpandedInventoryItem)inventoryItem).RealItem;
		}
		sourceInventoryDict[InventoryTypeEnum.Loose].AddInventoryItem(inventoryItem);
	}

	public IUIItem SelectHighlightedItem()
	{
		if (CurrentHighlightedIndex >= topVisibleIndex && CurrentHighlightedIndex <= bottomVisibleIndex && itemList != null && itemList.Length > 0)
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

	private void RefreshMoreButtons()
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
