using System;
using Jundroo.Juicy.Widgets;
using UnityEngine;

namespace Assets.Scripts.UI.Controls
{
	public class NumericSpinnerControl : WidgetControl
	{
		private const float RepeatHoldTime = 0.75f;

		private int _holdState;

		private float _holdTimer;

		private InputWidget _inputField;

		private float _numericValue;

		public Func<float> GetDecrementAmount { get; set; }

		public Func<float> GetIncrementAmount { get; set; }

		public TextWidget LabelText { get; }

		public float MaxValue { get; set; } = float.MaxValue;

		public float MinValue { get; set; } = float.MinValue;

		public ButtonWidget NextButton { get; }

		public string NumericFormat { get; set; }

		public bool NumericWrap { get; set; }

		public OnValueChanged<float> OnValueChanged { get; set; }

		public OnValueChanging<float> OnValueChanging { get; set; }

		public ButtonWidget PrevButton { get; }

		public float StepSize { get; set; }

		public string Suffix { get; set; }

		public TextWidget Text { get; }

		public bool UserEndedEdit { get; private set; }

		public virtual float Value
		{
			get
			{
				return _numericValue;
			}
			set
			{
				SetValueInternal(value, updateText: true);
			}
		}

		public NumericSpinnerControl(Widget widget)
			: base(widget)
		{
			widget.gameObject.AddComponent<UpdateScript>().MonoBehaviourUpdate += OnUpdateScript;
			NextButton = widget.FindWidget<ButtonWidget>("next-button");
			NextButton.PointerUp += delegate
			{
				UpdateHoldState(pressed: false, 1);
			};
			NextButton.PointerDown += delegate
			{
				OnButtonClicked(1);
				UpdateHoldState(pressed: true, 1);
			};
			PrevButton = widget.FindWidget<ButtonWidget>("prev-button");
			PrevButton.PointerUp += delegate
			{
				UpdateHoldState(pressed: false, -1);
			};
			if (PrevButton != null)
			{
				PrevButton.PointerDown += delegate
				{
					OnButtonClicked(-1);
					UpdateHoldState(pressed: true, -1);
				};
			}
			LabelText = widget.FindWidget<TextWidget>("label-text");
			_inputField = widget.FindWidget<InputWidget>("value-input");
			if (_inputField != null)
			{
				_inputField.Input.onValueChanged.AddListener(OnInputValueChanged);
				_inputField.Input.onEndEdit.AddListener(OnInputEndEdit);
			}
			else
			{
				Text = widget.FindWidget<TextWidget>("value-text");
			}
			GetIncrementAmount = () => StepSize;
			GetDecrementAmount = () => StepSize;
		}

		protected virtual void OnDestroy()
		{
			OnValueChanged = null;
		}

		private void OnButtonClicked(int direction)
		{
			float value = Value;
			float num = ((direction > 0) ? GetIncrementAmount() : (0f - GetDecrementAmount()));
			float num2 = Value + num;
			OnValueChanging?.Invoke(value, num2);
			Value = num2;
			OnValueChanged?.Invoke(value, num2);
		}

		private void OnInputEndEdit(string value)
		{
			try
			{
				UserEndedEdit = true;
				OnUserEditValue(value, updateText: true);
			}
			finally
			{
				UserEndedEdit = false;
			}
		}

		private void OnInputValueChanged(string value)
		{
			if (_inputField.Input.isFocused)
			{
				OnUserEditValue(value, updateText: false);
			}
		}

		private void OnUpdateScript()
		{
			if (_holdState != 0)
			{
				if (_holdTimer > 0f)
				{
					_holdTimer -= Time.unscaledDeltaTime;
				}
				if (_holdTimer <= 0f)
				{
					OnButtonClicked(_holdState);
					_holdTimer = 0.01f;
				}
			}
		}

		private void OnUserEditValue(string value, bool updateText)
		{
			if (Suffix != null)
			{
				int num = Math.Min(Suffix.Length, value.Length);
				ReadOnlySpan<char> span = value.AsSpan();
				ReadOnlySpan<char> readOnlySpan = Suffix.AsSpan();
				while (num > 0)
				{
					ReadOnlySpan<char> readOnlySpan2 = readOnlySpan;
					int num2 = num;
					int length = readOnlySpan2.Length;
					int num3 = length - num2;
					if (span.EndsWith(readOnlySpan2.Slice(num3, length - num3), StringComparison.OrdinalIgnoreCase))
					{
						string text = value;
						num3 = num;
						value = text.Substring(0, text.Length - num3);
						break;
					}
					num--;
				}
			}
			float value2 = Value;
			float num4 = _numericValue;
			float result = 0f;
			if (float.TryParse(value, out result))
			{
				num4 = result;
			}
			OnValueChanging?.Invoke(value2, num4);
			SetValueInternal(num4, updateText);
			OnValueChanged?.Invoke(value2, num4);
		}

		private void SetValueInternal(float value, bool updateText)
		{
			if (NumericWrap)
			{
				if (value > MaxValue)
				{
					value = MinValue + (value - MaxValue);
				}
				else if (value < MinValue)
				{
					value = MaxValue + (value - MinValue);
				}
			}
			_numericValue = Mathf.Clamp(value, MinValue, MaxValue);
			if (updateText)
			{
				string text = _numericValue.ToString(NumericFormat);
				if (Suffix != null)
				{
					text += Suffix;
				}
				if (_inputField != null)
				{
					_inputField.Text = text;
				}
				else if (Text != null)
				{
					Text.Text = text;
				}
			}
		}

		private void UpdateHoldState(bool pressed, int direction)
		{
			if (pressed)
			{
				if (_holdState == 0)
				{
					_holdState = direction;
					_holdTimer = 0.75f;
				}
			}
			else
			{
				_holdState = 0;
				_holdTimer = 0f;
			}
		}
	}
}
