using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Kamgam.UGUIComponentsForSettings
{
	[SelectionBase]
	public class SliderUGUI : MonoBehaviour
	{
		public delegate void ValueChangedDelegate(float value);

		[Tooltip("How big should one step be. Keep in mind that very small step sizes are cumbersome if used with a controller or keyboard.")]
		public float StepSize = 10f;

		[Tooltip("The number format:\n'{0:N0}' = whole number without commas ('1')\n'{0:N1}' = one digit after the comma ('1.2')\n\nYou can learn more here: https://learn.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings")]
		public string ValueFormat = "{0:N0} %";

		[Tooltip("Should the default move left/right input commands be used to change the value of the slider\nDisable if you want to ship your own controller input. You will have to call Increase() and Decrease() manually.")]
		public bool UseMoveCommandToChangeValue = true;

		public SliderWithEventOverridesUGUI Slider;

		[SerializeField]
		private Slider.SliderEvent OnValueChangedEvent;

		public ValueChangedDelegate OnValueChanged;

		[NonSerialized]
		protected float _lastSetValue = float.MinValue;

		public TextMeshProUGUI TextTf;

		public TextMeshProUGUI ValueTf;

		public float MinValue
		{
			get
			{
				if (!(Slider == null))
				{
					return Slider.minValue;
				}
				return 0f;
			}
			set
			{
				if (Slider != null)
				{
					Slider.minValue = value;
				}
			}
		}

		public float MaxValue
		{
			get
			{
				if (!(Slider == null))
				{
					return Slider.maxValue;
				}
				return 1f;
			}
			set
			{
				if (Slider != null)
				{
					Slider.maxValue = value;
				}
			}
		}

		public bool WholeNumbers
		{
			get
			{
				if (Slider == null)
				{
					return false;
				}
				return Slider.wholeNumbers;
			}
			set
			{
				if (Slider != null)
				{
					Slider.wholeNumbers = value;
				}
			}
		}

		public float Value
		{
			get
			{
				if (Slider == null)
				{
					return 0f;
				}
				if (!WholeNumbers)
				{
					return Slider.value;
				}
				return Mathf.Round(Slider.value);
			}
			set
			{
				if (!(Slider == null) && !(Mathf.Abs(_lastSetValue - value) <= Mathf.Epsilon))
				{
					float value2 = (WholeNumbers ? Mathf.Round(value) : value);
					value2 = ConvertToStepValue(value2);
					value2 = Mathf.Clamp(value2, MinValue, MaxValue);
					if (Mathf.Abs(value2) < 0.0001f)
					{
						value2 = 0f;
					}
					if (Mathf.Abs(Slider.value - value2) > float.Epsilon)
					{
						Slider.value = value2;
					}
					_lastSetValue = value2;
					UpdateText();
				}
			}
		}

		public int IntValue => Mathf.RoundToInt(Slider.value);

		public string Text
		{
			get
			{
				if (TextTf == null)
				{
					return null;
				}
				return TextTf.text;
			}
			set
			{
				if (!(value == Text) && !(TextTf == null))
				{
					TextTf.text = value;
				}
			}
		}

		protected void UpdateText()
		{
			if (!(ValueTf == null))
			{
				if (!string.IsNullOrEmpty(ValueFormat))
				{
					ValueTf.text = string.Format(ValueFormat, Slider.value);
				}
				else
				{
					ValueTf.text = Slider.value.ToString();
				}
			}
		}

		public void Start()
		{
			Slider.onValueChanged.AddListener(onValueChangedHandler);
			Slider.OnMoveOverride = onMove;
			Slider.minValue = MinValue;
			Slider.maxValue = MaxValue;
			Slider.wholeNumbers = WholeNumbers;
			Slider.value = Value;
			UpdateText();
		}

		private void onValueChangedHandler(float value)
		{
			Value = value;
			OnValueChangedEvent?.Invoke(Value);
			OnValueChanged?.Invoke(Value);
		}

		public bool onMove(AxisEventData eventData)
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return false;
			}
			switch (eventData.moveDir)
			{
			case MoveDirection.Left:
				if (UseMoveCommandToChangeValue)
				{
					Decrease();
					return false;
				}
				return true;
			case MoveDirection.Right:
				if (UseMoveCommandToChangeValue)
				{
					Increase();
					return false;
				}
				return true;
			default:
				return true;
			}
		}

		public float ConvertToStepValue(float value)
		{
			float num = float.MaxValue;
			float num2 = value;
			float num3 = MinValue;
			int num4 = Mathf.CeilToInt((MaxValue - MinValue) / StepSize) + 1;
			for (int i = 0; i < num4; i++)
			{
				float num5 = Mathf.Abs(value - num3);
				if (num5 < num)
				{
					num = num5;
					num2 = num3;
				}
				num3 += StepSize;
			}
			if (WholeNumbers)
			{
				num2 = Mathf.Round(num2);
			}
			return num2;
		}

		public void Increase()
		{
			Step(1);
		}

		public void Decrease()
		{
			Step(-1);
		}

		public void Step(int steps)
		{
			Value = Slider.value + (float)steps * StepSize;
		}
	}
}
