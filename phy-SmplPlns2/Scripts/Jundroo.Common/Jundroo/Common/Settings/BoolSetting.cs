using System.Xml.Linq;
using Jundroo.Common.Platform;
using UnityEngine;

namespace Jundroo.Common.Settings
{
	public class BoolSetting : Setting<bool>
	{
		public class BoolSettingBuilder : SettingBuilder<BoolSettingBuilder, BoolSetting>
		{
			public BoolSettingBuilder(BoolSetting setting)
				: base(setting)
			{
			}

			public static implicit operator BoolSetting(BoolSettingBuilder builder)
			{
				return builder.Setting;
			}

			public BoolSettingBuilder AddWarningOnDisabled(string warning = "This setting is not intended to run on your device and is not officially supported. Performance of the game could be severely impacted or it may fail to run entirely. Use at your own risk.")
			{
				return AddWarningOnDisabled(DeviceFlags.All, warning);
			}

			public BoolSettingBuilder AddWarningOnDisabled(DeviceFlags devices, string warning = "This setting is not intended to run on your device and is not officially supported. Performance of the game could be severely impacted or it may fail to run entirely. Use at your own risk.")
			{
				if (Device.HasAnyFlag(devices))
				{
					AddWarning(devices, (bool x) => !x, warning);
				}
				return this;
			}

			public BoolSettingBuilder AddWarningOnEnabled(string warning = "This setting is not intended to run on your device and is not officially supported. Performance of the game could be severely impacted or it may fail to run entirely. Use at your own risk.")
			{
				return AddWarningOnEnabled(DeviceFlags.All, warning);
			}

			public BoolSettingBuilder AddWarningOnEnabled(DeviceFlags devices, string warning = "This setting is not intended to run on your device and is not officially supported. Performance of the game could be severely impacted or it may fail to run entirely. Use at your own risk.")
			{
				if (Device.HasAnyFlag(devices))
				{
					AddWarning(devices, (bool x) => x, warning);
				}
				return this;
			}

			public BoolSettingBuilder SetDisplayText(string disabledDisplayText, string enabledDisplayText)
			{
				return SetDisplayText(DeviceFlags.All, disabledDisplayText, enabledDisplayText);
			}

			public BoolSettingBuilder SetDisplayText(DeviceFlags devices, string disabledDisplayText, string enabledDisplayText)
			{
				if (Device.HasAnyFlag(devices))
				{
					base.Setting._displayText[0] = disabledDisplayText;
					base.Setting._displayText[1] = enabledDisplayText;
				}
				return this;
			}
		}

		private string[] _displayText;

		protected BoolSetting(string displayName, SettingsCategory category, string xmlName)
			: base(displayName, category, xmlName)
		{
			_displayText = new string[2] { "Disabled", "Enabled" };
		}

		public static BoolSettingBuilder Create(string displayName, SettingsCategory category, string xmlName = null)
		{
			return new BoolSettingBuilder(new BoolSetting(displayName, category, xmlName));
		}

		public override string GetDisplayValue(bool value)
		{
			if (!base.Value)
			{
				return _displayText[0];
			}
			return _displayText[1];
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
				if (!bool.TryParse(text, out var result))
				{
					result = base.Value;
					Debug.LogError($"Value '{text}' is not valid for setting '{base.XmlName}'. Defaulting to '{result}'.");
				}
				SetValue(result);
			}
		}
	}
}
