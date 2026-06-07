using System.Collections.Generic;
using Gh.Tk;
using UnityEngine;

namespace I18n
{
	public class I18nLanguageDb : ScriptableObject
	{
		public string languageIsoCode;

		public List<I18nLanguageEntry> entries;

		private static List<string> _allAvailableLanguages;

		public static I18nLanguageDb LoadAsset(string language)
		{
			return null;
		}

		public static List<string> GetAllAvailableLanguages()
		{
			return null;
		}
	}
}
