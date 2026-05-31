using UnityEngine;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/Vector2 Int Prefs Setting")]
	public class Vector2IntSetting : PlayerPrefSetting<Vector2Int>
	{
		private string GetXString()
		{
			return _prefKey + "X";
		}

		private string GetYString()
		{
			return _prefKey + "Y";
		}

		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetInt(GetXString(), _currentValue.x);
			PlayerPrefs.SetInt(GetYString(), _currentValue.y);
		}

		protected override Vector2Int GetValueFromDisk()
		{
			int x = PlayerPrefs.GetInt(GetXString(), _defaultValue.x);
			int y = PlayerPrefs.GetInt(GetYString(), _defaultValue.y);
			return new Vector2Int(x, y);
		}
	}
}
