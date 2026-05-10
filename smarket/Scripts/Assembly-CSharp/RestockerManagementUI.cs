using UnityEngine;

public class RestockerManagementUI : MonoBehaviour
{
	[SerializeField]
	private RestockerManagementData data;

	[SerializeField]
	private ToggleSwitch m_IsActiveToggle;

	[SerializeField]
	private ToggleSwitch m_UseUnlabeledRacksToggle;

	[SerializeField]
	private ToggleSwitch m_PickUpBoxGroundToggle;

	[SerializeField]
	private ToggleSwitch m_RemoveLabelRackToggle;

	[SerializeField]
	private ToggleSwitch m_DropEmptyBoxToggle;

	[SerializeField]
	private ToggleSwitch m_RestockDisplayToggle;

	[SerializeField]
	private ToggleSwitch m_RestockFromVehiclesToggle;

	private RestockerItem m_RestockerItem;

	public RestockerItem RestockerItem => null;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void SetRestockerData(RestockerManagementData _data)
	{
	}

	public void OnIsActiveToggleChange(bool isOn)
	{
	}

	public void OnUseUnlabeledRacksToggleChange(bool isOn)
	{
	}

	public void OnPickUpBoxGroundToggleChange(bool isOn)
	{
	}

	public void OnRemoveLabelRackToggleChange(bool isOn)
	{
	}

	public void OnDropEmptyBoxToggleChange(bool isOn)
	{
	}

	public void OnRestockShelfToggleChange(bool isOn)
	{
	}

	private void OnRestockFromVehiclesToggleChange(bool value)
	{
	}
}
