using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class VOManager : MustCallDestroy
	{
		public enum Language
		{
			English = 0,
			German = 1,
			Chinese = 2
		}

		private readonly VOBank _bank;

		private readonly Dictionary<string, AudioClip> _cachedBank = new Dictionary<string, AudioClip>();

		private Preferences _userPreferences;

		public VOManager(Preferences userPreferences, AudioManagerConfig config)
		{
			_bank = config.VOBank;
			Refresh(userPreferences);
		}

		public override void Destroy()
		{
			base.Destroy();
			Preferences.LanguagePreferences language = _userPreferences.Language;
			language.OnAudioLanguageChanged = (Action<Preferences.LanguagePreferences.AudioLanguage>)Delegate.Remove(language.OnAudioLanguageChanged, new Action<Preferences.LanguagePreferences.AudioLanguage>(OnLanguageChanged));
		}

		public AudioClip GetLocalizedVO(string tag)
		{
			if (string.IsNullOrEmpty(tag))
			{
				return null;
			}
			_cachedBank.TryGetValue(tag, out var value);
			return value;
		}

		private void OnLanguageChanged(Preferences.LanguagePreferences.AudioLanguage language)
		{
			Language currentLanguage = GetCurrentLanguage(language);
			foreach (KeyValuePair<string, AudioClip> item in _cachedBank)
			{
				AudioClip value = item.Value;
				if (value != null)
				{
					value.UnloadAudioData();
				}
			}
			_cachedBank.Clear();
			foreach (VOBank.Item item2 in _bank.Bank)
			{
				_cachedBank.Add(item2.Tag, GetClipForLanguage(item2, currentLanguage));
			}
		}

		private Language GetCurrentLanguage(Preferences.LanguagePreferences.AudioLanguage language)
		{
			return language switch
			{
				Preferences.LanguagePreferences.AudioLanguage.German => Language.German, 
				Preferences.LanguagePreferences.AudioLanguage.Mandarin => Language.Chinese, 
				_ => Language.English, 
			};
		}

		private AudioClip GetClipForLanguage(VOBank.Item item, Language language)
		{
			return language switch
			{
				Language.German => item.German, 
				Language.Chinese => item.Chinese, 
				Language.English => item.English, 
				_ => item.English, 
			};
		}

		public void Refresh(Preferences userPreferences)
		{
			if (_userPreferences != null)
			{
				Preferences.LanguagePreferences language = _userPreferences.Language;
				language.OnAudioLanguageChanged = (Action<Preferences.LanguagePreferences.AudioLanguage>)Delegate.Remove(language.OnAudioLanguageChanged, new Action<Preferences.LanguagePreferences.AudioLanguage>(OnLanguageChanged));
			}
			_userPreferences = userPreferences;
			Preferences.LanguagePreferences language2 = _userPreferences.Language;
			language2.OnAudioLanguageChanged = (Action<Preferences.LanguagePreferences.AudioLanguage>)Delegate.Combine(language2.OnAudioLanguageChanged, new Action<Preferences.LanguagePreferences.AudioLanguage>(OnLanguageChanged));
			OnLanguageChanged(_userPreferences.Language.SelectedAudioLanguage);
		}
	}
}
