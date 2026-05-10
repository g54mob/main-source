using CTS.ScriptableSettings;
using UnityEngine;

namespace CTS
{
	[CreateAssetMenu(menuName = "CTS/Settings/DLC Bool Setting")]
	public class DLCBoolSetting : DLCSetting<bool>
	{
		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetInt(_prefKey, BoolToInt(_currentValue));
		}

		protected override bool GetValueFromDisk()
		{
			return PlayerPrefs.GetInt(_prefKey, BoolToInt(_defaultValue)) != 0;
		}

		private static int BoolToInt(bool value)
		{
			if (value)
			{
				return 1;
			}
			return 0;
		}
	}
}
