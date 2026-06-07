using System.Globalization;
using SettingScripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts.SettingHandles
{
	public abstract class LogSettingSlider<TSetting, TType> : SettingSlider<TSetting, TType> where TSetting : NumericSetting<TType>
	{
		private bool intStep;

		private float defaultValue;

		private float baseValue;

		private float? spanIfZero;

		protected override void TypeSpecificUIElementCreation()
		{
			defaultValue = (dynamic)setting.DefaultValue;
			SettingSliderRef.slider.wholeNumbers = intStep;
			if (SettingSliderRef.sliderValue != null)
			{
				SettingSliderRef.sliderValue.precisionIsSI = true;
			}
			SettingSliderRef.slider.SetValueWithoutNotify(ToLog(setting.val));
			SettingSliderRef.editField.contentType = (intStep ? TMP_InputField.ContentType.IntegerNumber : TMP_InputField.ContentType.DecimalNumber);
		}

		public override void PositionDefaultPointer()
		{
			if (setting != null && !(SettingSliderRef.defaultPointer == null))
			{
				Slider slider = SettingSliderRef.slider;
				float width = SettingSliderRef.defaultPointer.transform.parent.GetComponent<RectTransform>().rect.width;
				Vector2 vector = Vector2.zero + new Vector2(1f, 0f) * width;
				SettingSliderRef.defaultPointer.GetComponent<RectTransform>().localPosition = vector * (0f - slider.minValue) / (slider.maxValue - slider.minValue) - new Vector2(width / 2f, 0f);
			}
		}

		public override void SetMinMax(float? min = null, float? max = null, bool forceInBounds = false)
		{
			TType val = setting.val;
			float num = ToLog(setting.val);
			if (max.HasValue)
			{
				SettingSliderRef.slider.maxValue = ToLog((TType)(dynamic)max.GetValueOrDefault());
			}
			if ((dynamic)setting.minValue <= 0f)
			{
				SettingSliderRef.slider.minValue = SettingSliderRef.slider.maxValue - (spanIfZero ?? 5f);
			}
			else if (min.HasValue)
			{
				SettingSliderRef.slider.minValue = ToLog((TType)(dynamic)min.GetValueOrDefault());
			}
			if (!forceInBounds && (num <= SettingSliderRef.slider.minValue || num >= SettingSliderRef.slider.maxValue))
			{
				SettingSliderRef.slider.SetValueWithoutNotify(num);
				setting.SetValue(val);
			}
		}

		public override TType SettingValueOfSlider(float val)
		{
			if (!Mathf.Approximately(val, SettingSliderRef.slider.minValue))
			{
				return ToLinear(val);
			}
			return setting.minValue;
		}

		public override void UpdateUIElement()
		{
			if ((dynamic)setting.val > 0f)
			{
				SettingSliderRef.slider.SetValueWithoutNotify(ToLog(setting.val));
			}
			else
			{
				SettingSliderRef.slider.SetValueWithoutNotify(SettingSliderRef.slider.minValue);
			}
			if (SettingSliderRef.sliderValue != null)
			{
				SettingSliderRef.sliderValue.UpdateValue((float)(dynamic)setting.val);
			}
		}

		public override void SubmitEditValue(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				text = "0";
			}
			float num = float.Parse(text.Replace(",", "."), NumberStyles.Any, CultureInfo.InvariantCulture);
			if (!setting.canBeNegative)
			{
				num = Mathf.Max(0f, num);
			}
			if (!setting.canGoOutOfBounds)
			{
				num = Mathf.Clamp(num, (dynamic)setting.minValue, (dynamic)setting.maxValue);
			}
			SetValue((TType)(dynamic)(num / setting.factor));
			onValueChangedByUser.Invoke((TType)(dynamic)(num / setting.factor));
		}

		public float ToLog(TType value)
		{
			return Mathf.Log((dynamic)value / defaultValue, baseValue);
		}

		public TType ToLinear(float p)
		{
			return (TType)(dynamic)(defaultValue * Mathf.Pow(baseValue, p));
		}

		public LogSettingSlider(TSetting _setting, float logBase, bool wholeNumbers = false, bool simple = false, float? targetSpanIfZero = null)
			: base(_setting, simple)
		{
			intStep = wholeNumbers;
			baseValue = logBase;
			spanIfZero = targetSpanIfZero;
		}

		public LogSettingSlider(float logBase, bool wholeNumbers = false, bool simple = false, float? targetSpanIfZero = null)
			: base((TSetting)null, simple)
		{
			intStep = wholeNumbers;
			baseValue = logBase;
			spanIfZero = targetSpanIfZero;
		}
	}
}
