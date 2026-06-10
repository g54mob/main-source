using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSMedieval.Sound;
using UnityEngine.UI;

namespace NSEipix.View.UI
{
	public class CustomSlider : Slider
	{
		protected override void Start()
		{
			base.Start();
			base.onValueChanged.AddListener(delegate(float value)
			{
				OnValueChanged(value);
			});
		}

		private void OnValueChanged(float value)
		{
			if (Math.Abs((int)(value * 100f) % 5) <= 0)
			{
				MonoSingleton<AudioManager>.Instance.PlaySound("UI_Slider", new Dictionary<string, float> { { "SliderValue", value } });
			}
		}
	}
}
