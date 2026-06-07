using System;
using System.Collections.Generic;
using DV.ThingTypes;
using I2.Loc;
using UnityEngine;

namespace DV.UI
{
	public abstract class ASettingsProvider : MonoBehaviour
	{
		public AudioSource mainMenuMusicAudioSource;

		public readonly Dictionary<string, PreferenceValues> preferenceValues = new Dictionary<string, PreferenceValues>();

		protected Dictionary<string, List<SettingsPreset>> presets = new Dictionary<string, List<SettingsPreset>>();

		public abstract bool IsStillExportingTelemetry { get; }

		public abstract bool IsVR { get; }

		public abstract bool AnyWandController { get; }

		public abstract bool IsFullscreen { get; }

		public abstract bool ShouldShowLanguageSelector { get; }

		public abstract bool IsClosePauseMenuKeyPressed { get; }

		public event Action ResetOrApplied;

		public abstract void ReloadPreferenceValues();

		public virtual void ApplyChanges()
		{
			this.ResetOrApplied?.Invoke();
		}

		public virtual void RevertChanges()
		{
			foreach (KeyValuePair<string, PreferenceValues> preferenceValue in preferenceValues)
			{
				preferenceValue.Value.RevertChange();
			}
			this.ResetOrApplied?.Invoke();
		}

		public abstract bool IsPreferenceApplicable(string preferenceName);

		public void AddChange(SettingChangeSource settingChangeSource)
		{
			AddChange(settingChangeSource.PreferencesName, settingChangeSource.latestValue);
		}

		public virtual void AddChange(string preferenceName, object value)
		{
			if (!preferenceValues.TryGetValue(preferenceName, out var value2))
			{
				Debug.LogError($"Unknown preference name '{preferenceName}' (requested change value: {value})");
			}
			else if ((!value2.latestValue.Equals(value)))
			{
				value2.latestValue = value;
				value2.ImmediateEffectApply();
			}
		}

		public void GetDiff(Dictionary<string, PreferenceValues> cachedDict)
		{
			cachedDict.Clear();
			foreach (KeyValuePair<string, PreferenceValues> preferenceValue in preferenceValues)
			{
				if (preferenceValue.Value.HasChange)
				{
					cachedDict.Add(preferenceValue.Key, preferenceValue.Value);
				}
			}
		}

		public List<SettingsPreset> GetPresetsFor(string categoryName)
		{
			if (presets.TryGetValue(categoryName, out var value))
			{
				return value;
			}
			return null;
		}

		public abstract string[] GetLocalizationKeysForSelector(string key);

		public abstract T GetLiveReadout<T>(string key);

		public abstract bool ExportTelemetry(out string path);

		public abstract void ToggleFullscreen();

		public abstract void OpenLocalizationScene();

		public abstract void CalibrateHeightVR();

		public abstract void CalibrateInputVR();

		public abstract void OpenTranslationForm();

		public AudioSource GetMainMenuAudioSource()
		{
			if (!(mainMenuMusicAudioSource == null))
			{
				return mainMenuMusicAudioSource;
			}
			return null;
		}

		public virtual List<string> GetLanguages()
		{
			return LocalizationManager.GetAllLanguages();
		}

		public virtual string GetCurrentLanguage()
		{
			return LocalizationManager.CurrentLanguage;
		}

		public virtual void ApplyLanguage(string language)
		{
			LocalizationManager.CurrentLanguage = language;
		}

		public virtual LanguageItem ToLanguageItem(string langName)
		{
			string translation = LocalizationManager.GetTranslation("lang_name_native", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, langName);
			string translation2 = LocalizationManager.GetTranslation("meta_percent_translated", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters: false, null, langName);
			int result = -1;
			int result2 = -1;
			if (string.IsNullOrWhiteSpace(translation2))
			{
				Debug.LogWarning("Language '" + langName + "' doesn't have a translation for 'meta_percent_translated', assuming 'unknown'");
			}
			else if (translation2.Contains("|"))
			{
				int.TryParse(translation2.Split('|')[0], out result);
				int.TryParse(translation2.Split('|')[1], out result2);
			}
			else
			{
				int.TryParse(translation2, out result);
			}
			return new LanguageItem
			{
				languageName = langName,
				languageNameNative = translation,
				percentTranslated = result,
				percentTranslatedManual = result2
			};
		}

		public abstract void ApplyLanguageAndRestart(string language);
	}
}
