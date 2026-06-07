using System.Collections.Generic;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public static class SettingsSerializer
	{
		public static string ToJson(Settings settings)
		{
			SettingFieldsData settingFieldsData = new SettingFieldsData(new List<SettingData>());
			foreach (ISetting allSetting in settings.GetAllSettings())
			{
				if (!string.IsNullOrEmpty(allSetting.GetID()) && allSetting.IsActive)
				{
					SettingData settingData = allSetting.SerializeValueToData();
					if (settingData.Type == SettingData.DataType.Unknown)
					{
						Debug.LogError("SGSettings: Unknown data type for path '" + settingData.ID + "'. Ignoring.");
					}
					else
					{
						settingFieldsData.Fields.Add(settingData);
					}
				}
			}
			return JsonUtility.ToJson(settingFieldsData);
		}

		public static void FromJson(string json, Settings settings)
		{
			SettingFieldsData settingFieldsData = JsonUtility.FromJson<SettingFieldsData>(json);
			List<ISetting> allSettings = settings.GetAllSettings();
			foreach (ISetting item in allSettings)
			{
				foreach (SettingData field in settingFieldsData.Fields)
				{
					if (field.ID == item.GetID())
					{
						if (field.Type == SettingData.DataType.Unknown)
						{
							Debug.LogError("SGSettings: Unknown data type for path '" + field.ID + "'. Ignoring.");
							break;
						}
						item.DeserializeValueFromData(field);
						item.SetHasUserData(hasUserData: true);
						break;
					}
				}
			}
			foreach (SettingData field2 in settingFieldsData.Fields)
			{
				bool flag = false;
				foreach (ISetting item2 in allSettings)
				{
					if (field2.ID == item2.GetID())
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					if (field2.Type == SettingData.DataType.Unknown)
					{
						Debug.LogError("SGSettings: Unknown data type for path '" + field2.ID + "'. Ignoring.");
						break;
					}
					ISetting setting = null;
					switch (field2.Type)
					{
					case SettingData.DataType.Int:
						setting = settings.AddIntFromSerializedData(field2);
						break;
					case SettingData.DataType.Float:
						setting = settings.AddFloatFromSerializedData(field2);
						break;
					case SettingData.DataType.Bool:
						setting = settings.AddBoolFromSerializedData(field2);
						break;
					case SettingData.DataType.String:
						setting = settings.AddStringFromSerializedData(field2);
						break;
					case SettingData.DataType.Color:
						setting = settings.AddColorFromSerializedData(field2);
						break;
					case SettingData.DataType.KeyCombination:
						setting = settings.AddKeyCombinationFromSerializedData(field2);
						break;
					case SettingData.DataType.Option:
						setting = settings.AddOptionFromSerializedData(field2);
						break;
					case SettingData.DataType.ColorOption:
						setting = settings.AddColorOptionFromSerializedData(field2);
						break;
					}
					setting?.SetHasUserData(hasUserData: true);
				}
			}
			settings.RebuildSettingsCache();
		}
	}
}
