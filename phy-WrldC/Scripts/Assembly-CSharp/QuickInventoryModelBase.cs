using System.Collections.Generic;
using UnityEngine;

public abstract class QuickInventoryModelBase<TItemModel> : BaseModel where TItemModel : class
{
	public const string AddTabEvent = "QuickInventoryModelBase.AddTabEvent";

	public const string RemoveTabEvent = "QuickInventoryModelBase.RemoveTabEvent";

	public const string SwapTabEvent = "QuickInventoryModelBase.SwapTabEvent";

	public const string AddItemEvent = "QuickInventoryModelBase.AddItemEvent";

	public const string InsertItemEvent = "QuickInventoryModelBase.InsertItemEvent";

	public const string SwapItemEvent = "QuickInventoryModelBase.SwapItemEvent";

	public const string RemoveItemEvent = "QuickInventoryModelBase.RemoveItemEvent";

	public const string SelectedTabIndexEvent = "QuickInventoryModelBase.SelectedTabIndexEvent";

	public const string SelectedItemIndexEvent = "QuickInventoryModelBase.SelectedItemIndexEvent";

	public const string UnfocusSelectedItemEvent = "QuickInventoryModelBase.UnfocusSelectedItemEvent";

	public const string MaxTabsLimitEvent = "QuickInventoryModelBase.MaxTabsLimitEvent";

	public const string MaxSlotsLimitEvent = "QuickInventoryModelBase.MaxSlotsLimitEvent";

	public const string LastTabWarningEvent = "QuickInventoryModelBase.LastTabWarningEvent";

	public const string LastItemWarningEvent = "QuickInventoryModelBase.LastItemWarningEvent";

	private const int maxTabsLimit = 16;

	private const int maxSlotsLimit = 16;

	private readonly List<List<TItemModel>> tabsItems;

	private int selectedTabIndex;

	private int selectedItemIndex;

	public bool IsSelectedItemFocused { get; private set; }

	public int SelectedTabIndex
	{
		get
		{
			return selectedTabIndex;
		}
		set
		{
			int max = ((TabCount() > 0) ? (TabCount() - 1) : 0);
			selectedTabIndex = Mathf.Clamp(value, 0, max);
			NotifyChange("QuickInventoryModelBase.SelectedTabIndexEvent", selectedTabIndex);
		}
	}

	public int SelectedItemIndex
	{
		get
		{
			return selectedItemIndex;
		}
		set
		{
			IsSelectedItemFocused = true;
			int max = ((ItemCount(selectedTabIndex) > 0) ? (ItemCount(selectedTabIndex) - 1) : 0);
			selectedItemIndex = Mathf.Clamp(value, 0, max);
			NotifyChange("QuickInventoryModelBase.SelectedItemIndexEvent", selectedTabIndex, selectedItemIndex);
		}
	}

	public QuickInventoryModelBase()
	{
		tabsItems = new List<List<TItemModel>>();
		selectedTabIndex = 0;
		selectedItemIndex = 0;
		IsSelectedItemFocused = false;
	}

	public bool AddTab()
	{
		if (tabsItems.Count >= 16)
		{
			NotifyChange("QuickInventoryModelBase.MaxTabsLimitEvent");
			return false;
		}
		tabsItems.Add(new List<TItemModel>());
		NotifyChange("QuickInventoryModelBase.AddTabEvent", tabsItems.Count - 1);
		return true;
	}

	public void RemoveTab(int tabIndex)
	{
		if (TabCount() <= 1)
		{
			NotifyChange("QuickInventoryModelBase.LastTabWarningEvent");
			return;
		}
		if (!IsThereOriginalItemInOthersTab(tabIndex))
		{
			NotifyChange("QuickInventoryModelBase.LastTabWarningEvent");
			return;
		}
		if (IsLastOriginalItem())
		{
			foreach (TItemModel item in tabsItems[tabIndex])
			{
				if (IsOriginalItem(item))
				{
					NotifyChange("QuickInventoryModelBase.LastItemWarningEvent");
					return;
				}
			}
		}
		tabsItems.RemoveAt(tabIndex);
		NotifyChange("QuickInventoryModelBase.RemoveTabEvent", tabIndex);
		if (selectedTabIndex == tabIndex)
		{
			SelectedTabIndex--;
			SelectedItemIndex = 0;
		}
		else if (selectedTabIndex > tabIndex)
		{
			SelectedTabIndex--;
			SelectedItemIndex = selectedItemIndex;
		}
		else
		{
			SelectedTabIndex = selectedTabIndex;
			SelectedItemIndex = selectedItemIndex;
		}
	}

	public void SwapTab(int oldTabIndex, int newTabIndex)
	{
		List<TItemModel> item = tabsItems[oldTabIndex];
		tabsItems.RemoveAt(oldTabIndex);
		tabsItems.Insert(newTabIndex, item);
		NotifyChange("QuickInventoryModelBase.SwapTabEvent", oldTabIndex, newTabIndex);
	}

