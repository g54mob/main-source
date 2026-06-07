using UnityEngine;
using UnityEngine.UI;

public class FilterUIInteractable : UIInteractable
{
	[SerializeField]
	private Image _icon;

	[SerializeField]
	private Sprite _defaultBackground;

	[SerializeField]
	private Image _background;

	private bool _activated = true;

	private ItemFilter _filter;

	private ItemTooltip _tooltip;

	public ItemProperties ItemProperties { get; private set; }

	public void InitializeItem(ItemProperties itemProperties)
	{
		ItemProperties = itemProperties;
		_tooltip = GetComponent<ItemTooltip>();
		_tooltip.Initialize(itemProperties);
	}

	public void Initialize(ItemFilter filter)
	{
		_filter = filter;
		_activated = filter.AcceptsItem(ItemProperties);
		_icon.sprite = ItemProperties.InventorySprite;
		SetBackground();
	}

	public override void Interact()
	{
		InvertFilter();
		base.Interact();
	}

	private void InvertFilter()
	{
		ActivateFilter(!_activated);
	}

	public void ActivateFilter(bool activate)
	{
		_activated = activate;
		if (_activated)
		{
			_filter.AddAcceptedItem(ItemProperties);
		}
		else
		{
			_filter.RemoveAcceptedItem(ItemProperties);
		}
		SetBackground();
	}

	private void SetBackground()
	{
		_background.sprite = _defaultBackground;
		_background.color = (_activated ? ItemProperties.ItemType.Color : GameManager.Settings.ItemSettings.DisabledColor);
		_background.DisableSpriteOptimizations();
	}
}
