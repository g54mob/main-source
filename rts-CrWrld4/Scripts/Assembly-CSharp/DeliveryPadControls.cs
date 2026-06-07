using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryPadControls : MonoBehaviour
{
	public Dropdown resourceDropdown;

	public Slider capacitySlider;

	public Text capacityText;

	public Toggle repeatMissionToggle;

	public GameObject cancelRouteButton;

	public Toggle autoBeamToggle;

	public TMP_Dropdown autoBeamDropdown;

	public GameObject mverseControls;

	private bool ignoreChange;

	private void OnDisable()
	{
	}

	public void OnEnable()
	{
	}

	private string GetWareName(int rt)
	{
		return null;
	}

	public void OnChangeResource(int i)
	{
	}

	public void OnCapacitySliderChanged(float val)
	{
	}

	public void OnCancelRoute()
	{
	}

	public void OnRepeatMissionChanged(bool val)
	{
	}

	public void OnAutoBeamChanged(bool val)
	{
	}

	public void OnAutoBeamPlayerChanged(int val)
	{
	}
}
