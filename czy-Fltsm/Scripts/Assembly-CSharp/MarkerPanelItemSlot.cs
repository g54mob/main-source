using UnityEngine;

public class MarkerPanelItemSlot : MonoBehaviour
{
	[SerializeField]
	[Tooltip("The item slot used to display the item.")]
	public InventoryPanelItemSlot _itemSlot;

	[SerializeField]
	[Tooltip("The toggle used to toggle between the item being salvaged or not.")]
	private MarkerPanelToggle _toggle;

	private bool _initializedToggle;

	public ItemProperties Properties { get; private set; }

	public bool IsOn
	{
		get
		{
			if (_toggle.enabled)
			{
				return _toggle.IsOn;
			}
			return false;
		}
	}

	public UnityItemPropertiesEvent OnToggleEvent { get; private set; }

	public void Initialize(ItemProperties properties, int markerCount, bool isEnabled, bool hideToggle = false, bool showCounter = true)
	{
		Properties = properties;
		_itemSlot.Initialize(properties, markerCount, showCounter);
		if (OnToggleEvent == null)
		{
			OnToggleEvent = new UnityItemPropertiesEvent();
		}
		else
		{
			OnToggleEvent.RemoveAllListeners();
		}
		if (hideToggle)
		{
			_toggle.enabled = false;
		}
		else
		{
			if (!_initializedToggle)
			{
				_toggle.OnToggleEvent.AddListener(OnToggle);
				_initializedToggle = true;
			}
			_toggle.enabled = true;
			_toggle.Toggle(isEnabled, invokeOnToggleEvent: false);
		}
		base.gameObject.SetActive(value: true);
	}

	private void OnDestroy()
	{
		_toggle.OnToggleEvent.RemoveListener(OnToggle);
	}

	private void OnToggle()
	{
		OnToggleEvent.Invoke(Properties);
	}

	public void SetMarkerCount(int markerCount)
	{
		_itemSlot.SetCount(markerCount);
	}
}
