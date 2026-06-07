using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class LocalizedGameObjectSwitcher : MonoBehaviour
	{
		[SerializeField]
		private GameObject _gameObjectByDefault;

		[SerializeField]
		private SerializableDictionary<string, GameObject> _locales;

		private void Awake()
		{
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
			LocalizationSettings_SelectedLocaleChanged(LocalizationSettings.SelectedLocale);
		}

		private void OnDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale locale)
		{
			_gameObjectByDefault.SetActive(value: false);
			foreach (string key in _locales.Keys)
			{
				_locales[key].SetActive(value: false);
			}
			bool flag = true;
			foreach (string key2 in _locales.Keys)
			{
				if (key2 == LocalizationSettings.SelectedLocale.LocaleName)
				{
					flag = false;
					_locales[LocalizationSettings.SelectedLocale.LocaleName].SetActive(value: true);
					break;
				}
			}
			if (flag)
			{
				_gameObjectByDefault.SetActive(value: true);
			}
		}
	}
}
