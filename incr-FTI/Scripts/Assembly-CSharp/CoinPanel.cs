using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinPanel : MenuPanel
{
	public GameObject listItemPrefab;

	private readonly Dictionary<ItemType, InventoryListItem> currencyItems = new Dictionary<ItemType, InventoryListItem>(new ItemEqualityComparer());

	public GridLayoutGroup coinsLayoutGroup;

	[NonSerialized]
	public SingleSelectionManager selectionManager;

	public override void Initialize()
	{
		base.Initialize();
		selectionManager = new SingleSelectionManager(OnSelectionChangedByManager);
	}

	public float GetLayoutHeight()
	{
		int num = 0;
		foreach (InventoryListItem value in currencyItems.Values)
		{
			if (value.gameObject.activeInHierarchy)
			{
				num++;
			}
		}
		int num2 = (num + 1) / 2;
		return (float)coinsLayoutGroup.padding.top + (float)num2 * coinsLayoutGroup.cellSize.y;
	}

	public override void CreateItems()
	{
		base.CreateItems();
		foreach (ItemType coin in Data.Instance.coins)
		{
			if (coin == ItemType.TownExperiencePoint)
			{
				break;
			}
			InventoryListItem component = MenuManager.GetMenuObject(listItemPrefab, coinsLayoutGroup.transform).GetComponent<InventoryListItem>();
			currencyItems[coin] = component;
			component.LoadSelectionManager(selectionManager);
			component.Initialize();
			component.buttonState = CustomButtonState.Default;
		}
	}

	protected override void UpdateSimulationDisplay()
	{
		base.UpdateSimulationDisplay();
		foreach (InventoryListItem value in currencyItems.Values)
		{
			if (value.gameObject.activeInHierarchy && value.itemState != null)
			{
				value.UpdateSimulationDisplay();
			}
		}
	}

	public override void CreateLayoutForActiveTown()
	{
		base.CreateLayoutForActiveTown();
		foreach (KeyValuePair<ItemType, InventoryListItem> currencyItem in currencyItems)
		{
			if (displayedTown.inventory.TryGetValue(currencyItem.Key, out var value))
			{
				currencyItem.Value.LoadState(value);
			}
			else
			{
				currencyItem.Value.gameObject.SetActive(value: false);
			}
		}
	}

	protected override void UpdateItemAvailability()
	{
		base.UpdateItemAvailability();
		bool flag = false;
		foreach (KeyValuePair<ItemType, InventoryListItem> currencyItem in currencyItems)
		{
			bool flag2 = !currencyItem.Value.itemState.isLocked;
			bool activeSelf = currencyItem.Value.gameObject.activeSelf;
			if (flag2 != activeSelf)
			{
				currencyItem.Value.gameObject.SetActive(flag2);
				flag = true;
			}
		}
		if (flag)
		{
			MenuManager.Instance.isLeftLayoutStale = true;
		}
	}

	private void OnSelectionChangedByManager(EntityId id, bool nextState)
	{
		InventoryListItem inventoryListItem = null;
		if (id.TryAsItem(out var i) && currencyItems.TryGetValue(i, out var value))
		{
			inventoryListItem = value;
		}
		if (null != inventoryListItem)
		{
			TooltipPanel tooltipPanel = MenuManager.Instance.tooltipPanel;
			if (nextState)
			{
				tooltipPanel.LoadEntityProduction(id);
				tooltipPanel.Pin();
			}
			else
			{
				inventoryListItem.RemoveSelection();
				tooltipPanel.Unpin();
			}
		}
	}
}
