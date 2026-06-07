using System;
using System.Globalization;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class FloatInputSlider : MonoBehaviour
	{
		public UIInput Input;

		public UISlider Slider;

		public float MinValue;

		public float MaxValue;

		private float _currentValue;

		private bool _ignoreSlider;

		private bool _firstUpdate;

		private bool _unknownValue;

		public float CurrentValue
		{
			get
			{
				return _currentValue;
			}
			set
			{
				float num = MaxValue - MinValue;
				_ignoreSlider = true;
				Slider.value = 1f / num * (value - MinValue);
				Input.value = value.ToString("0.00", CultureInfo.InvariantCulture);
				_ignoreSlider = false;
				_currentValue = value;
			}
		}

		public event Action<float> ValueChanged;

		public void Start()
		{
			Input.submitOnUnselect = true;
			EventDelegate.Add(Slider.onChange, OnSliderChange);
			EventDelegate.Add(Input.onSubmit, OnSubmit);
		}

		public void OnSubmit()
		{
			float result;
			if (float.TryParse(Input.value, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
			{
				if (result > MaxValue)
				{
					result = MaxValue;
				}
				if (result < MinValue)
				{
					result = MinValue;
				}
				_currentValue = result;
				float num = MaxValue - MinValue;
				_ignoreSlider = true;
				Slider.value = 1f / num * (result - MinValue);
				_ignoreSlider = false;
				Input.value = result.ToString("0.00", CultureInfo.InvariantCulture);
				Action<float> action = this.ValueChanged;
				if (action != null)
				{
					action(CurrentValue);
				}
				_unknownValue = false;
			}
			else
			{
				CurrentValue = _currentValue;
			}
		}

		public void Init(float min, float max, int steps)
		{
			MinValue = min;
			MaxValue = max;
			Slider.numberOfSteps = steps;
			_firstUpdate = true;
		}

		public void Init(float min, float max, int steps, float value, bool valueUnknown)
		{
			Init(min, max, steps);
			CurrentValue = value;
			_unknownValue = valueUnknown;
			if (_unknownValue)
			{
				Input.value = "?";
			}
		}

		public void OnSliderChange()
		{
			if (_firstUpdate)
			{
				_firstUpdate = false;
			}
			else if (!_ignoreSlider)
			{
				float currentValue = Slider.value * (MaxValue - MinValue) + MinValue;
				Input.value = currentValue.ToString("0.00", CultureInfo.InvariantCulture);
				_currentValue = currentValue;
				Action<float> action = this.ValueChanged;
				if (action != null)
				{
					action(CurrentValue);
				}
				_unknownValue = false;
			}
		}
	}
}
