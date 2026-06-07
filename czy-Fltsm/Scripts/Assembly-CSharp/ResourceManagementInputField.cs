using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ResourceManagementInputField : Selectable
{
	[Header("References")]
	[SerializeField]
	[Tooltip("Item slot to display relevant item.")]
	private InventoryPanelItemSlot _itemSlot;

	[Tooltip("The InputField to determine resource limits.")]
	[SerializeField]
	private TMP_InputField _input;

	[SerializeField]
	[Tooltip("The tooltip attached to this object.")]
	private ItemTooltip Tooltip;

	private int _limit;

	public ItemProperties ItemProperties { get; private set; }

	public void Initialize(ItemProperties properties, int limit)
	{
		_limit = limit;
		_itemSlot.Initialize(properties, 1, showCounter: false);
		_input.onEndEdit.AddListener(UpdateResourceLimit);
		Tooltip.Initialize(properties.LocalizedName);
		ItemProperties = properties;
		UpdateLimitField();
	}

	public void Increase()
	{
		_limit++;
		if (_limit < 0)
		{
			_limit = -1;
		}
		UpdateLimitField();
	}

	public void Decrease()
	{
		if (0 <= _limit)
		{
			_limit--;
			UpdateLimitField();
		}
	}

	public void SetInfinite()
	{
		if (_limit != -1)
		{
			_limit = -1;
			UpdateLimitField();
		}
		UpdateLimitField();
	}

	private void SetLimit(int limitToSet)
	{
		_limit = limitToSet;
		UpdateLimitField();
	}

	private void UpdateLimitField()
	{
		_input.text = ((_limit < 0) ? "∞" : _limit.ToString());
		GameManager.ResourceManager.UpdateResourceLimit(ItemProperties, _limit);
	}

	private void UpdateResourceLimit(string limit)
	{
		int result;
		if (limit == "∞")
		{
			SetLimit(-1);
		}
		else if (int.TryParse(limit, out result))
		{
			SetLimit(result);
		}
		else
		{
			UpdateLimitField();
		}
	}

	public override void OnSelect(BaseEventData eventData)
	{
		base.OnSelect(eventData);
		Debug.LogFormat("'{0}' selected!", ItemProperties.LocalizedName);
	}
}
