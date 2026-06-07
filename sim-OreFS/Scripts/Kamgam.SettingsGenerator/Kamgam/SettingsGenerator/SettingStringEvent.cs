namespace Kamgam.SettingsGenerator
{
	public class SettingStringEvent : SettingEvent<string>
	{
		public string FloatFormat = "{0:0.00}";

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			if (_supportedDataTypes == null)
			{
				_supportedDataTypes = new SettingData.DataType[4]
				{
					SettingData.DataType.String,
					SettingData.DataType.Bool,
					SettingData.DataType.Int,
					SettingData.DataType.Float
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
				if (setting.GetDataType() == SettingData.DataType.String)
				{
					string value = SettingsProvider.Settings.GetString(ID).GetValue();
					OnValueChanged?.Invoke(value);
				}
				else if (setting.GetDataType() == SettingData.DataType.Bool)
				{
					bool value2 = SettingsProvider.Settings.GetBool(ID).GetValue();
					OnValueChanged?.Invoke(value2.ToString());
				}
				else if (setting.GetDataType() == SettingData.DataType.Int)
				{
					int value3 = SettingsProvider.Settings.GetInt(ID).GetValue();
					OnValueChanged?.Invoke(value3.ToString());
				}
				else if (setting.GetDataType() == SettingData.DataType.Float)
				{
					float value4 = SettingsProvider.Settings.GetFloat(ID).GetValue();
					OnValueChanged?.Invoke(string.Format(FloatFormat, value4));
				}
			}
		}
	}
}
