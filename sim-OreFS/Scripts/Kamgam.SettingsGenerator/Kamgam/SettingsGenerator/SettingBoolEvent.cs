using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class SettingBoolEvent : SettingEvent<bool>
	{
		public static string FalseStringValue0 = "";

		public static string FalseStringValue1 = null;

		public static int FalseIntValue = 0;

		public static float FalseFloatValue = 0f;

		public static Color FalseColorValue = Color.black;

		public override SettingData.DataType[] GetSupportedDataTypes()
		{
			if (_supportedDataTypes == null)
			{
				_supportedDataTypes = new SettingData.DataType[5]
				{
					SettingData.DataType.Bool,
					SettingData.DataType.Int,
					SettingData.DataType.Float,
					SettingData.DataType.Color,
					SettingData.DataType.String
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
				if (setting.GetDataType() == SettingData.DataType.Bool)
				{
					bool value = SettingsProvider.Settings.GetBool(ID).GetValue();
					OnValueChanged?.Invoke(value);
				}
				else if (setting.GetDataType() == SettingData.DataType.Int)
				{
					bool arg = SettingsProvider.Settings.GetInt(ID).GetValue() != FalseIntValue;
					OnValueChanged?.Invoke(arg);
				}
				else if (setting.GetDataType() == SettingData.DataType.Float)
				{
					bool arg2 = SettingsProvider.Settings.GetFloat(ID).GetValue() != FalseFloatValue;
					OnValueChanged?.Invoke(arg2);
				}
				else if (setting.GetDataType() == SettingData.DataType.Color)
				{
					bool arg3 = SettingsProvider.Settings.GetColor(ID).GetValue() != FalseColorValue;
					OnValueChanged?.Invoke(arg3);
				}
				else if (setting.GetDataType() == SettingData.DataType.String)
				{
					string value2 = SettingsProvider.Settings.GetString(ID).GetValue();
					bool arg4 = value2 != FalseStringValue0 && value2 != FalseStringValue1;
					OnValueChanged?.Invoke(arg4);
				}
			}
		}
	}
}
