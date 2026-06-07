using System;
using UnityEngine;

namespace ModApi.Settings
{
	public class PlayerPrefsEnumHelper<T> where T : struct, IConvertible
	{
		private T _defaultValue;

		private string _playerPrefsKey;

		public PlayerPrefsEnumHelper(string playerPrefsKey, T defaultValue)
		{
			_defaultValue = defaultValue;
			_playerPrefsKey = playerPrefsKey;
		}

		public T GetDefault()
		{
			return GetType(GetDefaultValueFromPlayerPrefs());
		}

		public void SetDefault(T newDefault)
		{
			PlayerPrefs.SetString(_playerPrefsKey, newDefault.ToString());
		}

		private string GetDefaultValueFromPlayerPrefs()
		{
			string text = PlayerPrefs.GetString(_playerPrefsKey);
			if (string.IsNullOrEmpty(text))
			{
				text = _defaultValue.ToString();
			}
			return text;
		}

		private T GetType(string playerPrefValue)
		{
			if (!Enum.TryParse<T>(playerPrefValue, out var result))
			{
				result = _defaultValue;
				Debug.LogError("Unknown type: " + playerPrefValue);
			}
			return result;
		}
	}
}
