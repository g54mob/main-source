using System.Collections;
using System.Collections.Generic;
using I2.Loc;
using Kamgam.SettingsGenerator;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

public class LanguageWrapper : MonoBehaviour
{
	public OptionsButtonUGUI languageObj;

	private void OnEnable()
	{
		StartCoroutine(DetectCurrentLanguage());
	}

	private IEnumerator DetectCurrentLanguage()
	{
		yield return new WaitForSeconds(1.5f);
		_ = LanguageConnection.CurrentValue;
	}

	public void ApplyLanguage()
	{
		List<string> options = languageObj.GetOptions();
		if (LocalizationManager.HasLanguage(options[languageObj.SelectedIndex]))
		{
			LocalizationManager.CurrentLanguage = options[languageObj.SelectedIndex];
			SettingsProvider lastUsedSettingsProvider = SettingsProvider.LastUsedSettingsProvider;
			if (lastUsedSettingsProvider != null)
			{
				lastUsedSettingsProvider.Settings.GetInt("language")?.SetValue(languageObj.SelectedIndex);
			}
		}
	}
}
