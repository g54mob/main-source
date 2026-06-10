using System.Collections.Generic;
using ModIO.Util;
using ModIOBrowser.Implementation;
using Plugins.mod.io.UI.Translations;
using UnityEngine;

namespace ModIOBrowser
{
	public class TranslationManager : SelfInstancingMonoSingleton<TranslationManager>
	{
		public bool markUntranslatedStringsWithRed;

		private TranslatedLanguages Language;

		private List<string> originalTranslationKeyCache;

		private Dictionary<string, string> translations;

		public string attemptToTranslate;

		public List<TextAsset> translationsTextAssets;

		public TranslatedLanguageFontPairings defaultTranslatedLanguageFontPairings;

		public TranslatedLanguages SelectedLanguage => default(TranslatedLanguages);

		protected override void Awake()
		{
		}

		private void Start()
		{
		}

		public void ChangeLanguage(TranslatedLanguages language)
		{
		}

		private void ForceChangeLanguage(TranslatedLanguages language)
		{
		}

		public string Get(string key, params string[] values)
		{
			return null;
		}

		public TextAsset GetTranslationResource(TranslatedLanguages language)
		{
			return null;
		}

		private static string GetQuotedString(string input)
		{
			return null;
		}

		public static Dictionary<string, string> BuildLanguageDictionary(TranslatedLanguages language)
		{
			return null;
		}

		private void ApplyTranslations()
		{
		}

		public void Translate(ITranslatable translatable)
		{
		}

		public static string Get(Dictionary<string, string> translations, string key, params string[] values)
		{
			return null;
		}

		public static string ReplaceParameters(string text, string[] values)
		{
			return null;
		}
	}
}
