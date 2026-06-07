using System;
using UnityEngine;

namespace Kamgam.SettingsGenerator
{
	public static class ISettingExtensions
	{
		public static float GetFloatValue(this ISetting setting)
		{
			return ((setting as SettingFloat) ?? throw new Exception("Setting is not a float setting!")).GetValue();
		}

		public static float GetIntValue(this ISetting setting)
		{
			if (setting is SettingInt settingInt)
			{
				return settingInt.GetValue();
			}
			if (setting is SettingOption settingOption)
			{
				return settingOption.GetValue();
			}
			if (setting is SettingColorOption settingColorOption)
			{
				return settingColorOption.GetValue();
			}
			throw new Exception("Setting is not an integer, option or color option setting!");
		}

		public static bool GetBoolValue(this ISetting setting)
		{
			return ((setting as SettingBool) ?? throw new Exception("Setting is not a bool setting!")).GetValue();
		}

		public static string GetStringValue(this ISetting setting)
		{
			return ((setting as SettingString) ?? throw new Exception("Setting is not a string setting!")).GetValue();
		}

		public static Color GetColorValue(this ISetting setting)
		{
			return ((setting as SettingColor) ?? throw new Exception("Setting is not a color setting!")).GetValue();
		}

		public static int GetColorOptionValue(this ISetting setting)
		{
			return ((setting as SettingColorOption) ?? throw new Exception("Setting is not a color option setting!")).GetValue();
		}

		public static KeyCombination GetKeyCombinationValue(this ISetting setting)
		{
			return ((setting as SettingKeyCombination) ?? throw new Exception("Setting is not a KeyCombination setting!")).GetValue();
		}

		public static int GetOptionValue(this ISetting setting)
		{
			return ((setting as SettingOption) ?? throw new Exception("Setting is not a option setting!")).GetValue();
		}
	}
}
