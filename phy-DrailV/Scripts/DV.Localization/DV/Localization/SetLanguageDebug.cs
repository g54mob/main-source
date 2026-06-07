using I2.Loc;
using TMPro;
using UnityEngine;

namespace DV.Localization
{
	public class SetLanguageDebug : MonoBehaviour
	{
		public string languageOverride;

		public void ApplyLanguage()
		{
			string language = GetLanguage();
			if (LocalizationManager.HasLanguage(language))
			{
				LocalizationManager.CurrentLanguage = language;
			}
			else
			{
				Debug.LogWarning("Language " + language + " is not supported");
			}
		}

		public string GetLanguage()
		{
			string text;
			if (!string.IsNullOrWhiteSpace(languageOverride))
			{
				text = languageOverride;
				Debug.Log("Using language from override field: " + text);
			}
			else
			{
				text = GetComponentInChildren<TextMeshProUGUI>().text;
			}
			return text;
		}
	}
}
