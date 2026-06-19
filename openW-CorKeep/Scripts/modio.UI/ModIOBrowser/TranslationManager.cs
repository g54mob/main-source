using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ModIO.Util;
using ModIOBrowser.Implementation;
using Plugins.mod.io.UI.Translations;
using UnityEngine;

namespace ModIOBrowser
{
	public class TranslationManager : SelfInstancingMonoSingleton<TranslationManager>
	{
		public bool markUntranslatedStringsWithRed = true;

		private TranslatedLanguages Language;

		private List<string> originalTranslationKeyCache = new List<string>();

		private Dictionary<string, string> translations = new Dictionary<string, string>();

		public string attemptToTranslate;

		public List<TextAsset> translationsTextAssets;

		public TranslatedLanguageFontPairings defaultTranslatedLanguageFontPairings;

		public TranslatedLanguages SelectedLanguage => Language;

		protected override void Awake()
		{
			base.Awake();
		}

		public void ChangeLanguage(TranslatedLanguages language)
		{
			Debug.Log($"Setting language to {language} from {SelectedLanguage}");
			ForceChangeLanguage(language);
		}

		private void ForceChangeLanguage(TranslatedLanguages language)
		{
			Language = language;
			translations = BuildLanguageDictionary(language);
			ApplyTranslations();
		}

		public string Get(string key, params string[] values)
		{
			return Get(translations, key, values);
		}

		public TextAsset GetTranslationResource(TranslatedLanguages language)
		{
			return translationsTextAssets.FirstOrDefault((TextAsset x) => x.name == language.ToString());
		}

		private static string GetQuotedString(string input)
		{
			int num = input.IndexOf('"');
			int num2 = input.LastIndexOf('"');
			return input.Substring(num + 1, num2 - num - 1);
		}

		public static Dictionary<string, string> BuildLanguageDictionary(TranslatedLanguages language)
		{
			TextAsset translationResource = SelfInstancingMonoSingleton<TranslationManager>.Instance.GetTranslationResource(language);
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (translationResource != null)
			{
				StringReader stringReader = new StringReader(translationResource.text);
				string text = null;
				string text2 = "";
				string text3;
				while ((text3 = stringReader.ReadLine()) != null)
				{
					if (text3.StartsWith("msgid"))
					{
						text = null;
						text = GetQuotedString(text3);
						text2 = "";
					}
					else if (text3.StartsWith("msgstr") && text != null)
					{
						text2 = GetQuotedString(text3);
						if (dictionary.ContainsKey(text))
						{
							Debug.LogWarning("Warning: value for " + text + " - " + dictionary[text] + " already exists");
							dictionary[text] = text2;
						}
						else
						{
							dictionary.Add(text, text2);
						}
					}
					else if (text3.StartsWith("\""))
					{
						text2 = (dictionary[text] = text2 + "\n" + GetQuotedString(text3));
					}
					else
					{
						text3.StartsWith("#");
					}
				}
				stringReader.Close();
			}
			else
			{
				Debug.Log("Text asset for .po file is null?");
			}
			return dictionary;
		}

		private void ApplyTranslations()
		{
			SelfInstancingMonoSingleton<SimpleMessageHub>.Instance.Publish(new MessageUpdateTranslations());
		}

		public void Translate(ITranslatable translatable)
		{
			if (translations.TryGetValue(translatable.GetReference(), out var value))
			{
				translatable.SetTranslation(value);
				return;
			}
			Debug.LogWarning("The translation for " + translatable.GetReference() + " on gameobject identifier " + translatable.Identifier + " path: " + translatable.TransformPath);
		}

		public static string Get(Dictionary<string, string> translations, string key, params string[] values)
		{
			string value = key.Trim();
			if (value != null && translations.TryGetValue(key, out value))
			{
				if (values == null || values.Length == 0)
				{
					return value;
				}
				return ReplaceParameters(value, values);
			}
			return key;
		}

		public static string ReplaceParameters(string text, string[] values)
		{
			string arg = text;
			int num = 0;
			int num2 = text.IndexOf('{');
			try
			{
				while (num2 != -1)
				{
					int num3 = text.IndexOf('}') + 1;
					string oldValue = text.Substring(num2, num3 - num2);
					text = text.Replace(oldValue, values[num]);
					num2 = text.IndexOf('{');
					num++;
				}
			}
			catch (Exception arg2)
			{
				Debug.LogError($"translating {arg} gives error:\n{arg2}");
			}
			if (num != values.Length)
			{
				Debug.LogWarning($"String of \"{text}\" parameter count did not match expected parameter count, ({values.Length} ");
				return "<color=red>" + text + "</color>";
			}
			return text;
		}
	}
}
