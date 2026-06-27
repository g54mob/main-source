using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Localization.Modifiers;
using UnityEngine;

namespace Restory.Data.Localization
{
	[Serializable]
	public class LocalizationDataBase
	{
		private const string LocalizationLabel = "<color=#00FF00><b>[LOCALIZATION]</b></color>";

		private Dictionary<string, Dictionary<string, string>> localizationData = new Dictionary<string, Dictionary<string, string>>();

		private HashSet<LocalizationModifierBase> modifiers = new HashSet<LocalizationModifierBase>(5);

		public readonly Dictionary<SystemLanguage, string> LanguageIds = new Dictionary<SystemLanguage, string>();

		private readonly List<SystemLanguage> supportedLanguages = new List<SystemLanguage>();

		private bool isTranslationValueWarningShown;

		public bool IsEmpty => localizationData.Count == 0;

		public LocalizationDataBase()
		{
			foreach (SystemLanguage item in Enum.GetValues(typeof(SystemLanguage)).Cast<SystemLanguage>())
			{
				LanguageIds[item] = item.ToString();
			}
		}

		public void Initialize(Dictionary<string, Dictionary<string, string>> dictionary, IReadOnlyCollection<SystemLanguage> supportedLocalizations)
		{
			localizationData = dictionary;
			supportedLanguages.Clear();
			supportedLanguages.AddRange(supportedLocalizations);
		}

		private static string GetUnknownValue(string stringID)
		{
			return "[" + stringID + "]";
		}

		public string GetTranslation(string localizationID, string targetLanguage)
		{
			string value = string.Empty;
			if (string.IsNullOrEmpty(localizationID))
			{
				Debug.LogWarning("<color=#00FF00><b>[LOCALIZATION]</b></color> localizationID can't be null or empty.");
				return value;
			}
			if (!localizationData.TryGetValue(targetLanguage, out var value2) || value2 == null)
			{
				Debug.LogWarning("<color=#00FF00><b>[LOCALIZATION]</b></color> database error: targetLanguage: \"" + targetLanguage + "\" not found.");
				return value;
			}
			if (!value2.TryGetValue(localizationID, out value) || string.IsNullOrEmpty(value))
			{
				if (!isTranslationValueWarningShown)
				{
					isTranslationValueWarningShown = true;
					Debug.LogWarning("<color=#00FF00><b>[LOCALIZATION]</b></color> database error: translationValue on \"" + targetLanguage + "\" language for text with id \"" + localizationID + "\" is lost or empty");
				}
				return value;
			}
			return ApplyModifiers(value);
		}

		private string ApplyModifiers(string message)
		{
			foreach (LocalizationModifierBase modifier in modifiers)
			{
				message = modifier.Execute(message);
			}
			return message;
		}

		public void AddModifier(LocalizationModifierBase newModifier)
		{
			modifiers.Add(newModifier);
		}

		public void RemoveModifier(LocalizationModifierBase oldModifier)
		{
			modifiers.Remove(oldModifier);
		}

		public bool LocalizationKeyExists(string localizationKey)
		{
			bool result = false;
			foreach (SystemLanguage supportedLanguage in supportedLanguages)
			{
				if (!string.IsNullOrEmpty(GetTranslation(localizationKey, supportedLanguage.ToString())))
				{
					result = true;
					break;
				}
			}
			return result;
		}

		public bool TryGetMissingLocalization(string localizationKey, List<string> missingLanguages)
		{
			missingLanguages.Clear();
			foreach (SystemLanguage supportedLanguage in supportedLanguages)
			{
				if (string.IsNullOrEmpty(GetTranslation(localizationKey, supportedLanguage.ToString())))
				{
					missingLanguages.Add(supportedLanguage.ToString());
				}
			}
			return missingLanguages.Count > 0;
		}
	}
}
