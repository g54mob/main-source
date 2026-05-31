using NaughtyAttributes;
using UnityEngine;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/Int Prefs Setting")]
	public class IntSetting : PlayerPrefSetting<int>
	{
		[SerializeField]
		private bool _clampValue;

		[SerializeField]
		[ShowIf("_clampValue")]
		private Vector2Int _clampRange = new Vector2Int(0, 100);

		public override void SetValue(int value)
		{
			if (_clampValue)
			{
				value = Mathf.Clamp(value, _clampRange.x, _clampRange.y);
			}
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
	}
}
