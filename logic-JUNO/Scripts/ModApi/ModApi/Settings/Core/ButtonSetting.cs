using System;
using System.Xml.Linq;
using ModApi.Settings.Core.Events;

namespace ModApi.Settings.Core
{
	public class ButtonSetting : Setting<int>
	{
		public class ButtonSettingBuilder : SettingBuilder<ButtonSettingBuilder, ButtonSetting>
		{
			public ButtonSettingBuilder(ButtonSetting setting)
				: base(setting)
			{
			}

			public static implicit operator ButtonSetting(ButtonSettingBuilder builder)
			{
				return builder.Setting;
			}

			public ButtonSettingBuilder AddClickEvent(EventHandler<SettingChangedEventArgs<int>> eventHandler)
			{
				base.Setting.Changed += eventHandler;
				return this;
			}
		}

		public string ButtonText { get; }

		public ButtonSetting(string labelText, string buttonText, SettingsCategory category, string xmlName)
			: base(labelText, category, xmlName)
		{
			ButtonText = buttonText;
		}

		public static ButtonSettingBuilder Create(string labelText, string buttonText, SettingsCategory category, string xmlName = null)
		{
			return new ButtonSettingBuilder(new ButtonSetting(labelText, buttonText, category, xmlName));
		}

		public override void RestoreFromXml(XElement xml)
		{
		}

		public override void SaveToXml(XElement xml)
		{
		}
	}
}
