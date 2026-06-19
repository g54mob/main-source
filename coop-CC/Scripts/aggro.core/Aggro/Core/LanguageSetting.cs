using UnityEngine;

namespace Aggro.Core
{
	public sealed class LanguageSetting : AggroSettingBase
	{
		public LocalizedText.Language currentLanguage { get; private set; }

		public override void SetToDefault()
		{
		}

		protected override void SaveToPrefs(string preferencesKey)
		{
			LocalizedText.SetLanguage((int)currentLanguage);
			PlayerPrefs.SetInt(preferencesKey, (int)currentLanguage);
			AggroSettings.RefreshSettingUIs();
		}

		protected override void LoadFromPrefs(string preferencesKey)
		{
			currentLanguage = (LocalizedText.Language)PlayerPrefs.GetInt(preferencesKey, (int)LocalizedText.GetSystemLanguage());
			if (currentLanguage >= (LocalizedText.Language)9)
			{
				currentLanguage = LocalizedText.GetSystemLanguage();
			}
		}

		public void SetLanguage(LocalizedText.Language language)
		{
			currentLanguage = language;
		}
	}
}
