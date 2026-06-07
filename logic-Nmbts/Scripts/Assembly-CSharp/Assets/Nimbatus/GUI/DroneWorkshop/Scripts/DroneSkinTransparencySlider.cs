using System;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class DroneSkinTransparencySlider : MonoBehaviour
	{
		private UISlider _slider;

		private float _currentValue;

		public void Start()
		{
			_slider = GetComponent<UISlider>();
			_slider.value = RuntimeGlobals.Settings.DroneSkinTransparency;
		}

		public void Update()
		{
			if (Math.Abs(_slider.value - _currentValue) > 0.0001f)
			{
				RuntimeGlobals.Settings.DroneSkinTransparency = _slider.value;
				_currentValue = _slider.value;
			}
		}
	}
}
