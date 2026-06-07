using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class DayLengthSlider : WeatherSlider
	{
		public override float Value
		{
			get
			{
				return Mathf.Lerp(minMax.x, minMax.y, Mathf.SmoothStep(0f, 1f, slider.value));
			}
			set
			{
				slider.SetValueWithoutNotify(SmoothStepInverse(Mathf.InverseLerp(minMax.x, minMax.y, value)));
			}
		}

		private float SmoothStepInverse(float y)
		{
			if (y <= 0f)
			{
				return 0f;
			}
			if (y >= 1f)
			{
				return 1f;
			}
			return 0.5f - Mathf.Sin(Mathf.Asin(1f - 2f * y) / 3f);
		}
	}
}
