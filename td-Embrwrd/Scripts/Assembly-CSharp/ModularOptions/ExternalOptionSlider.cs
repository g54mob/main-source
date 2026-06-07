using UnityEngine;
using UnityEngine.UI;

namespace ModularOptions
{
	[AddComponentMenu("Modular Options/External/Slider")]
	public class ExternalOptionSlider : SliderOption
	{
		public Slider.SliderEvent onValueChange;

		protected override void ApplySetting(float _value)
		{
		}
	}
}
