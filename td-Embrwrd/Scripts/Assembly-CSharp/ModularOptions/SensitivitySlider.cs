using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Controls/Sensitivity Slider")]
	public class SensitivitySlider : SliderOption, ISliderDisplayFormatter
	{
		public FirstPersonCameraRotation cameraController;

		protected override void ApplySetting(float _value)
		{
		}

		public string OverrideFormatting(float _value)
		{
			return null;
		}
	}
}
