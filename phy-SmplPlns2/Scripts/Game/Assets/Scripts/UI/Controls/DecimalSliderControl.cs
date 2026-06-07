using System;
using System.Globalization;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Controls
{
	public class DecimalSliderControl : WidgetControl
	{
		private decimal _value;

		private TextWidget _labelText;

		private TextWidget _unitText;

		private string _unit;

		private bool _isEditingText;

		private bool _ignoreTextValueChanges;

		public string LabelText
		{
			get
			{
				if (!(_labelText != null))
				{
					return null;
				}
				return _labelText.Text;
			}
			set
			{
				if (_labelText != null)
				{
					_labelText.Text = value;
				}
			}
		}

		public SliderWidget Slider { get; private set; }

		public string Unit
		{
			get
			{
				return _unit;
			}
			set
			{
				_unit = value;
				UpdateValueText(Value);
			}
		}

		public decimal MaxValue { get; set; } = 1m;

		public decimal MinValue { get; set; } = 1m;

		public string ValueString
		{
			get
			{
				if (ValueText != null)
				{
					return ValueText.Text;
				}
				return ValueInput.Text;
			}
			set
			{
				if (ValueText != null)
				{
					ValueText.Text = value;
					return;
				}
				try
				{
					_ignoreTextValueChanges = true;
					ValueInput.Text = value;
				}
				finally
				{
					_ignoreTextValueChanges = false;
				}
			}
		}

		public decimal Value => _value;

		public Func<decimal, string> ValueFormatter { get; set; }

		public TextWidget ValueText { get; private set; }

		public InputWidget ValueInput { get; private set; }

		public decimal TextValueScale { get; set; } = 1m;

		public bool AllowOutOfRangeEntry { get; set; }

		public event OnValueChanged<decimal> OnValueChanged;

		public DecimalSliderControl(Widget widget)
			: base(widget)
		{
			_labelText = widget.FindWidget<TextWidget>("label-text");
			ValueText = widget.FindWidget<TextWidget>("value-text");
			ValueInput = widget.FindWidget<InputWidget>("value-input");
			Slider = widget.FindWidget<SliderWidget>("slider");
			_unitText = widget.FindWidget<TextWidget>("unit-text");
			Slider.ValueChanged += delegate
			{
				OnSliderValueChanged(Slider.Value);
			};
			if (ValueInput != null)
			{
				ValueInput.Input.onSelect.AddListener(delegate
				{
					_isEditingText = true;
				});
				ValueInput.Input.onValueChanged.AddListener(OnInputValueChanged);
				ValueInput.Input.onEndEdit.AddListener(OnInputEndEdit);
			}
		}

		public void SetValue(decimal value, bool events = false, bool setSlider = true, bool setText = true)
		{
			decimal value2 = _value;
			_value = value;
			if (setSlider)
			{
				Slider.Value = (float)value;
			}
			if (setText)
			{
				UpdateValueText(value);
			}
			if (!(value2 == value) && events)
			{
				this.OnValueChanged?.Invoke(value2, _value);
			}
		}

		public void SetRange(decimal min, decimal max, int numberOfSteps = 0)
		{
			MinValue = min;
			MaxValue = max;
			Slider.MinValue = (float)min;
			Slider.MaxValue = (float)max;
			if (numberOfSteps != Slider.NumberOfSteps)
			{
				Slider.NumberOfSteps = numberOfSteps;
			}
		}

		private void OnSliderValueChanged(float x)
		{
			decimal num = (decimal)x;
			if (Slider.NumberOfSteps > 1)
			{
				int decimals = Mathf.CeilToInt(Mathf.Log10(Slider.NumberOfSteps));
				num = decimal.Round(num, decimals);
			}
			SetValue(num, events: true, setSlider: false);
		}

		private void OnInputValueChanged(string text)
		{
			if (_ignoreTextValueChanges || !decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				return;
			}
			result /= TextValueScale;
			if (!AllowOutOfRangeEntry)
			{
				if (result < MinValue)
				{
					result = MinValue;
				}
				else if (result > MaxValue)
				{
					result = MaxValue;
				}
			}
			SetValue(result, events: true, setSlider: true, setText: false);
		}

		private void OnInputEndEdit(string text)
		{
			_isEditingText = false;
			UpdateValueText(_value);
		}

		private void UpdateValueText(decimal value)
		{
			if (_isEditingText)
			{
				return;
			}
			value /= 1m / TextValueScale;
			if (ValueFormatter != null)
			{
				ValueString = ValueFormatter(value);
				return;
			}
			string text = value.ToString(CultureInfo.InvariantCulture);
			string text2 = _unit ?? string.Empty;
			if (_unitText != null)
			{
				_unitText.Text = text2;
			}
			else
			{
				text += text2;
			}
			ValueString = text;
		}
	}
}
