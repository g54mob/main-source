using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryPanelCapacityBar : InventoryCapacityBar
{
	[Header("Settings")]
	[SerializeField]
	[Tooltip("Does this bar use an item tag as filter?")]
	private bool _useInventoryTag = true;

	[SerializeField]
	[Tooltip("The item tag used to toggle this bar on or off.")]
	[EnumFlag(1)]
	private Item.Tags _inventoryTag;

	[SerializeField]
	[Range(0f, 1f)]
	[Tooltip("The threshold for the capacity warning as a percentage of the total capacity.")]
	private float _warningThreshold = 0.9f;

	[Header("UI Components")]
	[SerializeField]
	[Tooltip("Reference to the slider used for display the amount of items that are currently in the inventory.")]
	private Slider _inInventorySlider;

	[SerializeField]
	[Tooltip("Reference to the slider used for display the amount of items that are currently reserved to go to the inventory.")]
	private Slider _reservedSlider;

	[SerializeField]
	[Tooltip("Reference to the text used for displaying the usage/capacity in plain text.")]
	private TextMeshProUGUI _text;

	[SerializeField]
	[Tooltip("Reference to the image used for the capacity warning.")]
	private Image _warning;

	[SerializeField]
	private Animator _animator;

	[SerializeField]
	[Tooltip("Boolean that decides whether we need to look at the liquid subinventory or not.")]
	private bool _isLiquid;

	public void OnDisable()
	{
		if (_inventory != null)
		{
			_inventory.InventoryUpdatedEvent.RemoveListener(UpdateCapacity);
			_inventory = null;
		}
	}

	public bool Initialize(ICommunalInventory inventory, Item.Tags filter)
	{
		if ((_inventoryTag & filter) != Item.Tags.None || _inventoryTag == Item.Tags.None)
		{
			base.gameObject.SetActive(value: true);
			Initialize(inventory);
			if (filter != Item.Tags.None)
			{
				return filter == _inventoryTag;
			}
			return false;
		}
		base.gameObject.SetActive(value: false);
		return false;
	}

	public override void UpdateCapacity()
	{
		SubInventoryType subInventory = (_isLiquid ? SubInventoryType.Liquid : SubInventoryType.Storage);
		int num;
		int num2;
		int num3;
		if (_useInventoryTag)
		{
			num = _inventory.ReturnCapacity(_inventoryTag);
			num2 = _inventory.ReturnCount(_inventoryTag, includeReserved: true);
			num3 = _inventory.ReturnIncomingItemsAmount(_inventoryTag);
		}
		else
		{
			num = _inventory.ReturnCapacity(subInventory);
			num2 = _inventory.ReturnCount(subInventory, includeReserved: true);
			num3 = _inventory.ReturnIncomingItemsAmount(subInventory);
		}
		float num4 = (float)num2 / (float)num;
		float num5 = (float)num3 / (float)num;
		if (num == 0)
		{
			num4 = (num5 = 0f);
		}
		else
		{
			num4 = (float)num2 / (float)num;
			num5 = (float)num3 / (float)num;
		}
		_text.text = $"{num2 + num3} / {num}";
		_inInventorySlider.value = (_inInventorySlider.maxValue - _inInventorySlider.minValue) * num4;
		if (num3 == 0)
		{
			_reservedSlider.value = 0f;
		}
		else
		{
			_reservedSlider.value = (_reservedSlider.maxValue - _reservedSlider.minValue) * (num4 + num5);
		}
		if ((bool)_warning && !_isLiquid)
		{
			_warning.enabled = _warningThreshold <= num4 + num5;
		}
		if ((bool)_animator && !_isLiquid)
		{
			_animator.SetBool("Is Low", _warningThreshold <= num4 + num5);
		}
	}
}