	public void AddItem(int tabIndex, TItemModel item)
	{
		tabsItems[tabIndex].Add(item);
		NotifyChange("QuickInventoryModelBase.AddItemEvent", tabIndex, tabsItems[tabIndex].Count - 1, item);
	}

	public void InsertItem(int tabIndex, int itemIndex, TItemModel item)
	{
		if (tabsItems[tabIndex].Count >= 16)
		{
			NotifyChange("QuickInventoryModelBase.MaxSlotsLimitEvent");
			return;
		}
		tabsItems[tabIndex].Insert(itemIndex, item);
		NotifyChange("QuickInventoryModelBase.InsertItemEvent", tabIndex, itemIndex, item);
	}

	public void RemoveItem(int tabIndex, int itemIndex)
	{
		if (TabCount() == 1 && ItemCount(tabIndex) <= 1)
		{
			NotifyChange("QuickInventoryModelBase.LastItemWarningEvent");
			return;
		}
		if (ItemCount(tabIndex) <= 1)
		{
			RemoveTab(tabIndex);
			return;
		}
		if (IsLastOriginalItem(tabsItems[tabIndex][itemIndex]))
		{
			NotifyChange("QuickInventoryModelBase.LastItemWarningEvent");
			return;
		}
		tabsItems[tabIndex].RemoveAt(itemIndex);
		NotifyChange("QuickInventoryModelBase.RemoveItemEvent", tabIndex, itemIndex);
		if (selectedTabIndex == tabIndex)
		{
			if (selectedItemIndex >= itemIndex)
			{
				SelectedItemIndex--;
			}
			else
			{
				SelectedItemIndex = selectedItemIndex;
			}
		}
	}

	public void RemoveItem(TItemModel toRemoveItem)
	{
		int num = 0;
		int num2 = 0;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		foreach (List<TItemModel> tabsItem in tabsItems)
		{
			foreach (TItemModel item in tabsItem)
			{
				if (toRemoveItem == item)
				{
					list.Add(num);
					list2.Add(num2);
				}
				num2++;
			}
			num2 = 0;
			num++;
		}
		if (list.Count > 0 && list2.Count > 0)
		{
			for (int num3 = list.Count - 1; num3 >= 0; num3--)
			{
				RemoveItem(list[num3], list2[num3]);
			}
		}
	}

	public void SwapItem(int tabIndex, int oldItemIndex, int newItemIndex)
	{
		TItemModel item = tabsItems[tabIndex][oldItemIndex];
		tabsItems[tabIndex].RemoveAt(oldItemIndex);
		tabsItems[tabIndex].Insert(newItemIndex, item);
		NotifyChange("QuickInventoryModelBase.SwapItemEvent", tabIndex, oldItemIndex, newItemIndex);
	}

	public void UnfocusSelectedItem()
	{
		if (IsSelectedItemFocused)
		{
			IsSelectedItemFocused = false;
			NotifyChange("QuickInventoryModelBase.UnfocusSelectedItemEvent");
		}
	}

	public TItemModel GetItem(int tabIndex, int itemIndex)
	{
		return tabsItems[tabIndex][itemIndex];
	}

	public ICollection<TItemModel> GetAllItems(int tabIndex)
	{
		return tabsItems[tabIndex].ToArray();
	}

	public TItemModel GetSelectedItem()
	{
		return tabsItems[selectedTabIndex][selectedItemIndex];
	}

	public int TabCount()
	{
		return tabsItems.Count;
	}

	public int ItemCount(int tabIndex)
	{
		return tabsItems[tabIndex].Count;
	}

	private bool IsLastOriginalItem(TItemModel toSkipItemModel = null)
	{
		bool flag = true;
		int num = 0;
		foreach (List<TItemModel> tabsItem in tabsItems)
		{
			foreach (TItemModel item in tabsItem)
			{
				if (item != toSkipItemModel && IsOriginalItem(item))
				{
					if (toSkipItemModel != null || num != 0)
					{
						flag = false;
						break;
					}
					num++;
				}
			}
			if (!flag)
			{
				break;
			}
		}
		return flag;
	}

	private bool IsThereOriginalItemInOthersTab(int toSkipTabIndex)
	{
		for (int i = 0; i < tabsItems.Count; i++)
		{
			if (i == toSkipTabIndex)
			{
				continue;
			}
			foreach (TItemModel item in tabsItems[i])
			{
				if (IsOriginalItem(item))
				{
					return true;
				}
			}
		}
		return false;
	}

	protected abstract bool IsOriginalItem(TItemModel itemModel);

	public virtual TSubclass Clone<TSubclass>() where TSubclass : QuickInventoryModelBase<TItemModel>, new()
	{
		TSubclass val = NewInstance<TSubclass>();
		for (int i = 0; i < tabsItems.Count; i++)
		{
			val.AddTab();
			foreach (TItemModel item in tabsItems[i])
			{
				val.AddItem(i, item);
			}
		}
		return val;
	}

	protected abstract TSubclass NewInstance<TSubclass>() where TSubclass : QuickInventoryModelBase<TItemModel>, new();
}
