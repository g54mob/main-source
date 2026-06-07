using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildableTooltipItemSlot : BuildableTooltipSlot, GUIItemSlot
{
	[SerializeField]
	private InventoryIcon _inventoryIcon;

	[SerializeField]
	private TextMeshProUGUI _label;

	private CountedItemProperty _slotItem;

	private int _multiplier;

	private bool _showAvailable = true;

	GameObject GUIItemSlot.gameObject => base.gameObject;

	Transform GUIItemSlot.transform => base.transform;

	public void Initialize(ItemProperties itemProperties, int amount, bool showCounter)
	{
		GetInventoryIcon().Initialize(itemProperties);
		_showAvailable = false;
		_multiplier = 1;
		if (showCounter)
		{
			base.Counter.gameObject.SetActive(value: true);
			base.Counter.text = amount.ToString();
			ResetColor();
		}
		else
		{
			base.Counter.gameObject.SetActive(value: false);
		}
	}

	public void Initialize(CountedItemProperty slotItem, bool showAvailable = true)
	{
		_showAvailable = showAvailable;
		_slotItem = slotItem;
		_multiplier = 1;
		base.Counter.gameObject.SetActive(value: true);
		UpdateSlot();
	}

	public override void UpdateSlot()
	{
		int num = Community.PlayerCommunity.Inventory.ReturnCount(_slotItem.ItemProperties);
		GetInventoryIcon().Initialize(_slotItem.ItemProperties);
		if (_showAvailable)
		{
			base.Counter.text = $"{num}/{_slotItem.Amount * _multiplier}";
		}
		else
		{
			base.Counter.text = (_slotItem.Amount * _multiplier).ToString();
		}
		OverrideColor(num >= _slotItem.Amount * _multiplier);
		if ((bool)_label)
		{
			_label.text = _slotItem.ItemProperties.LocalizedName;
		}
	}

	public override void OverrideColor(bool validColor)
	{
		base.OverrideColor(validColor);
		if (validColor)
		{
			GetInventoryIcon().SetValid(validColor);
		}
		else
		{
			GetInventoryIcon().SetValid(valid: false);
		}
	}

	public void SetBuildableAmount(int amount)
	{
		_multiplier = amount;
		UpdateSlot();
	}

	public void DisableRaycasts()
	{
		Image[] componentsInChildren = GetComponentsInChildren<Image>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].raycastTarget = false;
		}
	}

	private void Reset()
	{
	}

	public static void InitializeItemListInfo<T>(List<CountedItemProperty> countedItems, T slotPrefab, List<GUIItemSlot> slotInstances, RectTransform parent, bool showCounter = false) where T : Component, GUIItemSlot
	{
		int i = 0;
		foreach (CountedItemProperty countedItem in countedItems)
		{
			GUIItemSlot gUIItemSlot;
			if (i == slotInstances.Count)
			{
				gUIItemSlot = Object.Instantiate(slotPrefab);
				gUIItemSlot.transform.SetParent(parent);
				gUIItemSlot.transform.localScale = Vector3.one;
				slotInstances.Add(gUIItemSlot);
			}
			else
			{
				gUIItemSlot = slotInstances[i];
			}
			gUIItemSlot.Initialize(countedItem.ItemProperties, countedItem.Amount, showCounter);
			gUIItemSlot.gameObject.SetActive(value: true);
			i++;
		}
		for (; i < slotInstances.Count; i++)
		{
			slotInstances[i].gameObject.SetActive(value: false);
		}
	}

	private InventoryIcon GetInventoryIcon()
	{
		if (_inventoryIcon == null)
		{
			_inventoryIcon = GetComponent<InventoryIcon>();
		}
		return _inventoryIcon;
	}
}
