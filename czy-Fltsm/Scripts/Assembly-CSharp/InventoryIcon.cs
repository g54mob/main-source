using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryIcon : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[Header("UI Components")]
	[SerializeField]
	[Tooltip("Background image of the button.")]
	private Image _itemBackgroundImage;

	[SerializeField]
	[Tooltip("Icon image of the item.")]
	private Image _iconImage;

	[SerializeField]
	[Tooltip("Text to display number of items in item stack.")]
	private Text _stackNumber;

	[HideInInspector]
	public IInventorySlot InventorySlot;

	private ItemProperties _itemProperties;

	private int _stackSize;

	public void OnPointerClick(PointerEventData eventData)
	{
		switch (eventData.button)
		{
		case PointerEventData.InputButton.Right:
			throw new NotImplementedException();
		case PointerEventData.InputButton.Left:
		case PointerEventData.InputButton.Middle:
			break;
		}
	}

	public void Initialize(ItemProperties properties, int stackSize = 1, bool isDisabledSlot = false, bool alwaysShowStacksize = false)
	{
		_itemProperties = properties;
		_stackSize = stackSize;
		_iconImage.sprite = _itemProperties.InventorySprite;
		SetResourceColor(_itemProperties);
		if (alwaysShowStacksize || (!isDisabledSlot && stackSize > 1))
		{
			_stackNumber.text = stackSize.ToString();
		}
		Tooltip tooltip = GetComponent<Tooltip>();
		if (tooltip == null)
		{
			tooltip = base.gameObject.AddComponent<Tooltip>();
		}
		tooltip.LocalizedText = properties.LocalizedName;
	}

	public void Initialize(IInventorySlot inventorySlot)
	{
		InventorySlot = inventorySlot;
		Initialize(InventorySlot.ItemProperties, InventorySlot.Count);
	}

	private void Reset()
	{
		_itemBackgroundImage = GetComponent<Image>();
		_stackNumber = GetComponentInChildren<Text>(includeInactive: true);
	}

	private void SetResourceColor(ItemProperties properties)
	{
		_itemBackgroundImage.color = properties.ItemType.Color;
	}

	public void SetValid(bool valid)
	{
		if (valid)
		{
			SetResourceColor(_itemProperties);
		}
		else
		{
			_itemBackgroundImage.color = GameManager.Settings.ItemSettings.DisabledColor;
		}
	}

	public void UpdateValid(CommunityInventory inventory)
	{
		SetValid(inventory.ReturnCount(_itemProperties) >= _stackSize);
	}
}
