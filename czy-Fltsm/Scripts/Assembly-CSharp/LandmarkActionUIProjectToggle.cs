using I2.Loc;
using UnityEngine;
using UnityEngine.UI;

public class LandmarkActionUIProjectToggle : MonoBehaviour
{
	[SerializeField]
	private Toggle _swimToggle;

	[SerializeField]
	private LocalizedString _swimTooltip;

	[SerializeField]
	private Toggle _boatToggle;

	[SerializeField]
	private LocalizedString _boatTooltip;

	private LandmarkAction _landmarkAction;

	private TooltipButton _tooltipButton;

	public void Initialize(LandmarkAction landmarkAction, TooltipButton tooltipButton)
	{
		if (!(landmarkAction == null))
		{
			_landmarkAction = landmarkAction;
			_tooltipButton = tooltipButton;
			_boatToggle.isOn = _landmarkAction.UseBoat;
			_boatToggle.onValueChanged.AddListener(BoatValueChanged);
			_swimToggle.isOn = !_landmarkAction.UseBoat;
			_swimToggle.onValueChanged.AddListener(SwimValueChanged);
			UpdateTooltip();
		}
	}

	private void OnDestroy()
	{
		_boatToggle.onValueChanged.RemoveListener(BoatValueChanged);
		_swimToggle.onValueChanged.RemoveListener(SwimValueChanged);
	}

	private void BoatValueChanged(bool value)
	{
		_landmarkAction.UseBoat = value;
		UpdateTooltip();
	}

	private void SwimValueChanged(bool value)
	{
		_landmarkAction.UseBoat = !value;
		UpdateTooltip();
	}

	private void UpdateTooltip()
	{
		_tooltipButton.SetTooltipMessage(_landmarkAction.UseBoat ? _boatTooltip : _swimTooltip);
	}
}
