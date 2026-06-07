using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Jundroo.Common.Settings
{
	public class EnumSetting<T> : Setting<T>, IEnumSetting where T : struct
	{
		public class EnumSettingBuilder : SettingBuilder<EnumSettingBuilder, EnumSetting<T>>
		{
			public EnumSettingBuilder(EnumSetting<T> setting)
				: base(setting)
			{
			}

			public static implicit operator EnumSetting<T>(EnumSettingBuilder builder)
			{
				return builder.Setting;
			}
		}

		private string _description;

		private Dictionary<T, string> _descriptions;

		private Dictionary<T, string> _displayNames;

		public IReadOnlyList<string> AvailableStringValues { get; private set; }

		public IReadOnlyList<T> AvailableValues { get; private set; }

		public override string Description
		{
			get
			{
				return _description;
			}
			protected set
			{
				_description = value;
				foreach (T availableValue in AvailableValues)
				{
					if (_descriptions.TryGetValue(availableValue, out var value2) && !string.IsNullOrWhiteSpace(value2))
					{
						string text = _displayNames[availableValue];
						_description = _description + Environment.NewLine + Environment.NewLine + text + ": " + value2;
					}
				}
			}
		}

		public IReadOnlyList<T> DisabledValues { get; private set; }

		public IReadOnlyList<T> HiddenValues { get; private set; }

		protected EnumSetting(string displayName, SettingsCategory category, string xmlName)
			: base(displayName, category, xmlName)
		{
			Initialize();
		}

		public static EnumSettingBuilder Create(string displayName, SettingsCategory category, string xmlName = null)
		{
			return new EnumSettingBuilder(new EnumSetting<T>(displayName, category, xmlName));
		}

		public override string GetDisplayValue(T value)
		{
			if (!_displayNames.TryGetValue(value, out var value2))
			{
				return value.ToString();
			}
			return value2;
		}

		public string GetDisplayValue(string value)
		{
			return GetDisplayValue((T)Enum.Parse(base.ValueType, value));
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
				if (!Enum.TryParse<T>(text, ignoreCase: true, out var result))
				{
					result = (AvailableValues.Contains(base.Value) ? base.Value : AvailableValues.FirstOrDefault());
					Debug.LogError($"Value '{text}' is not valid for setting '{base.XmlName}'. Defaulting to '{result}'.");
				}
				else if (DisabledValues.Contains(result))
				{
					result = (AvailableValues.Contains(base.Value) ? base.Value : AvailableValues.FirstOrDefault());
					Debug.LogError($"Value '{text}' is not supported for setting '{base.XmlName}'. Defaulting to '{result}'.");
				}
				SetValue(result);
			}
		}

		public void SetInternalValueFromDisplayValue(string displayValue)
		{
			foreach (T key in _displayNames.Keys)
			{
				if (!DisabledValues.Contains(key) && _displayNames[key] == displayValue)
				{
					base.Value = key;
				}
			}
		}

		public void SetStringValue(string value)
		{
			base.Value = (T)Enum.Parse(base.ValueType, value);
		}

		protected override T Validate(T value)
		{
			if (AvailableValues.Contains(value) || HiddenValues.Contains(value))
			{
				return value;
			}
			T val = AvailableValues.FirstOrDefault();
			Debug.LogError($"Value '{value}' is not supported for setting '{base.XmlName}'. Defaulting to '{val}'.");
			return val;
		}

		private void Initialize()
		{
			SortedList<int, T> sortedList = new SortedList<int, T>();
			List<T> list = new List<T>();
			List<T> list2 = new List<T>();
			_displayNames = new Dictionary<T, string>();
			_descriptions = new Dictionary<T, string>();
			FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Static | BindingFlags.Public);
			foreach (FieldInfo fieldInfo in fields)
			{
				T value = (T)fieldInfo.GetValue(null);
				string value2 = fieldInfo.Name;
				string value3 = string.Empty;
				string warning = string.Empty;
				SettingState settingState = SettingState.Enabled;
				int num = (int)fieldInfo.GetValue(null);
				foreach (EnumOptionAttribute item in (from EnumOptionAttribute x in fieldInfo.GetCustomAttributes(typeof(EnumOptionAttribute), inherit: false)
					orderby x.AttributePriority
					select x).ToList())
				{
					if (Device.HasAnyFlag(item.Devices))
					{
						settingState = item.State;
						if (!string.IsNullOrWhiteSpace(item.DisplayName))
						{
							value2 = item.DisplayName;
						}
						if (!string.IsNullOrWhiteSpace(item.Description))
						{
							value3 = item.Description;
						}
						if (!string.IsNullOrWhiteSpace(item.Warning))
						{
							warning = item.Warning;
						}
						if (item.DisplayOrder != int.MaxValue)
						{
							num = item.DisplayOrder;
						}
					}
				}
				_displayNames[value] = value2;
				_descriptions[value] = value3;
				if (!string.IsNullOrWhiteSpace(warning))
				{
					base.WarningChecks.Add((T x) => (!x.Equals(value)) ? null : warning);
				}
				switch (settingState)
				{
				case SettingState.Disabled:
					list2.Add(value);
					continue;
				case SettingState.Hidden:
				case SettingState.HiddenReadOnly:
					list.Add(value);
					continue;
				}
				for (; sortedList.ContainsKey(num); num++)
				{
				}
				sortedList.Add(num, value);
			}
			AvailableValues = sortedList.Values.ToList();
			List<string> list3 = new List<string>();
			foreach (T availableValue in AvailableValues)
			{
				list3.Add(availableValue.ToString());
			}
			AvailableStringValues = list3;
			HiddenValues = list;
			DisabledValues = list2;
		}
	}
}
