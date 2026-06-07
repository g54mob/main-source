using System;
using UnityEngine;

namespace Doozy.Engine.Utils
{
	[Serializable]
	public class LanguagePack : ScriptableObject
	{
		private const string CURRENT_LANGUAGE_PREFS_KEY = "Doozy.CurrentLanguage";

		public const Language DEFAULT_LANGUAGE = Language.English;

		private static Language s_currentLanguage;

		public static Language CurrentLanguage
		{
			get
			{
				return default(Language);
			}
			set
			{
			}
		}

		private static void SaveLanguagePreference(Language language)
		{
		}

		private static void SaveLanguagePreference(string prefsKey, Language language)
		{
		}
	}
}
