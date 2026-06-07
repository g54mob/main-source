using TMPro;
using UnityEngine;

public class BirdHousePanelSalvageToggle : AnimatedToggle
{
	[SerializeField]
	private ItemCounterSlot _itemSlot;

	[SerializeField]
	private TextMeshProUGUI _label;

	private ItemPropertiesGroup _itemPropertiesGroup;

	private int _count;

	private void Update()
	{
		if (Application.isPlaying)
		{
			_itemSlot.Count = _itemPropertiesGroup.Items.Count;
		}
	}

	public void Initialize(ItemPropertiesGroup itemPropertiesGroup)
	{
		_itemPropertiesGroup = itemPropertiesGroup;
		SetIsOnWithoutNotify(itemPropertiesGroup.Enabled);
		_count = itemPropertiesGroup.Items.Count;
		_itemSlot.Initialize(itemPropertiesGroup.UIProperties, _count, itemPropertiesGroup.Enabled);
		_label.text = itemPropertiesGroup.UIProperties.LocalizedName;
	}

	protected override void OnValueChanged(bool value)
	{
		base.OnValueChanged(value);
		_itemPropertiesGroup.Enabled = value;
	}
}
