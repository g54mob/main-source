namespace Kamgam.SettingsGenerator
{
	public class SettingFloatEvent : SettingEvent<float>
	{
		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			if (_supportedDataTypes == null)
			{
				_supportedDataTypes = new SettingData.DataType[4]
				{
					SettingData.DataType.Int,
					SettingData.DataType.Float,
					SettingData.DataType.Option,
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
				if (setting.GetDataType() == SettingData.DataType.Int)
				{
					int value = SettingsProvider.Settings.GetInt(ID).GetValue();
					OnValueChanged?.Invoke(value);
				}
				else if (setting.GetDataType() == SettingData.DataType.Float)
				{
					float value2 = SettingsProvider.Settings.GetFloat(ID).GetValue();
					OnValueChanged?.Invoke(value2);
				}
				else if (setting.GetDataType() == SettingData.DataType.Option)
				{
					int value3 = SettingsProvider.Settings.GetOption(ID).GetValue();
					OnValueChanged?.Invoke(value3);
				}
				else if (setting.GetDataType() == SettingData.DataType.ColorOption)
				{
					int value4 = SettingsProvider.Settings.GetColorOption(ID).GetValue();
					OnValueChanged?.Invoke(value4);
				}
			}
		}
	}
}
