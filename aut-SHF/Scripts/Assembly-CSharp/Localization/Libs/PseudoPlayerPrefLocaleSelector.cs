using System;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace Localization.Libs
{
	[Serializable]
	public class PseudoPlayerPrefLocaleSelector : IStartupLocaleSelector, IInitialize
	{
		public string forceStartupLanguage;

		private static string _playerPreferenceKey;

		private static bool _getSavedLocaleIdentifierCodeDone;

		public static string PlayerPreferenceKey => null;

		internal bool IsPlayingOrWillChangePlaymode => false;

		internal bool IsPlaying => false;

		public void PostInitialization(LocalizationSettings settings)
		{
		}

		public Locale GetStartupLocale(ILocalesProvider availableLocales)
		{
			return null;
		}

		public static string GetSavedLocaleIdentifierCode()
		{
			return null;
		}

		public static bool ClearSavedLocale()
		{
			return false;
		}
	}
}
