using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCounterSlot : MonoBehaviour, GUIItemSlot
{
	[SerializeField]
	private Image _backgroundImage;

	[SerializeField]
	private Image _itemImage;

	[SerializeField]
	private Tooltip _tooltip;

	[SerializeField]
	private TextMeshProUGUI _counter;

	protected ItemProperties _properties;

	private int _count;

	public int Count
	{
		get
		{
			return Count;
		}
		set
		{
			if (_count != value)
			{
				_count = value;
				if ((bool)_counter && _counter.isActiveAndEnabled)
				{
					_counter.text = _count.ToString();
				}
			}
		}
	}

	public Color BackgroundColor
	{
		get
		{
			if (!_backgroundImage)
			{
				return Color.white;
			}
			return _backgroundImage.color;
		}
	}

	GameObject GUIItemSlot.gameObject => base.gameObject;

	Transform GUIItemSlot.transform => base.transform;

	public void Initialize(ItemProperties itemProperties, int amount, bool showCounter = false)
	{
		_properties = itemProperties;
		Color backgroundColor = ((amount <= 0) ? GameManager.Settings.ItemSettings.DisabledColor : itemProperties.ItemType.Color);
		if (showCounter)
		{
			Initialize(itemProperties.InventorySprite, backgroundColor, amount, itemProperties.LocalizedName);
			return;
		}
		Initialize(itemProperties.InventorySprite, backgroundColor, itemProperties.LocalizedName);
		if ((bool)_counter)
		{
			_counter.gameObject.SetActive(value: false);
		}
	}

	public void Initialize(Sprite icon, Color backgroundColor)
	{
		if ((bool)_backgroundImage)
		{
			_backgroundImage.color = backgroundColor;
		}
		_itemImage.sprite = icon;
	}

	public void Initialize(Sprite icon, Color backgroundColor, int count)
	{
		Initialize(icon, backgroundColor);
		if ((bool)_counter)
		{
			_count = count;
			_counter.gameObject.SetActive(value: true);
			_counter.text = count.ToString();
		}
	}

	public void Initialize(Sprite icon, Color backgroundColor, LocalizedString tooltip)
	{
		Initialize(icon, backgroundColor);
		if ((bool)_tooltip)
		{
			_tooltip.LocalizedText = tooltip;
		}
	}

	public void Initialize(Sprite icon, Color backgroundColor, int count, LocalizedString tooltip)
	{
		Initialize(icon, backgroundColor, count);
		if (_tooltip != null)
		{
			if (_properties != null && _tooltip is ItemTooltip itemTooltip)
			{
				itemTooltip.Initialize(_properties);
			}
			else
			{
				_tooltip.LocalizedText = tooltip;
			}
		}
	}

	public void SetCount(int count, bool updateBackgroundColor)
	{
		if ((bool)_counter && _count != count)
		{
			_count = count;
			_counter.text = _count.ToString();
			if (updateBackgroundColor && (bool)_backgroundImage)
			{
				_backgroundImage.color = ((_count <= 0) ? GameManager.Settings.ItemSettings.DisabledColor : _properties.ItemType.Color);
			}
		}
	}
}
