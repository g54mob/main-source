using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemPropertiesTab : MonoBehaviour
{
	[SerializeField]
	private Toggle _toggle;

	[SerializeField]
	private Image _icon;

	private UnityAction<ItemProperties> _selectedCallback;

	public ItemProperties ItemProperties { get; private set; }

	private void OnEnable()
	{
		_toggle.onValueChanged.AddListener(OnValueChanged);
	}

	private void OnDisable()
	{
		_toggle.onValueChanged.RemoveListener(OnValueChanged);
		_selectedCallback = null;
	}

	public void Initialize(ItemProperties itemProperties, bool isOn, UnityAction<ItemProperties> selectedCallback)
	{
		ItemProperties = itemProperties;
		_toggle.SetIsOnWithoutNotify(isOn);
		_selectedCallback = selectedCallback;
	}

	private void OnValueChanged(bool value)
	{
		if (value && _selectedCallback != null)
		{
			_selectedCallback(ItemProperties);
		}
	}
}
