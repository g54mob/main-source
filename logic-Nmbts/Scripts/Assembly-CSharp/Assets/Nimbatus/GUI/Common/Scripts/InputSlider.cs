using System;
using System.Globalization;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class InputSlider : MonoBehaviour
	{
		public UIInput Input;

		public UISlider Slider;

		public int MinValue;

		public int MaxValue;

		private int _currentValue;

		private bool _ignoreSlider;

		private bool _firstUpdate;

		private bool _unknownValue;

		public int CurrentValue
		{
			get
			{
				return _currentValue;
			}
			set
			{
				float num = MaxValue - MinValue;
				_ignoreSlider = true;
				Slider.value = 1f / num * (float)(value - MinValue);
				Input.value = value.ToString(CultureInfo.InvariantCulture);
				_ignoreSlider = false;
				_currentValue = value;
			}
		}

		public event Action<int> ValueChanged;

		public void Start()
		{
			Input.submitOnUnselect = true;
			EventDelegate.Add(Slider.onChange, OnSliderChange);
			EventDelegate.Add(Input.onSubmit, OnSubmit);
		}

		public void OnSubmit()
		{
			int result;
			if (int.TryParse(Input.value, out result))
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
				Slider.value = 1f / num * (float)(result - MinValue);
				_ignoreSlider = false;
				Input.value = result.ToString(CultureInfo.InvariantCulture);
				Action<int> action = this.ValueChanged;
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

		public void Init(int min, int max, int steps = 100)
		{
			MinValue = min;
			MaxValue = max;
			Slider.numberOfSteps = steps;
			_firstUpdate = true;
		}

		public void Init(int min, int max, int steps, int value, bool valueUnknown)
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
				int currentValue = Mathf.RoundToInt(Slider.value * (float)(MaxValue - MinValue) + (float)MinValue);
				Input.value = currentValue.ToString(CultureInfo.InvariantCulture);
				_currentValue = currentValue;
				Action<int> action = this.ValueChanged;
				if (action != null)
				{
					action(CurrentValue);
				}
				_unknownValue = false;
			}
		}
	}
}
