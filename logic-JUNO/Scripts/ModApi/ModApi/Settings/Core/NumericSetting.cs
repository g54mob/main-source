using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml.Linq;
using UnityEngine;

namespace ModApi.Settings.Core
{
	public class NumericSetting<T> : Setting<T> where T : struct, IComparable, IComparable<T>, IEquatable<T>
	{
		public class NumericSettingBuilder : SettingBuilder<NumericSettingBuilder, NumericSetting<T>>
		{
			public NumericSettingBuilder(NumericSetting<T> setting)
				: base(setting)
			{
			}

			public static implicit operator NumericSetting<T>(NumericSettingBuilder builder)
			{
				return builder.Setting;
			}

			public NumericSettingBuilder SetDisplayFormatter(Func<T, string> formatter)
			{
				base.Setting.DisplayFormatter = formatter;
				return this;
			}

			public NumericSettingBuilder SetEnforcedRange(T min, T max)
			{
				return SetEnforcedRange(DeviceFlags.All, min, max);
			}

			public NumericSettingBuilder SetEnforcedRange(DeviceFlags devices, T min, T max)
			{
				if (CurrentDevice.HasAnyFlag(devices))
				{
					base.Setting.EnforcedMin = min;
					base.Setting.EnforcedMax = max;
				}
				return this;
			}

			public NumericSettingBuilder SetRange(DeviceFlags devices, T min, T max, T step)
			{
				if (CurrentDevice.HasAnyFlag(devices))
				{
					base.Setting.Min = min;
					base.Setting.Max = max;
					base.Setting.Step = step;
				}
				return this;
			}
		}

		public T? EnforcedMax { get; private set; }

		public T? EnforcedMin { get; private set; }

		public T Max { get; private set; }

		public T Min { get; private set; }

		public bool ReverseSpinnerUIValues { get; set; }

		public T Step { get; private set; }

		public bool UseSpinnerUI { get; set; }

		protected Func<T, string> DisplayFormatter { get; set; }

		protected NumericSetting(string displayName, SettingsCategory category, T min, T max, T step, string xmlName)
			: base(displayName, category, xmlName)
		{
			Min = min;
			Max = max;
			Step = step;
			DisplayFormatter = (T x) => x.ToString();
		}

		public static NumericSettingBuilder Create(string displayName, SettingsCategory category, T min, T max, T step, string xmlName = null)
		{
			return new NumericSettingBuilder(new NumericSetting<T>(displayName, category, min, max, step, xmlName));
		}

		public override string GetDisplayValue(T value)
		{
			return DisplayFormatter(value);
		}

		public override void RestoreFromXml(XElement xml)
		{
			if (base.State == SettingState.Disabled)
			{
				return;
			}
			string text = (string)xml.Attribute(base.XmlName);
			if (!string.IsNullOrWhiteSpace(text))
			{
				TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
				T val;
				if (converter.CanConvertFrom(typeof(string)))
				{
					val = (T)converter.ConvertFrom(null, CultureInfo.InvariantCulture, text);
				}
				else
				{
					val = base.Value;
					Debug.LogError($"Value '{text}' is not valid for setting '{base.XmlName}'. Defaulting to '{val}'.");
				}
				SetValue(val);
			}
		}

		protected override T Validate(T value)
		{
			if (EnforcedMin.HasValue && EnforcedMin.Value.CompareTo(value) > 0)
			{
				Debug.LogError($"Value '{value}' is less than the minimum allowed ({EnforcedMin.Value}) for setting '{base.XmlName}'. Defaulting to '{EnforcedMin.Value}'.");
				return EnforcedMin.Value;
			}
			if (EnforcedMax.HasValue && EnforcedMax.Value.CompareTo(value) < 0)
			{
				Debug.LogError($"Value '{value}' is greater than the maximum allowed ({EnforcedMax.Value}) for setting '{base.XmlName}'. Defaulting to '{EnforcedMax.Value}'.");
				return EnforcedMax.Value;
			}
			return value;
		}
	}
}
