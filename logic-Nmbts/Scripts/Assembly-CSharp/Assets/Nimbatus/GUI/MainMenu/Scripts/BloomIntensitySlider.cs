using System;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MainMenu.Scripts
{
	internal class BloomIntensitySlider : MonoBehaviour
	{
		private UISlider _slider;

		private float _currentValue;

		public void Start()
		{
			_slider = GetComponent<UISlider>();
			_slider.value = RuntimeGlobals.Settings.BloomIntensity;
		}

		public void Update()
		{
			if (Math.Abs(_slider.value - _currentValue) > 0.0001f)
			{
				RuntimeGlobals.Settings.BloomIntensity = _slider.value;
				_currentValue = _slider.value;
			}
		}
	}
}
