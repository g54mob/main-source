using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class InventoryTagToggle : MonoBehaviour
{
	[Serializable]
	public class ValueChanged : UnityEvent<Item.Tags, bool>
	{
	}

	[SerializeField]
	private Item.Tags _tag;

	[SerializeField]
	private ItemType _type;

	[SerializeField]
	private Image _selector;

	[SerializeField]
	private Tooltip _tooltip;

	[SerializeField]
	private ValueChanged _onValueChanged;

	private Toggle _toggle;

	public Item.Tags ItemTags => _tag;

	private void OnValidate()
	{
		if ((bool)_type)
		{
			if ((bool)_selector)
			{
				_selector.color = _type.Color;
			}
			if ((bool)_tooltip)
			{
				_tooltip.LocalizedText = _type.Name;
			}
		}
	}

	private void OnEnable()
	{
		if (_toggle == null)
		{
			_toggle = GetComponent<Toggle>();
		}
		_toggle.onValueChanged.AddListener(OnValueChanged);
	}

	private void OnDisable()
	{
		if ((bool)_toggle)
		{
			_toggle.onValueChanged.RemoveListener(OnValueChanged);
		}
	}

	public void SetIsOnValueWithoutNotify(bool value)
	{
		if ((bool)_toggle)
		{
			_toggle.SetIsOnWithoutNotify(value);
		}
	}

	private void OnValueChanged(bool value)
	{
		_onValueChanged.Invoke(_tag, value);
	}
}
