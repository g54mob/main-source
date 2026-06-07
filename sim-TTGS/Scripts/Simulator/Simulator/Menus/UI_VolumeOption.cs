using System;
using System.Collections.Generic;
using Simulator.CustomSettings;
using UnityEngine;

namespace Simulator.Menus
{
	[Serializable]
	public class UI_VolumeOption
	{
		[SerializeField]
		private EnumValues<VolumeOption.EBus, UI_SliderPlayerPrefFloatOptions> m_volumeSliders;

		public void Awake()
		{
			foreach (KeyValuePair<VolumeOption.EBus, UI_SliderPlayerPrefFloatOptions> volumeSlider in m_volumeSliders)
			{
				volumeSlider.Value.Init(AudioApplicationOptions.VolumeOption.Get(volumeSlider.Key));
				volumeSlider.Value.Awake();
			}
		}

		public void OnEnable()
		{
			foreach (KeyValuePair<VolumeOption.EBus, UI_SliderPlayerPrefFloatOptions> volumeSlider in m_volumeSliders)
			{
				volumeSlider.Value.OnEnable();
				volumeSlider.Value.OnValueChanged += OnValueChanged;
			}
		}

		public void OnDisable()
		{
			foreach (KeyValuePair<VolumeOption.EBus, UI_SliderPlayerPrefFloatOptions> volumeSlider in m_volumeSliders)
			{
				volumeSlider.Value.OnDisable();
				volumeSlider.Value.OnValueChanged -= OnValueChanged;
			}
		}

		private void OnValueChanged(float value)
		{
			AudioApplicationOptions.VolumeOption.Update();
		}
	}
}
