using System;
using System.Globalization;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.Controls
{
	public class SliderControl : WidgetControl
	{
		public static readonly Func<float, string> PercentageFormatter = (float x) => $"{x:P0}";

		private float _value;

		private TextWidget _labelText;

		private TextWidget _unitText;

		private string _unit;

		private string _format;

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
				UpdateValueText(Slider.Value);
			}
		}

		public string ValueFormat
		{
			get
			{
				return _format;
			}
			set
			{
				_format = value;
				UpdateValueText(Slider.Value);
			}
		}

		public bool ManualValueString { get; set; }

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

		public float Value => _value;

		public Func<float, string> ValueFormatter { get; set; }

		public TextWidget ValueText { get; private set; }

		public InputWidget ValueInput { get; private set; }

		public float TextValueScale { get; set; } = 1f;

		public bool AllowOutOfRangeEntry { get; set; }

		public event OnValueChanged<float> OnValueChanged;

		public event OnValueChanged<float> OnRelease;

		public SliderControl(Widget widget)
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
			Slider.ValueSet += UpdateValueText;
			if (ValueInput != null)
			{
				ValueInput.Input.onSelect.AddListener(delegate
				{
					_isEditingText = true;
				});
				ValueInput.Input.onValueChanged.AddListener(OnInputValueChanged);
				ValueInput.Input.onEndEdit.AddListener(OnInputEndEdit);
			}
			EventTrigger eventTrigger = Slider.Slider.gameObject.GetComponent<EventTrigger>();
			if (eventTrigger == null)
			{
				eventTrigger = Slider.Slider.gameObject.AddComponent<EventTrigger>();
			}
			EventTrigger.Entry entry = new EventTrigger.Entry();
			entry.eventID = EventTriggerType.PointerUp;
			entry.callback.AddListener(delegate
			{
				OnSliderReleased();
			});
			eventTrigger.triggers.Add(entry);
		}

		public void SetValue(float value, bool events = false, bool setSlider = true, bool setText = true)
		{
			float value2 = _value;
			_value = value;
			if (setSlider)
			{
				Slider.Value = value;
			}
			if (setText)
			{
				UpdateValueText(value);
			}
			if (value2 != value && events)
			{
				this.OnValueChanged?.Invoke(value2, _value);
			}
		}

		public void SetRange(float min, float max, int numberOfSteps = 0)
		{
			Slider.MinValue = min;
			Slider.MaxValue = max;
			if (numberOfSteps != Slider.NumberOfSteps)
			{
				Slider.NumberOfSteps = numberOfSteps;
			}
		}

		private void OnSliderValueChanged(float x)
		{
			SetValue(x, events: true, setSlider: false);
		}

		private void OnSliderReleased()
		{
			this.OnRelease?.Invoke(Slider.Value, Slider.Value);
		}

		private void OnInputValueChanged(string text)
		{
			if (!_ignoreTextValueChanges && float.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				result /= TextValueScale;
				if (!AllowOutOfRangeEntry)
				{
					result = Mathf.Clamp(result, Slider.MinValue, Slider.MaxValue);
				}
				SetValue(result, events: true, setSlider: true, setText: false);
			}
		}

		private void OnInputEndEdit(string text)
		{
			_isEditingText = false;
			UpdateValueText(_value);
		}

		private void UpdateValueText(float value)
		{
			if (_isEditingText || ManualValueString)
			{
				return;
			}
			value *= TextValueScale;
			if (ValueFormatter != null)
			{
				ValueString = ValueFormatter(value);
				return;
			}
			string text = ((_format == null) ? value.ToString(CultureInfo.InvariantCulture) : value.ToString(_format, CultureInfo.InvariantCulture));
			string text2 = _unit ?? string.Empty;
			if (_unitText != null)
			{
				_unitText.Text = text2;
			}
			else
			{
				text += text2;
			}
			if (ValueText != null)
			{
				ValueText.Text = text;
			}
			else if (ValueInput != null)
			{
				ValueInput.Text = text;
			}
		}
	}
}
