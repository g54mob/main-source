using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class SettingColorEvent : SettingEvent<Color>
	{
		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			if (_supportedDataTypes == null)
			{
				_supportedDataTypes = new SettingData.DataType[2]
				{
					SettingData.DataType.Color,
					SettingData.DataType.ColorOption
				};
			}
			return _supportedDataTypes;
		}

		public override void TriggerEvent()
		{
			if (!HasActiveSettingForID(ID))
			{
				return;
			}
			ISetting setting = GetSetting();
			if (setting != null)
			{
				if (setting.GetDataType() == SettingData.DataType.Color)
				{
					Color value = SettingsProvider.Settings.GetColor(ID).GetValue();
					OnValueChanged?.Invoke(value);
				}
				else if (setting.GetDataType() == SettingData.DataType.ColorOption)
				{
					Color colorValue = SettingsProvider.Settings.GetColorOption(ID).GetColorValue(Color.white);
					OnValueChanged?.Invoke(colorValue);
				}
			}
		}
	}
}
