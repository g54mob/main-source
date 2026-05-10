using System;
using UnityEngine;

namespace CTS.ScriptableSettings
{
	public class EnumSetting<TEnum> : PlayerPrefSetting<TEnum> where TEnum : Enum
	{
		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetInt(_prefKey, Convert.ToInt32(_currentValue));
		}

		protected override TEnum GetValueFromDisk()
		{
			return (TEnum)Enum.ToObject(typeof(TEnum), PlayerPrefs.GetInt(_prefKey, Convert.ToInt32(_defaultValue)));
		}
	}
}
