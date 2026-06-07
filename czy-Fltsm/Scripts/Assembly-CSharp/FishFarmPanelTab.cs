using UnityEngine;
using UnityEngine.UI;

public class FishFarmPanelTab : MonoBehaviour
{
	[SerializeField]
	private Toggle _toggle;

	[SerializeField]
	private GameObject _fishFarmPage;

	[SerializeField]
	private FishFarmPanel _fishFarmPanel;

	[SerializeField]
	private FishProperties _fishProperties;

	private void Awake()
	{
		if (_toggle == null)
		{
			_toggle = GetComponent<Toggle>();
		}
		_toggle.onValueChanged.AddListener(OnValueChanged);
		if (_toggle.isOn)
		{
			_fishFarmPanel.SetActiveFishProperties(_fishProperties);
		}
	}

	private void OnDestroy()
	{
		if ((bool)_toggle)
		{
			_toggle.onValueChanged.RemoveListener(OnValueChanged);
		}
	}

	private void OnValueChanged(bool newValue)
	{
		_fishFarmPage.SetActive(newValue);
		if (newValue)
		{
			_fishFarmPanel.SetActiveFishProperties(_fishProperties);
		}
	}
}
