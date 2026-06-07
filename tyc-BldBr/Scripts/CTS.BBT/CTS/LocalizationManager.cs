using System;
using CTS.Core;
using CTS.ScriptableSettings;
using Steamworks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	[DefaultExecutionOrder(-200)]
	public class LocalizationManager : MonoSingleton<LocalizationManager>
	{
		[SerializeField]
		private LocaleSetting _localeSetting;

		[SerializeField]
		private LocaleList _allowedLocales;

		private string _tmpLang;

		public static event Action LanguageSwitched;

		protected override void SingletonAwake()
		{
			OnLocaleSettingChanged(_localeSetting.GetValue());
			_localeSetting.ValueChanged += OnLocaleSettingChanged;
		}

		protected override void OnSingletonDestroy()
		{
			_localeSetting.ValueChanged -= OnLocaleSettingChanged;
		}

		private void OnLocaleSettingChanged(LocaleIdentifier obj)
		{
			if (!string.IsNullOrEmpty(obj.Code))
			{
				Locale locale = LocalizationSettings.AvailableLocales.GetLocale(obj);
				if ((object)locale != null)
				{
					SwitchLanguage(locale);
					return;
				}
			}
			if (SteamAPI.IsSteamRunning() && SteamManager.Initialized && _allowedLocales.TryGetSteamLanguage(SteamApps.GetCurrentGameLanguage(), out var outLocale))
			{
				SwitchLanguage(LocalizationSettings.AvailableLocales.GetLocale(outLocale));
			}
			else if (_allowedLocales.TryGetSystemLanguage(Application.systemLanguage, out outLocale))
			{
				SwitchLanguage(LocalizationSettings.AvailableLocales.GetLocale(outLocale));
			}
			else
			{
				SwitchLanguage(LocalizationSettings.AvailableLocales.GetLocale(_allowedLocales.DefaultLocale));
			}
		}

		public void SwitchLanguage(Locale value)
		{
			_localeSetting.SetValue(value.Identifier);
			if (!(LocalizationSettings.SelectedLocale == value))
			{
				LocalizationSettings.SelectedLocale = value;
				LocalizationManager.LanguageSwitched?.Invoke();
			}
		}
	}
}
