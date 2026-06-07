using System;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.ScriptableSettings
{
	[CreateAssetMenu(menuName = "CTS/Settings/Float Prefs Setting")]
	public class FloatSetting : PlayerPrefSetting<float>
	{
		[SerializeField]
		private bool _clampValue;

		[SerializeField]
		[ShowIf("_clampValue")]
		private Vector2 _clampRange = new Vector2(0f, 100f);

		public override void SetValue(float value)
		{
			if (_clampValue)
			{
				value = Math.Clamp(value, _clampRange.x, _clampRange.y);
			}
			base.SetValue(value);
		}

		protected override float GetValueFromDisk()
		{
			return PlayerPrefs.GetFloat(_prefKey, _defaultValue);
		}

		protected override void OnSaveCurrentValueToDisk()
		{
			PlayerPrefs.SetFloat(_prefKey, _currentValue);
		}
	}
}
