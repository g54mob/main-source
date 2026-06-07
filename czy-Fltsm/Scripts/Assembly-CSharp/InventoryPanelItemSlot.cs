using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Tooltip))]
public class InventoryPanelItemSlot : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, GUIItemSlot
{
	[Header("Background")]
	[SerializeField]
	private bool _applyBackgroundColor = true;

	[SerializeField]
	[Tooltip("The default background sprite.")]
	private Sprite _defaultBackground;

	[Header("References")]
	[SerializeField]
	[Tooltip("The image used for the background of the slot.")]
	protected Image _background;

	[SerializeField]
	[Tooltip("The text used for displaying the item count.")]
	protected TextMeshProUGUI _counter;

	[SerializeField]
	[Tooltip("The image used for the icon of the item.")]
	protected Image _icon;

	[SerializeField]
	[Tooltip("Should the icon be disabled when the ItemProperties are null?")]
	protected bool _disableIcon;

	[SerializeField]
	[Tooltip("An optional label to display the items name")]
	private TextMeshProUGUI _label;

	protected IInventoryView _inventoryView;

	protected ItemTooltip _tooltip;

	private int _count = int.MinValue;

	public ItemProperties ItemProperties { get; private set; }

	GameObject GUIItemSlot.gameObject => base.gameObject;

	Transform GUIItemSlot.transform => base.transform;

	private void Awake()
	{
		if (_inventoryView == null)
		{
			_inventoryView = GetComponentInParent<IInventoryView>();
		}
	}

	public void Initialize(ItemProperties itemProperties)
	{
		Initialize(itemProperties, 0, showCounter: false);
	}

	public void Initialize(InventoryAuditor.CountedItem countedItem)
	{
		Initialize(countedItem.ItemProperties, countedItem.UnreservedCount);
	}

	public virtual void Initialize(ItemProperties itemProperties, int itemCount, bool showCounter = true)
	{
		if (ItemProperties != itemProperties)
		{
			bool flag = itemProperties != null;
			ItemProperties = itemProperties;
			if (_tooltip == null)
			{
				_tooltip = GetComponent<ItemTooltip>();
			}
			if ((bool)_tooltip)
			{
				_tooltip.Initialize(itemProperties);
			}
			_icon.enabled = flag || !_disableIcon;
			_icon.overrideSprite = (flag ? itemProperties.InventorySprite : null);
			if ((bool)_label)
			{
				_label.text = (flag ? itemProperties.LocalizedName : string.Empty);
			}
		}
		if ((bool)_counter)
		{
			_counter.gameObject.SetActive(showCounter);
			if (showCounter)
			{
				SetCount(itemCount);
			}
		}
		SetBackground(itemCount, itemProperties);
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
		}
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Right && _inventoryView != null && !ItemProperties.IsQuestItem)
		{
			_inventoryView.ThrowItem(ItemProperties);
		}
	}

	protected void SetBackground(int itemCount, ItemProperties properties)
	{
		_background.sprite = _defaultBackground;
		if (_applyBackgroundColor)
		{
			_background.color = ((itemCount == 0) ? GameManager.Settings.ItemSettings.DisabledColor : properties.ItemType.Color);
		}
	}

	public void SetCount(int count)
	{
		if (_count != count)
		{
			_count = count;
			_counter.text = count.ToString();
			SetBackground(count, ItemProperties);
		}
	}

	public void SetSize(int index, float size, float padding)
	{
		RectTransform obj = base.transform as RectTransform;
		float size2 = size - padding * (float)index;
		obj.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size2);
		obj.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, size2);
	}
}
