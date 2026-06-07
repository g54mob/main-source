using System;
using System.Xml.Linq;
using UnityEngine;

namespace Jundroo.Common.Settings
{
	public class ResolutionSetting : Setting<Resolution>
	{
		public class ResolutionSettingBuilder : SettingBuilder<ResolutionSettingBuilder, ResolutionSetting>
		{
			public ResolutionSettingBuilder(ResolutionSetting setting)
				: base(setting)
			{
			}

			public static implicit operator ResolutionSetting(ResolutionSettingBuilder builder)
			{
				return builder.Setting;
			}
		}

		protected ResolutionSetting(string displayName, SettingsCategory category)
			: base(displayName, category, (string)null)
		{
		}

		public static ResolutionSettingBuilder Create(string displayName, SettingsCategory category)
		{
			return new ResolutionSettingBuilder(new ResolutionSetting(displayName, category));
		}

		public override void RestoreFromXml(XElement xml)
		{
			if (base.State != SettingState.Disabled)
			{
				string text = (string)xml.Attribute(base.XmlName);
				try
				{
					string[] array = text.Split('x', 'X', '@');
					base.Value = new Resolution
					{
						width = DataIO.ParseInt(array[0]),
						height = DataIO.ParseInt(array[1]),
						refreshRateRatio = new RefreshRate
						{
							numerator = ((array.Length == 3) ? DataIO.ParseUInt(array[2]) : 0u),
							denominator = 1u
						}
					};
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					Debug.LogError($"Unable to parse resolution setting '{0}'. Expected format '[width]x[height]@[refresh]'. Defaulting to current resolution.");
					base.Value = Screen.currentResolution;
				}
			}
		}

		public override void SaveToXml(XElement xml)
		{
			if (base.State == SettingState.Enabled || base.State == SettingState.Hidden)
			{
				xml.SetAttributeValue(base.XmlName, DataIO.ToString(base.Value.width) + "x" + DataIO.ToString(base.Value.height) + "@" + DataIO.ToString((uint)base.Value.refreshRateRatio.value));
			}
		}
	}
}
