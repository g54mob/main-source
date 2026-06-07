using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kamgam.SettingsGenerator
{
	public class SliderUIElementResolver : SettingResolverForVisualElement, ISettingResolver
	{
		[Tooltip("How big should one step be. Keep in mind that very small step sizes are cumbersome if used with a controller or keyboard.")]
		public float StepSize = 10f;

		[Tooltip("Should the value be rounded to integers?\nNOTICE: If connected to an Integer settings then this will always be true.")]
		public bool WholeNumbers;

		[NonSerialized]
		protected float _value;

		public string ValueFormat = "{0:N0} %";

		[Tooltip("Should the default move left/right input commands be used to change the value of the slider\nDisable if you want to ship your own controller input. You will have to call Increase() and Decrease() manually.")]
		public bool UseMoveCommandToChangeValue = true;

		protected Slider _slider;

		protected TextField _valueTf;

		protected SettingData.DataType[] supportedDataTypes = new SettingData.DataType[2]
		{
			SettingData.DataType.Int,
			SettingData.DataType.Float
		};

		protected bool stopPropagation;

		public float Value
		{
			get
			{
				if (!WholeNumbers)
				{
					return _value;
				}
				return Mathf.Round(_value);
			}
			set
			{
				if (Slider == null)
				{
					_value = Mathf.Round(value / StepSize) * StepSize;
					if (WholeNumbers)
					{
						_value = Mathf.Round(_value);
					}
				}
				else if (!(Mathf.Abs(_value - value) <= Mathf.Epsilon))
				{
					float value2 = (WholeNumbers ? Mathf.Round(value) : value);
					value2 = ConvertToStepValue(value2);
					value2 = Mathf.Clamp(value2, Slider.lowValue, Slider.highValue);
					if (Mathf.Abs(value2) < 0.0001f)
					{
						value2 = 0f;
					}
					if (Mathf.Abs(Slider.value - value2) > float.Epsilon)
					{
						Slider.value = value2;
					}
					_value = value2;
				}
			}
		}

		public Slider Slider
		{
			get
			{
				if ((_slider == null && base.VisualElement != null) || _slider != base.VisualElement)
				{
					_slider = base.VisualElement as Slider;
					if (_slider != null)
					{
						_slider.RegisterValueChangedCallback(onValueChanged);
						_slider.RegisterCallback<NavigationMoveEvent>(onMove);
					}
				}
				return _slider;
			}
		}

		public TextField ValueTf
		{
			get
			{
				if (_valueTf == null)
				{
					_valueTf = base.VisualElement.Q<TextField>();
				}
				return _valueTf;
			}
		}

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			return supportedDataTypes;
		}

		public override void OnEnable()
		{
			base.OnEnable();
			if (HasValidSettingForID(ID, GetSupportedDataTypes()))
			{
				SettingsProvider.Settings.GetSetting(ID).AddPulledFromConnectionListener(Refresh);
				Refresh();
			}
		}

		public override void OnDisable()
		{
			_slider = null;
			base.OnDisable();
		}

		public override void OnDestroy()
		{
			base.OnDestroy();
			if (Slider != null)
			{
				Slider.UnregisterValueChangedCallback(onValueChanged);
			}
		}

		protected void onValueChanged(ChangeEvent<float> evt)
		{
			if (!stopPropagation && HasValidSettingForID(ID, GetSupportedDataTypes()) && HasActiveSettingForID(ID))
			{
				Value = evt.newValue;
				SettingFloat settingFloat = SettingsProvider.Settings.GetFloat(ID);
				if (settingFloat != null)
				{
					settingFloat.SetValue(Value);
				}
				else
				{
					SettingsProvider.Settings.GetInt(ID)?.SetValue(Mathf.RoundToInt(Value));
				}
			}
		}

		public void onMove(NavigationMoveEvent evt)
		{
			if (!isFocused(Slider))
			{
				return;
			}
			switch (evt.direction)
			{
			case NavigationMoveEvent.Direction.Left:
				if (UseMoveCommandToChangeValue)
				{
					Decrease();
					evt.StopPropagation();
				}
				break;
			case NavigationMoveEvent.Direction.Right:
				if (UseMoveCommandToChangeValue)
				{
					Increase();
					evt.StopPropagation();
				}
				break;
			}
		}

		protected bool isFocused(VisualElement ele)
		{
			return ele == ele.panel.focusController.focusedElement;
		}

		public float ConvertToStepValue(float value)
		{
			float num = float.MaxValue;
			float num2 = value;
			float num3 = Slider.lowValue;
			int num4 = Mathf.CeilToInt((Slider.highValue - Slider.lowValue) / StepSize) + 1;
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
			Value += (float)steps * StepSize;
		}

		public override void Refresh()
		{
			if (!HasValidSettingForID(ID, GetSupportedDataTypes()) || !HasActiveSettingForID(ID))
			{
				return;
			}
			try
			{
				stopPropagation = true;
				SettingFloat settingFloat = SettingsProvider.Settings.GetFloat(ID);
				if (settingFloat != null)
				{
					Value = settingFloat.GetValue();
					return;
				}
				SettingInt settingInt = SettingsProvider.Settings.GetInt(ID);
				if (settingInt != null)
				{
					Value = settingInt.GetValue();
				}
			}
			finally
			{
				stopPropagation = false;
			}
		}
	}
}
