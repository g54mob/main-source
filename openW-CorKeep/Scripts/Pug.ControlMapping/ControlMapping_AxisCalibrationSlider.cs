using UnityEngine;

public class ControlMapping_AxisCalibrationSlider : RadicalOptionsMenuOption_Slider
{
	[SerializeField]
	private PugText _numericalValue;

	protected override void OnValueChanged(float value, int step)
	{
		if (!(_numericalValue == null))
		{
			_numericalValue.Render(value.ToString("F2"), rewindEffectAnims: false, force: true);
		}
	}
}
