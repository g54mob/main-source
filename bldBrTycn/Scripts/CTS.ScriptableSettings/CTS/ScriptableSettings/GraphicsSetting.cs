using UnityEngine;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/Graphics Prefs Setting")]
	public class GraphicsSetting : PlayerPrefSetting<int>
	{
		public override void SetValue(int value)
		{
			value = Mathf.Clamp(value, 0, QualitySettings.count - 1);
			base.SetValue(value);
		}

		protected override int GetValueFromDisk()
		{
			return PlayerPrefs.GetInt(_prefKey, _defaultValue);
		}

		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetInt(_prefKey, _currentValue);
		}

		public override string GetCurrentValueName()
		{
			return QualitySettings.names[_currentValue];
		}
	}
}
