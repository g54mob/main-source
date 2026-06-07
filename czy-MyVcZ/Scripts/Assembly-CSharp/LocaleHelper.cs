using System;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public static class LocaleHelper
{
	public const string TABLE = "MyVoiceZoo_LocaleTable";

	public static string Get(string key)
	{
		return LocalizationSettings.StringDatabase.GetLocalizedString("MyVoiceZoo_LocaleTable", key, null, FallbackBehavior.UseProjectSettings);
	}

	public static string Get(string key, params object[] args)
	{
		return LocalizationSettings.StringDatabase.GetLocalizedString("MyVoiceZoo_LocaleTable", key, args);
	}

	public static void SubscribeLocaleChanged(Action<Locale> callback)
	{
		LocalizationSettings.SelectedLocaleChanged += callback;
	}

	public static void UnsubscribeLocaleChanged(Action<Locale> callback)
	{
		LocalizationSettings.SelectedLocaleChanged -= callback;
	}
}
