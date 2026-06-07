using System;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class WeatherSlider : MonoBehaviour
	{
		public PhotoModeWeatherController.WeatherSettingType type;

		public SliderDV slider;

		public ButtonDV clearButton;

		public float exponent;

		[NonSerialized]
		public bool isOverrideOn;

		[NonSerialized]
		public Vector2 minMax;

		public virtual float Value
		{
			get
			{
				return Mathf.Lerp(minMax.x, minMax.y, Mathf.Pow(slider.value, exponent));
			}
			set
			{
				slider.SetValueWithoutNotify(Mathf.InverseLerp(minMax.x, minMax.y, Mathf.Pow(value, 1f / exponent)));
			}
		}
	}
}
