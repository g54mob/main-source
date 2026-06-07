using System.Xml.Linq;
using Jundroo.Common.DataTypes;

namespace Jundroo.Common.Settings
{
	public class StringSetting : Setting<StringValueTypeWrapper>
	{
		public class StringSettingBuilder : SettingBuilder<StringSettingBuilder, StringSetting>
		{
			public StringSettingBuilder(StringSetting setting)
				: base(setting)
			{
			}

			public static implicit operator StringSetting(StringSettingBuilder builder)
			{
				return builder.Setting;
			}
		}

		public StringSetting(string displayName, SettingsCategory category, string xmlName)
			: base(displayName, category, xmlName)
		{
		}

		public static implicit operator string(StringSetting setting)
		{
			return setting.Value.Value;
		}

		public static StringSettingBuilder Create(string displayName, SettingsCategory category, string xmlName = null)
		{
			return new StringSettingBuilder(new StringSetting(displayName, category, xmlName));
		}

		public override void RestoreFromXml(XElement xml)
		{
			if (base.State != SettingState.Disabled)
			{
				string text = (string)xml.Attribute(base.XmlName);
				if (text != null)
				{
					SetValue(text);
				}
			}
		}
	}
}
