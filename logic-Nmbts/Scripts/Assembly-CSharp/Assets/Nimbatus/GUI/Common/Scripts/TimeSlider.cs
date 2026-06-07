using System;
using Assets.Nimbatus.Scripts.Persistence;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class TimeSlider : MonoBehaviour
	{
		public bool IgnoreKeys;

		public UILabel TimeLabel;

		private UISlider _slider;

		private float _currentValue;

		public void Start()
		{
			_slider = GetComponent<UISlider>();
			_slider.value = RuntimeGlobals.TimeScale;
			TimeLabel.text = RuntimeGlobals.TimeScale.ToString("F3");
		}

		public void Update()
		{
			if (RuntimeGlobals.IsGamePaused)
			{
				return;
			}
			if (!IgnoreKeys)
			{
				if (Input.GetKeyDown(KeyCode.Alpha1))
				{
					_slider.value = 0.1f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha2))
				{
					_slider.value = 0.2f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha3))
				{
					_slider.value = 0.3f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha4))
				{
					_slider.value = 0.4f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha5))
				{
					_slider.value = 0.5f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha6))
				{
					_slider.value = 0.6f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha7))
				{
					_slider.value = 0.7f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha8))
				{
					_slider.value = 0.8f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha9))
				{
					_slider.value = 0.9f;
				}
				else if (Input.GetKeyDown(KeyCode.Alpha0))
				{
					_slider.value = 1f;
				}
			}
			if (Math.Abs(_slider.value - _currentValue) > 0.0001f)
			{
				RuntimeGlobals.TimeScale = (float)Math.Round(_slider.value, 3);
				TimeLabel.text = RuntimeGlobals.TimeScale.ToString("F3");
				_currentValue = _slider.value;
			}
		}
	}
}
