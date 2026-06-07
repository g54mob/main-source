using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public class SettingIntEvent : SettingEvent<int>
	{
		public enum FloatToIntConversion
		{
			Round = 0,
			Ceil = 1,
			Floor = 2
		}

		[Tooltip("If the input value is a float then this defines how it will be converted to an int.")]
		public FloatToIntConversion FloatToInt;

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
					int num = 0;
					num = FloatToInt switch
					{
						FloatToIntConversion.Ceil => Mathf.CeilToInt(value2), 
						FloatToIntConversion.Floor => Mathf.FloorToInt(value2), 
						_ => Mathf.RoundToInt(value2), 
					};
					OnValueChanged?.Invoke(num);
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
