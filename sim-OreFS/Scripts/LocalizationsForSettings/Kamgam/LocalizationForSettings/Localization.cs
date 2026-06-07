using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Kamgam.LocalizationForSettings
{
	[Serializable]
	public class Localization : ILocalization
	{
		[Tooltip("The default language used if language detection fails to find a language (or if auto detect is disabled.")]
		public string DefaultLanguage = "English";

		[Tooltip("Should the language be detected at start? If disabled then the default language is used.")]
		public bool AutoDetectLanguage = true;

		[SerializeField]
		protected List<string> _languages = new List<string>();

		[SerializeField]
		[HideInInspector]
		protected List<Translation> _translations = new List<Translation>();

		public OnLanguageChangedDelegate OnLanguageChanged;

		public UnityEvent<string> OnLanguageChangedEvent;

		[NonSerialized]
		protected TranslateTermCallback _translateTermCallback;

		[NonSerialized]
		protected LocalizationSourceBehaviour _sourceBehaviour;

		[NonSerialized]
		protected int _currentLanguageIndex = -1;

		public void SetDynamicLocalizationCallback(TranslateTermCallback translateTermCallback)
		{
			_translateTermCallback = translateTermCallback;
		}

		[Obsolete("Please use Get(string term, bool ignoreDynamic) instead.")]
		public void SetLocalizationSourceBehaviour(LocalizationSourceBehaviour behaviour)
		{
			_sourceBehaviour = behaviour;
		}

		private void autoDetectLanguage()
		{
			if (_currentLanguageIndex < 0)
			{
				if (AutoDetectLanguage)
				{
					DetectLanguage();
				}
				else
				{
					SetLanguage(DefaultLanguage);
				}
			}
		}

		public int DetectLanguage(bool setAsCurrent = true)
		{
			string text = Application.systemLanguage.ToString();
			if (text == null)
			{
				text = DefaultLanguage;
			}
			int num = GetLanguageIndex(text);
			if (num < 0)
			{
				num = AddLanguage(text);
			}
			if (setAsCurrent)
			{
				SetLanguage(num);
			}
			return num;
		}

		public int AddLanguage(string newLanguage)
		{
			int num = _languages.IndexOf(newLanguage);
			if (num < 0)
			{
				_languages.Add(newLanguage);
			}
			return num;
		}

		public string GetLanguage()
		{
			if (_currentLanguageIndex < 0 || _languages == null || _languages.Count == 0 || _currentLanguageIndex > _languages.Count - 1)
			{
				return null;
			}
			return _languages[_currentLanguageIndex];
		}

		public int GetLanguageIndex()
		{
			return _currentLanguageIndex;
		}

		public string GetLanguageAt(int languageIndex)
		{
			if (languageIndex < 0 || _languages == null || _languages.Count == 0 || languageIndex > _languages.Count - 1)
			{
				return null;
			}
			return _languages[languageIndex];
		}

		public int GetLanguageIndex(string language)
		{
			for (int i = 0; i < _languages.Count; i++)
			{
				if (_languages[i] == language)
				{
					return i;
				}
			}
			return -1;
		}

		public void SetLanguageIndex(int languageIndex)
		{
			SetLanguage(languageIndex);
		}

		public void SetLanguage(string language)
		{
			int num = _languages.IndexOf(language);
			if (num >= 0)
			{
				SetLanguage(num);
			}
		}

		public void SetLanguage(int languageIndex)
		{
			if (languageIndex >= 0 && languageIndex < _languages.Count && _currentLanguageIndex != languageIndex)
			{
				_currentLanguageIndex = languageIndex;
				string languageAt = GetLanguageAt(languageIndex);
				OnLanguageChanged?.Invoke(languageAt);
				OnLanguageChangedEvent?.Invoke(languageAt);
			}
		}

		public List<string> GetLanguages()
		{
			return new List<string>(_languages);
		}

		public int GetLanguageCount()
		{
			return _languages.Count;
		}

		public int GetTranslationCount()
		{
			return _translations.Count;
		}

		public Translation GetTranslationAt(int index)
		{
			if (index < 0 || index >= _translations.Count)
			{
				return null;
			}
			return _translations[index];
		}

		public int CreateOrUpdateTranslation(string term, string language, string text)
		{
			if (term == null)
			{
				return -1;
			}
			int languageIndex = GetLanguageIndex(language);
			for (int i = 0; i < _translations.Count; i++)
			{
				if (_translations[i].GetTerm() == term)
				{
					_translations[i].SetText(languageIndex, text);
					return i;
				}
			}
			Translation item = new Translation(term, GetLanguageCount());
			_translations.Add(item);
			return _translations.Count - 1;
		}

		public void DeleteTranslation(string term)
		{
			for (int i = 0; i < _translations.Count; i++)
			{
				if (_translations[i].GetTerm() == term)
				{
					_translations.RemoveAt(i);
					break;
				}
			}
		}

		public bool HasTerm(string term)
		{
			for (int i = 0; i < _translations.Count; i++)
			{
				if (_translations[i].GetTerm() == term)
				{
					return true;
				}
			}
			return false;
		}

		public string Get(string term)
		{
			return Get(term, ignoreDynamic: false);
		}

		public string Get(string term, bool ignoreDynamic)
		{
			autoDetectLanguage();
			if (!ignoreDynamic && _sourceBehaviour == LocalizationSourceBehaviour.PreferDynamic && _translateTermCallback != null)
			{
				return _translateTermCallback(term, GetLanguage());
			}
			for (int i = 0; i < _translations.Count; i++)
			{
				if (_translations[i].GetTerm() == term)
				{
					return _translations[i].GetText(_currentLanguageIndex);
				}
			}
			return term;
		}

		public T LocalizeListAsCopy<T>(T terms) where T : IList<string>, new()
		{
			T result = new T();
			for (int i = 0; i < terms.Count; i++)
			{
				result.Add(Get(terms[i]));
			}
			return result;
		}

		public void LocalizeList<T>(T terms, T target) where T : IList<string>, new()
		{
			target.Clear();
			for (int i = 0; i < terms.Count; i++)
			{
				string item = Get(terms[i]);
				target.Add(item);
			}
		}

		public void AddOnLanguageChangedListener(OnLanguageChangedDelegate listener)
		{
			OnLanguageChanged = (OnLanguageChangedDelegate)Delegate.Remove(OnLanguageChanged, listener);
			OnLanguageChanged = (OnLanguageChangedDelegate)Delegate.Combine(OnLanguageChanged, listener);
		}

		public void RemoveOnLanguageChangedListener(OnLanguageChangedDelegate listener)
		{
			OnLanguageChanged = (OnLanguageChangedDelegate)Delegate.Remove(OnLanguageChanged, listener);
		}

		public void Sort()
		{
			_translations.Sort(sortByTerm);
		}

		protected int sortByTerm(Translation a, Translation b)
		{
			if (a == null || b == null || a.GetTerm() == null || b.GetTerm() == null)
			{
				return 0;
			}
			return string.Compare(a.GetTerm(), b.GetTerm());
		}

		public void TriggerLanguageChangeEvent()
		{
			OnLanguageChanged?.Invoke(GetLanguage());
			OnLanguageChangedEvent?.Invoke(GetLanguage());
		}
	}
}
