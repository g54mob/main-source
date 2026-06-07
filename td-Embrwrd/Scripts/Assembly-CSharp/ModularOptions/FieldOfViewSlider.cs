using UnityEngine;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/Display/Field Of View Slider")]
	public sealed class FieldOfViewSlider : SliderOption
	{
		public Camera cam;

		protected override void ApplySetting(float _value)
		{
		}
	}
}
